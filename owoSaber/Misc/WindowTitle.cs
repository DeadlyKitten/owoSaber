using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace owoSaber.Misc
{
    internal static class WindowTitle
    {
        [DllImport("user32.dll", EntryPoint = "SetWindowText")]
        private static extern bool SetWindowText(IntPtr hwnd, string lpString);

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string className, string windowName);

        private static string windowName = Application.productName;

        internal static string Get()
        {
            return windowName;
        }

        internal static void Set(string title)
        {
            var windowPtr = FindWindow(null, windowName);
            SetWindowText(windowPtr, title);

            windowName = title;
        }
    }
}
