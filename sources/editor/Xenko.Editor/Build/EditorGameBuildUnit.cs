// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Collections.Generic;
using Xenko.Core.Assets;
using Xenko.Core.Assets.Compiler;
using Xenko.Core.Assets.Editor.Services;
using Xenko.Core.BuildEngine;

namespace Xenko.Editor.Build
{
    public class EditorGameBuildUnit : AssetBuildUnit
    {
        private readonly AssetItem asset;
        private readonly AssetCompilerContext compilerContext;
        private readonly AssetDependenciesCompiler compiler;

        private static readonly Guid SceneBuildUnitContextId = Guid.NewGuid();

        public EditorGameBuildUnit(AssetItem asset, AssetCompilerContext compilerContext, AssetDependenciesCompiler assetDependenciesCompiler)
            : base(new AssetBuildUnitIdentifier(SceneBuildUnitContextId, asset.Id))
        {
            this.asset = asset;
            this.compilerContext = compilerContext;
            compiler = assetDependenciesCompiler;
            PriorityMajor = DefaultAssetBuilderPriorities.ScenePriority;
        }

        protected override ListBuildStep Prepare()
        {
            var result = compiler.Prepare(compilerContext, asset);
            return result.BuildSteps;
        }
    }
}
