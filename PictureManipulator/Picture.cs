using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Text;

namespace PictureManipulator
{
    public class Picture
    {
        public Bitmap Bitmap { get; set; }
        public Bitmap ConvertedBitmap { get; set; }
        public string ErrorMessage { get; set; }
        public string PathOfOriginal { get; set; }
        public string PathOfCopy { get; set; }
        public bool FileIsOk { get; set; }

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


            string newPath = GetNewPathName("_negative");

            PathOfCopy = newPath;
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
            string newPath = GetNewPathName("_grayscale");

            PathOfCopy = newPath;
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

            string newPath = GetNewPathName("_blurred");

            PathOfCopy = newPath;
            ConvertedBitmap = tempBitmap;
        }

        public void ReadPictureFromFile(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    Bitmap = new Bitmap(path);
                    FileIsOk = true;
                    PathOfOriginal = path;
                    if (Bitmap.Width >= 1000 || Bitmap.Height >= 1000)
                    {
                        Bitmap = null;
                        FileIsOk = false;
                        ErrorMessage = "Image is too large. Max size is 1000x1000 pixels";
                    }
                }
                catch (ArgumentException e)
                {
                    FileIsOk = false;
                    ErrorMessage = e.Message;
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

        public string GetNewPathName(string wordToExtendPathWith)
        {

            string extension = Path.GetExtension(PathOfOriginal);
            string fileNameWithNoExtension = Path.GetFileNameWithoutExtension(PathOfOriginal);
            string directory = Path.GetDirectoryName(PathOfOriginal);
            string newFileName = fileNameWithNoExtension + wordToExtendPathWith + extension;

            string newPathName = Path.Combine(directory, newFileName);

            return newPathName;
        }




    }
}

