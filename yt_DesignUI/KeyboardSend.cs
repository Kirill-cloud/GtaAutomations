using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace yt_DesignUI
{
    internal static class KeyboardSend
    {
        // Token: 0x06000089 RID: 137
        [DllImport("user32.dll", SetLastError = true)]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        // Token: 0x0600008A RID: 138 RVA: 0x0000253D File Offset: 0x0000073D
        public static void KeyDown(Keys key)
        {
            KeyboardSend.keybd_event((byte)key, 0, 0U, 0);
        }

        // Token: 0x0600008B RID: 139 RVA: 0x00002549 File Offset: 0x00000749
        public static void KeyUp(Keys key)
        {
            KeyboardSend.keybd_event((byte)key, 0, 2U, 0);
        }

        public static void PressKey(Keys key)
        {
            KeyDown(key);
            KeyUp(key);
        }
    }
}
