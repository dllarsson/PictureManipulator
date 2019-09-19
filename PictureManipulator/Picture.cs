using System;
using System.IO;
using System.Drawing;

namespace PictureManipulator
{
    public class Picture
    {
        public string ImageAdress { get; set; }
        public Bitmap Image { get; set; }

        public Picture(string imageAdress)
        {
            ImageAdress = imageAdress;
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
                Image = image;
            }
            else
            {
                Image = null;
            }
        }

        public void ConvertPictureToNegative()
        {
            int x, y;
            for (x = 0; x < Image.Width; x++)
            {
                for (y = 0; y < Image.Height; y++)
                {
                    var pixel = Image.GetPixel(x, y);
                    int r = 255 - pixel.R;
                    int g = 255 - pixel.G;
                    int b = 255 - pixel.B;
                    Color newPixel = Color.FromArgb(r, g, b);
                    Image.SetPixel(x, y, newPixel);
                }
            }
            string[] imageName = ImageAdress.Split('.');
            string newImageName = imageName[0] + "_negative." + imageName[1];
            ImageAdress = newImageName;
        }

        public void ConvertPictureToGrayscale()
        {
            int x, y;
            for (x = 0; x < Image.Width; x++)
            {
                for (y = 0; y < Image.Height; y++)
                {
                    var pixel = Image.GetPixel(x, y);
                    int r = pixel.R;
                    int g = pixel.G;
                    int b = pixel.B;

                    int grayScaleValue = (r + g + b) / 3;

                    Color newPixel = Color.FromArgb(grayScaleValue, grayScaleValue, grayScaleValue);
                    Image.SetPixel(x, y, newPixel);
                }
            }
            string[] imageName = ImageAdress.Split('.');
            string newImageName = imageName[0] + "_grayscale." + imageName[1];
            ImageAdress = newImageName;
        }

        public Picture CovertPictureToBlurr()
        {
            Picture tempPicture = new Picture(ImageAdress);
            tempPicture.Image = Image;
            int x, y;
            Color[] blurBoxPixels = new Color[9];
            Color[] cornerPixels = new Color[4];
            Color[] indexOn0Pixels = new Color[6];
            for (x = 0; x < Image.Width - 1; x++)
            {

                for (y = 0; y < Image.Height - 1; y++)
                {
                    var pixel = Image.GetPixel(x, y);
                    if ((x > 0 && y > 0) && (x < Image.Height && y < Image.Width))
                    {
                        blurBoxPixels[0] = Image.GetPixel(x - 1, y - 1);
                        blurBoxPixels[1] = Image.GetPixel(x - 1, y);
                        blurBoxPixels[2] = Image.GetPixel(x - 1, y + 1);

                        blurBoxPixels[3] = Image.GetPixel(x, y - 1);
                        blurBoxPixels[4] = Image.GetPixel(x, y);
                        blurBoxPixels[5] = Image.GetPixel(x, y + 1);

                        blurBoxPixels[6] = Image.GetPixel(x + 1, y - 1);
                        blurBoxPixels[7] = Image.GetPixel(x + 1, y);
                        blurBoxPixels[8] = Image.GetPixel(x + 1, y + 1);

                        var r = 0;
                        var g = 0;
                        var b = 0;

                        for (int i = 0; i < 9; i++)
                        {
                            r = r + blurBoxPixels[i].R;
                            g = g + blurBoxPixels[i].G;
                            b = b + blurBoxPixels[i].B;
                        }

                        r = r / 9;
                        g = g / 9;
                        b = b / 9;

                        Color c = Color.FromArgb(r, g, b);
                        tempPicture.Image.SetPixel(x, y, c);
                    }
                    else  // The first and last pixel of x and y array
                    {
                        if (x == 0) // If x is first or last pixel;
                        {
                            if (y == 0)
                            {
                                cornerPixels[0] = Image.GetPixel(x, y);
                                cornerPixels[1] = Image.GetPixel(x, y + 1);
                                cornerPixels[2] = Image.GetPixel(x + 1, y);
                                cornerPixels[3] = Image.GetPixel(x + 1, y + 1);

                                var r = 0;
                                var g = 0;
                                var b = 0;

                                for (int i = 0; i < 4; i++)
                                {
                                    r = r + cornerPixels[i].R;
                                    g = g + cornerPixels[i].G;
                                    b = b + cornerPixels[i].B;
                                }
                                r = r / 4;
                                g = g / 4;
                                b = b / 4;
                                Color c = Color.FromArgb(r, g, b);
                                tempPicture.Image.SetPixel(x, y, c);
                            }
                            else if (y == Image.Height - 2)
                            {
                                y++;

                                cornerPixels[0] = Image.GetPixel(x, y);
                                cornerPixels[1] = Image.GetPixel(x, y - 1);
                                cornerPixels[2] = Image.GetPixel(x + 1, y);
                                cornerPixels[3] = Image.GetPixel(x + 1, y - 1);
                                var r = 0;
                                var g = 0;
                                var b = 0;

                                for (int i = 0; i < 4; i++)
                                {
                                    r = r + cornerPixels[i].R;
                                    g = g + cornerPixels[i].G;
                                    b = b + cornerPixels[i].B;
                                }
                                r = r / 4;
                                g = g / 4;
                                b = b / 4;
                                Color c = Color.FromArgb(r, g, b);
                                tempPicture.Image.SetPixel(x, y, c);

                            }
                            else
                            {
                                indexOn0Pixels[0] = Image.GetPixel(x, y);
                                indexOn0Pixels[1] = Image.GetPixel(x, y - 1);
                                indexOn0Pixels[2] = Image.GetPixel(x, y + 1);
                                indexOn0Pixels[3] = Image.GetPixel(x + 1, y);
                                indexOn0Pixels[4] = Image.GetPixel(x + 1, y - 1);
                                indexOn0Pixels[5] = Image.GetPixel(x + 1, y + 1);

                                var r = 0;
                                var g = 0;
                                var b = 0;

                                for (int i = 0; i < 6; i++)
                                {
                                    r = r + indexOn0Pixels[i].R;
                                    g = g + indexOn0Pixels[i].G;
                                    b = b + indexOn0Pixels[i].B;
                                }
                                r = r / 6;
                                g = g / 6;
                                b = b / 6;
                                Color c = Color.FromArgb(r, g, b);
                                tempPicture.Image.SetPixel(x, y, c);
                            }
                        }
                        else if (x == Image.Width - 2)
                        {
                            x++;
                            if (y == 0)
                            {
                                cornerPixels[0] = Image.GetPixel(x, y);
                                cornerPixels[1] = Image.GetPixel(x, y + 1);
                                cornerPixels[2] = Image.GetPixel(x - 1, y);
                                cornerPixels[3] = Image.GetPixel(x - 1, y + 1);
                                var r = 0;
                                var g = 0;
                                var b = 0;

                                for (int i = 0; i < 4; i++)
                                {
                                    r = r + cornerPixels[i].R;
                                    g = g + cornerPixels[i].G;
                                    b = b + cornerPixels[i].B;
                                }
                                r = r / 4;
                                g = g / 4;
                                b = b / 4;
                                Color c = Color.FromArgb(r, g, b);
                                tempPicture.Image.SetPixel(x, y, c);
                            }
                            else if (y == Image.Height - 2)
                            {
                                y++;
                                cornerPixels[0] = Image.GetPixel(x, y);
                                cornerPixels[1] = Image.GetPixel(x, y - 1);
                                cornerPixels[2] = Image.GetPixel(x - 1, y);
                                cornerPixels[3] = Image.GetPixel(x - 1, y - 1);

                                var r = 0;
                                var g = 0;
                                var b = 0;

                                for (int i = 0; i < 4; i++)
                                {
                                    r = r + cornerPixels[i].R;
                                    g = g + cornerPixels[i].G;
                                    b = b + cornerPixels[i].B;
                                }
                                r = r / 4;
                                g = g / 4;
                                b = b / 4;
                                Color c = Color.FromArgb(r, g, b);
                                tempPicture.Image.SetPixel(x, y, c);
                            }
                        }
                        else if ((x > 0) && (x < Image.Width -1))
                        {
                            indexOn0Pixels[0] = Image.GetPixel(x, y + 1);
                            indexOn0Pixels[1] = Image.GetPixel(x - 1, y + 1);
                            indexOn0Pixels[2] = Image.GetPixel(x + 1, y + 1);
                            indexOn0Pixels[3] = Image.GetPixel(x, y);
                            indexOn0Pixels[4] = Image.GetPixel(x - 1, y);
                            indexOn0Pixels[5] = Image.GetPixel(x + 1, y);

                            var r = 0;
                            var g = 0;
                            var b = 0;

                            for (int i = 0; i < 6; i++)
                            {
                                r = r + indexOn0Pixels[i].R;
                                g = g + indexOn0Pixels[i].G;
                                b = b + indexOn0Pixels[i].B;
                            }
                            r = r / 6;
                            g = g / 6;
                            b = b / 6;
                            Color c = Color.FromArgb(r, g, b);
                            tempPicture.Image.SetPixel(x, y, c);

                        }
                    }
                }
            }
            string[] imageName = ImageAdress.Split('.');
            string newImageName = imageName[0] + "_blurredPicture." + imageName[1];
            tempPicture.ImageAdress = newImageName;
            return tempPicture;

        }

    }
}

