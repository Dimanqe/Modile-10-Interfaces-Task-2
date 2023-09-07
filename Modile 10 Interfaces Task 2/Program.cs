using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modile_10_Interfaces_Task_2
{
    internal class Program
    {
        static ILogger Logger { get; set; }
        static void Main(string[] args)

        {
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo() { NumberDecimalSeparator = "." };
            Logger = new logger();
            var calculator = new Calculator(Logger);

            try
            {
                Console.WriteLine("Введите первое число:");
                string input1 = Console.ReadLine();
                double num1 = ParseDouble(input1, numberFormatInfo);

                Console.WriteLine("Введите второе число:");
                string input2 = Console.ReadLine();
                double num2 = ParseDouble(input2, numberFormatInfo);

                double result = calculator.Add(num1, num2);
                Console.WriteLine($"Сумма чисел: {result}");

            }
            catch (FormatException ex)
            {
                calculator.Error(ConsoleColor.Red);
                Console.WriteLine($"Ошибка формата: {ex.Message}");
            }
            catch (Exception ex)
            {
                calculator.Error(ConsoleColor.Red);
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
            finally
            {
                calculator.Error(ConsoleColor.Green);
                Console.WriteLine("Программа завершена.");
            }
        }

        public static double ParseDouble(string input, NumberFormatInfo numberFormatInfo)
        {
            if (double.TryParse(input, NumberStyles.Float, numberFormatInfo, out double result))
            {
                return result;
            }
            else
            {
                throw new FormatException("Некорректный ввод числа.");
            }
        }

        public interface ILogger
        {
            void Event(string text);
            void Error(ConsoleColor color);
        }

        public class logger : ILogger
        {
            public void Error(ConsoleColor color)
            {
                Console.BackgroundColor = color;
            }

            public void Event(string text)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine(text);
            }
        }

        public interface ICalculator

        {
            void Error(ConsoleColor color);

            double Add(double a, double b);
        }

        public class Calculator : ICalculator
        {
            ILogger Logger { get; }
            public Calculator(ILogger logger)
            {
                Logger = logger;
            }

            public double Add(double a, double b)
            {
                Logger.Event("Операция сложения выполнена");
                return a + b;
            }
            public void Error(ConsoleColor color)
            {
                Console.BackgroundColor = color;
            }
        }
    }

}
