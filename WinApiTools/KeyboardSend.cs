using System.Runtime.InteropServices;

namespace WinApiTools
{
    public static class KeyboardSend
    {


        [DllImport("user32.dll", SetLastError = true)]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        private static void KeyDown(VirtualKeyCodes key)
        {
            keybd_event((byte)key, 0, 0U, 0);
        }

        private static void KeyUp(VirtualKeyCodes key)
        {
            keybd_event((byte)key, 0, 2U, 0);
        }

        public static async void PressKey(VirtualKeyCodes key)
        {
            KeyDown(key);
            KeyUp(key);
        }
    }

    //https://learn.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes
    public enum VirtualKeyCodes
    {
        VK_LBUTTON = 0x01,
        VK_RBUTTON = 0x02,
        VK_SPACE = 0x20,
        A = 0x41,
        D = 0x44,
        E = 0x45,
    }
}
