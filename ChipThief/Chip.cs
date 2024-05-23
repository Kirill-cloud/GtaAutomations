using Microsoft.Extensions.Configuration;
using ScreanBotsCommon;
using WinApiTools;

namespace ChipThief
{
    public class Chip
    {
        TargetOption redLine;
        TargetOption greenLine;

        RgbColor currenntRedLineColor;
        RgbColor currenntGreenLineColor;

        public Chip()
        {
            var config = ConfigTools.BuildConfig();
            redLine = config.GetSection("RedLine").Get<TargetOption>();
            greenLine = config.GetSection("GreenLine").Get<TargetOption>();
        }

        public async Task Thief()
        {
            int count = 0;
            bool thiffing = false;

            while (count < 100)
            {
                currenntRedLineColor = ColorPicker.GetPixelColor(redLine.X, redLine.Y);
                currenntGreenLineColor = ColorPicker.GetPixelColor(greenLine.X, greenLine.Y);

                await Console.Out.WriteLineAsync($"Green: {currenntGreenLineColor}");
                await Console.Out.WriteLineAsync($"Red: {currenntRedLineColor}");

                if (currenntRedLineColor == redLine.Color)
                {
                    await Console.Out.WriteLineAsync("Active");
                    thiffing = true;

                    if (currenntGreenLineColor == greenLine.Color)
                    {
                        await Console.Out.WriteLineAsync("Active + E");
                        KeyboardSend.PressKey(VirtualKeyCodes.E);
                    }
                    else
                    {
                        await Console.Out.WriteLineAsync("Active + NOT E");
                    }
                }
                else
                {
                    if (thiffing)
                    {
                        thiffing = false;
                        count++;
                    }

                    //KeyboardSend.PressKey(VirtualKeyCodes.E);
                    await Console.Out.WriteLineAsync("INactive");
                }

                await Console.Out.WriteLineAsync($"Count: {count}");

                await Task.Delay(16);
                Console.Clear();
            }
        }
    }
}
