using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OMR.helpers
{
    public class duplicateFile
    {
        public static string createDuplicate(string fileName)
        {
            if (!Directory.Exists("omrtemp"))
                Directory.CreateDirectory("omrtemp");
            string tempName = Path.GetFileNameWithoutExtension(Path.GetTempFileName());
            string dupFile = "omrTemp\\" + tempName + "_tmp"+ Path.GetExtension(fileName);
            try
            {
                File.Copy(fileName, dupFile, false);
            }
            catch
            {

            }
            return dupFile;
        }
        public static void cleanUpFiles()
        {
            if (!Directory.Exists("omrtemp"))
                Directory.CreateDirectory("omrtemp");
            string[] files = Directory.GetFiles("omrTemp");
            foreach (string file in files)
            {
                try
                {
                    File.Delete(file);
                }
                catch { }
            }
        }
    }
}
