// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.
using Xenko.Core;

namespace Xenko.Core.Assets.Editor.Quantum.NodePresenters.Keys
{
    public static class CategoryData
    {
        public const string Category = nameof(Category);

        public static readonly PropertyKey<bool> Key = new PropertyKey<bool>(Category, typeof(CategoryData));

        public static string ComputeCategoryNodeName(string categoryName) => categoryName + Category;
    }
}
