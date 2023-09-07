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
        static void Main(string[] args)
        {
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo() { NumberDecimalSeparator = "." };
            ICalculator calculator = new Calculator();

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
                Console.WriteLine($"Ошибка формата: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
            finally
            {
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

        public interface ICalculator
        {
            double Add(double a, double b);
        }

        public class Calculator : ICalculator
        {
            public double Add(double a, double b)
            {
                return a + b;
            }
        }
    }

}
