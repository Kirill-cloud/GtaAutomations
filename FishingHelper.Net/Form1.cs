namespace FishingHelper.Net
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Color clickPixel;
        private Size resolution = SystemInformation.PrimaryMonitorSize;

        private async void CheckPixelsTick(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(resolution.Width, resolution.Height);
            Graphics.FromImage(bitmap).CopyFromScreen(0, 0, 0, 0, bitmap.Size);
            //this.clickPixel = bitmap.GetPixel((int)(1052.0 * this.coefX), (int)(902.0 * this.coefY));
            //this.capchaPoint1Pixel = bitmap.GetPixel((int)(940.0 * this.coefX), (int)(606.0 * this.coefY));
            //this.capchaPoint2Pixel = bitmap.GetPixel((int)(980.0 * this.coefX), (int)(606.0 * this.coefY));
            //this.label5.Text = this.clickPixel.R.ToString() + ", ";
            //Label label = this.label5;
            //label.Text = label.Text + this.clickPixel.G.ToString() + ", ";
            //Label label2 = this.label5;
            //label2.Text += this.clickPixel.B.ToString();
            //Bitmap bmp = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            //Graphics.FromImage(bmp).Clear(this.clickPixel);
            //this.pictureBox1.Image = bmp;
            //this.pictureBox1.Refresh();
        }
    }
}
