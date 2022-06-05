namespace Calculator;
public class Program
{
    static void Main(string[] args)
    {
        void MainMenuText() //ничего не выводит, текстовое главное меню
        {
            Console.WriteLine("Wellcome to console calculator. Avalible operations are: "); 
            Console.WriteLine("Operation: addition (a+b) - 1");
            Console.WriteLine("Operation: subtraction (a-b) - 2");
            Console.WriteLine("Operation: multiplication (a*b) - 3");
            Console.WriteLine("Operation: division (a/b) - 4");
            Console.WriteLine("Operation: exponentiation (a^b) - 5");
            Console.WriteLine("Operation: factorial (a!) - 6");
            Console.WriteLine("Exit form program - 7");
            Console.WriteLine("Please, choose your operation to proсeed:");
        }
        var Input = "";
        var InputNumber = 0;
        var FirstNumber = 0.0;
        var SecondNumber = 0.0;
        var ResoultNumber = 0.0;
        var userInputCheck = false;
        var userInputOperCheck = false;
        var userInputOperCheck2 = false;
        MainMenuText();//выводит главное меню в консоли
        void CleaningVars() //чистим значения для сброса проверок после вычислений
        {
            Input = ""; 
            userInputCheck = false;
            userInputOperCheck = false;
            userInputOperCheck2 = false;
        }

        for (int MenuExitLoopSwitch = 0; MenuExitLoopSwitch < 1; )//бесконечный цикл разрываемый 7 строкой (посмотреть for бесокнечный цикл разрываемый 7 строкой)
        {
            Input = Console.ReadLine();
            userInputCheck = int.TryParse(Input, out InputNumber);
            switch (Input)
            {
                case "1":
                    {
                        Console.Clear();
                        Console.WriteLine("Operation: addition (a+b)");
                        Console.WriteLine("Enter the first number:");

                        while (userInputOperCheck == false) //while - if - else  проверка ввода на дабл первое число
                        {
                            Input = Console.ReadLine();
                            userInputOperCheck = double.TryParse(Input, out FirstNumber);

                            if (userInputOperCheck == false)

                                Console.WriteLine("Please enter valid number 1");

                            else
                            {
                                Console.WriteLine($"Number is valid and has value of: {FirstNumber}");//для дебагинга
                                Console.WriteLine("Enter the second number:");

                                Input = Console.ReadLine();
                                while (userInputOperCheck2 == false) //while - if - else  проверка ввода на дабл второе число
                                {
                                    userInputOperCheck2 = double.TryParse(Input, out SecondNumber);

                                    if (userInputOperCheck2 == false)

                                        Console.WriteLine("Please enter valid number 2");

                                    else // решение задачи и вывод
                                    {
                                        ResoultNumber = FirstNumber + SecondNumber;
                                        Console.WriteLine($"Number is valid and has value of: {SecondNumber}");//для дебагинга
                                        Console.WriteLine($"Calculating: {FirstNumber}+{SecondNumber} = {ResoultNumber}");
                                        Console.WriteLine("Press Enter to continue...");
                                        Console.ReadLine();
                                        Console.Clear();
                                        MainMenuText();
                                    }
                                }

                            }
                        }
                        CleaningVars();
                        break;
                    }
                case "2":
                    {
                        Console.Clear();
                        Console.WriteLine("Operation: subtraction (a-b)");
                        Console.WriteLine("Enter the first number:");

                        while (userInputOperCheck == false) //while - if - else проверка ввода на дабл первое число
                        {
                            Input = Console.ReadLine();
                            userInputOperCheck = double.TryParse(Input, out FirstNumber);

                            if (userInputOperCheck == false)

                                Console.WriteLine("Please enter valid number 1");

                            else
                            {
                                Console.WriteLine($"Number is valid and has value of: {FirstNumber}");
                                Console.WriteLine("Enter the second number:");
                                Input = Console.ReadLine();
                                while (userInputOperCheck2 == false) //while - if - else  проверка ввода на дабл второе число
                                {
                                    userInputOperCheck2 = double.TryParse(Input, out SecondNumber);

                                    if (userInputOperCheck2 == false)

                                        Console.WriteLine("Please enter valid number 2");

                                    else // решение задачи и вывод
                                    {
                                        ResoultNumber = FirstNumber - SecondNumber;
                                        Console.WriteLine($"Number is valid and has value of: {SecondNumber}");//для дебагинга
                                        Console.WriteLine($"Calculating: {FirstNumber}-{SecondNumber} = {ResoultNumber}");
                                        Console.WriteLine("Press Enter to continue...");
                                        Console.ReadLine();
                                        Console.Clear();
                                        MainMenuText();
                                    }
                                }

                            }
                        }
                        CleaningVars();
                        break;
                    }
                case "3":
                    {
                        Console.Clear();
                        Console.WriteLine("Operation: subtraction (a*b)");
                        Console.WriteLine("Enter the first number:");

                        while (userInputOperCheck == false) //while - if - else проверка ввода на дабл первое число
                        {
                            Input = Console.ReadLine();
                            userInputOperCheck = double.TryParse(Input, out FirstNumber);

                            if (userInputOperCheck == false)

                                Console.WriteLine("Please enter valid number 1");

                            else
                            {
                                Console.WriteLine($"Number is valid and has value of: {FirstNumber}");
                                Console.WriteLine("Enter the second number:");
                                Input = Console.ReadLine();
                                while (userInputOperCheck2 == false) //while - if - else  проверка ввода на дабл второе число
                                {
                                    userInputOperCheck2 = double.TryParse(Input, out SecondNumber);

                                    if (userInputOperCheck2 == false)

                                        Console.WriteLine("Please enter valid number 2");

                                    else // решение задачи и вывод
                                    {
                                        ResoultNumber = FirstNumber * SecondNumber;
                                        Console.WriteLine($"Number is valid and has value of: {SecondNumber}");//для дебагинга
                                        Console.WriteLine($"Calculating: {FirstNumber}*{SecondNumber} = {ResoultNumber}");
                                        Console.WriteLine("Press Enter to continue...");
                                        Console.ReadLine();
                                        Console.Clear();
                                        MainMenuText();
                                    }
                                }

                            }
                        }
                        CleaningVars();
                        break;
                    }
                case "4":
                    {
                        Console.Clear();
                        Console.WriteLine("Operation: subtraction (a/b)");
                        Console.WriteLine("Enter the first number:");

                        while (userInputOperCheck == false) //while - if - else проверка ввода на дабл первое число
                        {
                            Input = Console.ReadLine();
                            userInputOperCheck = double.TryParse(Input, out FirstNumber);

                            if (userInputOperCheck == false)

                                Console.WriteLine("Please enter valid number 1");

                            else
                            {
                                Console.WriteLine($"Number is valid and has value of: {FirstNumber}");
                                Console.WriteLine("Enter the second number:");
                                Input = Console.ReadLine();
                                while (userInputOperCheck2 == false) //while - if - else  проверка ввода на дабл второе число
                                {
                                    userInputOperCheck2 = double.TryParse(Input, out SecondNumber);

                                    if (userInputOperCheck2 == false)

                                        Console.WriteLine("Please enter valid number 2");

                                    else // решение задачи и вывод
                                    {
                                        ResoultNumber = FirstNumber / SecondNumber;
                                        Console.WriteLine($"Number is valid and has value of: {SecondNumber}");//для дебагинга
                                        Console.WriteLine($"Calculating: {FirstNumber}/{SecondNumber} = {ResoultNumber}");
                                        Console.WriteLine("Press Enter to continue...");
                                        Console.ReadLine();
                                        Console.Clear();
                                        MainMenuText();
                                    }
                                }

                            }
                        }
                        CleaningVars();
                        break;
                    }
                case "5":
                    {
                        Console.Clear();
                        Console.WriteLine("Operation: subtraction (a^b)");
                        Console.WriteLine("Enter the first number:");

                        while (userInputOperCheck == false) //while - if - else проверка ввода на дабл первое число
                        {
                            Input = Console.ReadLine();
                            userInputOperCheck = double.TryParse(Input, out FirstNumber);

                            if (userInputOperCheck == false)

                                Console.WriteLine("Please enter valid number 1");

                            else
                            {
                                Console.WriteLine($"Number is valid and has value of: {FirstNumber}");
                                Console.WriteLine("Enter the second number:");
                                Input = Console.ReadLine();
                                while (userInputOperCheck2 == false) //while - if - else  проверка ввода на дабл второе число
                                {
                                    userInputOperCheck2 = double.TryParse(Input, out SecondNumber);

                                    if (userInputOperCheck2 == false)

                                        Console.WriteLine("Please enter valid number 2");

                                    else // решение задачи и вывод
                                    {
                                        ResoultNumber = Math.Pow(FirstNumber, SecondNumber);
                                        Console.WriteLine($"Number is valid and has value of: {SecondNumber}");//для дебагинга
                                        Console.WriteLine($"Calculating: {FirstNumber}^{SecondNumber} = {ResoultNumber}");
                                        Console.WriteLine("Press Enter to continue...");
                                        Console.ReadLine();
                                        Console.Clear();
                                        MainMenuText();
                                    }
                                }

                            }
                        }
                        CleaningVars();
                        break;
                    }

                case "6":
                    {
                        Console.Clear();
                        Console.WriteLine("Operation: subtraction (a!)");
                        Console.WriteLine("Enter the number:");

                        while (userInputOperCheck == false) //while - if - else проверка ввода на дабл число
                        {
                            Input = Console.ReadLine();
                            userInputOperCheck = double.TryParse(Input, out FirstNumber);

                            if (userInputOperCheck == false)

                                Console.WriteLine("Please enter valid number 1");

                            else
                            {
                                Console.WriteLine($"Number is valid and has value of: {FirstNumber}");
                                ResoultNumber = FirstNumber;
                                for (var i = 1.0; i < FirstNumber; i++) //цикл для расчета факториала
                                {
                                    ResoultNumber *= i;
                                }
                                Console.WriteLine($"Calculating: {FirstNumber}! = {ResoultNumber}");
                                Console.WriteLine("Press Enter to continue...");
                                Console.ReadLine();
                                Console.Clear();
                                MainMenuText();
                            }
                        }
                        CleaningVars();
                        break;
                    }

                case "7":
                    MenuExitLoopSwitch = 1;
                    break;

            }

        }
    }
}
