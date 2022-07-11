using System.Text;
namespace Streams
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start working with file #1...");
            var file1 = new StreamSentenceWork();
            file1.SentenceParse(@"..\..\..\sample.txt", @"..\..\..\OutputFile№1.txt");
            Console.WriteLine("Writing sentetces in separate file #1 is complete.");
            Console.WriteLine("Press enter to continue the program.");
            Console.ReadLine();

            Console.WriteLine("Start working with file #2...");
            var file2 = new StreamWordWork();
            file2.WordParse(@"..\..\..\sample.txt", @"..\..\..\OutputFile№2.txt");
            Console.WriteLine("Writing words in separate file #2 is complete.");
            Console.WriteLine("Press enter to continue the program.");
            Console.ReadLine();

            Console.WriteLine("Start working with file #3...");
            var file3 = new StreamPunctuationWork();
            file3.PunctuationParse(@"..\..\..\sample.txt", @"..\..\..\OutputFile№3.txt");
            Console.WriteLine("Parsing text by punctuation in file #3 is complete.");
            Console.WriteLine("Press enter to continue the program.");
            Console.ReadLine();

            Console.WriteLine("Start working with file #4...");
            var file4 = new WorkWithStrings();
            file4.StringWork(@"..\..\..\sample.txt", @"..\..\..\OutputFile№4.txt");
            Console.WriteLine("Writing file with set parameters is complete.");
            Console.WriteLine("Press enter to complete the program.");
            Console.ReadLine();
        }
    }
}