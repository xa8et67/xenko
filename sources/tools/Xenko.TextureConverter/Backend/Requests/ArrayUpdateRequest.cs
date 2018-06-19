// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Collections.Generic;

namespace Xenko.TextureConverter.Requests
{
    /// <summary>
    /// Request to update a specific texture in a texture array.
    /// </summary>
    class ArrayUpdateRequest : IRequest
    {
        public override RequestType Type { get { return RequestType.ArrayUpdate; } }

        /// <summary>
        /// The indice of the texture to replace in the array.
        /// </summary>
        public int Indice { get; private set; }


        /// <summary>
        /// The new texture.
        /// </summary>
        public TexImage Texture { get; private set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="AtlasUpdateRequest"/> class.
        /// </summary>
        /// <param name="texture">The new texture.</param>
        /// <param name="name">The indice of the texture to replace.</param>
        public ArrayUpdateRequest(TexImage texture, int indice)
        {
            Texture = texture;
            Indice = indice;
        }
    }
}
