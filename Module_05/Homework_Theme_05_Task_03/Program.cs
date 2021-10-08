using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_05_Task_03
{
    class Program
    {
        /// <summary>
        /// Remove duplicate chars from string
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static string RemoveDuplicateChar(string text)
        {
            string outText = "";

            // check if we can proceed with text
            if (text.Length <= 0)
                return text;

            var textLow = text.ToLower();

            var tmpChar = textLow[0];
            outText += text[0];

            for (int i = 1; i < textLow.Length; i++)
            {
                if (tmpChar != textLow[i])
                {
                    outText += text[i];
                    tmpChar = textLow[i];
                }
            }

            return outText;
        }

        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Удалить из тескта все кратные рядом стоящие символы, оставив по одному.");
            Console.WriteLine("Введите текст.");
            string inputText = Console.ReadLine();

            Console.WriteLine("Текст после обработки >>> {0}", RemoveDuplicateChar(inputText));
            Console.ReadKey();
        }
    }
}
