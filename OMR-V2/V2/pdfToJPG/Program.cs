using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace pdfToJPG
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "";
            foreach (string str in args)
            {
                fileName += str + " ";
            }
            fileName = fileName.TrimEnd(' ');
            Image bk;
            try
            {
                Console.WriteLine("PDF Conversion Started");
                Console.WriteLine("Converting: " + fileName);
                Cyotek.GhostScript.PdfConversion.Pdf2Image p2i = new Cyotek.GhostScript.PdfConversion.Pdf2Image(fileName);
                
                p2i.Settings.Dpi = 600;
                bk = p2i.GetImage(1);
                if (bk == null)
                    throw new NullReferenceException();
                Console.WriteLine("Conversion Successful");
                bk.Save("tempPdfSave.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                Console.WriteLine("Image Successfully saved to: tempPdfSave.bmp");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Image Conversion Failed!\n\n" + ex.ToString() + "\n\nPress any key to return");
                Console.ReadKey();
            }
        }
    }
}
