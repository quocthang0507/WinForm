using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using OMR;

namespace OMR.omrConsole
{
    public class Program
    {
        bool runWithoutInput = true, argsValid = true, enableMT;
        string imageAddress = "", dbAddress = "", sheetName = "", whatToDo = "", whatToDoValue = "", outputDir = "", ansKeyTitle = "";
        //bool guiFB = false;
        OMREngine engine;
        int maxThreads = 1;
        
        static void Main(string[] args)
        {
            Console.WriteLine("OMR Console V0.9\n\n");
            Console.WriteLine("For any querries regarding this engine, read my article on codeProject.com.");
            Console.WriteLine("Just google \"OMR C# V2\" and follow the fisrt link.");
            Console.WriteLine("\nFor querries regarding this console, use \"help\" as command or commandline\nargument\n\n");

            Program p = new Program();
            if (args.Length > 0)
            {
                for (int i = 0; i < args.Length; i+=2)
                {
                    try
                    {
                        p.parseArg(new string[] { args[i], args[i + 1] });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        p.argsValid = false;
                        p.runWithoutInput = false;
                        Console.Read();
                    }
                }
                p.argsValid = p.checkArgValidity();
            }
            else p.runWithoutInput = false;
            if (p.argsValid || p.runWithoutInput)
            {
                if (!p.runWithoutInput)
                {
                    while (true)
                    {
                        Console.Write("\n> ");
                        string command = Console.ReadLine();
                        try
                        {
                            if (p.parseArg(command.Split(new char[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries)))
                            {
                                if (p.whatToDo == "exit")
                                    return;
                                p.processArgs();
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            p.argsValid = false;
                        }
                    }
                }
                else
                {
                    p.processArgs();
                }
                Console.WriteLine();
                if (!p.runWithoutInput)
                {
                    Console.WriteLine("Press any key to exit...");
                    Console.Read();
                }
            }
        }
        public volatile int total = 0, current = 0;
        public void processImage()
        {
            FileStream fs;
            StreamWriter sw;
            if (checkArgValidity())
            {
                bool sing = whatToDoValue == "single";
                Console.WriteLine("Processing");
                string [] allFiles;
                if (sing)
                    allFiles = new string[1] { imageAddress };
                else
                    allFiles = Directory.GetFiles(imageAddress, "*.jpg");
                int suc = 0, fail = 0;
                total = allFiles.Length; current = 0;
                for (int crsr = 0; crsr < allFiles.Length; crsr++)
                {
                    current++;
                    engine = new OMREngine(allFiles[crsr], dbAddress, sheetName, ansKeyTitle);
                    engine.onAsyncProgressUpdated += Engine_onAsyncProgressUpdated;
                    if (engine.StartProcess())
                    {
                        string fileName = Path.GetFileNameWithoutExtension(allFiles[crsr]);
                        if (outputDir == "")
                        { outputDir = Path.Combine(Environment.CurrentDirectory, fileName); }
                        if (!Directory.Exists(outputDir))
                            Directory.CreateDirectory(outputDir);
                        string readAbleResult = "";
                        readAbleResult += "Total Empty blocks: " + engine.EmptyBlocks.Count.ToString() + "\r\n";
                        readAbleResult += "Total Answer blocks: " + engine.AnswerBlocks.Count.ToString() + "\r\n";
                        readAbleResult += "Total Number blocks: " + engine.NumberBlocks.Count.ToString() + "\r\n";
                        for (int i = 0; i < engine.NumberBlocks.Count; i++)
                            readAbleResult += "Value of Number Block [" + (i + 1).ToString() + "]: " + engine.NumberBlocks[i].MarkedValue.ToString() + "\r\n";
                        for (int i = 0; i < engine.AnswerBlocks.Count; i++)
                            readAbleResult += "Result of Answer Block [" + (i + 1).ToString() + "]: " + engine.AnswerBlocks[i].ToString() + "\r\n";
                        for (int i = 0; i < engine.EmptyBlocks.Count; i++)
                            engine.EmptyBlocks[i].CroppedImage.Save(
                                Path.Combine(outputDir, fileName + "_emptyBlock" + (i + 1).ToString() + "CroppedImage.jpg"), System.Drawing.Imaging.ImageFormat.Jpeg);
                        fs = new FileStream(Path.Combine(outputDir, fileName + "_textResult.txt"), FileMode.Create);
                        sw = new StreamWriter(fs);
                        sw.Write(readAbleResult);
                        sw.Flush();
                        fs.Close();
                        suc++;
                    }
                    else
                    {
                        fail++;
                    }
                }
                Console.WriteLine("                                                                  " + outputDir);
                Console.WriteLine("All processes have been completed. Results compiled and save in: " + outputDir);

                fs = new FileStream(Path.Combine(outputDir, "ConversionLog.txt"), FileMode.Create);
                sw = new StreamWriter(fs);
                sw.Write("Total successful conversions: "+ suc.ToString()+"\r\nTotal failed Conversions: "+fail.ToString());
                sw.Flush();
                fs.Close();
            }
        }
        
        private void Engine_onAsyncProgressUpdated(ProgressEventArgs e)
        {
            Console.Write("\rProcess {0}/{1} [", current, total);
            int lineLength = 25;
            for (int i = 0; i < lineLength; i++)
            {
                if (i <= (int)Math.Round((double)e.Value / 100D * (double)lineLength, 0))
                    Console.Write("#");
                else
                    Console.Write(" ");
            }
            if (e.Value < 100)
            {
                Console.Write("]  {0}%", e.Value);
            }
            else
            {
                Console.Write("]", e.Value);
            }
        }

        public bool checkArgValidity()
        {
            if (whatToDo == "help")
                return true;
            else if (whatToDo == "process")
            {
                if (whatToDoValue == "single" || whatToDoValue == "multiple")
                {
                    if (whatToDoValue == "multiple")
                    {
                        try { Directory.GetFiles(imageAddress); }
                        catch
                        {
                            if (File.Exists(imageAddress)) // wrong call for multiple
                            {
                                whatToDoValue = "single";
                                Console.WriteLine("Forcing Single process mode because the selected target is an image");
                            }
                            else
                            {
                                Console.WriteLine("Target images path doesn't exist or is inaccessible");
                                return false;
                            }
                        }
                    }
                    else if (whatToDoValue == "sinlge")
                    {
                        if (!File.Exists(imageAddress))
                        {
                            Console.WriteLine("Target image doesn't exist or is inaccessible");
                            return false;
                        }
                    }
                    if (imageAddress.Length == 0 || dbAddress.Length == 0 || sheetName.Length == 0)
                    {
                        Console.WriteLine("Incomplete arguments. Missing: ");
                        if (imageAddress.Length == 0) Console.Write("\t-Camera Image Address.");
                        if (dbAddress.Length == 0) Console.Write("\t-OMR Sheet database Address.");
                        if (sheetName.Length == 0) Console.Write("\t-Sheet Name to be used from database.");
                        return false;
                    }
                    else return true;
                }
                else return false;
            }
            else
                return false;
        }
        public void processArgs()
        {
            if (whatToDo == "help")
                help();
            else if (whatToDo == "process")
            {
                if (whatToDoValue == "single")
                {
                    processImage();
                }
                else if (whatToDoValue == "multiple" && !enableMT)
                {
                    processImage();
                }
                else if (whatToDoValue == "multiple" && enableMT)
                {
                    Console.WriteLine("Multithreading is under development yet. Kindly use without multithreading.");
                }
                else
                    Console.WriteLine("Don't know how to process that.");
            }
            else
            {
                Console.WriteLine("Bad Command. Use \"help\" for more info.");
            }
        }
        public bool parseArg(string[] arg)
        {
            for (int i = 0; i < arg.Length; i++)
            {
                arg[i] = arg[i].Replace("\"", "");
            }
            bool processReq = false;
            if (arg.Length == 0)
            {
                arg = new string[] { "", "" };
            }
            else if (arg.Length == 1)
            {
                arg = new string[] { arg[0], "" };
            }
            else if (arg.Length > 2)
                throw new Exception("Invalid arguments. use help for more info.");
            if (arg[0].ToLower() == "help")
            {
                whatToDo = "help";
                whatToDoValue = "";
                processReq = true;
            }
            else if (arg[0].ToLower() == "exit")
            {
                whatToDo = "exit";
                whatToDoValue = "";
                processReq = true;
            }
            else if (arg[0].ToLower() == "process")
            {
                whatToDo = "process";
                if (arg[1].ToLower() == "single" || arg[1].ToLower() == "multiple")
                {
                    whatToDoValue = arg[1].ToLower();
                    processReq = true;
                }
                else
                    throw new Exception("Don't know how to process this. use \"single\" or \"multple\" after \"process\" to\nspecify the type of operation.");
            }
            else if (arg[0].ToLower() == "camimage")
            {
                if (File.Exists(arg[1].ToLower()) || Directory.Exists(arg[1]))
                {
                    imageAddress = arg[1].ToLower();
                    Console.WriteLine("Camera image(s) path set: " + arg[1]);
                }
                else
                    throw new Exception("File/directory not found: " + arg[1]);
            }

            else if (arg[0].ToLower() == "sheetdb")
            {
                if (File.Exists(arg[1].ToLower()))
                {
                    dbAddress = arg[1].ToLower();
                    Console.WriteLine("OMR Sheet path set: " + arg[1]);
                }
                else
                    throw new Exception("File not found: " + arg[1]);
            }
            else if (arg[0].ToLower() == "outputdir")
            {
                try
                {
                    if (!Directory.Exists(arg[1].ToLower()))
                        Directory.CreateDirectory(arg[1]);
                    if (Directory.Exists(arg[1].ToLower()))
                        outputDir = arg[1].ToLower();
                    Console.WriteLine("Output directory set: " + arg[1]);
                }
                catch
                {
                    throw new Exception("Invalid Directory: " + arg[1]);
                }
            }
            else if (arg[0].ToLower() == "sheetname")
            {
                sheetName = arg[1];
                Console.WriteLine("Table name set to be used from the DB: " + sheetName);
            }
            else if (arg[0].ToLower() == "answerkey")
            {
                ansKeyTitle = arg[1];
                Console.WriteLine("AnswerKey title set: " + ansKeyTitle);
            }
            else if (arg[0].ToLower() == "enablemt")
            {
                try
                {
                    if (arg[1] == "true")
                        enableMT = true;
                    else if (arg[1] == "false")
                        enableMT = false;
                    else
                        throw new Exception();
                    Console.WriteLine("Multithreading " + (enableMT ? "Enabled" : "Disabled") + " for processing multiple images.");
                }
                catch
                {
                    throw new Exception("Expecting either a True or a False");
                }
            }
            else if (arg[0].ToLower() == "maximumthreads")
            {
                try
                {
                    maxThreads = Convert.ToInt16(arg[1].ToLower());
                    if (maxThreads < 1 || maxThreads > 16)
                    {
                        maxThreads = 1;
                        throw new Exception();
                    }

                    Console.WriteLine("Maximum threads limit set: " + arg[1]);
                }
                catch
                {
                    throw new Exception("An integral value in the range of 1-16 is expected");
                }
            }
            else
            {
                throw new Exception("Invalid arguments. use help for more info.");
            }
            return processReq;
        }
        public static void help()
        {
            try
            {
                System.IO.FileStream fs = new FileStream("Console_readme.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs);

                Console.WriteLine(sr.ReadToEnd());
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
