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

namespace Xenko.Rendering
{
    public static partial class TemporalAntiAliasShaderKeys
    {
        public static readonly ValueParameterKey<float> u_BlendWeightMin = ParameterKeys.NewValue<float>();
        public static readonly ValueParameterKey<float> u_BlendWeightMax = ParameterKeys.NewValue<float>();
        public static readonly ValueParameterKey<float> u_HistoryBlurAmp = ParameterKeys.NewValue<float>();
        public static readonly ValueParameterKey<float> u_LumaContrastFactor = ParameterKeys.NewValue<float>();
        public static readonly ValueParameterKey<float> u_VelocityDecay = ParameterKeys.NewValue<float>();
        public static readonly ValueParameterKey<float> u_WeightCenter = ParameterKeys.NewValue<float>();
        public static readonly ValueParameterKey<float> u_WeightLowCenter = ParameterKeys.NewValue<float>();
        public static readonly ValueParameterKey<Vector4> u_Weight1 = ParameterKeys.NewValue<Vector4>();
        public static readonly ValueParameterKey<Vector4> u_Weight2 = ParameterKeys.NewValue<Vector4>();
        public static readonly ValueParameterKey<Vector4> u_WeightLow1 = ParameterKeys.NewValue<Vector4>();
        public static readonly ValueParameterKey<Vector4> u_WeightLow2 = ParameterKeys.NewValue<Vector4>();
    }
}
