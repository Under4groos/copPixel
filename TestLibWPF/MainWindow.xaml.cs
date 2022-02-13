using copPixel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestLibWPF
{
 
    public static class WinApiKeyboard
    {
        public static int KEYEVENTF_EXTENDEDKEY = 0x0001;
        public static int KEYEVENTF_KEYUP = 0x0002;
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        public static void KeyPress(byte keyCode)
        {
            keybd_event(keyCode, 0x45, KEYEVENTF_EXTENDEDKEY, 0);
        }
        public static void SendKeyInt(byte keyCode)
        {
            KeyPress(keyCode);
            KeyRelese(keyCode);
        }
        public static void KeyRelese(byte keyCode)
        {
            keybd_event(keyCode, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }
    }
    public partial class MainWindow : Window
    {
        copPixel.copPixel pixel = new copPixel.copPixel();

        TimerTick timerTick;
        public MainWindow()
        {
            InitializeComponent();
            
            timerTick = new TimerTick();
            timerTick.Time = 1;
            timerTick.Tick += (o, e) =>
            {
                gridg.Children.Clear();
                pixel.Screen(new copPixel.Point(710, 399), new copPixel.Point(60, 36));
                foreach (FPixel item in pixel.FintColor(Color.FromRgb(83, 83, 83))) // pixel.GetFPixels())
                {
                    if (item.color_rgba == Color.FromRgb(255, 255, 255))
                        continue;

                    WinApiKeyboard.SendKeyInt(32);
                    
                    
                     
                    Border b = new Border()
                    {
                        VerticalAlignment = VerticalAlignment.Top,
                        HorizontalAlignment = HorizontalAlignment.Left,

                        Margin = new Thickness(item.position.X * 10, item.position.Y * 10, 0, 0),
                        Background = new SolidColorBrush(item.color_rgba),

                    };
                    b.Height = b.Width = 10;
                    
                    gridg.Children.Add(b);

                }
                this.Topmost = true;
            };
            timerTick.Start();
            
        }
    }
}
