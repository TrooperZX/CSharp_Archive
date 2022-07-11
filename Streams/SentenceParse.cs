using System.Text;
using System.Text.RegularExpressions;
namespace Streams
{
    public class StreamSentenceWork
    {
        public void SentenceParse(string filePath, string outputFilePath)
        {
            // For Using without REGEX.
            //string[] separators = new string[] { "! ", ". ", "? ", "\"\n", "\"\n", "\"\n", ".\"", "!\"", "?\"", ".\'", "!\'", "?\'" };
            string[] sentences = new string[] { };
            List<string> bufferList = new List<string>();

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
                        // Not using REGEX, bad pattern sentences = line.Split(separators,StringSplitOptions.RemoveEmptyEntries);
                        bufferList.AddRange(sentences);
                    } 
                }
                //  Sorting bufferList with LINQ, removing empty lines.
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
    }
}
