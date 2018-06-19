// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using System;

namespace Sockets.Plugin.Abstractions
{
    /// <summary>
    ///     Fired when a TcpSocketListener receives a new connection.
    /// </summary>
    class TcpSocketListenerConnectEventArgs : EventArgs
    {
        private readonly ITcpSocketClient _socketClient;

        /// <summary>
        ///     A <code>TcpSocketClient</code> representing the newly connected client.
        /// </summary>
        public ITcpSocketClient SocketClient
        {
            get { return _socketClient; }
        }

        /// <summary>
        ///     Constructor for <code>TcpSocketListenerConnectEventArgs.</code>
        /// </summary>
        /// <param name="socketClient">A <code>TcpSocketClient</code> representing the newly connected client.</param>
        public TcpSocketListenerConnectEventArgs(ITcpSocketClient socketClient)
        {
            _socketClient = socketClient;
        }
    }
}
