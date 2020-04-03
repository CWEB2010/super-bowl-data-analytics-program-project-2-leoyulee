using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_Two
{
    class Game
    {
        public readonly string Date;
        public readonly int Year;
        public readonly string RomanOccurance;
        public readonly int IntOccurance;
        public readonly int Attendance;
        public readonly Team WinningTeam;
        public readonly Team LosingTeam;
        public readonly string MVP;
        public readonly string Stadium;
        public readonly string City;
        public readonly string State;

        public Game(string[] RawData)
        {
            DataToObject(RawData);
        }
        public Game(string Date, string RomanOccurance, string Attendance, string QBWin, string CoachWin, string Winner, string WinnerPts, string QBLose, string CoachLose, string Loser, string LoserPts, string MVP, string Stadium, string City, string State)
        {
            this.Date = Date;
            this.Year = DateToYear(Date);
            this.RomanOccurance = RomanOccurance;
            this.IntOccurance = RomanToInt(RomanOccurance);
            this.Attendance = StringToInt(Attendance);
            this.WinningTeam = new Team(Winner, this.Year, true, QBWin, CoachWin, StringToInt(WinnerPts));
            this.LosingTeam = new Team(Loser, this.Year, false, QBLose, CoachLose, StringToInt(LoserPts));
            this.MVP = MVP;
            this.Stadium = Stadium;
            this.City = City;
            this.State = State;
        }
        public Game(string Date, string RomanOccurance, string Attendance, string[] QBWin, string CoachWin, string Winner, string WinnerPts, string QBLose, string CoachLose, string Loser, string LoserPts, string MVP, string Stadium, string City, string State)
        {
            this.Date = Date;
            this.Year = DateToYear(Date);
            this.RomanOccurance = RomanOccurance;
            this.IntOccurance = RomanToInt(RomanOccurance);
            this.Attendance = StringToInt(Attendance);
            this.WinningTeam = new Team(Winner, this.Year, true, new List<string>(QBWin), CoachWin, StringToInt(WinnerPts));
            this.LosingTeam = new Team(Loser, this.Year, false, QBLose, CoachLose, StringToInt(LoserPts));
            this.MVP = MVP;
            this.Stadium = Stadium;
            this.City = City;
            this.State = State;
        }
        public Game(string Date, string RomanOccurance, string Attendance, string[] QBWin, string CoachWin, string Winner, string WinnerPts, string[] QBLose, string CoachLose, string Loser, string LoserPts, string MVP, string Stadium, string City, string State)
        {
            this.Date = Date;
            this.Year = DateToYear(Date);
            this.RomanOccurance = RomanOccurance;
            this.IntOccurance = RomanToInt(RomanOccurance);
            this.Attendance = StringToInt(Attendance);
            this.WinningTeam = new Team(Winner, this.Year, true, new List<string>(QBWin), CoachWin, StringToInt(WinnerPts));
            this.LosingTeam = new Team(Loser, this.Year, false, new List<string>(QBLose), CoachLose, StringToInt(LoserPts));
            this.MVP = MVP;
            this.Stadium = Stadium;
            this.City = City;
            this.State = State;
        }
        public Game(string Date, string RomanOccurance, string Attendance, string QBWin, string CoachWin, string Winner, string WinnerPts, string[] QBLose, string CoachLose, string Loser, string LoserPts, string MVP, string Stadium, string City, string State)
        {
            this.Date = Date;
            this.Year = DateToYear(Date);
            this.RomanOccurance = RomanOccurance;
            this.IntOccurance = RomanToInt(RomanOccurance);
            this.Attendance = StringToInt(Attendance);
            this.WinningTeam = new Team(Winner, this.Year, true, QBWin, CoachWin, StringToInt(WinnerPts));
            this.LosingTeam = new Team(Loser, this.Year, false, new List<string>(QBLose), CoachLose, StringToInt(LoserPts));
            this.MVP = MVP;
            this.Stadium = Stadium;
            this.City = City;
            this.State = State;
        }
        public Game(string Date, int Year, string RomanOccurance, string Attendance, string QBWin, string CoachWin, string Winner, string WinnerPts, string[] QBLose, string CoachLose, string Loser, string LoserPts, string MVP, string Stadium, string City, string State)
        {
            this.Date = Date;
            this.Year = Year;
            this.RomanOccurance = RomanOccurance;
            this.IntOccurance = RomanToInt(RomanOccurance);
            this.Attendance = StringToInt(Attendance);
            this.WinningTeam = new Team(Winner, this.Year, true, QBWin, CoachWin, StringToInt(WinnerPts));
            this.LosingTeam = new Team(Loser, this.Year, false, new List<string>(QBLose), CoachLose, StringToInt(LoserPts));
            this.MVP = MVP;
            this.Stadium = Stadium;
            this.City = City;
            this.State = State;
        }
        public Game(string Date, string RomanOccurance, int Attendance, string QBWin, string CoachWin, string Winner, int WinnerPts, string QBLose, string CoachLose, string Loser, int LoserPts, string MVP, string Stadium, string City, string State)
        {
            this.Date = Date;
            this.Year = DateToYear(Date);
            this.RomanOccurance = RomanOccurance;
            this.IntOccurance = RomanToInt(RomanOccurance);
            this.Attendance = Attendance;
            this.WinningTeam = new Team(Winner, this.Year, true, QBWin, CoachWin, WinnerPts);
            this.LosingTeam = new Team(Loser, this.Year, false, QBLose, CoachLose, LoserPts);
            this.MVP = MVP;
            this.Stadium = Stadium;
            this.City = City;
            this.State = State;
        }

        public Game(string Date,string RomanOccurance,int Attendance,Team WinningTeam,Team LosingTeam,string MVP,string Stadium,string City,string State)
        {
            this.Date = Date;
            this.Year = DateToYear(Date);
            this.RomanOccurance = RomanOccurance;
            this.IntOccurance = RomanToInt(RomanOccurance);
            this.Attendance = Attendance;
            this.WinningTeam = WinningTeam;
            this.LosingTeam = LosingTeam;
            this.MVP = MVP;
            this.Stadium = Stadium;
            this.City = City;
            this.State = State;
        }

        public static Game DataToObject(string[] RawData)
        {
            string Date = RawData[0];
            int Year = DateToYear(Date);
            string RomanOccurance = RawData[1];
            string Attendance = RawData[2];

            var QBWin = RawData[3]; //can be either string array or string
            string CoachWin = RawData[4];
            string Winner = RawData[5];
            string WinnerPts = RawData[6];
            Team WinningTeam = new Team(Winner, Year, true, QBWin, CoachWin, StringToInt(WinnerPts));

            var QBLose = RawData[7]; //can be either string array or string
            string CoachLose = RawData[8];
            string Loser = RawData[9];
            string LoserPts = RawData[10];
            Team LosingTeam = new Team(Loser, Year, false, QBLose, CoachLose, StringToInt(LoserPts));

            string MVP = RawData[11];
            string Stadium = RawData[12];
            string City = RawData[13];
            string State = RawData[14];

            return new Game(Date, RomanOccurance, StringToInt(Attendance), WinningTeam, LosingTeam, MVP, Stadium, City, State);
        }

        public static Game StringToObject(string input)
        {
            string[] RawData = DecodeString(input);
            string Date = RawData[0];
            int Year = DateToYear(Date);
            string RomanOccurance = RawData[1];
            string Attendance = RawData[2];

            var QBWin = RawData[3]; //can be either string array or string
            string CoachWin = RawData[4];
            string Winner = RawData[5];
            string WinnerPts = RawData[6];
            Team WinningTeam = new Team(Winner, Year, true, QBWin, CoachWin, StringToInt(WinnerPts));

            var QBLose = RawData[7]; //can be either string array or string
            string CoachLose = RawData[8];
            string Loser = RawData[9];
            string LoserPts = RawData[10];
            string MVP = RawData[11];
            string Stadium = RawData[12];
            string City = RawData[13];
            string State = RawData[14];

            return new Game(Date, RomanOccurance, Attendance, QBWin, CoachWin, Winner, WinnerPts, QBLose, CoachLose, Loser, LoserPts, MVP, Stadium, City, State);
        }

        //String to Int methods and checker
        public static int StringToInt(string input)
        {
            Int32.TryParse(input, out int output);
            if (output == 0 && input != "0")
                throw new InvalidInputException("String inputted to StringToInt does not output expected result.", input);
            return output;
        }

        //String to RawData array
        public static string[] DecodeString(string input)
        {
            string[] QuoteSplit = input.Split('"');
            string[] RawData = new string[0];
            foreach (string s in QuoteSplit)
            {
                string[] Array;
                if (s.Count(t => t.Equals(",")) > 1)
                    Array = s.Split(',');
                else
                    Array = new string[] { s };
                string[] EndArray = new string[RawData.Length + Array.Length];
                RawData.CopyTo(EndArray, 0);
                Array.CopyTo(EndArray, EndArray.Length);
                RawData = EndArray;
            }
            return RawData;
        }


        //Roman To Integer Methods
        public static int RomanToInt(string RomanNumeral)
        {
            RomanToIntList(RomanNumeral, out List<int> RomanIntList, out int LargestNumber);
            return RomanIntListToInt(RomanIntList, LargestNumber);
        }
        private static void RomanToIntList(string RomanNumeral, out List<int> Output, out int LargestNumber)
        {
            Output = new List<int>();
            LargestNumber = 0;
            foreach (char r in RomanNumeral)
            {
                if (r == 'L')
                {
                    Output.Add(50);
                    if (LargestNumber < 50)
                        LargestNumber = 50;
                }else
                if (r == 'X')
                {
                    Output.Add(10);
                    if (LargestNumber < 10)
                        LargestNumber = 10;
                }
                else
                if (r == 'V')
                {
                    Output.Add(5);
                    if (LargestNumber < 5)
                        LargestNumber = 5;
                }
                else
                if (r == 'I')
                {
                    Output.Add(1);
                    if (LargestNumber < 1)
                        LargestNumber = 1;
                }
                else
                {
                    throw new InvalidInputException("Unidentified Roman Numeral inputted into RomanToIntList method.", r.ToString());
                }
            }
            Output.TrimExcess();
        }
        private static int RomanIntListToInt(List<int> RomanIntList, int LargestNumber)
        {
            bool ReachLargest = false;
            int Output = 0;
            foreach(int i in RomanIntList)
            {
                if(i == LargestNumber && !ReachLargest)
                {
                    ReachLargest = true;
                }
                if (!ReachLargest)
                {
                    Output -= i;
                }
                else
                {
                    Output += i;
                }
            }
            return Output;
        }


        //Method to convert string Date to int Year.
        public static int DateToYear(string Date, Object Century = null)
        {
            string YearFooter = GetYearFooter(Date);
            string YearHeader;
            if (Century is null)
            {
                Int32.TryParse(YearFooter, out int IntFooter);
                if (IntFooter > 66)
                {
                    YearHeader = "19";
                }
                else
                {
                    YearHeader = "20";
                }
            }
            else
            {
                YearHeader = GetYearHeader(Century);
            }
            Int32.TryParse(YearHeader + YearFooter, out int Year);
            if(Year == 0)
            {
                throw new InvalidOutputException("Unexpected output in DateToYear.", YearHeader + YearFooter);
            }
            return Year;
        }
        private static string GetYearHeader(Object Input)
        {
            int obj;
            if (Input is string)
            {
                Int32.TryParse((string)Input, out obj);
            }
            else if (Input is int)
            {
                obj = (int)Input;
            }
            else
            {
                throw new InvalidOutputException("Invalid Century input.", (string)Input.ToString());
            }
            if (obj >= 100)
            {
                obj /= 100;
            }
            return obj.ToString();
        }
        private static string GetYearFooter(string Date)
        {
            string[] SplitDate = Date.Split('-');
            return SplitDate[2];
        }
    }
}
