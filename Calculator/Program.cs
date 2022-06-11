namespace Calculator;
public class Program
{
    static void Main(string[] args)
    {
        var input = "";
        var inputNumber = 0;
        var firstNumber = 0.0;
        var secondNumber = 0.0;
        var resultNumber = 0.0;
        var userinputCheck = false;
        double ValueCheck()
        {
            double doubleValue = 0.0;
            string inputString = "";
            bool inputCheckMethod = false; //сбрасываем значния, для работы повторных вызовов цикла
            do 
            {
                Console.WriteLine("Please enter valid number:");
                inputString = Console.ReadLine();
                inputCheckMethod = double.TryParse(inputString, out doubleValue);
            } 
            while (inputCheckMethod == false); //цикл do - while, заставить ввести пользователя число
            Console.WriteLine($"Number is valid and has value of: {doubleValue}");//для вывода пользователю
            return doubleValue;
        }//проверка на числовой ввод
        void MainMenuText() 
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
        }//ничего не выводит, текстовое главное меню
        void ReturnToMainMenu() 
        {
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
            Console.Clear();
            MainMenuText();
            input = "";
            userinputCheck = false;
        }// "возвращение" в главное меню с чисткой значений для последующих циклов
        MainMenuText();//выводит главное меню в консоли
        for (int menuExitLoopSwitch = 0; menuExitLoopSwitch < 1; )//бесконечный цикл разрываемый 7 строкой (посмотреть for бесокнечный цикл разрываемый 7 строкой)
        {
            input = Console.ReadLine();
            userinputCheck = int.TryParse(input, out inputNumber);

            switch (input)
            {
                case "1":
                    {
                        Console.Clear();
                        Console.WriteLine("Operation: addition (a+b)");
                        Console.WriteLine("Enter the first number...");
                        firstNumber = ValueCheck();
                        Console.WriteLine("Enter the second number...");
                        secondNumber = ValueCheck();
                        resultNumber = firstNumber + secondNumber;
                        if (resultNumber > double.MaxValue)
                        {
                            Console.WriteLine("Resulting number exceeds calculator capacity");
                        }
                        else if (resultNumber < double.MinValue)
                        {
                            Console.WriteLine("Resulting number exceeds calculator capacity");
                        }
                        else
                        {
                            Console.WriteLine($"Calculating: {firstNumber}+{secondNumber} = {resultNumber}");
                        }
                        ReturnToMainMenu();
                        break;
                    }

                case "2":
                    {
                        Console.Clear();
                        Console.WriteLine("Operation: subtraction (a-b)");
                        Console.WriteLine("Enter the first number...");
                        firstNumber = ValueCheck();
                        Console.WriteLine("Enter the second number...");
                        secondNumber = ValueCheck();
                        resultNumber = firstNumber - secondNumber;
                        if (resultNumber > double.MaxValue)
                        {
                            Console.WriteLine("Resulting number exceeds calculator capacity");
                        }
                        else if (resultNumber < double.MinValue)
                        {
                            Console.WriteLine("Resulting number exceeds calculator capacity");
                        }
                        else
                        {
                            Console.WriteLine($"Calculating: {firstNumber}-{secondNumber} = {resultNumber}");
                        }
                        ReturnToMainMenu();
                        break;
                    }

                case "3":
                    {
                        Console.Clear();
                        Console.WriteLine("Operation: subtraction (a*b)");
                        Console.WriteLine("Enter the first number...");
                        firstNumber = ValueCheck();
                        Console.WriteLine("Enter the second number...");
                        secondNumber = ValueCheck();
                        resultNumber = firstNumber * secondNumber;
                        if (resultNumber > double.MaxValue)
                        {
                            Console.WriteLine("Resulting number exceeds calculator capacity");
                        }
                        else if (resultNumber < double.MinValue)
                        {
                            Console.WriteLine("Resulting number exceeds calculator capacity");
                        }
                        else
                        {
                            Console.WriteLine($"Calculating: {firstNumber}*{secondNumber} = {resultNumber}");
                        }
                        ReturnToMainMenu();
                        break;
                    }

                case "4":
                    {
                        Console.Clear();
                        Console.WriteLine("Operation: subtraction (a/b)");
                        Console.WriteLine("Enter the first number...");
                        firstNumber = ValueCheck();
                        Console.WriteLine("Enter the second number...");
                        secondNumber = ValueCheck();
                        resultNumber = firstNumber / secondNumber;
                        if (resultNumber > double.MaxValue)
                        {
                            Console.WriteLine("Resulting number exceeds calculator capacity");
                        }
                        else if (resultNumber < double.MinValue)
                        {
                            Console.WriteLine("Resulting number exceeds calculator capacity");
                        }
                        else
                        {
                            Console.WriteLine($"Calculating: {firstNumber}/{secondNumber} = {resultNumber}");
                        }
                        ReturnToMainMenu();
                        break;
                    }

                case "5":
                    {
                        Console.Clear();
                        Console.WriteLine("Operation: subtraction (a^b)");
                        Console.WriteLine("Enter the first number...");
                        firstNumber = ValueCheck();
                        Console.WriteLine("Enter the second number...");
                        secondNumber = ValueCheck();
                        resultNumber = Math.Pow(firstNumber, secondNumber);
                        if (resultNumber > double.MaxValue)
                        {
                            Console.WriteLine("Resulting number exceeds calculator capacity");
                        }
                        else if (resultNumber < double.MinValue)
                        {
                            Console.WriteLine("Resulting number exceeds calculator capacity");
                        }
                        else
                        {
                            Console.WriteLine($"Calculating: {firstNumber}^{secondNumber} = {resultNumber}");
                        }
                        ReturnToMainMenu();
                        break;
                    }
                
                case "6":
                    {
                        Console.Clear();
                        Console.WriteLine("Operation: subtraction (a!)");
                        Console.WriteLine("Enter the first number...");
                        firstNumber = ValueCheck();
                        resultNumber = firstNumber;
                        for (var i = 1; i < firstNumber; i++)   //цикл для расчета факториала
                        {
                            resultNumber *= i;
                        }
                        if (resultNumber > double.MaxValue)
                        {
                            Console.WriteLine("Resulting number exceeds calculator capacity");
                        }
                        else if (resultNumber < double.MinValue)
                        {
                            Console.WriteLine("Resulting number exceeds calculator capacity");
                        }
                        else
                        {
                            Console.WriteLine($"Calculating: {firstNumber}! = {resultNumber}");
                        }
                        ReturnToMainMenu();
                        break;
                    }
                case "7":
                    menuExitLoopSwitch = 1;
                    break;
            }
        }
    }
}
