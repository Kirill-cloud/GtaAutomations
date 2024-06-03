using ScreanBotsCommon;
using System.Drawing;
using WinApiTools;

namespace WelcomeToTheClubBuddy
{
    public class Gym2
    {
        static int ringCenterX = 1920 / 2;
        static int ringCenterY = 770;
        static int maxR = 150;

        public async Task Tren()
        {
            var x = 0;
            var edgeFinded = false;
            var lastE = DateTime.Now;
            var last1 = DateTime.Now;

            while (true)
            {
                if (!edgeFinded)
                {
                    using var bmp = TakeScreenshot();
                    x = FindEdge(bmp);
                    if (x > 0)
                    {
                        x += 4;
                        edgeFinded = true;
                    }
                }
                else
                {
                    var white = ColorPicker.GetPixelColor(x, ringCenterY);
                    if (white.R >= 100 && white.G >= 200 && white.B >= 120)
                    {
                        await RichKeySend.PressKey(VirtualKeyCodes.VK_SPACE);
                        await Task.Delay(150);
                        edgeFinded = false;
                    }
                }

                if (lastE - DateTime.Now < TimeSpan.Zero)
                {
                    lastE = DateTime.Now.AddMilliseconds(2000);
                    await RichKeySend.PressKey(VirtualKeyCodes.E);
                    Console.Clear();
                }

                if (last1 - DateTime.Now < TimeSpan.Zero)
                {
                    last1 = DateTime.Now.Add(new TimeSpan(0, 5, 0));
                    await RichKeySend.PressKey(VirtualKeyCodes.NUM_1);
                }
            }
        }

        static Bitmap TakeScreenshot()
        {
            Bitmap bmp = new Bitmap(maxR + 10, 2);
            using Graphics graphics = Graphics.FromImage(bmp);
            graphics.CopyFromScreen(new System.Drawing.Point(ringCenterX - maxR, ringCenterY), System.Drawing.Point.Empty, bmp.Size);
            return bmp;
        }

        static int FindEdge(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                var clr = bmp.GetPixel(i, 1);
                if (IsEdgePixel(clr))
                {
                    Console.WriteLine($"Finded {ringCenterX - maxR + i}");
                    return ringCenterX - maxR + i;
                }
            }

            return -1;
        }

        private static bool Between(byte a, byte b, byte c)
        {
            return a < c && a > b;
        }

        private static bool IsEdgePixel(Color pColor)
        {
            return
                Between(pColor.R, 5, 50)
                && Between(pColor.G, 145, 185)
                && Between(pColor.B, 40, 100);
        }
    }
}
