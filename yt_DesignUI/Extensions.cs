using System;

namespace yt_DesignUI
{
    public static class Extensions
    {
        public static bool InRange<T>(this T value, T a, T b) where T : IComparable
        {
            return
                (value.CompareTo(a) == 1 || value.CompareTo(a) == 0)
                &&
                (value.CompareTo(b) == -1 || value.CompareTo(b) == 0);
        }
    }
}
