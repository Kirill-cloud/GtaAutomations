using System.Diagnostics;

namespace WinApiTools
{
    public static class Measurement
    {
        static Stopwatch stopwatch = new Stopwatch();

        public static TimeSpan MeasureTime(Action action)
        {
            stopwatch.Restart();
            action();
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
    }
}
