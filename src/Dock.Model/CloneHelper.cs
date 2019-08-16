﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using Dock.Model.Controls;

namespace Dock.Model
{
    /// <summary>
    /// Clone helper.
    /// </summary>
    public static class CloneHelper
    {
        /// <summary>
        /// Clones common dock properties.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <param name="target">The target object.</param>
        public static void CloneDockProperties(IDock source, IDock target)
        {
            target.Id = source.Id;
            target.Title = source.Title;

            target.Visible = source.Factory.CreateList<IDockable>();
            foreach (var visible in source.Visible)
            {
                target.Visible.Add(visible.Clone());
            }

            target.Hidden = source.Factory.CreateList<IDockable>();
            foreach (var hidden in source.Hidden)
            {
                target.Hidden.Add(hidden.Clone());
            }

            target.Pinned = source.Factory.CreateList<IDockable>();
            foreach (var pinned in source.Pinned)
            {
                target.Pinned.Add(pinned.Clone());
            }

            int indexCurrentDockable = source.Visible.IndexOf(source.CurrentDockable);
            if (indexCurrentDockable >= 0)
            {
                target.CurrentDockable = target.Visible[indexCurrentDockable];
            }

            int indexDefaultDockable = source.Visible.IndexOf(source.DefaultDockable);
            if (indexDefaultDockable >= 0)
            {
                target.DefaultDockable = target.Visible[indexDefaultDockable];
            }

            int indexFocusedDockable = source.Visible.IndexOf(source.FocusedDockable);
            if (indexFocusedDockable >= 0)
            {
                target.FocusedDockable = target.Visible[indexFocusedDockable];
            }

            target.Proportion = source.Proportion;
            target.IsActive = source.IsActive;
            target.IsCollapsable = source.IsCollapsable;

            target.Windows = source.Factory.CreateList<IDockWindow>();
            foreach (var window in source.Windows)
            {
                target.Windows.Add(window.Clone());
            }
        }

        /// <summary>
        /// Clones <see cref="IRootDock"/> object.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <returns>TThe new instance or reference of the <see cref="IRootDock"/> class.</returns>
        public static IRootDock CloneRootDock(IRootDock source)
        {
            var rootDock = source.Factory.CreateRootDock();

            CloneDockProperties(source, rootDock);

            rootDock.Window = source.Window.Clone();
            rootDock.Top = (IPinDock)source.Top.Clone();
            rootDock.Bottom = (IPinDock)source.Bottom.Clone();
            rootDock.Left = (IPinDock)source.Left.Clone();
            rootDock.Right = (IPinDock)source.Right.Clone();

            return rootDock;
        }

        /// <summary>
        /// Clones <see cref="IPinDock"/> object.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <returns>TThe new instance or reference of the <see cref="IPinDock"/> class.</returns>
        public static IPinDock ClonePinDock(IPinDock source)
        {
            var pinDock = source.Factory.CreatePinDock();

            CloneDockProperties(source, pinDock);

            pinDock.Alignment = source.Alignment;
            pinDock.IsExpanded = source.IsExpanded;
            pinDock.AutoHide = source.AutoHide;

            return pinDock;
        }

        /// <summary>
        /// Clones <see cref="IProportionalDock"/> object.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <returns>TThe new instance or reference of the <see cref="IProportionalDock"/> class.</returns>
        public static IProportionalDock CloneProportionalDock(IProportionalDock source)
        {
            var proportionalDock = source.Factory.CreateProportionalDock();

            CloneDockProperties(source, proportionalDock);

            proportionalDock.Orientation = source.Orientation;

            return proportionalDock;
        }

        /// <summary>
        /// Clones <see cref="ISplitterDock"/> object.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <returns>TThe new instance or reference of the <see cref="ISplitterDock"/> class.</returns>
        public static ISplitterDock CloneSplitterDock(ISplitterDock source)
        {
            var splitterDock = source.Factory.CreateSplitterDock();

            CloneDockProperties(source, splitterDock);

            return splitterDock;
        }

        /// <summary>
        /// Clones <see cref="IToolDock"/> object.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <returns>TThe new instance or reference of the <see cref="IToolDock"/> class.</returns>
        public static IToolDock CloneToolDock(IToolDock source)
        {
            var toolDock = source.Factory.CreateToolDock();

            CloneDockProperties(source, toolDock);

            return toolDock;
        }

        /// <summary>
        /// Clones <see cref="IDocumentDock"/> object.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <returns>TThe new instance or reference of the <see cref="IDocumentDock"/> class.</returns>
        public static IDocumentDock CloneDocumentDock(IDocumentDock source)
        {
            var documentDock = source.Factory.CreateDocumentDock();

            CloneDockProperties(source, documentDock);

            return documentDock;
        }

        /// <summary>
        /// Clones <see cref="IDockWindow"/> object.
        /// </summary>
        /// <param name="source">The source object.</param>
        /// <returns>TThe new instance or reference of the <see cref="IDockWindow"/> class.</returns>
        public static IDockWindow CloneDockWindow(IDockWindow source)
        {
            var dockWindow = source.Factory.CreateDockWindow();

            dockWindow.Id = source.Id;
            dockWindow.X = source.X;
            dockWindow.Y = source.Y;
            dockWindow.Width = source.Width;
            dockWindow.Height = source.Height;
            dockWindow.Topmost = source.Topmost;
            dockWindow.Title = source.Title;
            dockWindow.Layout = (IDock)source.Layout.Clone();

            return dockWindow;
        }
    }
}
