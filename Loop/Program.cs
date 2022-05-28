namespace Homework2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число для постраения таблицы умножения:");

            var InputNumber = 0;
            var Input = Console.ReadLine();

            bool userInput = int.TryParse(Input, out InputNumber);//check if input is number

            if (userInput)
            {
                Console.WriteLine($"Введенное значение - число и равно {InputNumber}.Построение таблицы...");

                for (int X = 0; X <= 10; X++)
                {
                    Console.WriteLine($"{Input} * {X} = {InputNumber * X}");
                }
            }

            else
            {
                Console.WriteLine("Введенное значение - не число");
            }

            Console.WriteLine("Конец программы");
        }
    }
}