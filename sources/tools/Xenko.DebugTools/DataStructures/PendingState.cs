// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xenko.Framework.MicroThreading;

namespace Xenko.DebugTools.DataStructures
{
    internal class MicroThreadPendingState
    {
        internal int ThreadId { get; set; }
        internal double Time { get; set; }
        internal MicroThreadState State { get; set; }
        internal MicroThread MicroThread { get; set; }
    }
}
