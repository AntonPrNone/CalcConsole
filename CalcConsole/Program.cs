using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcConsole
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                double num1, num2, result;
                char operation;

                Console.ForegroundColor = ConsoleColor.Blue; // Цвет сообщений - синий

                Console.WriteLine("Простой консольный калькулятор");
                Console.WriteLine("Введите первое число:");
                num1 = Convert.ToDouble(GetInput(ConsoleColor.White)); // Ввод пользователя белым цветом

                Console.WriteLine("Выберите операцию (+, -, *, /, ^, s (2√), !):");
                operation = Convert.ToChar(GetInput(ConsoleColor.White)); // Ввод пользователя белым цветом

                switch (operation)
                {
                    case '+':
                        Console.WriteLine("Введите второе число:");
                        num2 = Convert.ToDouble(GetInput(ConsoleColor.White)); // Ввод пользователя белым цветом
                        result = num1 + num2;
                        break;
                    case '-':
                        Console.WriteLine("Введите второе число:");
                        num2 = Convert.ToDouble(GetInput(ConsoleColor.White)); // Ввод пользователя белым цветом
                        result = num1 - num2;
                        break;
                    case '*':
                        Console.WriteLine("Введите второе число:");
                        num2 = Convert.ToDouble(GetInput(ConsoleColor.White)); // Ввод пользователя белым цветом
                        result = num1 * num2;
                        break;
                    case '/':
                        Console.WriteLine("Введите второе число:");
                        num2 = Convert.ToDouble(GetInput(ConsoleColor.White)); // Ввод пользователя белым цветом
                        if (num2 != 0)
                        {
                            result = num1 / num2;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red; // Цвет ошибки - красный
                            Console.WriteLine("Ошибка: деление на ноль.");
                            Console.ForegroundColor = ConsoleColor.Blue; // Возвращаем цвет по умолчанию
                            continue;
                        }
                        break;
                    case '^':
                        Console.WriteLine("Введите степень:");
                        num2 = Convert.ToDouble(GetInput(ConsoleColor.White)); // Ввод пользователя белым цветом
                        result = Math.Pow(num1, num2);
                        break;
                    case 's':
                        result = Math.Sqrt(num1);
                        break;
                    case '!':
                        result = Factorial(num1);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red; // Цвет ошибки - красный
                        Console.WriteLine("Ошибка: неверная операция.");
                        Console.ForegroundColor = ConsoleColor.Blue; // Возвращаем цвет по умолчанию
                        continue;
                }

                Console.ForegroundColor = ConsoleColor.Green; // Цвет ответа - зеленый
                Console.WriteLine("Результат: " + result);
                Console.ForegroundColor = ConsoleColor.Blue; // Возвращаем цвет по умолчанию

                Console.WriteLine("Нажмите Escape (Esc) для выхода или любую другую клавишу для продолжения.");

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }
                Console.WriteLine();
            }
        }

        static string GetInput(ConsoleColor color)
        {
            Console.ForegroundColor = color;
            string input = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Blue; // Возвращаем цвет по умолчанию
            return input;
        }

        static double Factorial(double n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }
    }
}