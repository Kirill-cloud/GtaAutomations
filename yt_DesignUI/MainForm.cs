using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TwoCaptcha.Captcha;

namespace yt_DesignUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private static Size resolution = SystemInformation.PrimaryMonitorSize;
        private double coefX = (double)MainForm.resolution.Width / 1920.0;
        private double coefY = (double)MainForm.resolution.Height / 1080.0;
        private Color clickPixel;
        private Point capchaPixel = new Point(860, 456);
        private static Size capchaSize = new Size(200, 50);
        private Color capchaPoint1Pixel;
        private Color capchaPoint2Pixel;
        private Random rnd = new Random();
        private bool isCapcha;
        private string apiKey = @"77f2f1d1d40ed1696de108d9d89babc6";
        private Point capchaInput = new Point(960, 550);
        private Point enterPoint = new Point(880, 606);
        private string captchaCode;
        private bool _scaningIsActive = false;
        private bool _isAutoCaptcha = false;
        private void MainForm_Load(object sender, EventArgs e)
        {
            label7.Text = MainForm.resolution.Width.ToString() + "x" + MainForm.resolution.Height.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://vk.com/id261884895");
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label3.Text = trackBar1.Value.ToString();
            Label label = label3;
            label.Text += " мс";
        }

        private async void CheckPixelsTick(object sender, EventArgs e)
        {
            using (Bitmap bitmap = new Bitmap(MainForm.resolution.Width, MainForm.resolution.Height))
            {
                Graphics.FromImage(bitmap).CopyFromScreen(0, 0, 0, 0, bitmap.Size);
                clickPixel = bitmap.GetPixel((int)(1052.0 * coefX), (int)(902.0 * coefY));
                capchaPoint1Pixel = bitmap.GetPixel((int)(940.0 * coefX), (int)(606.0 * coefY));
                capchaPoint2Pixel = bitmap.GetPixel((int)(980.0 * coefX), (int)(606.0 * coefY));
                label5.Text = clickPixel.R.ToString() + ", ";
                Label label = label5;
                label.Text = label.Text + clickPixel.G.ToString() + ", ";
                Label label2 = label5;
                label2.Text += clickPixel.B.ToString();
                using (Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height))
                {
                    Graphics.FromImage(bmp).Clear(clickPixel);
                    pictureBox1.Image = bmp;
                    pictureBox1.Refresh();
                }

                if (!_scaningIsActive) return;

                if (clickPixel.R == 255 && clickPixel.G == 0 && clickPixel.B == 0)
                {
                    clicker.Enabled = true;
                    isCapcha = false;
                    //не понятно почему чекер выключаем, это не обязательно
                    //this.checker.Enabled = false;
                }

                if (_isAutoCaptcha && !isCapcha && CaptchaIsOnScreen)
                {
                    isCapcha = true;
                    using (Bitmap capchaBitmap = new Bitmap(capchaSize.Width, capchaSize.Height))
                    {
                        captchaCode = string.Empty;
                        Graphics.FromImage(capchaBitmap).CopyFromScreen(capchaPixel.X, capchaPixel.Y, 0, 0, bitmap.Size);
                        var captchaFileName = DateTime.Now.ToFileTime().ToString() + ".jpg";
                        capchaBitmap.Save(captchaFileName, ImageFormat.Jpeg);
                        var solver = new TwoCaptcha.TwoCaptcha(apiKey);
                        Normal captcha = new Normal(captchaFileName);
                        try
                        {
                            //TODO по хорошему отменять запрос если тип выключил галочку 
                            await solver.Solve(captcha);
                            captchaCode = captcha.Code;
                            if (_isAutoCaptcha)
                            {
                                EnterCaptcha();
                            }
                        }
                        catch (AggregateException ex)
                        {
                            MessageBox.Show("Error occurred: " + ex.InnerExceptions.First().Message, "Error");
                        }
                    }
                }
            }
        }

        private bool CaptchaIsOnScreen
        {
            get =>
                capchaPoint1Pixel.R.InRange((byte)5, (byte)25)
                && capchaPoint1Pixel.G.InRange((byte)200, (byte)250)
                && capchaPoint1Pixel.B.InRange((byte)35, (byte)65)
                && capchaPoint2Pixel.R >= 245
                && capchaPoint2Pixel.G <= 10
                && capchaPoint2Pixel.B <= 20;
        }

        private void EnterCaptcha()
        {
            Thread.Sleep(100);
            Cursor.Position = capchaInput;
            MouseSend.LeftDown(capchaInput.X, capchaInput.Y);
            MouseSend.LeftUp(capchaInput.X, capchaInput.Y);
            Thread.Sleep(200);
            foreach (var key in captchaCode)
            {
                switch (key)
                {
                    case '0': KeyboardSend.PressKey(Keys.D0); break;
                    case '1': KeyboardSend.PressKey(Keys.D1); break;
                    case '2': KeyboardSend.PressKey(Keys.D2); break;
                    case '3': KeyboardSend.PressKey(Keys.D3); break;
                    case '4': KeyboardSend.PressKey(Keys.D4); break;
                    case '5': KeyboardSend.PressKey(Keys.D5); break;
                    case '6': KeyboardSend.PressKey(Keys.D6); break;
                    case '7': KeyboardSend.PressKey(Keys.D7); break;
                    case '8': KeyboardSend.PressKey(Keys.D8); break;
                    case '9': KeyboardSend.PressKey(Keys.D9); break;
                    default: break;

                }
                Thread.Sleep(new Random().Next(100, 300));
            }

            Thread.Sleep(300);
            Cursor.Position = enterPoint;
            MouseSend.LeftDown(enterPoint.X, enterPoint.Y);
            MouseSend.LeftUp(enterPoint.X, enterPoint.Y);
            Thread.Sleep(200);
            isCapcha = false;
        }

        private void ClickerTick(object sender, EventArgs e)
        {
            clicker.Interval = rnd.Next(45, 55);
            using (Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
            {
                Graphics.FromImage(bitmap).CopyFromScreen(0, 0, 0, 0, bitmap.Size);
                clickPixel = bitmap.GetPixel((int)(1052.0 * coefX), (int)(902.0 * coefY));
            }

            if (clickPixel.R == 255 && clickPixel.G == 0 && clickPixel.B == 0)
            {
                MouseSend.LeftDown((int)(860.0 * coefX), (int)(520.0 * coefY));
                for (int i = 0; i <= 5; i++)
                {
                    int x = Cursor.Position.X + 30;
                    int y = Cursor.Position.Y;
                    Cursor.Position = new Point(x, y);
                    Thread.Sleep(rnd.Next(2, 4));
                }
                MouseSend.LeftUp(Cursor.Position.X, Cursor.Position.Y);
                Cursor.Position = new Point((int)(860.0 * coefX), (int)(520.0 * coefY));
                return;
            }
            //TODO страшная заварушка 
            if (!clickPixel.R.InRange((byte)224, (byte)230)
                || !clickPixel.G.InRange((byte)224, (byte)230)
                || !clickPixel.B.InRange((byte)224, (byte)230))
            {
                clicker.Enabled = false;
                KeyboardSend.KeyDown(Keys.D1);
                KeyboardSend.KeyUp(Keys.D1);
                //TODO this.checker.Enabled = true;
            }
        }

        private void _fishingToggle_CheckedChanged(object sender)
        {
            {
                _scaningIsActive = _fishingToggle.Checked;
                trackBar1.Enabled = !_fishingToggle.Checked;
                checker.Interval = trackBar1.Value;
            }
        }

        private void captchaSwitch_CheckedChanged(object sender)
        {
            _isAutoCaptcha = captchaSwitch.Checked;
        }
    }
}
