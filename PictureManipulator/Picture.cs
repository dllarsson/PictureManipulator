using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;

namespace PictureManipulator
{
    public class Picture
    {
        public string PictureAdress { get; set; }
        public string PictureAdressCopy { get; set; }
        public Bitmap Bitmap { get; set; }

        public Picture(string imageAdress)
        {
            PictureAdress = imageAdress;
            Bitmap image = null;
            try
            {
                image = new Bitmap(imageAdress, true);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("No picture found");
                return;
            }
            if ((image.Width < 1000) && (image.Height < 1000))
            {
                Bitmap = image;
            }
            else
            {
                Bitmap = null;
                Console.WriteLine("Image is too large");
            }
        }

        public void ConvertPictureToNegative()
        {
            int x, y;
            for (x = 0; x < Bitmap.Width; x++)
            {
                for (y = 0; y < Bitmap.Height; y++)
                {
                    var pixel = Bitmap.GetPixel(x, y);
                    int r = 255 - pixel.R;
                    int g = 255 - pixel.G;
                    int b = 255 - pixel.B;
                    Color newPixel = Color.FromArgb(r, g, b);
                    Bitmap.SetPixel(x, y, newPixel);
                }
            }
            string[] pictureAdress = PictureAdress.Split('.');
            string newPictureName = pictureAdress[0] + "_negative." + pictureAdress[1];
            PictureAdressCopy = newPictureName;
        }

        public void ConvertPictureToGrayscale()
        {
            int x, y;
            for (x = 0; x < Bitmap.Width; x++)
            {
                for (y = 0; y < Bitmap.Height; y++)
                {
                    var pixel = Bitmap.GetPixel(x, y);
                    int r = pixel.R;
                    int g = pixel.G;
                    int b = pixel.B;

                    int grayScaleValue = (r + g + b) / 3;

                    Color newPixel = Color.FromArgb(grayScaleValue, grayScaleValue, grayScaleValue);
                    Bitmap.SetPixel(x, y, newPixel);
                }
            }
            string[] pictureAdress = PictureAdress.Split('.');
            string newPictureName = pictureAdress[0] + "_grayscale." + pictureAdress[1];
            PictureAdressCopy = newPictureName;
        }

        public void ConvertPictureToBlurr()
        {
            Bitmap tempBitmap = new Bitmap(Bitmap.Width,Bitmap.Height);
            int x, y;
            var pixels = new List<Color>();
            for (x = 0; x < Bitmap.Width; x++)
            {
                for (y = 0; y < Bitmap.Height; y++)
                {

                    if (x != 0)
                    {
                        pixels.Add(Bitmap.GetPixel(x - 1, y));
                    }
                    if (y != 0)
                    {
                        pixels.Add(Bitmap.GetPixel(x, y - 1));
                    }
                    if (x != 0 && y != 0)
                    {
                        pixels.Add(Bitmap.GetPixel(x - 1, y - 1));
                    }
                    if (x != 0 && y != Bitmap.Height - 1)
                    {
                        pixels.Add(Bitmap.GetPixel(x - 1, y + 1));
                    }
                    if (y != Bitmap.Height - 1)
                    {
                        pixels.Add(Bitmap.GetPixel(x, y + 1));
                    }
                    if (x != Bitmap.Width - 1)
                    {
                        pixels.Add(Bitmap.GetPixel(x + 1, y));
                    }
                    if (x != Bitmap.Width - 1 && y != 0)
                    {
                        pixels.Add(Bitmap.GetPixel(x + 1, y - 1));
                    }
                    if (x != Bitmap.Width - 1 && y != Bitmap.Height - 1)
                    {
                        pixels.Add(Bitmap.GetPixel(x + 1, y + 1));
                    }
                    pixels.Add(Bitmap.GetPixel(x, y));


                    int listSize = pixels.Count;

                    var r = 0;
                    var g = 0;
                    var b = 0;

                    for (int i = 0; i < listSize; i++)
                    {
                        r = r + pixels[i].R;
                        g = g + pixels[i].G;
                        b = b + pixels[i].B;
                    }

                    r = r / listSize;
                    g = g / listSize;
                    b = b / listSize;

                    Color c = Color.FromArgb(r, g, b);
                    tempBitmap.SetPixel(x, y, c);
                    pixels.Clear();
                }
            }

            string[] pictureAdress = PictureAdress.Split('.');
            string newPictureAdress = pictureAdress[0] + "_blurred." + pictureAdress[1];
            PictureAdressCopy = newPictureAdress;
            Bitmap = tempBitmap;
        }




    }
}

