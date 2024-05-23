using WinApiTools;

namespace ScreanBotsCommon
{
    public class TargetOption
    {
        public RgbColor Color { get; set; }

        public RgbColor CurrentColor { get; set; }

        public Point Position { get; set; }

        public int X => Position.X;

        public int Y => Position.Y;

        public void ReadColor()
        {
            CurrentColor = ColorPicker.GetPixelColor(X, Y);
        }

        public override string ToString()
        {
            return
                $@"R: {CurrentColor.R} G: {CurrentColor.G} B: {CurrentColor.B}
X: {X} Y: {Y} 
Triggered: {IsTriggered}
-----";
        }

        public bool IsTriggered => Trigger != null ? Trigger.Invoke() : false;

        public Func<bool> Trigger;
    }
}
