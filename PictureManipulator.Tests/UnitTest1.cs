using NUnit.Framework;
using PictureManipulator;
using System.Drawing;
using System.IO;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void ConvertPictureToGrayscale_TestIfPictureColosAreInGrayscale()
        {
            Bitmap bitmap = new Bitmap(1, 1);
            Color c = Color.FromArgb(123, 189, 222);
            bitmap.SetPixel(0, 0, c);
            Picture picture = new Picture();
            picture.PathOfOriginal = "test.jpg";
            picture.ConvertedBitmap = bitmap;
            picture.Bitmap = bitmap;
            picture.ConvertPictureToGrayscale();

            Assert.AreEqual(Color.FromArgb(178, 178, 178), picture.ConvertedBitmap.GetPixel(0, 0));

        }

        [Test]
        public void ConvertPictureToNegative_TestIfPictureColorsAreNegative()
        {
            Bitmap bitmap = new Bitmap(1, 1);
            Color c = Color.FromArgb(123, 189, 222);
            bitmap.SetPixel(0, 0, c);
            Picture picture = new Picture();
            picture.PathOfOriginal = "test.jpg";
            picture.ConvertedBitmap = bitmap;
            picture.Bitmap = bitmap;
            picture.ConvertPictureToNegative();

            Assert.AreEqual(Color.FromArgb(132, 66, 33), picture.ConvertedBitmap.GetPixel(0, 0));

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

            Picture picture = new Picture();
            picture.PathOfOriginal = "test.jpg";
            picture.Bitmap = bitmap;
            picture.ConvertedBitmap = bitmap;

            picture.ConvertPictureToBlurr();

            Assert.AreEqual(Color.FromArgb(226, 226, 226), picture.ConvertedBitmap.GetPixel(1, 1));
            Assert.AreNotEqual(picture.ConvertedBitmap.GetPixel(1, 1), picture.Bitmap.GetPixel(1, 1));
        }

        [Test]
        public void ReadPictureFromFile_TestIfFileExists()
        {
            Bitmap bitmap = new Bitmap(1, 1);
            bitmap.SetPixel(0, 0, Color.FromArgb(5, 5, 5));
            bitmap.Save("hello.jpg");

            Picture picture = new Picture();
            picture.ReadPictureFromFile("hello.jpg");

            Assert.IsNotNull(picture.Bitmap);

        }
        [Test]
        public void ReadPictureFromFile_TestIfFileDoesNotExcist()
        {
            Picture picture = new Picture();
            picture.ReadPictureFromFile("test.jpg");

            Assert.IsNull(picture.Bitmap);
        }

        [Test]
        public void ReadPictureFromFile_TestIfPictureIsToBig()
        {
            Bitmap bitmap = new Bitmap(1001, 10);
            bitmap.Save("tooBigTest.jpg");

            Picture picture = new Picture();
            picture.ReadPictureFromFile("tooBigTest.jpg");

            Assert.IsNull(picture.Bitmap);
        }
        [Test]
        public void SavePictureToFile_TestIfFileExtists()
        {
            Bitmap bitmap = new Bitmap(1, 1);
            Picture picture = new Picture();
            picture.PathOfCopy = "hej.jpg";
            picture.ConvertedBitmap = bitmap;
            picture.SavePictureFromFile();

            Assert.IsTrue(File.Exists("hej.jpg"));
        }

        [Test]
        public void GetNewPathName_TestIfSuffixIsIsAddedAsExpected()
        {
            string suffix = "_negative";
            Picture picture = new Picture();
            picture.PathOfOriginal = @"C:\Users\test\hello.jpg";

            string newPathName = picture.GetNewPathName(suffix);

            Assert.AreEqual(@"C:\Users\test\hello_negative.jpg", newPathName);
        }
    }
}