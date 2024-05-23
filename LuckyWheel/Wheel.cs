using Microsoft.Extensions.Configuration;
using ScreanBotsCommon;
using WinApiTools;

namespace LuckyWheel
{
    public class Wheel
    {
        private readonly TargetOption? target;

        public Wheel()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();

            target = config.GetSection("Target").Get<TargetOption>();
        }

        public async Task Clicking()
        {
            //880
            while (true)
            {
                MouseSend.SetCursorPos(target.X, target.Y);
                MouseSend.LeftClick(target.X, target.Y);
                for (int i = 0; i < 60; i++)
                {
                    await Task.Delay(new TimeSpan(0, 0, 1));
                    Console.Clear();
                    await Console.Out.WriteLineAsync($"{i}");
                }
                Console.Clear();
            }
        }
    }
}
