using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace Project_Two
{
    class Program
    {
        static readonly string DefaultFilePath = Path.GetFullPath(@"..\..\..\")+ "Super_Bowl_Project.csv";
        static readonly string DefaultOutputPath = Path.GetFullPath(@"..\..\..\");
        static void Main(string[] args)
        {
            /**Your application should allow the end user to pass end a file path for output 
            * or guide them through generating the file.
            **/
            List<Game> Games = new List<Game>();
            string OutputFilePath;
            Console.WriteLine("Welcome to the Superbowl [PC]superProgram!");
            Console.WriteLine("How would you like to access your data file?");
            string InputFilePath = GetFilePath(Prompt(false, "Use file at " + DefaultFilePath, "Input your own file path"), DefaultFilePath);
            GetData(InputFilePath, ref Games);
            Console.WriteLine("Where would you like the output file to be?");
            OutputFilePath = GetOutputPath(Prompt(false, "Output at " + DefaultOutputPath, "Input your own path"), DefaultOutputPath);
            OutputFile(OutputFilePath);
            Console.WriteLine("What pieces of data would you like to see?");
            int UserChoice = Prompt(false, "Winning Teams", "Top five attended super bowls", "The state that hosted the most super bowls", "List of players who won MVP more than once", "The coach that lost the most super bowls", "The coach that won the most super bowls", "The team(s) that won the most super bowls", "The super bowl that had the greatest point difference", "The average attendance of all super bowls");
        }
        private static void OutputFile(string FilePath)
        {

        }
        private static string GetOutputPath(int UserChoice, string FilePath)
        {
            if (UserChoice == 2)
            {
                Console.WriteLine("Input the output location:");
                FilePath = GetStrResponse();
            }
            Console.WriteLine("The file will be outputted at " + FilePath + "Super_Bowl_Project_Output.txt");
            Console.WriteLine("Confirm?");
            UserChoice = Prompt(false, "Yes", "No");
            if(UserChoice == 2)
            {
                GetOutputPath(UserChoice, FilePath);
            }
            return FilePath;
        }
        private static string GetFilePath(int UserChoice, string FilePath)
        {
            if (UserChoice == 2)
            {
                Console.WriteLine("Input the file location of the data file:");
                FilePath = GetStrResponse();
            }
            if (!CheckFilePath(FilePath))
            {
                Console.WriteLine("Would you like to try to read the file at {0} again?", FilePath);
                UserChoice = Prompt(false, "Yes", "No");
                GetFilePath(UserChoice, FilePath);
            }
            return FilePath;
        }
        private static bool CheckFilePath(string FilePath)
        {
            try
            {
                System.IO.File.OpenRead(FilePath);
            }
            catch
            {
                Console.WriteLine("File couldn't be read at {0}", FilePath);
                return false;
            }
            try
            {
                using var testParser = new TextFieldParser(FilePath)
                {
                    TextFieldType = FieldType.Delimited
                };
                if (testParser.EndOfData)
                {
                    Console.WriteLine("File doesn't contain data!");
                    return false;
                }
                testParser.SetDelimiters(",");
                string[] headerFields = testParser.ReadFields();
                if (headerFields.Length != 15)
                {
                    Console.WriteLine("File doesn't contain the correct amount of headers. Refer to README.");
                    return false;
                }
            }
            catch
            {
                Console.WriteLine("File cannot be read by the TextFieldParser.");
                return false;
            }
            return true;
        }
        private static void GetData(string FilePath, ref List<Game> GameList)
        {
            using var parser = new TextFieldParser(@FilePath)
            {
                TextFieldType = FieldType.Delimited
            };
            parser.SetDelimiters(",");
            string[] headerFields = parser.ReadFields();
            /*foreach(string header in headerFields)
            {
                Console.WriteLine(header);
            }*/
            while (!parser.EndOfData)
            {
                string[] GameData = parser.ReadFields();
                Game thisGame = Game.DataToObject(GameData);
                GameList.Add(thisGame);
            }
            Console.Clear();
            Console.WriteLine("Finished parsing data succesfully!");
        }
        private static int Prompt(bool subtractOne, params string[] args)
        {
            int argsLength = args.Length;
            if (argsLength == 1)
            {
                Console.WriteLine("Note to developer: You shouldn't be using this method if you're going to put only one argument in");
            }
            Console.WriteLine("Enter one button, 1 through {0}, to make your selection.", argsLength);
            for (int i = 0; i < argsLength; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, args[i]);
            }
            int response = GetIntResponse(1, argsLength);
            if (subtractOne)
            {
                response--;
            }
            return response;
        }
        private static int GetIntResponse(int min, int max, bool error = false)
        {
            PrintError(error);
            string userInput = Console.ReadLine();
            if (Int32.TryParse(userInput, out int response))
            {
                return response;
            }
            else
            {
                return GetIntResponse(min, max, true);
            }
        }
        private static string GetStrResponse(bool error = false)
        {
            PrintError(error);
            string userInput = Console.ReadLine();
            return userInput;
        }
        private static void PrintError(bool error = false, string reason = "Invalid input. Please try again.")
        {
            if (error)
            {
                Console.WriteLine(reason);
            }
        }
    }
}
