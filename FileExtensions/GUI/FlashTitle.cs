using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace GUI {
    class FlashTitle {

        [DllImport("user32.dll")]
        public static extern int FlashWindowEx(ref FLASHWINFO pfwi);

        public enum FLASHWINFOFLAGS {
            FLASHW_STOP = 0,
            FLASHW_CAPTION = 0x00000001,
            FLASHW_TRAY = 0x00000002,
            FLASHW_ALL = (FLASHW_CAPTION | FLASHW_TRAY),
            FLASHW_TIMER = 0x00000004,
            FLASHW_TIMERNOFG = 0x0000000C
        }

        /// <summary>
        /// http://msdn.microsoft.com/en-us/library/ms679348
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO {
            public UInt32 cbSize;
            public IntPtr hwnd;
            public Int32 dwFlags;
            public UInt32 uCount;
            public Int32 dwTimeout;

        }

        static public void Flash(Form mainForm) {
            FLASHWINFO fw = new FLASHWINFO();
            fw.cbSize = Convert.ToUInt32(Marshal.SizeOf(typeof(FLASHWINFO)));
            fw.hwnd = mainForm.Handle;
            // Flash both the window caption and the taskbar button until the window comes to the foreground
            fw.dwFlags = (Int32)(FLASHWINFOFLAGS.FLASHW_ALL | FLASHWINFOFLAGS.FLASHW_TIMERNOFG);
            fw.dwTimeout = 0;
            FlashWindowEx(ref fw);
        }

    }
}
