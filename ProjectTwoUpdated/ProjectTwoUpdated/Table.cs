using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Two
{
    class Table
    {
        private static readonly int TabLength = 8;
        private static readonly int minCharBeforeTab = 4;
        private readonly String[] Header;
        private int[] minColumnLength; //minColumnLength = new int[Header.Length]
        private List<Game> Rows;
        public Table()
        {
            this.Rows = new List<Game>();
        }
        public Table(String[] Headers, Game[] FilledRows)
        {
            this.Header = Headers;
            minColumnLength = new int[Header.Length];
            this.Rows = new List<Game>();
            foreach (Game row in FilledRows)
            {
                this.AddRow(row);
            }
        }
        public string[] ReturnTableArray(List<Game> TakenPlayers = null)
        {
            string[] output = new string[Rows.Count + 3];
            int tabs = 0;
            foreach (int column in minColumnLength)
            {
                tabs += column;
            }
            output[0] = ReturnSeparator(TabLength * tabs);
            for (int i = 1; i < Rows.Count+2; i++)
            {
                if (i == 1)
                {
                    output[i] = ReturnHeader();
                }
                else
                {
                    output[i] = ReturnRow(Rows[i], TakenPlayers);
                }
            }
            output[Rows.Count+1] = ReturnSeparator(TabLength * tabs);
            return output;
        }
        public void PrintTable(List<Game> TakenPlayers = null)
        {
            Console.Clear();
            int tabs = 0;
            foreach (int column in minColumnLength)
            {
                tabs += column;
            }
            for (int i = -1; i < Rows.Count; i++)
            {
                PrintSeparator(TabLength * tabs);
                if (i == -1)
                {
                    PrintHeader();
                }
                else
                {
                    PrintRow(Rows[i], TakenPlayers);
                }
            }
        }
        public void AddRow(Game FilledRow)
        {
            this.Rows.Add(FilledRow);
            this.Rows.TrimExcess();
            this.checkRowStrings(FilledRow);
        }
        /*public Game GetPlayerByName(string inputName)
        {
            foreach(Game row in this.Rows)
            {
                List<Game> PlayerList = row.GetPlayerList();
                if(PlayerList.Exists(p => p.Name == inputName))
                {
                    return PlayerList.Find(p => p.Name == inputName);
                }
            }
            return null;
        }*/
        private void checkRowStrings(Game Game)
        {
            string[] input = Game.ReturnOriginalData();
            for(int i = 0; i<input.Length; i++)
            {
                this.CalculateMinColumnLength(input[i], i);
            }
        }
        private void CalculateMinColumnLength(string input, int column)
        {
            int stringLength = input.Length;
            int minLengthForInput = (stringLength+minCharBeforeTab) / 8;
            if(minColumnLength[column] < minLengthForInput + 1)
            {
                minColumnLength[column] = minLengthForInput + 1;
            }
        }
        private string ReturnSeparator(int length)
        {
            string output = "";
            for (int i = 0; i < length; i++)
            {
                output += "-";
            }
            return "\n" + output;
        }
        private void PrintSeparator(int length)
        {
            string output = "";
            for (int i = 0; i < length; i++)
            {
                output += "-";
            }
            Console.WriteLine("\n" + output);
        }
        private string ReturnHeader()
        {
            string outputString = "";
            for (int i = 0; i < Header.Length; i++)
            {
                if (i != Header.Length - 1)
                {
                    outputString += createTab(minColumnLength[i], Header[i]);
                }
                else
                {
                    outputString += Header[i];
                }
            }
            return outputString;
        }
        private void PrintHeader()
        {
            string outputString = "";
            for (int i = 0; i < Header.Length; i++)
            {
                if (i != Header.Length - 1)
                {
                    outputString += createTab(minColumnLength[i], Header[i]);
                }
                else
                {
                    outputString += Header[i];
                }
            }
            Console.WriteLine(outputString);
        }
        private string ReturnRow(Game row, List<Game> TakenPlayer = null)
        {
            string output = "";
            //ConsoleColor originalColor = Console.ForegroundColor;
            string[] GameData = row.ReturnOriginalData();
            for (int i = 0; i < GameData.Length; i++)
            {
                if (i != GameData.Length - 1)
                {
                    output += createTab(minColumnLength[i], GameData[i]);
                }
                else
                {
                    output += GameData[i];
                }
            }
            //List<Game> PlayerList = row.GetPlayerList();

            /*for (int i = 0; i < PlayerList.Count; i++)
            {
                int j = i + 1;
                if (i == 0)
                {
                    outputs[0] += createTab(minColumnLength[i], row.Label);
                    outputs[1] += createTab(minColumnLength[i]);
                    outputs[2] += createTab(minColumnLength[i]);
                }
                //foreach(Game player in TakenPlayer)
                {
                    if(GetPlayerByName(player.Name) != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                //}
                if (i != PlayerList.Count - 1)
                {
                    outputs[0] += createTab(minColumnLength[j], PlayerList[i].PrintName());
                    outputs[1] += createTab(minColumnLength[j], PlayerList[i].PrintInstitution());
                    outputs[2] += createTab(minColumnLength[j], PlayerList[i].PrintSalary());
                }
                else
                {
                    outputs[0] += PlayerList[i].PrintName();
                    outputs[1] += PlayerList[i].PrintInstitution();
                    outputs[2] += PlayerList[i].PrintSalary();
                }
            }*/
            return output;
        }
        private void PrintRow(Game row, List<Game> TakenPlayer = null)
        {
            string output = "";
            //ConsoleColor originalColor = Console.ForegroundColor;
            string[] GameData = row.ReturnOriginalData();
            for (int i = 0; i < GameData.Length; i++)
            {
                if (i != GameData.Length - 1)
                {
                    output += createTab(minColumnLength[i], GameData[i]);
                }
                else
                {
                    output += GameData[i];
                }
            }
            //List<Game> PlayerList = row.GetPlayerList();

            /*for (int i = 0; i < PlayerList.Count; i++)
            {
                int j = i + 1;
                if (i == 0)
                {
                    outputs[0] += createTab(minColumnLength[i], row.Label);
                    outputs[1] += createTab(minColumnLength[i]);
                    outputs[2] += createTab(minColumnLength[i]);
                }
                //foreach(Game player in TakenPlayer)
                {
                    if(GetPlayerByName(player.Name) != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                //}
                if (i != PlayerList.Count - 1)
                {
                    outputs[0] += createTab(minColumnLength[j], PlayerList[i].PrintName());
                    outputs[1] += createTab(minColumnLength[j], PlayerList[i].PrintInstitution());
                    outputs[2] += createTab(minColumnLength[j], PlayerList[i].PrintSalary());
                }
                else
                {
                    outputs[0] += PlayerList[i].PrintName();
                    outputs[1] += PlayerList[i].PrintInstitution();
                    outputs[2] += PlayerList[i].PrintSalary();
                }
            }*/
            Console.WriteLine(output);
        }
        private string createTab(int columnLength, string stringToBeFormatted = "")
        {
            string output = stringToBeFormatted;
            int minTab = stringToBeFormatted.Length / 8;
            for (int i = 0; i < (columnLength - minTab); i++)
            {
                output += "\t";
            }
            return output;
        }
    }
}
