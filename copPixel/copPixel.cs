using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace copPixel
{
    public class copPixel
    {
        public string PATH_IMAGE = "";
        BitmapSource bitmapSource;
        public copPixel(string file_image )
        {
            if (File.Exists(file_image))
            {
                PATH_IMAGE = file_image;
            }
        }
        public copPixel()
        {
            
        }
        public void Screen()
        {
            bitmapSource = Screenshot.GetScreenshot();
        }
        public void Screen(Point point, Point size)
        {
            bitmapSource = Screenshot.GetScreenshot(point , size);
        }
        public List<FPixel> FintColor(Color color)
        {
            if (bitmapSource == null)
                return null;
            List<FPixel> fPixels = new List<FPixel>();

            int w = bitmapSource.PixelWidth;
            int h = bitmapSource.PixelHeight;

            Color rgba;
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h;y++)
                {
                    rgba = bitmapSource.GetPixelColor(x, y);
                    bool b = Screenshot.IsIdapazon(rgba, color);
                     
                    if (b)
                    {
                        fPixels.Add( 
                            new FPixel() 
                            { 
                                color_rgba = rgba , 
                                position = new Point(x,y) 
                            }
                            );
                    }
                }
            }

            return fPixels;
        }
        public List<FPixel> GetFPixels()
        {
            if (bitmapSource == null)
                return null;
            List<FPixel> fPixels = new List<FPixel>();

            int w = bitmapSource.PixelWidth;
            int h = bitmapSource.PixelHeight;

            Color rgba;
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    rgba = bitmapSource.GetPixelColor(x,y);


                    fPixels.Add(
                            new FPixel()
                            {
                                color_rgba = rgba,
                                position = new Point(x, y)
                            }
                            );
                }
            }

            return fPixels;
        }
    }
}
