using Microsoft.Extensions.Configuration;
using ScreanBotsCommon;
using WinApiTools;

namespace JerkOffCow
{
    public class Cow
    {
        TargetOption milk;
        TargetOption aKey;
        TargetOption throttle;
        TargetOption milkingBooster;
        TargetOption milkCollector;

        RgbColor currenntThrottleColor;
        RgbColor currenntMilkColor;
        RgbColor currenntKeyAColor;
        RgbColor currenntMilkBoostColor;
        RgbColor currenntCollectorColor;

        int milkCollected = 0;

        DateTime lastCollect = DateTime.MinValue;

        public Cow()
        {
            Initialize();
        }

        void Initialize()
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();

            milk = config.GetSection("Milk").Get<TargetOption>();
            aKey = config.GetSection("AKey").Get<TargetOption>();
            throttle = config.GetSection("Throttle").Get<TargetOption>();
            milkingBooster = config.GetSection("MilkingBooster").Get<TargetOption>();
            milkCollector = config.GetSection("MilkCollector").Get<TargetOption>();

        }

        public async Task Jerk()
        {
            var isBoostAvailable = false;
            while (true)
            {

                ReadKeyScreanPoints();

                await Console.Out.WriteLineAsync($"{(isBoostAvailable ? "Boost" : "Common")}");
                await Console.Out.WriteLineAsync($"Milk collected: {milkCollected}");
                await Console.Out.WriteLineAsync($"{currenntCollectorColor}");

                if (currenntMilkColor == milk.Color
                    && !IsThrottling())
                {
                    await MilkCow(aKey, currenntKeyAColor);
                }
                else
                {
                    if (IsThrottling())
                    {
                        if (currenntMilkBoostColor == milk.Color)
                        {
                            isBoostAvailable = true;
                        }
                        await Console.Out.WriteLineAsync("Throttling...");
                    }
                    else
                    {
                        isBoostAvailable = false;
                        await Console.Out.WriteLineAsync("Running..");
                    }
                }

                if (isBoostAvailable)
                {
                    await MilkCow(aKey, currenntKeyAColor);
                }

                if (currenntCollectorColor == milkCollector.Color
                    && DateTime.Now - lastCollect >= new TimeSpan(0, 0, 10))
                {
                    lastCollect = DateTime.Now;
                    milkCollected++;
                }

                await Task.Delay(60);
                KeyboardSend.PressKey(VirtualKeyCodes.E);
                Console.Clear();
            }
        }

        bool IsThrottling() =>
            !(currenntThrottleColor.R < throttle.Color.R
                || currenntThrottleColor.G > throttle.Color.G);

        async Task MilkCow(TargetOption aKey, RgbColor currenntKeyAColor)
        {
            if (currenntKeyAColor == aKey.Color)
            {
                await Task.Delay(200);
                KeyboardSend.PressKey(VirtualKeyCodes.A);
            }
            await Task.Delay(200);
            KeyboardSend.PressKey(VirtualKeyCodes.D);
        }

        void ReadKeyScreanPoints()
        {
            currenntThrottleColor = ColorPicker.GetPixelColor(throttle.X, throttle.Y);
            currenntMilkColor = ColorPicker.GetPixelColor(milk.X, milk.Y);
            currenntMilkBoostColor = ColorPicker.GetPixelColor(milkingBooster.X, milkingBooster.Y);
            currenntKeyAColor = ColorPicker.GetPixelColor(aKey.X, aKey.Y);
            currenntCollectorColor = ColorPicker.GetPixelColor(milkCollector.X, milkCollector.Y);
        }
    }
}
