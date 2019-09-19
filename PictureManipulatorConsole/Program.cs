using System;
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
                if (picture.Image != null)
                {
                    CreateCopysGrayscaleNegativeBlurred(picture);
                }
                else
                {
                    Console.WriteLine("Picture is too large!");
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

            Picture pictureNegative = new Picture(picture.ImageAdress);
            pictureNegative.ConvertPictureToNegative();
            string[] fileCopy = picture.ImageAdress.Split('.');
            string ConvertedPictureAdress = fileCopy[0] + "_negative" + "." + fileCopy[1];
            pictureNegative.Image.Save(ConvertedPictureAdress);

            Picture pictureGrayscale = new Picture(picture.ImageAdress);
            pictureGrayscale.ConvertPictureToGrayscale();
            fileCopy = picture.ImageAdress.Split('.');
            ConvertedPictureAdress = fileCopy[0] + "_grayscale" + "." + fileCopy[1];
            pictureGrayscale.Image.Save(ConvertedPictureAdress);


            Picture pictureBlurred = new Picture(picture.ImageAdress);
            pictureBlurred.CovertPictureToBlurr();
            fileCopy = picture.ImageAdress.Split('.');
            ConvertedPictureAdress = fileCopy[0] + "_blurred" + "." + fileCopy[1];
            pictureBlurred.Image.Save(ConvertedPictureAdress);

        }
    }
}
