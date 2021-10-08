using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace Homework_06_Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            #region global fields
            /// Объявляем глобальные переменные
            string pathName;
            string paramFileName;
            bool isFileOutput = false;
            #endregion

            #region set folder name with full path
            /// Задаем путь к файлу параметров
            pathName = Directory.GetCurrentDirectory();
            Console.Write($"Введите путь к файлу данных или нажмите ввод [{pathName}]: ");
            string tmpStr = Console.ReadLine();
            if (tmpStr.Trim() != "")
                pathName = tmpStr;

            if (!Directory.Exists(pathName))
            {
                Console.WriteLine($"Путь {pathName} не существует! Для выхода нажать любую клавишу...");
                Console.ReadLine();
                Environment.Exit(0);
            }
            #endregion

            #region set file name
            /// Задаем имя файла параметров
            paramFileName = "data.txt";
            Console.Write($"Введите имя файла данных или нажмите ввод [{paramFileName}]: ");

            tmpStr = Console.ReadLine();
            if (tmpStr.Trim() != "")
                paramFileName = tmpStr;
            #endregion

            #region set full file name 
            /// Формируем полное имя файла параметров с маршрутом к нему. Проверка файла на существование
            string fullFileName = $"{pathName}\\{paramFileName}";
            Console.WriteLine(fullFileName);

            if (!File.Exists(fullFileName))
            {
                Console.WriteLine($"Файл {paramFileName} не существует! Для выхода нажать любую клавишу...");
                Console.ReadLine();
                Environment.Exit(0);
            }
            #endregion

            #region read perameter from file
            /// Читаем число параметр из файла. Проверям число на заданные границы
            string textFromFile = File.ReadAllText(fullFileName);

            Int32 maxN;
            maxN = ValidateIntInput(textFromFile);

            if (maxN <=0 | maxN > 1_000_000_000)
            {
                Console.WriteLine($"Числовое значение из файла {maxN} выходит за границы предела 1..1000000000! Для выхода нажать любую клавишу...");
                Console.ReadLine();
                Environment.Exit(0);
            }

            Console.WriteLine($"Число из файла параметров {maxN}\n");
            #endregion

            #region select next action
            /// Запрашиваем что делать дальше
            Console.Write($"1 - показать группы в консоль, 2 - выгрузить группы в файл. Выбор [1]: ");
            string nextStepSelector = "1";
            do
            {
                tmpStr = Console.ReadLine();
                if (tmpStr.Trim() != "")
                    nextStepSelector = tmpStr;
            } while (!(nextStepSelector == "1" || nextStepSelector == "2"));

            isFileOutput = nextStepSelector == "2";
            #endregion

            #region for debug purpose only
            //Int64 k;
            //Int64 l;
            //Console.WriteLine("\n============================");
            //for (int n = 1; n < maxN; n++)
            //{
            //    k = (Int64)Math.Pow(2, n - 1);
            //    l = (Int64)Math.Log(n, 2) + 1;
            //    Console.WriteLine($"{n} = {k} = {l}");
            //}
            #endregion

            Console.WriteLine("\n====================================================================");
            Console.WriteLine("Для N={0}, число групп: через Pow={1}, или через Log={2}", maxN, GetNumberOfGroups(maxN), (Int64)Math.Log(maxN, 2) + 1);
            Console.WriteLine("=====================================================================");

            #region main block with logic for output to Console
            /// Основной блок формирования групп цифр и вывод в консоль

            DateTime dateStart = DateTime.Now;

            StreamWriter streamWriter = new StreamWriter(pathName+"\\output.txt");

            Int64[] arr = new Int64[(Int64)Math.Log(maxN, 2) + 1];
            arr = GetArrayOfGroups(maxN);

            long num = arr[0];
            for (int i = 0; i < arr.Length-1; i++)
            {
                if (isFileOutput)
                    streamWriter.Write("\nGroup item {0} - {1} = ", i, arr[i]);
                else
                    Console.Write("\nGroup item {0} - {1} = ", i, arr[i]);

                while (num < arr[i + 1])
                {
                    if (isFileOutput)
                        streamWriter.Write("{0} ", num);
                    else
                        Console.Write("{0} ", num);

                    num++;
                }
            }

            num = arr[arr.Length - 1];

            if (isFileOutput)
                streamWriter.Write("\nGroup item {0} - {1} = ", arr.Length, arr[arr.Length-1]);
            else
                Console.Write("\nGroup item {0} - {1} = ", arr.Length, arr[arr.Length-1]);

            while (num <= maxN)
            {
                if (isFileOutput)
                    streamWriter.Write("{0} ", num);
                else
                    Console.Write("{0} ", num);

                num++;
            }

            streamWriter.Flush();
            streamWriter.Close();

            TimeSpan timeSpan = DateTime.Now.Subtract(dateStart);
            Console.WriteLine($"\nДлительность операции {nextStepSelector} [мсек] = {timeSpan.TotalMilliseconds}");
            #endregion

            #region request to archive the putput file
            /// Запрашиваем нужно ли архивировать выходной файл
            /// 
            if (isFileOutput)
            {
                Console.Write($"Хотите заархивировать выходной файл? Выбор [Y]: ");
                tmpStr = Console.ReadLine();
                if (tmpStr.Trim() != "Y" | tmpStr.Trim() != "y")
                {
                    string source = pathName + "\\output.txt";
                    string compressed = pathName + "\\output.zip";

                    using (FileStream ss = new FileStream(source, FileMode.OpenOrCreate))
                    {
                        using (FileStream ts = File.Create(compressed))   
                        {
                            using (GZipStream cs = new GZipStream(ts, CompressionMode.Compress))
                            {
                                ss.CopyTo(cs); 
                                Console.WriteLine("Сжатие файла {0} завершено. Было: {1}  стало: {2}.",
                                                  source,
                                                  ss.Length,
                                                  ts.Length);
                            }
                        }
                    }

                }
            }

            #endregion

            Console.ReadLine();
        }

        /// <summary>
        /// Calculate number of groups
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        static int GetNumberOfGroups(int N = 0)
        {
            int counter = 0;

            while (Math.Pow(2, counter) <= N)
            {
                counter++;
            }

            return counter;
        }

        /// <summary>
        /// Get array of groups
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        static Int64[] GetArrayOfGroups(int N = 0)
        {
            int counter = 0;
            Int64[] arrayOfGroups = new Int64[/*N*/(Int64)Math.Log(N, 2) + 1];

            while (Math.Pow(2, counter) <= N)
            {
                arrayOfGroups[counter] = (Int64)Math.Pow(2, counter);
                counter++;
            }

            return arrayOfGroups;
        }


        /// <summary>
        /// Validate input for number
        /// </summary>
        /// <param name="inputToCheck"></param>
        /// <returns></returns>
        static Int32 ValidateIntInput(string inputToCheck)
        {
            bool success = Int32.TryParse(inputToCheck, out int number);

            if (success)
                return number;
            else
                return -1;
        }

                          
    }
}
