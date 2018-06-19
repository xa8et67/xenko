// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
#if XENKO_GRAPHICS_API_OPENGL 
namespace Xenko.Graphics
{
    public partial class GraphicsAdapterFactory
    {
        private static void InitializeInternal()
        {
            defaultAdapter = new GraphicsAdapter();
            adapters = new [] { defaultAdapter };
        }
    }
} 
#endif
