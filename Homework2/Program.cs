namespace Homework2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter positive integer number:");

            var InputNumber = 0;
            var Input = Console.ReadLine();

            bool userInput = int.TryParse(Input, out InputNumber);//check if input is number

            if (userInput)
            {
                Console.WriteLine($"You input number is \"{InputNumber}\".Forming multiplication table ...");

                for (int X = 0; X <= 10; X++)
                {
                    Console.WriteLine($"{Input} * {X} = {InputNumber * X}");
                }
            }

            else
            {
                Console.WriteLine("Your input are not positive integer number ");
            }

            Console.WriteLine("End of program");
        }
    }
}