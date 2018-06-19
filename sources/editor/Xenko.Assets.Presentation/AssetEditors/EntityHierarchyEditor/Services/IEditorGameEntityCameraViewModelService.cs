// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using Xenko.Core.Annotations;
using Xenko.Assets.Presentation.AssetEditors.EntityHierarchyEditor.ViewModels;
using Xenko.Assets.Presentation.AssetEditors.GameEditor.Services;
using Xenko.Assets.Presentation.AssetEditors.GameEditor.ViewModels;

namespace Xenko.Assets.Presentation.AssetEditors.EntityHierarchyEditor.Services
{
    /// <summary>
    /// Interface allowing a <see cref="EntityHierarchyEditorViewModel"/> to safely access the camera of the game instance in which the editor is running.
    /// </summary>
    public interface IEditorGameEntityCameraViewModelService : IEditorGameCameraViewModelService
    {
        /// <summary>
        /// Gets instance of a <see cref="EditorCameraViewModel"/> class used by this camera view model service.
        /// </summary>
        [NotNull] EditorCameraViewModel Camera { get; }

        /// <summary>
        /// Centers the editor camera on the given entity.
        /// </summary>
        /// <param name="entity">The entity on which to center the camera.</param>
        /// <param name="meshIndex">The index of the mesh to center on, if relevant. Otherwise, -1 should be passed.</param>
        void CenterOnEntity(EntityViewModel entity, int meshIndex = -1);
    }
}
