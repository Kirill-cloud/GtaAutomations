using ScreanBotsCommon;
using WinApiTools;

namespace WelcomeToTheClubBuddy
{
    public class Gym
    {
        int screenCenterX = 1920 / 2;
        int screenCenterY = 770;
        int maxR = 128;

        public Gym()
        {

        }
        public async Task Tren()
        {
            var greenX = 0;
            var whiteX = 0;
            var edgeFinded = false;
            var lastE = DateTime.Now;


            while (true)
            {
                if (edgeFinded)
                {
                    var whiteEdgeColor = ColorPicker.GetPixelColor(whiteX, screenCenterY);
                    if (whiteEdgeColor.R >= 180 && whiteEdgeColor.G >= 180)
                    {
                        await RichKeySend.PressKey(VirtualKeyCodes.VK_SPACE);
                        edgeFinded = false;
                    }
                }
                else
                {
                    var x = Measurement.MeasureTime(() => { FindEdge(ref greenX, ref whiteX, ref edgeFinded); });
                    await Console.Out.WriteLineAsync($"{x}");
                }
                //Console.Clear();

                await Console.Out.WriteLineAsync(ActiveWindow.GetActiveWindowTitle());
                Console.Out.WriteLineAsync($"Edge finded: {edgeFinded}");
                await Task.Delay(1);

                if (lastE - DateTime.Now < TimeSpan.Zero)
                {
                    lastE = DateTime.Now.AddMilliseconds(2000);
                    await RichKeySend.PressKey(VirtualKeyCodes.E);
                }
            }
        }

        private void FindEdge(ref int greenX, ref int whiteX, ref bool edgeFinded)
        {
            for (int i = screenCenterX - maxR; i < screenCenterX; i += 2)
            {
                var currentEdgeColor = ColorPicker.GetPixelColor(i, screenCenterY);

                if (IsEdgePixel(currentEdgeColor) && !edgeFinded)
                {
                    edgeFinded = true;
                    greenX = i;
                    whiteX = greenX + 5;
                    break;
                }
            }
        }

        private bool Between(int a, int b, int c)
        {
            return a < c && a > b;
        }

        private bool IsEdgePixel(RgbColor pColor)
        {
            return
                Between(pColor.R, 5, 50)
                && Between(pColor.G, 145, 185)
                && Between(pColor.B, 40, 100);
        }
    }
}
