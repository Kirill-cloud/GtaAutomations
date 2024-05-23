using FishingHelperWpf.Types;
using System.Runtime.InteropServices;

namespace FishingHelperWpf
{
    internal partial class MouseSend
    {
        // Token: 0x06000096 RID: 150
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool ClientToScreen(IntPtr hWnd, ref Point point);

        [DllImport("User32.dll")]
        public static extern bool SetCursorPos(int X, int Y);

        public static void Swipe(Point a, Point b)
        {
            var steps = 20;

            var horizontalStep = b.x - a.x;
            horizontalStep /= steps;

            var verticalStep = b.y - a.y;
            verticalStep /= steps;

            for (int i = 0; i < steps; i++)
            {
                var newPosX = a.x + horizontalStep * i;
                var newPosY = a.y + verticalStep * i;
                SetCursorPos(newPosX, newPosY);
                Thread.Sleep(10);
            }
        }

        // Token: 0x06000097 RID: 151
        [DllImport("user32.dll", SetLastError = true)]
        private static extern void mouse_event(int dsFlags, int dx, int dy, int cButtons, int dsExtraInfo);

        // Token: 0x06000098 RID: 152 RVA: 0x0000258D File Offset: 0x0000078D
        public static void LeftClick(int x, int y)
        {
            mouse_event(2, x, y, 0, 0);
            mouse_event(4, x, y, 0, 0);
        }

        // Token: 0x06000099 RID: 153 RVA: 0x000025A3 File Offset: 0x000007A3
        public static void LeftDown(int x, int y)
        {
            mouse_event(2, x, y, 0, 0);
        }

        // Token: 0x0600009A RID: 154 RVA: 0x000025AF File Offset: 0x000007AF
        public static void LeftUp(int x, int y)
        {
            mouse_event(4, x, y, 0, 0);
        }

        // Token: 0x04000071 RID: 113
        public const int MOUSEEVENTF_LEFTDOWN = 2;

        // Token: 0x04000072 RID: 114
        public const int MOUSEEVENTF_LEFTUP = 4;

        // Token: 0x04000073 RID: 115
        public const int MOUSEEVENTF_RIGHTDOWN = 8;

        // Token: 0x04000074 RID: 116
        public const int MOUSEEVENTF_RIGHTUP = 16;
    }
}
