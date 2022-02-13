using copPixel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ConsoleApplication1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            main(args);
            Console.ReadLine();
        }
        
        static void main(string[] args)
        {
            
            Console.WriteLine(
                Screenshot.IsIdapazon(
                    Color.FromRgb(200,200,200), 
                    Color.FromRgb(200, 180, 200)
                    )
                );
            
        }
    }
}
