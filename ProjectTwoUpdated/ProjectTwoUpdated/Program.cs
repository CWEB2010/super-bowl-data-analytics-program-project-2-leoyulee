using System;
using Microsoft.VisualBasic.FileIO;

namespace Project_Two
{
    class Program
    {
        static void Main(string[] args)
        {
            /**Your application should allow the end user to pass end a file path for output 
            * or guide them through generating the file.
            **/
            Console.WriteLine("Welcome to the Superbowl [PC]superProgram!");
            GetDataFile();
        }
        public void GetDataFile()
        {
            using (var parser = new TextFieldParser(@"c:\temp\test.csv"))
            {
                if (parser.EndOfData)
                {
                    yield break;
                }
                string[] headerFields = parser.ReadFields();
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    int fieldCount = Math.Min(headerFields.Length, fields.Length);
                    IDictionary<string, string> fieldDictionary = new Dictionary<string, string>(fieldCount);
                    for (var i = 0; i < fieldCount; i++)
                    {
                        string headerField = headerFields[i];
                        string field = fields[i];
                        fieldDictionary[headerField] = field;
                    }
                    yield return fieldDictionary;
                    //Processing row
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        //TODO: Process field
                    }
                }
            }
            ileStream
        }
    }
}
