// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using Xenko.Core;

namespace Xenko.Graphics.Font
{
    /// <summary>
    /// Describes kerning information.
    /// </summary>
    [DataContract]
    public struct Kerning
    {
        /// <summary>
        /// Unicode for the 1st character.
        /// </summary>
        public int First;

        /// <summary>
        /// Unicode for the 2nd character.
        /// </summary>
        public int Second;

        /// <summary>
        /// X Offsets in pixels to apply between the 1st and 2nd character.
        /// </summary>
        public float Offset;
    }
}
