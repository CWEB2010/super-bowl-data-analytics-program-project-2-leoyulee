using System;
using System.Collections.Generic;
using System.Text;

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

        public Game(string Date, string RomanOccurance, int Attendance, string QBWin, string CoachWin, string Winner, int WinnerPts, string QBLose, string CoachLose, int LoserPts, string MVP, string Stadium, string City, string State)
        {
            this.Date = Date;
            this.Year = DateToYear(Date);
            this.RomanOccurance = RomanOccurance;
            this.IntOccurance = RomanToInt(RomanOccurance);
            this.Attendance = Attendance;
            this.WinningTeam = new Team();
            this.LosingTeam = new Team();
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

        public Game StringToObject(string input)
        {
            string Date;
            string RomanOccurance;
            int Attendance;
            Team WinningTeam;
            Team LosingTeam;
            string MVP;
            string Stadium;
            string City;

            return Game(Date, RomanOccurance, Attendance, WinningTeam, LosingTeam, MVP, Stadium, City);
        }

        //Roman To Integer Methods
        public int RomanToInt(string RomanNumeral)
        {
            RomanToIntList(RomanNumeral, out List<int> RomanIntList, out int LargestNumber);
            return RomanIntListToInt(RomanIntList, LargestNumber);
        }
        private void RomanToIntList(string RomanNumeral, out List<int> Output, out int LargestNumber)
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
                }else
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
        private int RomanIntListToInt(List<int> RomanIntList, int LargestNumber)
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
        public int DateToYear(string Date, Object Century = null)
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
        private string GetYearHeader(Object Input)
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
        private string GetYearFooter(string Date)
        {
            string[] SplitDate = Date.Split('-');
            return SplitDate[3];
        }
    }
}
