using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_05_Task_04
{
    class Program
    {
        /// <summary>
        /// Convert array of strings to array of numbers
        /// </summary>
        /// <param name="stringArray"></param>
        /// <returns></returns>
        static int[] ConvertStringArray(string[] stringArray)
        {
            int[] intArray = new int[stringArray.Length];

            var idx = 0;
            foreach (var item in stringArray)
            {
                bool success = Int32.TryParse(item, out intArray[idx]);
                if (!success)
                    intArray[idx] = 0;

                idx++;
            }

            return intArray;
        }

        /// <summary>
        /// Check array for Arithmetic Progression
        /// </summary>
        /// <param name="numArray"></param>
        /// <returns></returns>
        static bool IsArithmeticProgression(int[] numArray)
        {
            if (numArray.Length < 2)
                return false;

            int delta = (numArray[1] - numArray[0]);

            for (int i = 2; i < numArray.Length; i++)
            {
                if ((numArray[i] - numArray[i-1]) != delta)
                    return false;
            }
                       
            return true;
        }

        /// <summary>
        /// Check array for Geometric Progression
        /// </summary>
        /// <param name="numArray"></param>
        /// <returns></returns>
        static bool IsGeometricProgression(int[] numArray)
        {
            if (numArray.Length < 2)
                return false;

            if (numArray[0] == 0)
                return false;

            int factor = (numArray[1] / numArray[0]);

            for (int i = 2; i < numArray.Length; i++)
            {
                if ((numArray[i] / numArray[i - 1]) != factor)
                    return false;
            }

            return true;
        }

        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Введите числовой ряд.");
            string inputText = Console.ReadLine();
            string[] stringNumbers = inputText.Split(' ', ',', '.');

            int[] intNumbers = ConvertStringArray(stringNumbers);

            //for debug purpose
            //foreach (var n in intNumbers)
            //    {
            //        Console.Write($"[{n}]");
            //    }
            Console.WriteLine("\n=================================================");

            if (IsArithmeticProgression(intNumbers))
                Console.WriteLine("Числовой ряд является арифметической прогрессией");
            else
                Console.WriteLine("Числовой ряд НЕ является арифметической прогрессией");

            Console.WriteLine("\n=================================================");

            if (IsGeometricProgression(intNumbers))
                Console.WriteLine("Числовой ряд является геометрической прогрессией");
            else
                Console.WriteLine("Числовой ряд НЕ является геометрической прогрессией");

            Console.ReadKey();

        }
    }
}
