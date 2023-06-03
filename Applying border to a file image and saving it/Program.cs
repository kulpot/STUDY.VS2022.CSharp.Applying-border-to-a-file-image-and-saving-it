using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

//ref link: https://www.youtube.com/watch?v=XhXbvdsO6AA&list=PLAIBPfq19p2EJ6JY0f5DyQfybwBGVglcR&index=64
// Using a console app and command line args - Debug/ProjectName Properties/Command Line Arguments/ "C:\Users\sunny\Pictures\Saved Pictures\woman.png"

namespace Applying_border_to_a_file_image_and_saving_it
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(string argument in args)
            {
                SaveWithBorder(argument);
            }
        }

        private static void SaveWithBorder(string filename)
        {
            try
            {
                Image image = Bitmap.FromFile(filename);

                using (Graphics GFX = Graphics.FromImage(image))
                {
                    Rectangle rect = new Rectangle(Point.Empty, image.Size);

                    ControlPaint.DrawBorder(GFX, rect, Color.Red, 10, ButtonBorderStyle.Inset, Color.Red, 10, ButtonBorderStyle.Inset,
                        Color.Red, 10, ButtonBorderStyle.Inset, Color.Red, 10, ButtonBorderStyle.Inset);
                }

                string newFilename = GetFilename(filename);
                image.Save(newFilename, ImageFormat.Bmp);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static string GetFilename(string filename)
        {
            int extLength = Path.GetExtension(filename).Length;
            // Remove extension
            string newName = filename.Remove(filename.Length - extLength);
            return newName + @" With Border.bmp";
        }
    }
}