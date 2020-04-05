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
        private readonly String Title;
        private readonly String[] Header;
        private int[] minColumnLength; //minColumnLength = new int[Header.Length]
        private List<string[]> Rows;
        public Table(String[] Headers)
        {
            this.Header = Headers;
            this.Rows = new List<string[]>();
        }
        public Table(String Title, String[] Headers, List<string[]> FilledRows)
        {
            this.Title = Title;
            this.Header = Headers;
            minColumnLength = new int[Header.Length];
            checkRowStrings(Headers);
            this.Rows = new List<string[]>();
            foreach (string[] row in FilledRows)
            {
                this.AddRow(row);
            }
        }
        public string[] ReturnHTMLArray()
        {
            List<string> output = new List<string>();
            output.Add("<h2>"+Title+"</h2>");
            output.Add("<table>"); // style=\"width:100%\"
            output.Add("\t<tr>");
            foreach(string head in Header)
            {
                output.Add("\t\t<th>" + head + "</th>");
            }
            output.Add("\t</tr>");
            foreach(string[] row in Rows)
            {
                output.Add("<tr>");
                foreach(string data in row)
                {
                    output.Add("\t\t<td>" + data + "</td>");
                }
                output.Add("\t</tr>");
            }
            output.Add("</table>");
            return output.ToArray();
        }
        public string[] ReturnTableArray()
        {
            string[] output = new string[Rows.Count + 4];
            int tabs = 0;
            foreach (int column in minColumnLength)
            {
                tabs += column;
            }
            output[0] = ReturnSeparator(TabLength * tabs);
            output[1] = Title;
            for (int i = 2; i < Rows.Count+3; i++)
            {
                if (i == 2)
                {
                    output[i] = ReturnHeader();
                }
                else
                {
                    output[i] = ReturnRow(Rows[i-3]);
                }
            }
            output[Rows.Count+3] = ReturnSeparator(TabLength * tabs);
            return output;
        }
        public void PrintTable()
        {
            Console.Clear();
            int tabs = 0;
            foreach (int column in minColumnLength)
            {
                tabs += column;
            }
            PrintSeparator(TabLength * tabs);
            Console.WriteLine(Title);
            for (int i = -1; i < Rows.Count; i++)
            {
                if (i == -1)
                {
                    PrintHeader();
                }
                else
                {
                    PrintRow(Rows[i]);
                }
            }
            PrintSeparator(TabLength * tabs);
        }
        public void AddRow(string[] FilledRow)
        {
            this.Rows.Add(FilledRow);
            this.Rows.TrimExcess();
            this.checkRowStrings(FilledRow);
        }
        private void checkRowStrings(string[] input)
        {
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
            return output;
        }
        private void PrintSeparator(int length)
        {
            string output = "";
            for (int i = 0; i < length; i++)
            {
                output += "-";
            }
            Console.WriteLine(output);
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
        private string ReturnRow(string[] row)
        {
            string output = "";
            for (int i = 0; i < row.Length; i++)
            {
                if (i != row.Length - 1)
                {
                    output += createTab(minColumnLength[i], row[i]);
                }
                else
                {
                    output += row[i];
                }
            }
            return output;
        }
        private void PrintRow(string[] row)
        {
            string output = "";
            for (int i = 0; i < row.Length; i++)
            {
                if (i != row.Length - 1)
                {
                    output += createTab(minColumnLength[i], row[i]);
                }
                else
                {
                    output += row[i];
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
