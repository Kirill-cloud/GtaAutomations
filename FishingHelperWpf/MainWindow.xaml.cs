using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media.Imaging;

namespace FishingHelperWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private System.Timers.Timer _detectorTimer;
        private System.Timers.Timer _fishingTimer;

        //TODO Bind
        public bool FishingEnabled
        {
            get => _fishingEnabled;
            set
            {
                NotifyPropertyChanged();
                _fishingEnabled = value;
            }
        }
        private bool _fishingEnabled = true;

        public bool CaptchaEnabled
        {
            get => _captchaEnabled;
            set
            {
                NotifyPropertyChanged();
                _captchaEnabled = value;
            }
        }
        private bool _captchaEnabled = true;

        public State CurrentState
        {
            get => _currentState;
            set
            {
                NotifyPropertyChanged();
                _currentState = value;
            }
        }
        private State _currentState;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private State DetectState()
        {
            Scan();
            if (!FishingEnabled)
            {
                return State.Idle;
            }


            if (true)
            {
                return State.Fishing;
            }
            if (false)
            {
                return State.Captcha;
            }
            return State.Idle;
        }

        private void Scan()
        {
            using Bitmap bitmap = new Bitmap(100, 100);
            Graphics.FromImage(bitmap).CopyFromScreen(0, 0, 0, 0, bitmap.Size);
            Dispatcher.Invoke(() => { Img.Source = BitmapToImageSource(bitmap); });
        }

        private BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

        private State Processing(State op) =>
            op switch
            {
                State.Idle => State.Idle,
                State.Fishing => State.Idle,
                State.Captcha => State.Idle,
                _ => throw new NotImplementedException($"{op}")
            };

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _detectorTimer = new(100)
            {
                AutoReset = true,
                Enabled = true,
            };
            _detectorTimer.Elapsed += detectTick;

            _fishingTimer = new(110)
            {
                AutoReset = false,
                Enabled = true,
            };
            _fishingTimer.Elapsed += fishingTick;
        }

        private async void fishingTick(object? sender, System.Timers.ElapsedEventArgs e)
        {
            var a = new Types.Point(1, 1);
            var b = new Types.Point(250, 250);


            //   MouseSend.Swipe(a, b);
            _fishingTimer.Start();

            //TODO if (_currentState != State.Fishing) return;
            //move mouse
        }

        private async void detectTick(object? sender, System.Timers.ElapsedEventArgs e)
        {
            var state = DetectState();
            CurrentState = state;
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}