namespace Homework1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите день недели:");

            var InputNumber = 0;
            var Input = Console.ReadLine();

            bool userInput = int.TryParse(Input, out InputNumber);//check if input is number
            
            if (userInput)
            {
                Console.WriteLine($"Введенное значение - число и равно {InputNumber}.Преобразуем в название...");
                switch (Input)
                {
                    case "1":
                        Console.WriteLine("День недели -  Понедельник");
                        break;
                    case "2":
                        Console.WriteLine("День недели -  Вторник");
                        break;
                    case "3":
                        Console.WriteLine("День недели -  Среда");
                        break;
                    case "4":
                        Console.WriteLine("День недели -  Четверг");
                        break;
                    case "5":
                        Console.WriteLine("День недели -  Пятница");
                        break;
                    case "6":
                        Console.WriteLine("День недели -  Суббота");
                        break;
                    case "7":
                        Console.WriteLine("День недели -  Воскресенье");
                        break;
                    default:
                        Console.WriteLine("Неверное число. В неделе только семь дней :*(");
                        break;
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