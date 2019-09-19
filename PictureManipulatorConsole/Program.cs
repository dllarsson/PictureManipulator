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
            }
            else
            {
                Picture picture = new Picture(args[0]);
                CreateCopysGrayscaleNegativeBlurred(picture);
            }
        }

        public static void CreateCopysGrayscaleNegativeBlurred(Picture picture)
        {

            //Picture pictureNegative = new Picture(picture.ImageAdress);
            picture.ConvertPictureToNegative();
            //string[] fileCopy = picture.ImageAdress.Split('.');
            //string ConvertedPictureAdress = fileCopy[0] + "_negative" + "." + fileCopy[1];
            picture.Image.Save(picture.ImageAdressCopy);


            //Picture pictureGrayscale = new Picture(picture.ImageAdress);
            picture.ConvertPictureToGrayscale();
            //fileCopy = picture.ImageAdress.Split('.');
            //ConvertedPictureAdress = fileCopy[0] + "_grayscale" + "." + fileCopy[1];
            picture.Image.Save(picture.ImageAdressCopy);


            //Picture pictureBlurred = new Picture(picture.ImageAdress);
            picture = picture.CovertPictureToBlurr();
            //fileCopy = picture.ImageAdress.Split('.');
            //ConvertedPictureAdress = fileCopy[0] + "_blurred" + "." + fileCopy[1];
            picture.Image.Save(picture.ImageAdressCopy);

        }
    }
}
