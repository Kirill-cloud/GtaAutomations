using System;
using System.Runtime.InteropServices;

namespace yt_DesignUI
{
    internal class MouseSend
    {
        // Token: 0x06000096 RID: 150
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool ClientToScreen(IntPtr hWnd, ref MouseSend.POINT point);


        // Token: 0x06000097 RID: 151
        [DllImport("user32.dll", SetLastError = true)]
        private static extern void mouse_event(int dsFlags, int dx, int dy, int cButtons, int dsExtraInfo);

        // Token: 0x06000098 RID: 152 RVA: 0x0000258D File Offset: 0x0000078D
        public static void LeftClick(int x, int y)
        {
            MouseSend.mouse_event(2, x, y, 0, 0);
            MouseSend.mouse_event(4, x, y, 0, 0);
        }

        // Token: 0x06000099 RID: 153 RVA: 0x000025A3 File Offset: 0x000007A3
        public static void LeftDown(int x, int y)
        {
            MouseSend.mouse_event(2, x, y, 0, 0);
        }

        // Token: 0x0600009A RID: 154 RVA: 0x000025AF File Offset: 0x000007AF
        public static void LeftUp(int x, int y)
        {
            MouseSend.mouse_event(4, x, y, 0, 0);
        }

        // Token: 0x04000071 RID: 113
        public const int MOUSEEVENTF_LEFTDOWN = 2;

        // Token: 0x04000072 RID: 114
        public const int MOUSEEVENTF_LEFTUP = 4;

        // Token: 0x04000073 RID: 115
        public const int MOUSEEVENTF_RIGHTDOWN = 8;

        // Token: 0x04000074 RID: 116
        public const int MOUSEEVENTF_RIGHTUP = 16;

        // Token: 0x02000015 RID: 21
        public struct POINT
        {
            // Token: 0x04000075 RID: 117
            public int x;

            // Token: 0x04000076 RID: 118
            public int y;
        }
    }
}
