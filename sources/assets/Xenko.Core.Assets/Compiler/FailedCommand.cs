// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Threading.Tasks;

using Xenko.Core.BuildEngine;
using Xenko.Core.Serialization;

namespace Xenko.Core.Assets.Compiler
{
    public class FailedCommand: Command
    {
        private readonly string objectThatFailed;

        public FailedCommand(string objectThatFailed)
        {
            this.objectThatFailed = objectThatFailed;
        }

        public override string Title => $"Failed command [Object={objectThatFailed}]";

        protected override Task<ResultStatus> DoCommandOverride(ICommandContext commandContext)
        {
            return Task.FromResult(ResultStatus.Failed);
        }

        public override string ToString()
        {
            return Title;
        }

        protected override void ComputeParameterHash(BinarySerializationWriter writer)
        {
            // force execution of the command with a new GUID
            var newGuid = Guid.NewGuid();
            writer.Serialize(ref newGuid, ArchiveMode.Serialize);
        }
    }
}
