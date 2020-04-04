using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Two
{
    class Team
    {
        public readonly string Name;
        public readonly int Year;
        public readonly bool Victory;
        public readonly List<string> Quarterbacks;
        public readonly string Coach;
        public readonly int Points;

        public Team(string Name, int Year, bool Victory, string Quarterback, string Coach, int Points)
        {
            this.Name = Name;
            this.Year = Year;
            this.Victory = Victory;
            List<string> qbList = new List<string>
            {
                Quarterback
            };
            this.Quarterbacks = qbList;
            this.Coach = Coach;
            this.Points = Points;
        }
        public Team(string Name, int Year, bool Victory, string[] Quarterbacks, string Coach, int Points)
        {
            this.Name = Name;
            this.Year = Year;
            this.Victory = Victory;
            List<string> qbList = new List<string>
            (
                Quarterbacks
            );
            this.Quarterbacks = qbList;
            this.Coach = Coach;
            this.Points = Points;
        }
        public Team(string Name, int Year, bool Victory, List<string> Quarterbacks, string Coach, int Points)
        {
            this.Name = Name;
            this.Year = Year;
            this.Victory = Victory;
            this.Quarterbacks = Quarterbacks;
            this.Coach = Coach;
            this.Points = Points;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
