using Microsoft.Extensions.Configuration;
using WinApiTools;

namespace ScreanBotsCommon
{
    public static class RichKeySend
    {
        private static string rageName;

        public static string RageName
        {
            get
            {
                if (rageName == null)
                {
                    rageName = ConfigTools.BuildConfig().GetValue<string>("RageName");
                }
                return rageName;
            }
        }

        public static bool IsActive
        {
            get
            {
                var window = (ActiveWindow.GetActiveWindowTitle() ?? "").Trim();
                Console.WriteLine($"{window}");

                return window.StartsWith("R") && window.EndsWith("r");
            }
        }

        public async static Task PressKey(VirtualKeyCodes key)
        {
            if (IsActive)
            {
                Console.Out.WriteLineAsync($"Pressed: {key}");
                KeyboardSend.PressKey(key);
            }
            else
            {
                Console.WriteLine("rage not active, key not pressed");
            }
        }
    }
}
