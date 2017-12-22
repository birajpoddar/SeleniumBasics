using Ghpr.Core;
using Ghpr.Core.Enums;
using Ghpr.NUnit.Extensions;
using Ghpr.NUnit.Utils;
using NUnit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ReportGenerator
{
    class Program
    {
        public static string ProjectPath { get; }
        public static string BinPath { get; }
        public static string ReportPath { get; }

        static Program()
        {
            ProjectPath = @"..\..\..";
            BinPath = @"..\..\Reports\bin";
            ReportPath = @"..\..\Reports\TestResult.xml";
        }

        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("\t╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("\t║  ---------------------- HELLO WORLD !!! -----------------  ║");
            Console.WriteLine("\t║  Select the report to be generated from the options below  ║");
            Console.WriteLine("\t║      1.  ReportUnit                                        ║");
            Console.WriteLine("\t║      2.  Ghpr                                              ║");
            Console.WriteLine("\t║      3.  OrangeUnit                                        ║");
            Console.WriteLine("\t║      4.  ExtentReport                                      ║");
            Console.WriteLine("\t╠════════════════════════════════════════════════════════════╣");
            Console.WriteLine("\t╠════════════════════════════════════════════════════════════╣");
            Console.WriteLine("\t║                                                            ║");
            Console.WriteLine("\t║ Select the report :                                        ║");
            Console.WriteLine("\t╠════════════════════════════════════════════════════════════╣");
            string reportType = Console.ReadKey(true).ToString();


            string str = string.Format("{0}\\{1}", ProjectPath, "packages");
            string[] strDir = Directory.GetDirectories(str);
            foreach (string dirNam in strDir)
                Console.WriteLine(dirNam);

            Console.WriteLine("\nDirectories available : {0}", strDir.Length);

            Console.ReadKey();

            //CopyPackages();
            //CopyBin();
            CreateReportFromFile();

            Console.ReadKey();
        }

        public static void CopyPackages()
        {
            string dirPath = string.Format("{0}\\{1}", ProjectPath, "packages");

            List<string> dirList = Directory.GetDirectories(dirPath).ToList();

            Console.WriteLine("Directories available\n---------------------\n");
            foreach (string dir in dirList)
            {
                string toolsPath = string.Format("{0}\\{1}", dir, "tools");                
               
                if (!Directory.Exists(toolsPath))
                    continue;

                #region DLL Files Copy from NuGet Packages
                List<string> fileList = Directory.GetFiles(toolsPath, "*.dll").ToList();

                Console.WriteLine("\nFiles available in {0}\n--------------------------------------------------------------------------------------------------------",toolsPath);
                foreach (string file in fileList)
                {
                    string destFileName = string.Format("{0}\\{1}",BinPath, file.Remove(0, toolsPath.Length + 1));
                    Console.WriteLine(file);

                    File.Copy(file, destFileName, true);
                }
                Console.WriteLine();
                #endregion

                #region EXE Files Copy from NuGet Packages
                fileList = Directory.GetFiles(toolsPath, "*.exe").ToList();

                Console.WriteLine("\nFiles available in {0}\n--------------------------------------------------------------------------------------------------------", toolsPath);
                foreach (string file in fileList)
                {
                    string destFileName = string.Format("{0}\\{1}", BinPath, file.Remove(0, toolsPath.Length + 1));
                    Console.WriteLine(file);

                    File.Copy(file, destFileName, true);
                }
                Console.WriteLine();
                #endregion
            }

            Console.ReadKey();
        }

        public static void CopyBin()
        {
            string dirPath = string.Format("{0}\\{1}\\{2}", ProjectPath, "SeleniumBasics", "bin");

            List<string> dirList = Directory.GetDirectories(dirPath).ToList();

            Console.WriteLine("Directories available\n---------------------\n");
            foreach (string dir in dirList)
            {
                #region DLL Files Copy from NuGet Packages
                List<string> fileList = Directory.GetFiles(dir, "*.dll").ToList();

                Console.WriteLine("\nFiles available in {0}\n--------------------------------------------------------------------------------------------------------", dir);
                foreach (string file in fileList)
                {
                    string destFileName = string.Format("{0}\\{1}", BinPath, file.Remove(0, dir.Length + 1));
                    Console.WriteLine(file);

                    File.Copy(file, destFileName, true);
                }
                Console.WriteLine();
                #endregion

                #region EXE Files Copy from NuGet Packages
                fileList = Directory.GetFiles(dir, "*.exe").ToList();

                Console.WriteLine("\nFiles available in {0}\n--------------------------------------------------------------------------------------------------------", dir);
                foreach (string file in fileList)
                {
                    string destFileName = string.Format("{0}\\{1}", BinPath, file.Remove(0, dir.Length + 1));
                    Console.WriteLine(file);

                    File.Copy(file, destFileName, true);
                }
                Console.WriteLine();
                #endregion
            }

            Console.ReadKey();
        }

        public static void CreateReportFromFile()
        {
            try
            {
                //var reporter = new Reporter();
                //reporter.Settings.

                // Ghp Reporter Initialization
                var reporter = new Reporter(TestingFramework.NUnit);

                // XmlDocument to store the NUnit Report
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(ReportPath);

                // Creating Nodes from XmlDocument for the test cases
                var testCases = xmlDoc.SelectNodes("//test-case")?.Cast<XmlNode>();

                // No test cases --> Return control
                if (testCases == null)
                    return;

                // Converts Test Case Nodes to ITest List
                var testRuns = testCases.Select(TestRunHelper.GetTestRun).ToList();

                string run = reporter.Settings.RunName;

                // Generate the report based on 'Ghpr.NUnit.Settings.json'            
                reporter.GenerateFullReport(testRuns);
            }
            catch (Exception ex)
            {
                // Get the Output Dir Path from 'Ghpr.NUnit.Settings.json'
                var log = new Ghpr.Core.Utils.Log(GhprEventListener.OutputPath);

                // Write Exception Log if Exception encountered in the Output Directory
                log.Exception(ex, "Exception in CreateReportFromFile");
            }
        }
    }
}
