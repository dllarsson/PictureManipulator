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
                    CreateCopysGrayscaleNegativeBlurred(picture);
                }
            }
            else
            {
                Picture picture = new Picture(args[0]);
                CreateCopysGrayscaleNegativeBlurred(picture);
            }
        }

        public static void CreateCopysGrayscaleNegativeBlurred(Picture picture)
        {
            picture.ConvertPictureToNegative();
            picture.Bitmap.Save(picture.PictureAdressCopy);

            picture.ConvertPictureToGrayscale();
            picture.Bitmap.Save(picture.PictureAdressCopy);

            picture.ConvertPictureToBlurr();
            picture.Bitmap.Save(picture.PictureAdressCopy);
        }
    }
}
