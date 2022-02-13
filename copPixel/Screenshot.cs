using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace copPixel
{
    public static class Screenshot
    {
        public static BitmapSource BitmapToBitmapSource(System.Drawing.Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);

                stream.Position = 0;
                BitmapImage result = new BitmapImage();
                result.BeginInit();
                result.CacheOption = BitmapCacheOption.OnLoad;
                result.StreamSource = stream;
                result.EndInit();
                result.Freeze();
                return result;
            }
        }
        public static BitmapSource GetScreenshot( )
        {
            System.Drawing.Bitmap printscreen = new System.Drawing.Bitmap(
                ScreenSize.GetWidth(),
                ScreenSize.GetHeight()
                );

            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(printscreen as System.Drawing.Bitmap);
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);

            return BitmapToBitmapSource(printscreen);
        }

        public static BitmapSource GetScreenshot(Point point , Point size)
        {
            System.Drawing.Bitmap printscreen = new System.Drawing.Bitmap(
                size.X,
                size.Y
                );

            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(printscreen as System.Drawing.Bitmap);
            graphics.CopyFromScreen(point.X, point.Y, 0, 0, printscreen.Size);

            return BitmapToBitmapSource(printscreen);
        }
        public static bool IsIdapazon(Color color , Color color2)
        {
            return NumberLib.diapazon(color.R, color2.R) &&
                NumberLib.diapazon(color.G, color2.G) &&
                NumberLib.diapazon(color.B, color2.B) && 
                NumberLib.diapazon(color.A, color2.A);
             
        }
        public static Color GetPixelColor(this BitmapSource bitmap, int x, int y)
        {
            Color color;
            var bytesPerPixel = (bitmap.Format.BitsPerPixel + 7) / 8;
            var bytes = new byte[bytesPerPixel];
            var rect = new Int32Rect(x, y, 1, 1);

            bitmap.CopyPixels(rect, bytes, bytesPerPixel, 0);
            if (bitmap.Format == PixelFormats.Bgra32)
            {
                color = Color.FromArgb(bytes[3], bytes[2], bytes[1], bytes[0]);
            }
            else if (bitmap.Format == PixelFormats.Bgr32)
            {
                color = Color.FromRgb(bytes[2], bytes[1], bytes[0]);
            }
            else
            {
                color = Colors.Black;
            }

            return color;
        }
    }
}
