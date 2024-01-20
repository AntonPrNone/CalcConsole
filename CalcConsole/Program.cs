using System;

namespace CalcConsole
{
    class Program
    {
        static void Main()
        {
            PrintOperatorsTable();
            Console.ForegroundColor = ConsoleColor.Blue;
            PrintCenteredText("Простой консольный калькулятор");

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;

                double num1 = GetUserInputAsDouble("Введите первое число:");
                char operation = GetUserInputAsChar("Выберите оператор:");

                double? num2 = null;
                if (IsBinaryOperation(operation))
                {
                    num2 = GetUserInputAsDouble("Введите второе число:");
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Запрос: {num1} {operation} {(num2.HasValue ? num2.Value.ToString() : "")}");

                double result = PerformOperation(num1, num2 ?? double.NaN, operation);

                Console.WriteLine($"Результат: {result}");
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine();
            }
        }

        static void PrintCenteredText(string text)
        {
            int screenWidth = Console.WindowWidth;
            int leftPadding = (screenWidth - text.Length) / 2;
            Console.SetCursorPosition(leftPadding, Console.CursorTop);
            Console.WriteLine(text);
        }

        static double GetUserInputAsDouble(string prompt)
        {
            double userInput;
            bool validInput;

            do
            {
                Console.Write(prompt + " ");
                validInput = double.TryParse(Console.ReadLine(), out userInput);

                if (!validInput)
                {
                    HandleError("Ошибка: введенное значение не является числом. Пожалуйста, введите корректное число.");
                }
            } while (!validInput);

            return userInput;
        }

        static char GetUserInputAsChar(string prompt)
        {
            char userInput;
            bool validInput;

            do
            {
                Console.Write(prompt + " ");
                validInput = char.TryParse(Console.ReadLine(), out userInput);

                if (!validInput || !IsOperator(userInput))
                {
                    HandleError("Ошибка: введенный символ не распознан или не является оператором. Пожалуйста, введите корректный оператор.");
                    validInput = false;
                }
            } while (!validInput);

            return userInput;
        }

        static bool IsOperator(char symbol)
        {
            return symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/' || symbol == '^' || symbol == 's' || symbol == '!' || symbol == '%';
        }

        static bool IsBinaryOperation(char operation)
        {
            return operation == '+' || operation == '-' || operation == '*' || operation == '/' || operation == '^' || operation == '%';
        }

        static double PerformOperation(double num1, double num2, char operation)
        {
            switch (operation)
            {
                case '+':
                    return num1 + num2;
                case '-':
                    return num1 - num2;
                case '*':
                    return num1 * num2;
                case '/':
                    if (num2 != 0)
                    {
                        return num1 / num2;
                    }
                    else
                    {
                        HandleError("Ошибка: деление на ноль.");
                        return double.NaN;
                    }
                case '%':
                    if (num2 != 0)
                    {
                        return num1 % num2;
                    }
                    else
                    {
                        HandleError("Ошибка: деление на ноль.");
                        return double.NaN;
                    }
                case '^':
                    return Math.Pow(num1, num2);
                case 's':
                    if (num1 >= 0)
                    {
                        return Math.Sqrt(num1);
                    }
                    else
                    {
                        HandleError("Ошибка: невозможно взять квадратный корень из отрицательного числа.");
                        return double.NaN;
                    }
                case '!':
                    return Factorial(num1);
                default:
                    HandleError("Ошибка: неверная операция.");
                    return double.NaN;
            }
        }

        static void HandleError(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        static double Factorial(double n)
        {
            if (n < 0 || n != Math.Floor(n))
            {
                HandleError("Ошибка: факториал определен только для неотрицательных целых чисел.");
                return double.NaN;
            }

            return (n == 0) ? 1 : n * Factorial(n - 1);
        }

        static void PrintOperatorsTable()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            int tableWidth = 30;
            int tableHeight = 11;

            Console.SetCursorPosition(Console.WindowWidth - tableWidth, 0);
            Console.WriteLine("╔" + new string('═', tableWidth - 2) + "╗");

            for (int i = 1; i < tableHeight - 1; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth - tableWidth, i);
                Console.WriteLine("║" + new string(' ', tableWidth - 2) + "║");
            }

            Console.SetCursorPosition(Console.WindowWidth - tableWidth, tableHeight - 1);
            Console.WriteLine("╚" + new string('═', tableWidth - 2) + "╝");

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Console.WindowWidth - 25, 1);
            Console.WriteLine("Операторы:");

            Console.SetCursorPosition(Console.WindowWidth - 25, 2);
            Console.WriteLine("+ : Сложение");

            Console.SetCursorPosition(Console.WindowWidth - 25, 3);
            Console.WriteLine("- : Вычитание");

            Console.SetCursorPosition(Console.WindowWidth - 25, 4);
            Console.WriteLine("* : Умножение");

            Console.SetCursorPosition(Console.WindowWidth - 25, 5);
            Console.WriteLine("/ : Деление");

            Console.SetCursorPosition(Console.WindowWidth - 25, 6);
            Console.WriteLine("% : Остаток от деления");

            Console.SetCursorPosition(Console.WindowWidth - 25, 7);
            Console.WriteLine("^ : Возведение в степень");

            Console.SetCursorPosition(Console.WindowWidth - 25, 8);
            Console.WriteLine("s : Извлечение корня");

            Console.SetCursorPosition(Console.WindowWidth - 25, 9);
            Console.WriteLine("! : Факториал");
        }
    }
}