namespace Homework1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of the day of the week:");

            var InputNumber = 0;
            var Input = Console.ReadLine();

            bool userInput = int.TryParse(Input, out InputNumber);//check if input is number

            if (userInput)
            {
                Console.WriteLine($"Your input number is \"{InputNumber}\".Convert to the name of the day of the week...");
                switch (Input)
                {
                    case "1":
                        Console.WriteLine("Monday");
                        break;
                    case "2":
                        Console.WriteLine("Tuesday");
                        break;
                    case "3":
                        Console.WriteLine("Wednesday");
                        break;
                    case "4":
                        Console.WriteLine("Thursday");
                        break;
                    case "5":
                        Console.WriteLine("Friday");
                        break;
                    case "6":
                        Console.WriteLine("Saturday");
                        break;
                    case "7":
                        Console.WriteLine("Sunday");
                        break;
                    default:
                        Console.WriteLine("Incorrect number. Please retry and enter number of a day from seven-day week.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Incorrect input. Please retry and enter number of a day from seven-day week");
            }
            Console.WriteLine("End of program");
        }
    }
}