using Microsoft.Extensions.Configuration;
using ScreanBotsCommon;
using System.Drawing;
using WinApiTools;

namespace YoungMinecrafter
{
    internal static class Miner
    {
        static Random Random = new();
        public async static Task StartMine()
        {
            string rageName = GetRageName();

            System.Drawing.Point workingPixel = GetWorkingPixel();

            while (true)
            {
                Thread.Sleep(1000);

                var windowName = ActiveWindow.GetActiveWindowTitle()?.Trim();
                await Console.Out.WriteLineAsync(windowName);

                if (windowName != rageName)
                    continue;

                var workingColor = GetColor(workingPixel);
                if (workingColor.R < (byte)116 || workingColor.R > (byte)136 || workingColor.G < (byte)201 || workingColor.G > (byte)221 || workingColor.B < (byte)22 || workingColor.B > (byte)42)
                    continue;

                for (int i = 0; i < 20; i++)
                {
                    await RichKeySend.PressKey(VirtualKeyCodes.E);
                    await Task.Delay(Random.Next(100, 200));
                }
            }
        }

        private static System.Drawing.Point GetWorkingPixel()
        {
            var x = Convert.ToInt32(ConfigTools.BuildConfig().GetValue<string>("Point:X"));
            var y = Convert.ToInt32(ConfigTools.BuildConfig().GetValue<string>("Point:Y"));
            return new System.Drawing.Point(x, y);
        }

        private static string GetRageName()
        {
            return ConfigTools.BuildConfig().GetValue<string>("RageName");
        }

        private static Color GetColor(System.Drawing.Point workingPixel)
        {
            Bitmap bmp = new Bitmap(1, 1);
            Rectangle bounds = new Rectangle(workingPixel.X, workingPixel.Y, 1, 1);
            using (Graphics g = Graphics.FromImage(bmp))
                g.CopyFromScreen(bounds.Location, System.Drawing.Point.Empty, bounds.Size);
            return bmp.GetPixel(0, 0);
        }
    }
}
