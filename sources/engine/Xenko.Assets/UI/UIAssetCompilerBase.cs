// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xenko.Core.Assets;
using Xenko.Core.Assets.Compiler;
using Xenko.Core.BuildEngine;
using Xenko.Core;
using Xenko.Core.Serialization.Contents;
using Xenko.UI;

namespace Xenko.Assets.UI
{
    public abstract class UIAssetCompilerBase<T> : AssetCompilerBase
        where T : UIAssetBase
    {
        public override IEnumerable<Type> GetRuntimeTypes(AssetItem assetItem)
        {
            yield return typeof(UIElement);
        }

        protected sealed override void Prepare(AssetCompilerContext context, AssetItem assetItem, string targetUrlInStorage, AssetCompilerResult result)
        {
            var asset = (T)assetItem.Asset;
            result.BuildSteps = new AssetBuildStep(assetItem);
            result.BuildSteps.Add(Create(targetUrlInStorage, asset, assetItem.Package));
        }

        protected abstract UIConvertCommand Create(string url, T parameters, Package package);

        protected abstract class UIConvertCommand : AssetCommand<T>
        {
            protected UIConvertCommand(string url, T parameters, IAssetFinder assetFinder)
                : base(url, parameters, assetFinder)
            {
            }

            protected sealed override Task<ResultStatus> DoCommandOverride(ICommandContext commandContext)
            {
                var assetManager = new ContentManager();

                var uiObject = Create(commandContext);
                assetManager.Save(Url, uiObject);

                return Task.FromResult(ResultStatus.Successful);
            }

            protected abstract ComponentBase Create(ICommandContext commandContext);
        }
    }
}
