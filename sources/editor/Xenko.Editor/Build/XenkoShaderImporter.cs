// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xenko.Core.Assets;
using Xenko.Core.Assets.Compiler;
using Xenko.Core.Assets.Editor.ViewModel;
using Xenko.Core.BuildEngine;
using Xenko.Assets.Effect;

namespace Xenko.Editor.Build
{
    public class XenkoShaderImporter
    {
        /// <summary>
        /// The current session being processed
        /// </summary>
        private readonly HashSet<Guid> systemProjectsLoaded = new HashSet<Guid>();

        private class UpdateImportShaderCacheBuildStep : BuildStep
        {
            private readonly HashSet<Guid> cachedProject;

            private readonly List<Guid> importedProjectIds;

            public UpdateImportShaderCacheBuildStep(HashSet<Guid> cachedProject, List<Guid> importedProjectIds)
            {
                this.cachedProject = cachedProject;
                this.importedProjectIds = importedProjectIds;
            }

            public override string Title
            {
                get { return "UpdateImportShaderCacheBuildStep"; }
            }

            public override Task<ResultStatus> Execute(IExecuteContext executeContext, BuilderContext builderContext)
            {
                // check the status of the import build steps
                if (((ListBuildStep)Parent).Steps.Any(s => s.Failed))
                    return Task.FromResult(ResultStatus.Successful);

                // Mark System projects as loaded
                foreach (var projectId in importedProjectIds)
                    cachedProject.Add(projectId);

                return Task.FromResult(ResultStatus.Successful);
            }

            public override string ToString()
            {
                return Title;
            }
        }

        /// <summary>
        /// Creates a build step that will build all shaders from system packages.
        /// </summary>
        /// <param name="session">The session used to retrieve currently used system packages.</param>
        /// <returns>A <see cref="ListBuildStep"/> containing the steps to build all shaders from system packages.</returns>
        public ListBuildStep CreateSystemShaderBuildSteps(SessionViewModel session)
        {
            if (session == null) throw new ArgumentNullException(nameof(session));
            // Check if there are any new system projects to preload
            // TODO: PDX-1251: For now, allow non-system project as well (which means they will be loaded only once at startup)
            // Later, they should be imported depending on what project the currently previewed/built asset is
            var systemPackages = session.AllPackages.Where(project => /*project.IsSystem &&*/ !systemProjectsLoaded.Contains(project.Id)).ToList();
            if (systemPackages.Count == 0)
                return null;

            var importShadersRootProject = new Package();
            var importShadersProjectSession = new PackageSession(importShadersRootProject);

            foreach (var package in systemPackages)
            {
                var mapPackage = new Package { FullPath = package.PackagePath };
                foreach (var asset in package.Assets)
                {
                    if (typeof(EffectShaderAsset).IsAssignableFrom(asset.AssetType))
                        mapPackage.Assets.Add(new AssetItem(asset.Url, asset.Asset) { SourceFolder = asset.AssetItem.SourceFolder, SourceProject = asset.AssetItem.SourceProject });
                }

                importShadersProjectSession.Packages.Add(mapPackage);
                importShadersRootProject.LocalDependencies.Add(mapPackage);
            }

            // compile the fake project (create the build steps)
            var assetProjectCompiler = new PackageCompiler(new PackageAssetEnumerator(importShadersRootProject));
            var context = new AssetCompilerContext { CompilationContext = typeof(AssetCompilationContext) };
            var dependenciesCompileResult = assetProjectCompiler.Prepare(context);
            context.Dispose();

            var buildSteps = dependenciesCompileResult.BuildSteps;
            buildSteps?.Add(new UpdateImportShaderCacheBuildStep(systemProjectsLoaded, systemPackages.Select(x => x.Id).ToList()));

            return buildSteps;
        }

        public ListBuildStep CreateUserShaderBuildSteps(SessionViewModel session)
        {
            var packages = session.AllPackages.Where(project => !project.Package.IsSystem).ToList();
            if (packages.Count == 0)
                return null;

            var importShadersRootProject = new Package();
            var importShadersProjectSession = new PackageSession(importShadersRootProject);

            foreach (var package in packages)
            {
                var mapPackage = new Package { FullPath = package.PackagePath };
                foreach (var asset in package.Assets)
                {
                    if (typeof(EffectShaderAsset).IsAssignableFrom(asset.AssetType))
                    {
                        mapPackage.Assets.Add(new AssetItem(asset.Url, asset.Asset) { SourceFolder = asset.AssetItem.SourceFolder, SourceProject = asset.AssetItem.SourceProject });
                    }
                }

                importShadersProjectSession.Packages.Add(mapPackage);
                importShadersRootProject.LocalDependencies.Add(mapPackage);
            }

            // compile the fake project (create the build steps)
            var assetProjectCompiler = new PackageCompiler(new PackageAssetEnumerator(importShadersRootProject));
            var dependenciesCompileResult = assetProjectCompiler.Prepare(new AssetCompilerContext { CompilationContext = typeof(AssetCompilationContext) });

            var buildSteps = dependenciesCompileResult.BuildSteps;
            buildSteps?.Add(new UpdateImportShaderCacheBuildStep(new HashSet<Guid>(), packages.Select(x => x.Id).ToList()));

            return buildSteps;
        }
    }
}
