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
                while (true)
                {
                    Console.Write("Image path: ");
                    string adress = Console.ReadLine();
                    Picture picture = new Picture(adress);
                    if (picture.Bitmap != null)
                    {
                        picture.ConvertPictureToNegative();
                        picture.SavePicture();
                        picture.ConvertPictureToGrayscale();
                        picture.SavePicture();
                        picture.ConvertPictureToBlurr();
                        picture.SavePicture();
                        break;
                    }
                    else
                    {
                        Console.WriteLine(picture.ErrorMessage);
                    }

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
