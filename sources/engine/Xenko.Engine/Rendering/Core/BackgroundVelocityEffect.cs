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

internal static partial class ShaderMixins
{
    internal partial class BackgroundVelocityEffect  : IShaderMixinBuilder
    {
        public void Generate(ShaderMixinSource mixin, ShaderMixinContext context)
        {
            context.Mixin(mixin, "ShaderBase");
            context.Mixin(mixin, "ShadingBase");
            context.Mixin(mixin, "BackgroundVelocity");
            var targetExtensions = context.GetParam(XenkoEffectBaseKeys.RenderTargetExtensions);
            if (targetExtensions != null)
            {
                context.Mixin(mixin, (targetExtensions));
            }
        }

        [ModuleInitializer]
        internal static void __Initialize__()

        {
            ShaderMixinManager.Register("BackgroundVelocityEffect", new BackgroundVelocityEffect());
        }
    }
}
