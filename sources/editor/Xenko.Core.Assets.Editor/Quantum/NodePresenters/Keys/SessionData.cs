// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using Xenko.Core.Assets.Editor.ViewModel;
using Xenko.Core;

namespace Xenko.Core.Assets.Editor.Quantum.NodePresenters.Keys
{
    public static class SessionData
    {
        public const string Session = nameof(Session);
        public const string DynamicThumbnail = nameof(DynamicThumbnail);

        public static readonly PropertyKey<SessionViewModel> SessionKey = new PropertyKey<SessionViewModel>(Session, typeof(SessionData));
        public static readonly PropertyKey<bool> DynamicThumbnailKey = new PropertyKey<bool>(DynamicThumbnail, typeof(SessionData));
    }
}
