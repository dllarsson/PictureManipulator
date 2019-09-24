using System;
using System.Drawing;
using PictureManipulator;

namespace PictureManipulatorConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Length == 0)
            {
                Console.Write("Image path: ");
                string adress = Console.ReadLine();
                Picture picture = new Picture(adress);
                if (picture.Bitmap != null)
                {
                    picture.ConvertPictureToNegative();
                    picture.ConvertedBitmap.Save(picture.PictureAdressCopy);
                    picture.ConvertPictureToGrayscale();
                    picture.ConvertedBitmap.Save(picture.PictureAdressCopy);
                    picture.ConvertPictureToBlurr();
                    picture.ConvertedBitmap.Save(picture.PictureAdressCopy);
                }
                else
                {

                }
            }
            else
            {
                Picture picture = new Picture(args[0]);

                picture.ConvertPictureToNegative();
                picture.SavePicture();
                picture.ConvertPictureToGrayscale();
                picture.SavePicture();
                picture.ConvertPictureToBlurr();
                picture.SavePicture();
            }
        }
    }
}
