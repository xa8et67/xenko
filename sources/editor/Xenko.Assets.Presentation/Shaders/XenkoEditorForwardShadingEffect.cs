﻿// <auto-generated>
// Do not edit this file yourself!
//
// This code was generated by Xenko Shader Mixin Code Generator.
// To generate it yourself, please install Xenko.VisualStudio.Package .vsix
// and re-save the associated .xkfx.
// </auto-generated>

using System;
using Xenko.Core;
using Xenko.Rendering;
using Xenko.Graphics;
using Xenko.Shaders;
using Xenko.Core.Mathematics;
using Buffer = Xenko.Graphics.Buffer;

using Xenko.Rendering.Data;
using Xenko.Shaders.Compiler;
namespace XenkoEffects
{
    internal static partial class ShaderMixins
    {
        internal partial class XenkoEditorForwardShadingEffect  : IShaderMixinBuilder
        {
            public void Generate(ShaderMixinSource mixin, ShaderMixinContext context)
            {
                if (context.GetParam(SceneEditorParameters.IsEffectError))
                {
                    context.Mixin(mixin, "ShaderBase");
                    context.Mixin(mixin, "ShadingBase");
                    context.Mixin(mixin, "TransformationBase");
                    context.Mixin(mixin, "TransformationWAndVP");
                    context.Mixin(mixin, "CompilationErrorShader");
                    context.Discard();
                    ;
                }
                context.Mixin(mixin, "XenkoForwardShadingEffect");
                if (context.ChildEffectName == "Picking")
                {
                    context.Mixin(mixin, "Picking");
                    return;
                }
                if (context.ChildEffectName == "Wireframe")
                {
                    context.Mixin(mixin, "Wireframe");
                    return;
                }
                if (context.ChildEffectName == "Highlight")
                {
                    context.Mixin(mixin, "Highlight");
                    return;
                }
                if (context.GetParam(SceneEditorParameters.IsEffectCompiling))
                {
                    context.Mixin(mixin, "EffectCompiling");
                }
            }

            [ModuleInitializer]
            internal static void __Initialize__()

            {
                ShaderMixinManager.Register("XenkoEditorForwardShadingEffect", new XenkoEditorForwardShadingEffect());
            }
        }
    }
    internal static partial class ShaderMixins
    {
        internal partial class Wireframe  : IShaderMixinBuilder
        {
            public void Generate(ShaderMixinSource mixin, ShaderMixinContext context)
            {
                context.Mixin(mixin, "MaterialFrontBackBlendShader", context.GetParam(MaterialFrontBackBlendShaderKeys.UseNormalBackFace));
            }

            [ModuleInitializer]
            internal static void __Initialize__()

            {
                ShaderMixinManager.Register("Wireframe", new Wireframe());
            }
        }
    }
    internal static partial class ShaderMixins
    {
        internal partial class Highlight  : IShaderMixinBuilder
        {
            public void Generate(ShaderMixinSource mixin, ShaderMixinContext context)
            {
                context.Mixin(mixin, "HighlightShader");
            }

            [ModuleInitializer]
            internal static void __Initialize__()

            {
                ShaderMixinManager.Register("Highlight", new Highlight());
            }
        }
    }
}
