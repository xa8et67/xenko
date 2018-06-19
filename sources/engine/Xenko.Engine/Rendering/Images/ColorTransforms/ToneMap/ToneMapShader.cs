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

namespace Xenko.Rendering.Images
{
    internal static partial class ToneMapShaderKeys
    {
        public static readonly ObjectParameterKey<Texture> LuminanceTexture = ParameterKeys.NewObject<Texture>();
        public static readonly ValueParameterKey<float> KeyValue = ParameterKeys.NewValue<float>(0.18f);
        public static readonly ValueParameterKey<float> LuminanceLocalFactor = ParameterKeys.NewValue<float>(0.0f);
        public static readonly ValueParameterKey<float> LuminanceAverageGlobal = ParameterKeys.NewValue<float>();
        public static readonly ValueParameterKey<float> Contrast = ParameterKeys.NewValue<float>(0.0f);
        public static readonly ValueParameterKey<float> Brightness = ParameterKeys.NewValue<float>(0.0f);
        public static readonly ValueParameterKey<float> Exposure = ParameterKeys.NewValue<float>(1.0f);
    }
}
