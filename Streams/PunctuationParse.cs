using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Streams
{
    public class StreamPunctuationWork
    {
        // StreamReader to work with original file.
        public void PunctuationParse(string filePath, string outputFilePath)
        {
            string[] sentences = new string[] { };
            List<string> bufferList = new List<string>();
            List<string> arrlist = new List<string>();
            using (var sr = new StreamReader(filePath, Encoding.UTF8))
            {

                // Worked to the end of file, string by string.
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    // If readed line != null, add it to the bufferList(buffer).
                    if (line != null)
                    {
                        sentences = Regex.Split(line, @"(?<=[.!?,;:\-""''\\//])");
                        bufferList.AddRange(sentences);
                    }
                }

                //  Sorting arrList with LINQ.
                bufferList.RemoveAll(s => s == "");
                sr.Close();
            }

            // StreamWriter to work with new file.
            using (var sw = new StreamWriter(outputFilePath, false, Encoding.UTF8))
            {
                // Re/-write from bufferList to file. 
                foreach (string line in bufferList)
                {
                    sw.WriteLine(line);
                }
                sw.Close();
            }
        }



        public void PunctuationParse22(string filePath, string outputFilePath)
        {
            // StreamReader to work with original file.
            {
                string[] sentences = new string[] { };
                List<string> bufferList = new List<string>();
                List<string> arrlist = new List<string>();
                using (var sr = new StreamReader(filePath, Encoding.UTF8))
                {

                    // Worked to the end of file, string by string.
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        // If readed line != null, add it to the bufferList(buffer).
                        if (line != null)
                        {
                            sentences = Regex.Split(line, @"(?<=[.!?,;:-])");
                            bufferList.AddRange(sentences);
                        }
                    }
                    //  Sorting arrList with LINQ.
                    arrlist.RemoveAll(s => s == "");
                    arrlist = arrlist.OrderBy(o => o).ToList();
                    sr.Close();
                }

                // StreamWriter to work with new file.
                using (var sw = new StreamWriter(outputFilePath, false, Encoding.UTF8))
                {
                    // With LINQ find duplecates and combine them with counter, ignoring case.
                    var duplicates = arrlist.GroupBy(x => x, StringComparer.OrdinalIgnoreCase)
                    .Where(g => g.Count() > 1)
                    .Select(y => new { Word = y.Key, Count = y.Count() })
                    .ToList();
                    // Countered list writing in file.
                    foreach (var i in duplicates)
                    {
                        sw.WriteLine(i);
                    }
                    sw.Close();
                }
            }
        } 
    }
}
