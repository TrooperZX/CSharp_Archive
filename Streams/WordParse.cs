using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Streams
{
    public class StreamWordWork
    {
        // StreamReader to work with original file.
        public void WordParse(string filePath, string outputFilePath)
        {
            string[] separators = new string[] {"!",".",",","?"," ","-", "\t ", "\n ", "\"", "(", ")", ";", ":","_","+", };
            string[] sentences = new string[] { };
            List<string> bufferList = new List<string>();
            using (var sr = new StreamReader(filePath, Encoding.UTF8))
            {

                // Worked to the end of file, string by string.
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    // If readed line != null, add it to the bufferList(buffer).
                    if (line != null)
                    {
                        sentences = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                        bufferList.AddRange(sentences);
                    }
                }

                //  Sorting arrList with LINQ.
                bufferList.RemoveAll(s => s == "");
                bufferList = bufferList.OrderBy(s => s).ToList();
                sr.Close();
            }

            // StreamWriter to work with new file.
            using (var sw = new StreamWriter(outputFilePath, false, Encoding.UTF8))
            {
                // With LINQ find duplecates and combine them with counter, ignoring case.
                var duplicates = bufferList.GroupBy(x => x, StringComparer.OrdinalIgnoreCase)
                .Where(g => g.Count() > 1)
                .Select(y => new { Word = y.Key , Count = y.Count() })
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
