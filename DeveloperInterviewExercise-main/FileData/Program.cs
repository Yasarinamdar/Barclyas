using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using ThirdPartyTools;

namespace FileData
{
    public static class Program
    {
        private const string regexVersion = "^-v|--v|/v|--version$";
        private const string regexSize = "^-s|--s|/s|--size";


        public static void Main(string[] args)
        {
            if (args.Length > 1)
            {
                string fileArg = args[0];
                string filePath = args[1];

                ProcessTask(fileArg, filePath);
            }
            else
            {
                Console.WriteLine($"Please pass 2 arguments ");
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Task1 and Task2 completed in single logic
        /// </summary>
        /// <param name="args"></param>
        public static bool ProcessTask(string fileArg, string filePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fileArg))
                {
                    Console.WriteLine($"First argument is required");
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(filePath))
                    {
                        Console.WriteLine($"Second argument is required");
                    }
                    else
                    {
                        FileDetails fileDetails = new FileDetails();

                        if (ValidateVersion(fileArg))
                        {
                            string versionResult = fileDetails.Version(filePath);
                            Console.WriteLine($"{fileArg} {versionResult}");
                            return true;
                        }

                        if (ValidateSize(fileArg))
                        {
                            int sizeResult = fileDetails.Size(filePath);
                            Console.WriteLine($"{fileArg} {sizeResult}");
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Runtime error occured during execution of code: {ex.Message} ");
                return false;
            }

            return false;
        }

        /// <summary>
        /// Validating the first version argument
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static bool ValidateVersion(string input)
        {
            Regex regex = new Regex(regexVersion, RegexOptions.IgnoreCase);
            return regex.IsMatch(input.ToLower());
        }

        /// <summary>
        /// Validating the first size argument
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static bool ValidateSize(string input)
        {
            Regex regex = new Regex(regexSize, RegexOptions.IgnoreCase);
            return regex.IsMatch(input.ToLower());
        }
    }
}
