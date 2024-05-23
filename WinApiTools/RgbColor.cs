namespace WinApiTools
{
    public struct RgbColor
    {
        public int R { get; set; }

        public int G { get; set; }

        public int B { get; set; }

        public RgbColor(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }

        public RgbColor()
        {

        }

        public static bool operator ==(RgbColor a, RgbColor b)
        {
            return a.R == b.R && a.G == b.G && a.B == b.B;
        }

        public static bool operator !=(RgbColor a, RgbColor b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            return $"{R} {G} {B}";
        }
    }
}
