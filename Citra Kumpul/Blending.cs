using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Citra_Kumpul
{
    class Blending
    {
        public void ColorMode(Image originalImg, Image invertedBmp)
        {
            using (Bitmap lower = new Bitmap(invertedBmp))
            using (Bitmap upper = new Bitmap(originalImg))
            using (Bitmap output = new Bitmap(lower.Width, lower.Height))
            {
                var width = lower.Width;
                var height = lower.Height;

                for (var i = 0; i < height; i++)
                {
                    for (var j = 0; j < width; j++)
                    {
                        var upperPixel = upper.GetPixel(j, i);
                        var lowerPixel = lower.GetPixel(j, i);

                        var lowerColor = new HSLColor(lowerPixel.R, lowerPixel.G, lowerPixel.B);
                        var upperColor = new HSLColor(upperPixel.R, upperPixel.G, upperPixel.B) { Luminosity = lowerColor.Luminosity };
                        var outputColor = (Color)upperColor;

                        output.SetPixel(j, i, outputColor);
                    }
                }

                // Drawing the output image
            }
        }
    }
}
