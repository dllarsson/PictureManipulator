using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;

namespace PictureManipulator
{
    public class Picture
    {
        public Bitmap Bitmap { get; set; }
        public Bitmap ConvertedBitmap { get; set; }
        public string ErrorMessage { get; set; }
        public string Path { get; set; }
        public string PathOfCopy { get; set; }

        public Picture()
        {
        }

        public void ConvertPictureToNegative()
        {
            Bitmap tempBitmap = new Bitmap(Bitmap.Width, Bitmap.Height);
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
                    tempBitmap.SetPixel(x, y, newPixel);
                }
            }
            string[] pictureAdress = Path.Split('.');
            string newPictureName = pictureAdress[0] + "_negative." + pictureAdress[1];
            PathOfCopy = newPictureName;
            ConvertedBitmap = tempBitmap;
        }

        public void ConvertPictureToGrayscale()
        {
            Bitmap tempBitmap = new Bitmap(Bitmap.Width, Bitmap.Height);
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
                    tempBitmap.SetPixel(x, y, newPixel);
                }
            }
            string[] pictureAdress = Path.Split('.');
            string newPictureName = pictureAdress[0] + "_grayscale." + pictureAdress[1];
            PathOfCopy = newPictureName;
            ConvertedBitmap = tempBitmap;
        }

        public void ConvertPictureToBlurr()
        {
            Bitmap tempBitmap = new Bitmap(Bitmap.Width, Bitmap.Height);
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

            string[] pictureAdress = Path.Split('.');
            string newPictureAdress = pictureAdress[0] + "_blurred." + pictureAdress[1];
            PathOfCopy = newPictureAdress;
            ConvertedBitmap = tempBitmap;
        }

        public void ReadPictureFromFile(string path)
        {
            path.Trim();
            path.ToLower();
            string[] fileTypes = { "jpg", "png", "bmp", "jpeg" };
            string[] pathSplitted = path.Split('.');

            if (File.Exists(path))
            {
                foreach (var fileType in fileTypes)
                {
                    if (fileType == pathSplitted[pathSplitted.Length - 1])
                    {
                        Bitmap = new Bitmap(path);
                        Path = path;
                        if (Bitmap.Width > 1000 || Bitmap.Height > 1000)
                        {
                            Bitmap = null;
                            ErrorMessage = "Image is too large. Max size is 1000x1000 pixels";
                        }
                        break;
                    }
                    else
                    {
                        ErrorMessage = "Filetype is not accepted";
                    }
                }
            }
            else
            {
                ErrorMessage = "File does not exist";
            }
        }
        public void SavePictureFromFile()
        {
            ConvertedBitmap.Save(PathOfCopy);
            ConvertedBitmap = Bitmap;
        }




    }
}

