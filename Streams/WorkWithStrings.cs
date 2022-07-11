using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Streams
{
    internal class WorkWithStrings
    {
        public void StringWork(string filePath, string outputFilePath)
        {
            string[] sentences = new string[] { };
            List<string> bufferList = new List<string>();
            List<string> arrlist = new List<string>();

            // StreamReader to work with original file.
            using (var sr = new StreamReader(filePath, Encoding.UTF8))
            {

                // Worked to the end of file, string by string.
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    // If readed line != null, add it to the sentences(buffer) after that to the bufferList - then to writing to file.
                    if (line != null)
                    {
                        sentences = Regex.Split(line, @"(?<=[.!?]+[^""'']|[.!?]+[""''])");
                        bufferList.AddRange(sentences);
                    }
                }
                //  Sorting arrList with LINQ, removing empty lines.
                bufferList.RemoveAll(s => s == "");
                sr.Close();
            }
            
            // StreamWriter to work with new file.
            using (var sw = new StreamWriter(outputFilePath, false, Encoding.UTF8))
            {
                // Find lingest string in bufferList list.
                string longest = bufferList.OrderByDescending(s => s.Length).First();
                sw.WriteLine($"Longest parsed sentence by characters in text are:");
                sw.WriteLine(longest);
                sw.WriteLine();
                // LinesCounter - list for find words in strings.
                List<int> linesCounter = new List<int>();
                // Dictionary for char counter
                Dictionary<char, int> charsCounter = new Dictionary<char, int>()
                {
                    {'a',0},
                    {'b',0},
                    {'c',0},
                    {'d',0},
                    {'e',0},
                    {'f',0},
                    {'g',0},
                    {'h',0},
                    {'i',0},
                    {'j',0},
                    {'k',0},
                    {'l',0},
                    {'m',0},
                    {'n',0},
                    {'o',0},
                    {'p',0},
                    {'q',0},
                    {'r',0},
                    {'s',0},
                    {'t',0},
                    {'u',0},
                    {'w',0},
                    {'x',0},
                    {'y',0},
                    {'z',0}
                };
                //  Cycle i for enumeration lines in bufferList list.
                for (int i = 0; i < bufferList.Count; i++)
                {
                    var wordCounter = 0;
                    
                    //  Cycle j for enumeration chars in bufferList list string.
                    for (int j = 0; j < bufferList[i].Length; j++)
                    {
                        // Convert all letters to lowercase.
                        bufferList[i].ToLower();
                        char symbolInString = bufferList[i][j];
                        // If current char is 'space', then wordCounter + 1.
                        if (symbolInString is ' ')
                        {
                            wordCounter += 1;
                        }
                        // Esle if char has pair in dictionary, then dictionary letter count +1.
                        else
                        {
                            foreach (var keyChar in charsCounter.Keys)
                            {
                                if(keyChar == symbolInString)
                                {
                                    charsCounter[keyChar] += 1;
                                }
                            }
                        }
                    }
                    // Add words Counter do counterList.
                    linesCounter.Add(wordCounter);
                }

                // Find min. int Value in linesCounter.
                int minValue = linesCounter.Min();
                // Find index of min. int Value in linesCounter.
                int minIndex = linesCounter.IndexOf(minValue);
                // Writing shortest text sentence in txt file.
                sw.WriteLine($"Srortest parsed sentence by words in text are:");
                sw.WriteLine(bufferList[minIndex]);
                sw.WriteLine();

                // Find most frequently letter in text.
                var maxValue = charsCounter.Values.Max();
                var keyOfMaxValue = charsCounter.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
                // Writing most frequently letter in txt file.
                sw.WriteLine($"Most frequently used letter in text are:\"{keyOfMaxValue}\".");
                sw.Close();
            }
        }
    }
}

