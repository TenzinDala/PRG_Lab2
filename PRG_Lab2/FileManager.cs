using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Seneca
{
    public static class FileManager
    {
        //Field/Attributes

        public static List<string> ReadFile(string filePath)
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
                    List<string> columns = splitForLines(Line);
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

        private static List<string> splitForLines(string line)
        {
            List<string> columns = new List<string>();
            //string columnBuilder = "";

            StringBuilder columnBuilder = new StringBuilder();
            bool inQuotes = false;

            foreach (char character in line)
            {
                if (character == '"')
                {
                    inQuotes = !inQuotes;
                    columnBuilder.Append('"');
                }
                else if (character == ',' && !inQuotes)
                {
                    columns.Add(columnBuilder.ToString().Trim());
                    columnBuilder.Clear();
                }
                else
                {
                    columnBuilder.Append(character);
                }
            }

            columns.Add(columnBuilder.ToString().Trim());

            return columns;
        }


        public static bool WriteFile(string filePath, FileWriteModes fileWriteMode)
        {
            DateTime currentDateTime = DateTime.Now;
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();
                File.AppendAllText(filePath, currentDateTime.ToString());
                return true;
                //try
                //{
                //    using (StreamWriter sw = File.CreateText(filePath))
                //    {
                //        sw.WriteLine($"Date And Time");
                //        sw.WriteLine($"{currentDateTime}");
                //        sw.WriteLine("Welcome");
                //    }
                //    return true;
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine(e.Message);
                //    return false;
                //}

            }
            else
            {
                Console.WriteLine("File found");
                return false;
            }
           
        }
        public static bool DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            else { return false; }
        }
    }
}
