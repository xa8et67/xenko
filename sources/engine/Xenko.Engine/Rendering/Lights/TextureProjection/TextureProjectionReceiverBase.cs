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

namespace Xenko.Rendering.Lights
{
    internal static partial class TextureProjectionReceiverBaseKeys
    {
        public static readonly ValueParameterKey<Matrix> WorldToProjectiveTextureUV = ParameterKeys.NewValue<Matrix>();
        public static readonly ValueParameterKey<Matrix> ProjectorPlaneMatrices = ParameterKeys.NewValue<Matrix>();
        public static readonly ValueParameterKey<float> ProjectionTextureMipMapLevels = ParameterKeys.NewValue<float>();
        public static readonly ValueParameterKey<float> TransitionAreas = ParameterKeys.NewValue<float>();
    }
}
