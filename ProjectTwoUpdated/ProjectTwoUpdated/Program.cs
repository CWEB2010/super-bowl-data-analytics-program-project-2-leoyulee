using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace Project_Two
{
    class Program
    {
        static readonly string DefaultFilePath = Path.GetFullPath(@"..\..\..\") + "Super_Bowl_Project.csv";
        static readonly string DefaultOutputPath = Path.GetFullPath(@"..\..\..\");
        static void Main(string[] args)
        {
            /**Your application should allow the end user to pass end a file path for output 
            * or guide them through generating the file.
            **/
            List<Game> Games = new List<Game>();
            string OutputFilePath;
            Console.WriteLine("Welcome to the Super Bowl Sorter!");
            Console.WriteLine("How would you like to access your data file?");
            string InputFilePath = GetFilePath(Prompt(false, "Use file at " + DefaultFilePath, "Input your own file path"), DefaultFilePath);
            GetData(InputFilePath, ref Games);
            Console.WriteLine("Where would you like the output file to be?");
            OutputFilePath = GetOutputPath(Prompt(false, "Output at " + DefaultOutputPath, "Input your own path"), DefaultOutputPath);
            OutputFile(OutputFilePath, ref Games);
            AccessData(ref Games);

        }
        private static void AccessData(ref List<Game> Games)
        {
            //Console.Clear();
            Console.WriteLine("What pieces of data would you like to see?");
            int UserChoice = Prompt(true,
                "Winning Teams",
                "Top five attended super bowls",
                "The state that hosted the most super bowls",
                "List of players who won MVP more than once",
                "The coach that lost the most super bowls",
                "The coach that won the most super bowls",
                "The team(s) that won the most super bowls",
                "The team(s) that lost the most super bowls",
                "The super bowl that had the greatest point difference",
                "The average attendance of all super bowls");
            CreateTable(UserChoice, ref Games).PrintTable();
            Console.WriteLine("Would you like to see the other queries?");
            UserChoice = Prompt(false, "Yes", "No");
            if(UserChoice == 1)
            {
                AccessData(ref Games);
            }
            else
            {
                Exit();
            }
        }
        private static Table CreateTable(int UserChoice, ref List<Game> Games)
        {
            Table output = null;
            List<string[]> AssembledRows = new List<string[]>();
            if (UserChoice == 0)
            {
                foreach (Game game in Games)
                {
                    string[] row = new string[] { game.WinningTeam.Name, game.WinningTeam.Year.ToString(), game.WinningTeam.QBToString(), game.WinningTeam.Coach, game.MVP, (game.WinningTeam.Points - game.LosingTeam.Points).ToString() };
                    AssembledRows.Add(row);
                }
                AssembledRows.TrimExcess();
                output = new Table("List of all super bowl winners", new string[] { "Winning Team", "Year", "Winning Quaterback(s)", "Winning Coach", "MVP", "Point difference" }, AssembledRows);
            }
            else if (UserChoice == 1)
            {
                var AttendenceQuery = from game in Games
                                      orderby game.Attendance descending
                                      select game;
                Game[] QueryArray = AttendenceQuery.ToArray();
                for(int i = 0; i < 5; i++)
                {
                    Game focusedGame = QueryArray[i];
                    string[] row = new string[] { focusedGame.Attendance.ToString(), focusedGame.Year.ToString(), focusedGame.WinningTeam.Name, focusedGame.LosingTeam.Name, focusedGame.City, focusedGame.State, focusedGame.Stadium };
                    AssembledRows.Add(row);
                }
                AssembledRows.TrimExcess();
                output = new Table("Top five attended super bowls", new string[] { "Attendance", "Year", "Winning Team", "Losing Team", "City", "State", "Stadium"}, AssembledRows);
            }
            else if (UserChoice == 2)
            {
                var MostHostedQuery = from game in Games
                                 group game by game.State into StateGroups
                                 orderby StateGroups.Count() descending
                                 select StateGroups;
                var State = MostHostedQuery.First();
                foreach(Game game in State)
                {
                    string[] row = new string[] { game.City, game.State, game.Stadium };
                    AssembledRows.Add(row);
                }
                AssembledRows.TrimExcess();
                output = new Table("The state that hosted the most super bowls", new string[] { "Cities", "State", "Stadiums" }, AssembledRows);
            }
            else if (UserChoice == 3)
            {
                //Generate a list of players who won MVP more than once and output the following:
                /*Name of MVP
                The winning team
                The losing team*/
                var MVPQuery = from game in Games
                               group game by game.MVP into Players
                               where Players.Count() > 1
                               orderby Players.Count() descending
                               select Players;
                foreach (var player in MVPQuery)
                {
                    foreach(var game in player)
                    {
                        string[] row = new string[] { game.MVP, game.WinningTeam.Name, game.LosingTeam.Name };
                        AssembledRows.Add(row);
                    }
                }
                AssembledRows.TrimExcess();
                output = new Table("Players who have won MVP more than once", new string[] { "Name of MVP", "Winning Team", "Losing Team" }, AssembledRows);
            }
            else if (UserChoice == 4)
            {
                //Which coach lost the most super bowls?
                var CoachLostQuery = from game in Games
                                     group game by game.LosingTeam.Coach into Coaches
                                     let Lose = Coaches.Count()
                                     orderby Coaches.Count() descending
                                     select new { Coaches.Key, Lose };
                var MostLostCoach = from coach in CoachLostQuery
                                    let Most = CoachLostQuery.First().Lose
                                    where coach.Lose == Most
                                    select coach;
                foreach (var coach in MostLostCoach)
                {
                    string[] row = new string[] { coach.Key, coach.Lose.ToString() };
                    AssembledRows.Add(row);
                }
                AssembledRows.TrimExcess();
                output = new Table("Coach(es) that lost the most super bowls", new string[] { "Name of Coach", "Number of Losts" }, AssembledRows);
            }
            else if (UserChoice == 5)
            {
                //Which coach won the most super bowls?
                var CoachWinQuery = from game in Games
                                     group game by game.WinningTeam.Coach into Coaches
                                    let Wins = Coaches.Count()
                                    orderby Coaches.Count() descending
                                    select new { Coaches.Key, Wins };
                var MostWinCoach = from coach in CoachWinQuery
                                   let Most = CoachWinQuery.First().Wins
                                   where coach.Wins == Most
                                   select coach;
                foreach (var coach in MostWinCoach)
                {
                    string[] row = new string[] { coach.Key, coach.Wins.ToString() };
                    AssembledRows.Add(row);
                }
                AssembledRows.TrimExcess();
                output = new Table("Coach(es) that won the most super bowls", new string[] { "Name of Coach", "Number of Wins" }, AssembledRows);
            }
            else if (UserChoice == 6)
            {
                //Which team(s) won the most super bowls?
                var TeamWinQuery = from game in Games
                                     group game by game.WinningTeam.Name into Teams
                                     let Wins = Teams.Count()
                                     orderby Teams.Count() descending
                                     select new { Teams.Key, Wins };
                var MostWinTeams = from team in TeamWinQuery
                                   let Most = TeamWinQuery.First().Wins
                                    where team.Wins == Most
                                    select team;
                foreach (var team in MostWinTeams)
                {
                    string[] row = new string[] { team.Key, team.Wins.ToString() };
                    AssembledRows.Add(row);
                }
                AssembledRows.TrimExcess();
                output = new Table("Team that won the most super bowls", new string[] { "Name of Team", "Number of wins" }, AssembledRows);
            }
            else if (UserChoice == 7)
            {
                //Which team(s) lost the most super bowls?
                var TeamLoseQuery = from game in Games
                                   group game by game.WinningTeam.Name into Teams
                                   let Lose = Teams.Count()
                                   orderby Teams.Count() descending
                                   select new { Teams.Key, Lose };
                var MostLoseTeams = from team in TeamLoseQuery
                                    let Most = TeamLoseQuery.First().Lose
                                    where team.Lose == Most
                                    select team;
                foreach (var team in MostLoseTeams)
                {
                    string[] row = new string[] { team.Key, team.Lose.ToString() };
                    AssembledRows.Add(row);
                }
                AssembledRows.TrimExcess();
                output = new Table("Team that won the most super bowls", new string[] { "Name of Team", "Number of losts" }, AssembledRows);
            }
            else if (UserChoice == 8)
            {
                //Which Super bowl had the greatest point difference?
                var ScoreQuery = from game in Games
                                 let diff = game.WinningTeam.Points - game.LosingTeam.Points
                                 orderby diff descending
                                 select new { game.RomanOccurance, WinName = game.WinningTeam.Name, LoseName = game.LosingTeam.Name, game.Date, diff};
                var MostDiffTeams = from team in ScoreQuery
                                    let Most = ScoreQuery.First().diff
                                    where team.diff == Most
                                    select team;
                foreach (var game in MostDiffTeams)
                {
                    string[] row = new string[] { game.RomanOccurance, game.Date, game.WinName, game.LoseName, game.diff.ToString() };
                    AssembledRows.Add(row);
                }
                AssembledRows.TrimExcess();
                output = new Table("Super bowl(s) with the greatest point difference", new string[] { "nth Super Bowl", "Date", "Winning Team", "Losing Team", "Point difference" }, AssembledRows);
            }
            else if (UserChoice == 9)
            {
                //What is the average attendance of all super bowls?
                var AttendanceQuery = from game in Games
                              let TotalAttendance = +game.Attendance
                              select TotalAttendance;
                double averageAttendance = AttendanceQuery.Average();
                AssembledRows.Add(new string[] { averageAttendance.ToString() });
                AssembledRows.TrimExcess();
                output = new Table("", new string[] { "Average Attendance" }, AssembledRows);
                              
            }else if (UserChoice == 10)
            {
                Exit();
            }
            return output;
        }
        private static void OutputFile(string FilePath, ref List<Game> Games)
        {
            List<string> OutputArray = new List<string>();
            for(int i = 0; i<10; i++)
            {
                Table Query = CreateTable(i, ref Games);
                OutputArray.AddRange(Query.ReturnTableArray());
            }
            foreach(string row in OutputArray)
            {
                //Console.WriteLine(row);//debug
            }
            Console.WriteLine("Finished outputting the file");
        }
        private static void Exit()
        {
            Console.WriteLine("Thank you for using the Super Bowl Sorter!");
            Thread.Sleep(3000);
            Environment.Exit(0);
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
                if (min <= response && response <= max)
                return response;
            }
            return GetIntResponse(min, max, true);
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
