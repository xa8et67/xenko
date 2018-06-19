// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System;

namespace Xenko.Core
{
    /// <summary>
    /// Internally this file is used by the ExecServer project in order to copy native dlls to shadow copy folders.
    /// </summary>
    internal static class NativeLibraryInternal
    {
        private const string AppDomainCustomDllPathKey = "native_";

#if XENKO_PLATFORM_WINDOWS_DESKTOP
#if !XENKO_RUNTIME_CORECLR
        public static void SetShadowPathForNativeDll(AppDomain appDomain, string dllFileName, string dllPath)
        {
            if (dllFileName == null) throw new ArgumentNullException("dllFileName");
            if (dllPath == null) throw new ArgumentNullException("dllPath");
            var key = AppDomainCustomDllPathKey + dllFileName.ToLowerInvariant();
            appDomain.SetData(key, dllPath);
        }
#endif
#endif

        public static string GetShadowPathForNativeDll(string dllFileName)
        {
#if XENKO_PLATFORM_WINDOWS_DESKTOP
#if !XENKO_RUNTIME_CORECLR
            if (dllFileName == null) throw new ArgumentNullException("dllFileName");
            var key = AppDomainCustomDllPathKey + dllFileName.ToLowerInvariant();
            return (string)AppDomain.CurrentDomain.GetData(key);
#else
            return null;
#endif
#else
            return null;
#endif
        }
    }
}
