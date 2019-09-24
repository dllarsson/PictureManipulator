using NUnit.Framework;
using PictureManipulator;
using System.Collections.Generic;
using System.Drawing;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ConvertPictureToGrayscale_TestIfPictureColosAreInGrayscale()
        {
            Bitmap bitmap = new Bitmap(1, 1);
            Color c = Color.FromArgb(123, 189, 222);

            bitmap.SetPixel(0, 0, c);

            Picture picture = new Picture("test.jpg");
            picture.Bitmap = bitmap;

            picture.ConvertPictureToGrayscale();

            Color c2 = picture.Bitmap.GetPixel(0, 0);

            var avrage = (c.R + c.G + c.B) / 3;
            c = Color.FromArgb(avrage, avrage, avrage);

            Assert.AreEqual(picture.Bitmap.GetPixel(0, 0), c);

        }

        [Test]
        public void ConvertPictureToNegative_TestIfPictureColorsAreNegative()
        {
            Bitmap bitmap = new Bitmap(1, 1);
            Color c = Color.FromArgb(123, 189, 222);

            bitmap.SetPixel(0, 0, c);

            Picture picture = new Picture("test.jpg");
            picture.Bitmap = bitmap;

            picture.ConvertPictureToNegative();

            Color c2 = picture.Bitmap.GetPixel(0, 0);

            var r = 255 - c.R;
            var g = 255 - c.G;
            var b = 255 - c.B;
            c = Color.FromArgb(r, g, b);

            Assert.AreEqual(picture.Bitmap.GetPixel(0, 0), c);
        }
        [Test]
        public void ConvertPictureToBlurred_TestIfConvertsToBlurred()
        {
            Bitmap bitmap = new Bitmap(3, 3);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 1 && j == 1)
                    {
                        bitmap.SetPixel(i, j, (Color.FromArgb(0, 0, 0)));
                    }
                    else
                    {
                        bitmap.SetPixel(i, j, (Color.FromArgb(255, 255, 255)));
                    }
                }
            }

            Picture picture = new Picture("test.jpg");
            picture.Bitmap = bitmap;

            picture.ConvertPictureToBlurr();

            Assert.AreEqual(Color.FromArgb(226,226,226), picture.Bitmap.GetPixel(1, 1));
        }
    }
}