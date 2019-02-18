//-----------------------------------------------------------------------
// <copyright file="BССOverlayWindow.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using RedDragonCardCatcher.Common.WinApi;
using System;
using System.Drawing;
using System.Windows.Interop;

namespace RedDragonCardCatcher.Overlays
{
    internal class RDOverlayWindow
    {
        private const double pt4Scale = 1;

        private IntPtr tableHwnd;
        private CustomWin32Window overlayWin32Wnd;

        public bool IsNameSet { get; set; }

        public IntPtr OverlayHwnd { get; private set; }

        public bool IsScalingEnabled { get; set; }

        protected WindowInteropHelper windowInteropHelper;

        public bool IsInit { get; set; }

        public string Title { get; private set; }

        public WndProc GetWndProcDlegate()
        {
            return overlayWin32Wnd.GetWndProcDlegate();
        }

        public RDOverlayWindow()
        {
            tableHwnd = IntPtr.Zero;
            OverlayHwnd = IntPtr.Zero;
            IsNameSet = false;
            IsInit = false;
        }

        public void Initialize(IntPtr tableHwnd, string title)
        {
            if (overlayWin32Wnd != null)
            {
                return;
            }

            this.tableHwnd = tableHwnd;

            // create win32 Window
            var rect = new RECT();
            WinApi.GetClientRect(this.tableHwnd, out rect);

            var pt = new Point(rect.Left, rect.Top);
            WinApi.ClientToScreen(this.tableHwnd, ref pt);

            var width = rect.Right - rect.Left;
            var height = rect.Bottom - rect.Top;

            if (IsScalingEnabled)
            {
                width = (int)(pt4Scale * height);
            }

            var originalSize = new Size(width, height);

            var styles = (uint)WindowStyles.WS_POPUP | (uint)WindowStyles.WS_CLIPSIBLINGS;

            var exStyles = (int)WindowStylesEx.WS_EX_LEFT | (int)WindowStylesEx.WS_EX_LTRREADING |
                            (int)WindowStylesEx.WS_EX_LAYERED | (int)WindowStylesEx.WS_EX_NOPARENTNOTIFY |
                            (int)WindowStylesEx.WS_EX_NOACTIVATE;

            var className = CustomWindowClassHelper.GetClassName();

            overlayWin32Wnd = new CustomWin32Window(
                className,
                title,
                this.tableHwnd,
                styles,
                (uint)exStyles,
                pt,
                originalSize);

            if (overlayWin32Wnd.Handle() != IntPtr.Zero)
            {
                WinApi.SetLayeredWindowAttributes(overlayWin32Wnd.Handle(), 0, 0, 0x2);
                WinApi.ShowWindow(overlayWin32Wnd.Handle(), ShowWindowCommands.Show);
                IsInit = true;
                Title = title;
            }

            OverlayHwnd = overlayWin32Wnd.Handle();
        }

        public void SetWindowTextWin32(string text)
        {
            if (overlayWin32Wnd == null)
            {
                return;
            }

            WinApi.SetWindowText(overlayWin32Wnd.Handle(), text);
            Title = text;
        }

        public void SetSizeToTable()
        {
            if (tableHwnd != IntPtr.Zero && overlayWin32Wnd != null && overlayWin32Wnd.Handle() != IntPtr.Zero)
            {
                var rect = new RECT();
                WinApi.GetClientRect(tableHwnd, out rect);
                Point pt = new Point(rect.Left, rect.Top);
                WinApi.ClientToScreen(tableHwnd, ref pt);
                Size sz = new Size(rect.Right - rect.Left, rect.Bottom - rect.Top);

                var width = IsScalingEnabled ? (int)(pt4Scale * sz.Height) : sz.Width;

                WinApi.MoveWindow(overlayWin32Wnd.Handle(), pt.X, pt.Y, width, sz.Height, false);
            }
        }

        public void CloseWindow()
        {
            if (overlayWin32Wnd != null)
            {
                overlayWin32Wnd.Dispose();
            }
        }
    }
}