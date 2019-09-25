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
                    string path = Console.ReadLine();
                    Picture picture = new Picture();
                    picture.ReadPictureFromFile(path);
                    if (picture.Bitmap != null)
                    {
                        picture.ConvertPictureToNegative();
                        picture.SavePictureFromFile();
                        picture.ConvertPictureToGrayscale();
                        picture.SavePictureFromFile();
                        picture.ConvertPictureToBlurr();
                        picture.SavePictureFromFile();
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
                Picture picture = new Picture();
                picture.ReadPictureFromFile(args[0]);
                if (picture.Bitmap != null)
                {
                    picture.ReadPictureFromFile(args[0]);
                    picture.ConvertPictureToNegative();
                    picture.SavePictureFromFile();
                    picture.ConvertPictureToGrayscale();
                    picture.SavePictureFromFile();
                    picture.ConvertPictureToBlurr();
                    picture.SavePictureFromFile();
                }
                else
                {
                    Console.WriteLine(picture.ErrorMessage);
                }

            }
        }
    }
}
