using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_05_Task_02
{
    class Program
    {
        /// <summary>
        /// get shorter word from string
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static string GetShortWord(string text)
        {
            string tmpWord = "";
            string returnWord = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (((text[i] == ' ') || (text[i] == ',') || (text[i] == '.')) & (tmpWord.Length > 0))
                {
                    if (returnWord.Length <= 0)
                    {
                        returnWord = tmpWord;
                    }
                    else
                    if (tmpWord.Length <= returnWord.Length)
                    {
                        returnWord = tmpWord;
                    }

                    tmpWord = "";
                }
                else
                {
                    tmpWord += text[i];
                }
            }

            // check last word
            if ((tmpWord.Length <= returnWord.Length) & (tmpWord.Length > 0))
                returnWord = tmpWord;

            return returnWord;
        }


        /// <summary>
        ///  get shorter word from string in advanced way
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static string GetShortWordAdvanced(string text)
        {
            string tmpWord = "";
            string[] words = text.Split(' ', ',', '.');

            foreach (var w in words)
            {
                // assign first word
                if (w.Length > 0 & tmpWord.Length <= 0)
                    tmpWord = w;

                // check each word in text
                if (w.Length > 0 & w.Length <= tmpWord.Length)
                    tmpWord = w;
            }

            return tmpWord;
        }


        /// <summary>
        /// get longest word(s) from string
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static string GetLongWord(string text)
        {
            string tmpWord = "";
            string returnWord = "";
            string returnWords = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (((text[i] == ' ') || (text[i] == ',') || (text[i] == '.')) & (tmpWord.Length > 0))
                {
                    if (returnWord.Length <= 0)
                    {
                        returnWord = tmpWord;
                    }
                    else
                    if (tmpWord.Length == returnWord.Length)
                    {
                        returnWord = tmpWord;

                        if (returnWords.Length > 0)
                            returnWords += ", ";

                        returnWords += tmpWord;
                    }
                    if (tmpWord.Length > returnWord.Length)
                    {
                        returnWord = tmpWord;
                        returnWords = tmpWord;
                    }

                    tmpWord = "";
                }
                else
                {
                    tmpWord += text[i];
                }
            }

            return returnWords;
        }

        /// <summary>
        /// Sort array of string by item length in ascending direction
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string[] SortArrayAsc(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i].Length > array[j].Length)
                    {
                        var temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            return array;
        }

        /// <summary>
        /// Sort array of string by item length in descending direction
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static string[] SortArrayDesc(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i].Length < array[j].Length)
                    {
                        var temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            return array;
        }

        /// <summary>
        /// get longest word(s) from string using array sorting
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static string GetLongWordAdvanced(string text)
        {
            // create and make sort of array
            string[] words = text.Split(' ', ',', '.');

            words = SortArrayDesc(words);

            // for debug purpose
            //foreach (var w in words)
            //{
            //    Console.Write($"[{w}]");
            //}
            //Console.WriteLine("\n==================================");

            string tmpWord = "";
            string returnWords = "";
            int locIdx = 0;
            foreach (var w in words)
            {
                // check for equals current and previous
                if (w.Length > 0 & w.Length >= tmpWord.Length)
                {
                    tmpWord = w;

                    if (locIdx == 0)
                        returnWords = w;
                    else
                        returnWords += ", " + w;

                    locIdx++;
                }
                else
                    break;  // leave the loop because next words will be shorter
            }

            return returnWords;
        }


        static void Main(string[] args)
        {
            # region Задание 2.1
            Console.Clear();
            Console.WriteLine("Cлово, содержащее минимальное количество букв.");
            Console.WriteLine("Введите текст.");
            string inputText = Console.ReadLine();

            string outputText = GetShortWord(inputText);
            Console.WriteLine($"Короткое слово (classic): {outputText}");

            outputText = GetShortWordAdvanced(inputText);
            Console.WriteLine($"Короткое слово (advanced): {outputText}");

            Console.ReadKey();
            #endregion

            # region Задание 2.2
            Console.Clear();
            Console.WriteLine("Cлово(слова) с максимальным количеством букв.");
            Console.WriteLine("Введите текст.");
            string outputStarText = GetLongWordAdvanced(Console.ReadLine());

            Console.WriteLine($"Cлово(слова) с максимальным количеством букв: {outputStarText}");

            Console.ReadKey();
            #endregion

        }


    }
}
