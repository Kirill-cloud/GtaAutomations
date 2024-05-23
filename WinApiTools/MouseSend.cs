using System.Runtime.InteropServices;

namespace WinApiTools
{
    public class MouseSend
    {
        // Token: 0x06000096 RID: 150
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool ClientToScreen(IntPtr hWnd, ref MouseSend.POINT point);


        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetCursorPos(int X, int Y);


        [DllImport("user32.dll", SetLastError = true)]
        private static extern void mouse_event(int dsFlags, int dx, int dy, int cButtons, int dsExtraInfo);

        private static void SendMouseEvent(MouseEvents @event, int dx, int dy, int cButtons, int dsExtra)
            => mouse_event((int)@event, dx, dy, cButtons, dsExtra);

        public static void LeftClick(int x, int y)
        {
            SendMouseEvent(MouseEvents.LeftDown, x, y, 0, 0);
            SendMouseEvent(MouseEvents.LeftUp, x, y, 0, 0);
        }


        public enum MouseEvents
        {
            LeftDown = 0x02,
            LeftUp = 0x04,
            RightDown = 0x08,
            RightUp = 0x0F
        }

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
