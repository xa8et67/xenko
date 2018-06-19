// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System;
using System.Collections.Generic;
using Xenko.Rendering.Materials;
using Xenko.Rendering.Materials.ComputeColors;
using Xenko.Core.Shaders.Ast.Xenko;
using Xenko.Shaders.Parser.Mixins;
using Xenko.Core.Shaders.Utility;

namespace Xenko.Assets.Materials
{
    public static class ComputeShaderClassHelper
    {
        private static readonly Dictionary<string, Type> ComputeColorParameterTypeMapping = new Dictionary<string, Type>
        {
            {"Texture2D", typeof(ComputeColorParameterTexture) },
            {"int", typeof(ComputeColorParameterInt) },
            {"float", typeof(ComputeColorParameterFloat) },
            {"float2", typeof(ComputeColorParameterFloat2) },
            {"float3", typeof(ComputeColorParameterFloat3) },
            {"float4", typeof(ComputeColorParameterFloat4) },
            {"SamplerState", typeof(ComputeColorParameterSampler) },
        };

        public static Type GetComputeColorParameterType(string typeName)
        {
            Type type;
            ComputeColorParameterTypeMapping.TryGetValue(typeName, out type);
            return type;
        }

        public static ShaderClassType ParseReferencedShader<T>(this ComputeShaderClassBase<T> node, IDictionary<string, string> projectShaders)
            where T : class, IComputeNode
        {
            ShaderClassType shader = null;

            string source;
            if (projectShaders.TryGetValue(node.MixinReference, out source))
            {
                var logger = new LoggerResult();
                try
                {
                    shader = ShaderLoader.ParseSource(source, logger);
                    if (logger.HasErrors)
                    {
                        return null;
                    }
                }
                catch
                {
                    // TODO: output messages
                    return null;
                }
            }

            return shader;
        }
    }
}
