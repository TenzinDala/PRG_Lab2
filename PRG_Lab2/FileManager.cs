using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Seneca
{
    public class FileManager
    {
        //Field/Attributes

        public List<string> ReadFile(string filePath)
        {
            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                bool isFirstRow = true;
                string Line;

                while ((Line = reader.ReadLine()) != null)
                {
                    if (isFirstRow)
                    {
                        isFirstRow = false;
                        continue;
                    }
                    //string[] columns = Line.Split(',');
                    List<string> columns = SplitCSVLine(Line);
                    string formattedLine = string.Join(",", columns);
                    lines.Add(formattedLine);
                    //Console.WriteLine(columns[1]);
                    // Access the ISBN value (first column)
                }
            }
            return lines;


        }

        //public List<string> ReadFile(string filePath)
        //{
        //    List<string> lines = new List<string>();

        //    using (TextFieldParser parser = new TextFieldParser(filePath))
        //    {
        //        parser.TextFieldType = FieldType.Delimited;
        //        parser.SetDelimiters(",");
        //        parser.HasFieldsEnclosedInQuotes = true;
        //        parser.ReadLine();

        //        while (!parser.EndOfData)
        //        {
        //            string[] fields = parser.ReadFields();
        //            string line = string.Join(",", fields);
        //            lines.Add(line);
        //        }
        //    }

        //    return lines;
        //}

        private List<string> SplitCSVLine(string line)
        {
            List<string> columns = new List<string>();
            StringBuilder columnBuilder = new StringBuilder();
            bool inQuotes = false;

            foreach (char c in line)
            {
                if (c == '"')
                {
                    inQuotes = !inQuotes;
                    columnBuilder.Append('"');
                }
                else if (c == ',' && !inQuotes)
                {
                    columns.Add(columnBuilder.ToString().Trim());
                    columnBuilder.Clear();
                }
                else
                {
                    columnBuilder.Append(c);
                }
            }

            columns.Add(columnBuilder.ToString().Trim());

            // Combine the columns that belong to the same cell enclosed in quotes
            if (inQuotes)
            {
                int startIndex = columns.Count - 2;
                int endIndex = columns.Count - 1;

                if (startIndex >= 0 && endIndex >= 0)
                {
                    string combinedValue = string.Join(",", columns.GetRange(startIndex, endIndex - startIndex + 1));
                    columns.RemoveRange(startIndex, endIndex - startIndex + 1);
                    columns.Add(combinedValue);
                }
            }

            return columns;
        }


        //public bool WriteFile(string fielPath, FileWriteMode fileWriteModes)
        //{

        //}
        //public bool DeleteFile(string filePath)
        //{

        //}
    }
}
