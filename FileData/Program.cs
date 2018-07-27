using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ThirdPartyTools;

namespace FileData
{
    public static class Program
    {
        static readonly List<string> listVersion = new List<string>() { "-v", "--v", "/v", "--version" };
        static readonly List<string> listSize = new List<string>() { "-s", "--s", "/s", "--size" };

        public static void Main(string[] args)
        {
            FileOperation(args);
            Console.ReadLine();
        }

        /// <summary>
        /// This function gets File version / size
        /// </summary>
        /// <param name="args"></param>
        public static void FileOperation(string[] args)
        {
            string fileVersionResult = string.Empty;
            int fileSizeResult = 0;

            try
            {
                // check arguments count
                if (args.Length == 2)
                {
                    string arg1 = args[0].Trim('\'');
                    string arg2 = args[1].Trim('\'');

                    //get file version result
                    fileVersionResult = GetFileVersion(arg1, arg2);
                    if (fileVersionResult.Length > 0)
                    {
                        Console.WriteLine("File Name: {0}", Path.GetFileName(arg2));
                        Console.WriteLine("File Version: {0}", fileVersionResult);
                    }

                    //get file size result
                    fileSizeResult = GetFileSize(arg1, arg2);
                    if (fileSizeResult > 0)
                    {
                        Console.WriteLine("File Name: {0}", Path.GetFileName(arg2));
                        Console.WriteLine("File Size: {0}", fileSizeResult);
                    }
                }
                else
                {
                    Console.WriteLine("Oops... invalid arguments");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
       
        /// <summary>
        /// this function return file version
        /// </summary>
        /// <param name="version"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetFileVersion(string version, string fileName)
        {
            string fileVersion = string.Empty;

            //check file version format exists
            bool validSizeFormat = listVersion.Any(s => s.Equals(version));
            if (validSizeFormat && fileName.Trim().Length > 0)
            {
                FileDetails fileDetails;
                try
                {
                    fileDetails = new FileDetails();
                    fileVersion = fileDetails.Version(fileName);
                    return fileVersion;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
                finally
                {
                    fileDetails = null;
                }
            }

            return fileVersion;
        }

        /// <summary>
        /// This function return file size
        /// </summary>
        /// <param name="size"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static int GetFileSize(string size, string fileName)
        {
            //check file size format exists
            bool validSizeFormat = listSize.Any(s => s.Equals(size));
            int fileSize = 0;
            FileDetails fileDetails;
            if (validSizeFormat && fileName.Trim().Length > 0)
            {
                try
                {
                    fileDetails = new FileDetails();
                    fileSize = fileDetails.Size(fileName);

                    return fileSize;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                }
                finally
                {
                    fileDetails = null;
                }
            }

            return fileSize;
        }
    }
}
