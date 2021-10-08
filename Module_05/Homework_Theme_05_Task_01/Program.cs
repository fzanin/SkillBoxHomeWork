using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_05_Task_01
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Задание 1.1


            Int32 rowNum = GetNumberFromInput("Введите количество строк матрицы: ");

            Int32 colNum = GetNumberFromInput("Введите количество столбцов матрицы: ");

            Int32 multiNum = GetNumberFromInput("Введите число-множитель матрицы: ");

            Int32[,] locArray = new Int32[rowNum, colNum];

            Console.WriteLine("\nИсходная матрица:");
            PrintMatrix(locArray);

            FillMatrix(locArray);
            
            Console.WriteLine("\nМатрица после заполнения:");
            PrintMatrix(locArray);
            
            locArray = MatrixMutiplyByNumber(multiNum, locArray);

            Console.WriteLine("\nМатрица после умножения на {0}:", multiNum);
            PrintMatrix(locArray);


            Console.WriteLine("");
            Console.ReadLine();


            #endregion


            #region Задание 1.2

            Console.Clear();

            Int32 rowAB = GetNumberFromInput("Введите количество строк матриц: ");
            Int32 colAB = GetNumberFromInput("Введите количество столбцов матриц: ");
            Int32[,] locArrayA = new Int32[rowAB, colAB];
            Int32[,] locArrayB = new Int32[rowAB, colAB];
            Int32[,] locArrayC = new Int32[rowAB, colAB];


            Console.WriteLine("\nМатрица A до заполнения:");
            PrintMatrix(locArrayA);

            Console.WriteLine("\nМатрица B до заполнения:");
            PrintMatrix(locArrayB);

            FillMatrix(locArrayA);
            Console.WriteLine("\nМатрица A после заполнения:");
            PrintMatrix(locArrayA);


            FillMatrix(locArrayB);
            Console.WriteLine("\nМатрица B после заполнения:");
            PrintMatrix(locArrayB);

            locArrayC = MatrixPlusMatrix(locArrayA, locArrayB);

            Console.WriteLine("\nМатрица после сложения матриц А и В:");
            PrintMatrix(locArrayC);

            Console.WriteLine("");
            Console.ReadLine();

            #endregion


            #region Задание 1.3

            Console.Clear();

            Int32 rowA = GetNumberFromInput("Введите количество строк матрицы А: ");
            Int32 colA = GetNumberFromInput("Введите количество столбцов матриц A: ");
            Int32 rowB = rowA;
            Console.WriteLine("Количество строк матрицы В: {0}", rowB);
            Int32 colB = GetNumberFromInput("Введите количество столбцов матриц B: ");


            Int32[,] matrixA = new Int32[rowA, colA];
            Int32[,] matrixB = new Int32[rowB, colB];
            Int32[,] matrixC = new Int32[rowA, colB];

            FillMatrix(matrixA);
            Console.WriteLine("\nМатрица A после заполнения:");
            PrintMatrix(matrixA);

            FillMatrix(matrixB);
            Console.WriteLine("\nМатрица B после заполнения:");
            PrintMatrix(matrixB);

            matrixC = MatrixMultiplyByMatrix(matrixA, matrixB);
            Console.WriteLine("\nМатрица C после умножения А на В:");
            PrintMatrix(matrixC);

            Console.ReadLine();
            #endregion


        }

        /// <summary>
        /// Method which accept input into Console, check for correct input, convert and return number
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static Int32 GetNumberFromInput(string text)
        {
            Int32 inputNumber = 0;
            bool isGoodInput = false;

            while (!isGoodInput)
            {
                Console.Write(text);

                isGoodInput = Int32.TryParse(Console.ReadLine(), out inputNumber);

                if (!isGoodInput)
                    Console.WriteLine("Oшибка ввода.");
            }

            return inputNumber;
        }

        /// <summary>
        /// Print values of passed matrix
        /// </summary>
        /// <param name="array"></param>
        static void PrintMatrix(Int32[,] array)
        {
            for (int n = 0; n < array.GetLength(0); n++)
            {
                for (int m = 0; m < array.GetLength(1); m++)
                {
                    Console.Write("{0}", array[n, m].ToString().PadRight(10));
                }
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Fill up the matrix with random numbers
        /// </summary>
        /// <param name="array"></param>
        static void FillMatrix(Int32[,] array)
        {
            Random random = new Random();

            for (int n = 0; n < array.GetLength(0); n++)
            {
                for (int m = 0; m < array.GetLength(1); m++)
                {
                    array[n, m] = random.Next(1, 3);
                }
            }
        }

        /// <summary>
        /// Multiply the matrix by number
        /// </summary>
        /// <param name="multNumber"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        static Int32[,] MatrixMutiplyByNumber(Int32 multNumber, Int32[,] array)
        {
            Int32[,] tmpArray;
            tmpArray = new Int32[array.GetLength(0), array.GetLength(1)];

            for (int n = 0; n < array.GetLength(0); n++)
            {
                for (int m = 0; m < array.GetLength(1); m++)
                {
                    tmpArray[n, m] = array[n, m] * multNumber;
                }
            }

            return tmpArray;
        }

        /// <summary>
        /// Make sum of two matrix
        /// </summary>
        /// <param name="arrayA"></param>
        /// <param name="arrayB"></param>
        /// <returns></returns>
        static Int32[,] MatrixPlusMatrix(Int32[,] arrayA, Int32[,] arrayB)
        {
            Int32[,] tmpArray;
            tmpArray = new Int32[arrayA.GetLength(0), arrayA.GetLength(1)];

            for (int n = 0; n < arrayA.GetLength(0); n++)
            {
                for (int m = 0; m < arrayA.GetLength(1); m++)
                {
                    tmpArray[n, m] = arrayA[n, m] + arrayB[n, m];
                }
            }

            return tmpArray;
        }


        static Int32[,] MatrixMultiplyByMatrix(Int32[,] arrayA, Int32[,] arrayB)
        {
            Int32[,] tmpArray;
            tmpArray = new Int32[arrayA.GetLength(0), arrayB.GetLength(1)];

            for (int n = 0; n < tmpArray.GetLength(0); n++)
            {

                Int32 resultA = 1;
                for (int j = 0; j < arrayA.GetLength(1); j++)
                {
                    resultA *= arrayA[n, j];
                }


                for (int m = 0; m < tmpArray.GetLength(1); m++)
                {


                    Int32 resultB = 1;
                    for (int k = 0; k < arrayB.GetLength(0); k++)
                    {
                        resultB *= arrayB[k, n];
                    }


                    tmpArray[n, m] = resultA + resultB;
                }
            }

            return tmpArray;
        }

    }
}
