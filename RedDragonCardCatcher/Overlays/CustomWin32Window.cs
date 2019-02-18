//-----------------------------------------------------------------------
// <copyright file="CustomWin32Window.cs" company="Ace Poker Solutions">
// Copyright © 2019 Ace Poker Solutions. All Rights Reserved.
// Unless otherwise noted, all materials contained in this Site are copyrights, 
// trademarks, trade dress and/or other intellectual properties, owned, 
// controlled or licensed by Ace Poker Solutions and may not be used without 
// written consent except as provided in these terms and conditions or in the 
// copyright notice (documents and software) or other proprietary notices 
// provided with the relevant materials.
// </copyright>
//----------------------------------------------------------------------

using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace RedDragonCardCatcher.Overlays
{
    internal delegate IntPtr WndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

    internal static class NativeMethodsCustomWin32
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct WNDCLASS
        {
            public uint style;
            public IntPtr lpfnWndProc;
            public int cbClsExtra;
            public int cbWndExtra;
            public IntPtr hInstance;
            public IntPtr hIcon;
            public IntPtr hCursor;
            public IntPtr hbrBackground;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszMenuName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszClassName;
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static extern ushort RegisterClassW([In] ref WNDCLASS lpWndClass);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr CreateWindowExW(
           uint dwExStyle,
           [MarshalAs(UnmanagedType.LPWStr)]
           string lpClassName,
           [MarshalAs(UnmanagedType.LPWStr)]
           string lpWindowName,
           uint dwStyle,
           int x,
           int y,
           int nWidth,
           int nHeight,
           IntPtr hWndParent,
           IntPtr hMenu,
           IntPtr hInstance,
           IntPtr lpParam
        );

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr DefWindowProcW(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool DestroyWindow(IntPtr hWnd);
    }

    internal class CustomWin32Window : IDisposable
    {
        private const int ERROR_CLASS_ALREADY_EXISTS = 1410;

        private bool m_disposed;
        private IntPtr m_hwnd;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources
                }

                // Dispose unmanaged resources
                if (m_hwnd != IntPtr.Zero)
                {
                    NativeMethodsCustomWin32.DestroyWindow(m_hwnd);                    
                    m_hwnd = IntPtr.Zero;
                }

                m_disposed = true;
            }
        }

        public CustomWin32Window(string class_name, string caption, IntPtr hwndParent, uint Styles, uint exStyles,
            Point startPos, Size wndSize)
        {
            // Create WNDCLASS
            NativeMethodsCustomWin32.WNDCLASS wind_class = new NativeMethodsCustomWin32.WNDCLASS();
            wind_class.lpszClassName = class_name;
            wind_class.lpfnWndProc = Marshal.GetFunctionPointerForDelegate(m_wnd_proc_delegate);

            UInt16 class_atom = NativeMethodsCustomWin32.RegisterClassW(ref wind_class);

            int last_error = Marshal.GetLastWin32Error();

            if (class_atom == 0 && last_error != ERROR_CLASS_ALREADY_EXISTS)
            {
                throw new Exception("Could not register window class");
            }

            // Create window
            m_hwnd = NativeMethodsCustomWin32.CreateWindowExW(
                exStyles,
                class_name,
                caption,
                Styles,
                startPos.X,
                startPos.Y,
                wndSize.Width,
                wndSize.Height,
                hwndParent,
                IntPtr.Zero,
                IntPtr.Zero,
                IntPtr.Zero
            );
        }

        public IntPtr Handle()
        {
            return m_hwnd;
        }

        private static IntPtr CustomWndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            return NativeMethodsCustomWin32.DefWindowProcW(hWnd, msg, wParam, lParam);
        }

        private static WndProc m_wnd_proc_delegate = new WndProc(CustomWndProc);

        public WndProc GetWndProcDlegate()
        {
            return m_wnd_proc_delegate;
        }
    }
}