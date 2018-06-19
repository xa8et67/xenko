// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System.Runtime.InteropServices;

namespace Xenko.VisualStudio
{
    internal static class NativeMethods
    {
        public static int ThrowOnFailure(int hr)
        {
            if (hr < 0)
            {
                Marshal.ThrowExceptionForHR(hr);
            }

            return hr;
        }
    }
}
