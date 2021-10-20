using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_04_Task_01
{
    class Program
    {
        static void Main(string[] args)
        {

            #region double dimension array realization
            int[,] financeBase = new int[12, 4]; // [col_0=month, col_1=income, col_2=expenses, col_3=profit]

            Random random = new Random();

            Console.WriteLine("     Сводная таблица расходов и поступлений за 12 месяцев (2D)");
            Console.WriteLine("-------+--------------------+--------------------+--------------------");
            Console.WriteLine("Месяц  |  Доход, тыс. руб.  |  Расход, тыс.руб.  |   Прибыль, тыс.руб.");
            Console.WriteLine("-------+--------------------+--------------------+--------------------");
            string outTemplet = "  {0, 2}   |      {1, 7}       |      {2,7}       |       {3, 7}        ";
            var positiveCounter = 0;
            var negativeCounter = 0;

            for (int i = 0; i < financeBase.GetLength(0); i++)
            {
                financeBase[i, 0] = i + 1;  //month
                financeBase[i, 1] = random.Next(1, 21) * 10000; //incom
                financeBase[i, 2] = random.Next(1, 21) * 10000; //expences
                financeBase[i, 3] = financeBase[i, 1] - financeBase[i, 2];  //profit

                Console.WriteLine(outTemplet, financeBase[i, 0], financeBase[i, 1], financeBase[i, 2], financeBase[i, 3]);

                if (financeBase[i, 3] > 0)
                    positiveCounter++;

                if (financeBase[i, 3] < 0)
                    negativeCounter++;
            }

            Console.WriteLine("-------+--------------------+--------------------+--------------------");
            Console.WriteLine("Месяцев с положительной прибылью: {0}", positiveCounter);
            Console.WriteLine("Месяцев с отрицательной прибылью: {0}", negativeCounter);

            Console.WriteLine("======================================================================");
            Console.Write("Худшая прибыль в месяцах [<20001]: ");

            var strPrefix = " ";
            for (int i = 0; i < financeBase.GetLength(0); i++)
            {
                if (financeBase[i, 3] <= 20000)
                {
                    Console.Write($"{strPrefix}{financeBase[i, 0]}");
                    strPrefix = ", ";
                }
            }

            Console.WriteLine("\n======================================================================");
            Console.ReadLine();

            #endregion


            #region single dimension array realization
            int[] baseMonth = new int[12];
            int[] baseIncome = new int[12];
            int[] baseExpences = new int[12];
            int[] baseProfit = new int[12];

            Random randomize = new Random();

            Console.Clear();
            Console.WriteLine("     Сводная таблица расходов и поступлений за 12 месяцев (1D)");
            Console.WriteLine("-------+--------------------+--------------------+--------------------");
            Console.WriteLine("Месяц  |  Доход, тыс. руб.  |  Расход, тыс.руб.  |   Прибыль, тыс.руб.");
            Console.WriteLine("-------+--------------------+--------------------+--------------------");

            positiveCounter = 0;
            negativeCounter = 0;

            for (int i = 0; i < baseMonth.Length; i++)
            {
                baseMonth[i] = i + 1;
                baseIncome[i] = randomize.Next(1, 21) * 10000;
                baseExpences[i] = randomize.Next(1, 21) * 10000;
                baseProfit[i] = baseIncome[i] - baseExpences[i];

                Console.WriteLine(outTemplet, baseMonth[i], baseIncome[i], baseExpences[i], baseProfit[i]);

                if (baseProfit[i] > 0)
                    positiveCounter++;

                if (baseProfit[i] < 0)
                    negativeCounter++;
            }

            Console.WriteLine("-------+--------------------+--------------------+--------------------");
            Console.WriteLine("Месяцев с положительной прибылью: {0}", positiveCounter);
            Console.WriteLine("Месяцев с отрицательной прибылью: {0}", negativeCounter);
            Console.WriteLine("======================================================================");

            //PrintIncomeExpenseTable(baseMonth, baseProfit);

            Array.Sort(baseProfit, baseMonth);

            PrintIncomeExpenseTable(baseMonth, baseProfit, " после сортировки");

            Console.WriteLine("======================================================================");
            Console.Write("3 месяца с худшей прибылью: ");
            var prefText = " ";

            for (int item = 0; item < 3; item++)
            {
                Console.Write($"{prefText}{baseMonth[item]}");
                prefText = ", ";
            }
            
            Console.WriteLine("\n======================================================================");
            Console.ReadLine();

            #endregion


            #region Pascal's triangle - fill data
            Console.Clear();
            Console.WriteLine("Треугольник Паскаля.");
            Console.Write("Введите количество строк :");
            string str = Console.ReadLine();
            int rows = Convert.ToInt32(str);

            Int64[,] array = new Int64[rows, rows];

            for (int n = 0; n < rows; n++)
            {
                for (int m = 0; m <= n; m++)
                {
                    array[n, m] = (Int64)(Factorial(n) / (Factorial(m) * Factorial(n - m)));
                }
            }

            #endregion

            #region Pascal's triangle show simple

            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;

            for (int n = 0; n < rows; n++)
            {
                Console.Write("{0, 2}:", n);
                for (int m = 0; m < rows; m++)
                {
                    if (array[n, m] > 0)
                        Console.Write("{0, 9}", array[n, m]);
                }
                Console.WriteLine("");
            }
            Console.ReadLine();

            #endregion

            #region Pascal's triangle show normal 
            Console.Clear();
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;
            string space = "";

            for (int n = 0; n < rows; n++)
            {
                Console.Write("{0}", space.PadRight(Math.Max(Console.WindowWidth/2 - (n * 5) - 5, 0), ' '));
                for (int m = 0; m < rows; m++)
                {
                    if (array[n, m] > 0)
                        Console.Write("{0}", array[n, m].ToString().PadRight(10, ' '));
                }
                Console.WriteLine("");
            }
            Console.ReadLine();

            #endregion


            #region Matrix - multiply by number
            Console.Clear();
            Console.WriteLine("Умножить математическую матрицу на число.");

            Console.Write("Введите количество строк матрицы: ");
            string strRows = Console.ReadLine();
            int rowNum = Convert.ToInt32(strRows);

            Console.Write("Введите количество столбцов матрицы: ");
            string strCols = Console.ReadLine();
            int colNum = Convert.ToInt32(strCols);

            Console.Write("Введите число-множитель матрицы: ");
            string strMulti = Console.ReadLine();
            int multiNum = Convert.ToInt32(strMulti);
            Console.WriteLine("");

            Int64[,] matrix = new Int64[rowNum, colNum];
            Int64[,] matrixMulti = new Int64[rowNum, colNum];
            Random randMatrix = new Random();

            for (int n = 0; n < rowNum; n++)
            {
                if (n == rowNum / 2)
                    Console.Write("{0}| ", String.Format("{0} x ", multiNum).PadLeft(15));
                else
                    Console.Write("{0}| ", String.Format("{0}", "").PadRight(15));


                for (int m = 0; m < colNum; m++)
                {
                    matrix[n, m] = randMatrix.Next(1, 10);
                    Console.Write("{0}", matrix[n, m].ToString().PadRight(10));
                }

                if (n == rowNum / 2)
                    Console.Write(" |  =  | ");
                else
                    Console.Write(" |     | ");

                for (int m = 0; m < colNum; m++)
                {
                    matrixMulti[n, m] = matrix[n, m] * multiNum;
                    Console.Write("{0}", matrixMulti[n, m].ToString().PadRight(10));
                }

                Console.Write(" |");

                Console.WriteLine("");
            }

            Console.ReadLine();


            #endregion


            #region Matrix - plus/minus matrix
            Console.Clear();
            Console.WriteLine("Сложение/вычитание двух матриц.");

            Console.Write("Введите количество строк матриц: ");
            strRows = Console.ReadLine();
            rowNum = Convert.ToInt32(strRows);

            Console.Write("Введите количество столбцов матриц: ");
            strCols = Console.ReadLine();
            colNum = Convert.ToInt32(strCols);

            Int64[,] matrixA = new Int64[rowNum, colNum];
            Int64[,] matrixB = new Int64[rowNum, colNum];
            Int64[,] matrixC = new Int64[rowNum, colNum];

            // fill matrix A and B
            for (int n = 0; n < rowNum; n++)
            {
                for (int m = 0; m < colNum; m++)
                {
                    matrixA[n, m] = randMatrix.Next(1, 10);
                    matrixB[n, m] = randMatrix.Next(1, 10);
                }
            }

            // matrix A + matrix B
            Console.WriteLine("\nСложение двух матриц");
            for (int n = 0; n < rowNum; n++)
            {
                Console.Write("| ");

                // show matrix A
                for (int m = 0; m < colNum; m++)
                {
                    Console.Write("{0}", matrixA[n, m].ToString().PadRight(5));
                }

                if (n == rowNum / 2)
                    Console.Write(" | + | ");
                else
                    Console.Write(" |   | ");

                // show matrix B
                for (int m = 0; m < colNum; m++)
                {
                    Console.Write("{0}", matrixB[n, m].ToString().PadRight(5));
                }

                if (n == rowNum / 2)
                    Console.Write(" |  =  | ");
                else
                    Console.Write(" |     | ");

                // sum matrix A + B and show result as matrix C
                for (int m = 0; m < colNum; m++)
                {
                    matrixC[n, m] = matrixA[n, m] + matrixB[n, m];
                    Console.Write("{0}", matrixC[n, m].ToString().PadRight(10));
                }

                Console.Write(" |");

                Console.WriteLine("");
            }

            // matrix A - matrix B
            Console.WriteLine("\nВычитание двух матриц");
            for (int n = 0; n < rowNum; n++)
            {
                Console.Write("| ");

                // show matrix A
                for (int m = 0; m < colNum; m++)
                {
                    Console.Write("{0}", matrixA[n, m].ToString().PadRight(5));
                }

                if (n == rowNum / 2)
                    Console.Write(" | - | ");
                else
                    Console.Write(" |   | ");

                // show matrix B
                for (int m = 0; m < colNum; m++)
                {
                    Console.Write("{0}", matrixB[n, m].ToString().PadRight(5));
                }

                if (n == rowNum / 2)
                    Console.Write(" |  =  | ");
                else
                    Console.Write(" |     | ");

                // minus matrix A - B and show result as matrix C
                for (int m = 0; m < colNum; m++)
                {
                    matrixC[n, m] = matrixA[n, m] - matrixB[n, m];
                    Console.Write("{0}", matrixC[n, m].ToString().PadRight(10));
                }

                Console.Write(" |");

                Console.WriteLine("");
            }

            Console.ReadLine();
            
            #endregion


            #region Matrix - multipy by matrix
            Console.Clear();
            Console.WriteLine("Произведение двух матриц.");

            Console.Write("Введите количество строк матрицы A: ");
            strRows = Console.ReadLine();
            int rowNumA = Convert.ToInt32(strRows);

            Console.Write("Введите количество столбцов матрицы A: ");
            strCols = Console.ReadLine();
            int colNumA = Convert.ToInt32(strCols);

            int rowNumB = colNumA;
            Console.WriteLine("Количество строк матрицы В: {0}", rowNumB);

            Console.Write("Введите количество столбцов матрицы В: ");
            strCols = Console.ReadLine();
            int colNumB = Convert.ToInt32(strCols);
            Console.WriteLine("\n");
                       
            matrixA = new Int64[rowNumA, colNumA];
            matrixB = new Int64[rowNumB, colNumB];
            matrixC = new Int64[rowNumA, colNumB];

            // fill matrix A
            Console.WriteLine("Матрица A\n");
            for (int n = 0; n < matrixA.GetLength(0); n++)
            {
                for (int m = 0; m < matrixA.GetLength(1); m++)
                {
                    matrixA[n, m] = randMatrix.Next(1, 10);

                    Console.Write("{0}", matrixA[n, m].ToString().PadRight(5));
                }
                Console.WriteLine("\n");
            }

            Console.WriteLine("\n");

            // fill matrix B
            Console.WriteLine("Матрица В\n");

            for (int n = 0; n < matrixB.GetLength(0); n++)
            {
                for (int m = 0; m < matrixB.GetLength(1); m++)
                {
                    matrixB[n, m] = randMatrix.Next(1, 10);

                    Console.Write("{0}", matrixB[n, m].ToString().PadRight(5));
                }
                Console.WriteLine("\n");
            }

            Console.WriteLine("\n");


            // matrix A * matrix B
            Console.WriteLine("Произведение двух матриц\n");
            for (int n = 0; n < matrixC.GetLength(0); n++)
            {
                Int64 resultA = 1;
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    resultA *= matrixA[n, j];
                }


                // matrix A * B and show result as matrix C
                for (int m = 0; m < matrixC.GetLength(1); m++)
                {
                    Int64 resultB = 1;
                    for (int k = 0; k < matrixB.GetLength(0); k++)
                    {
                        resultB *= matrixB[k, n];
                    }

                    matrixC[n, m] = resultA + resultB;

                    Console.Write("{0}", matrixC[n, m].ToString().PadRight(5));

                }
                Console.WriteLine("\n");
            }

                                 
            #endregion
            
            Console.ReadLine();
        }
        
        public static void PrintIncomeExpenseTable(int[] keyValue, int[] deltaValue, string text = "")
        {
            Console.WriteLine(" Прибыль по 12 месяцам (1D){0}", text);
            Console.WriteLine("----------+-------------------------");
            Console.WriteLine("   Месяц  |     Прибыль, тыс.руб.");
            Console.WriteLine("----------+-------------------------");

            for (int i = 0; i < keyValue.Length; i++)
            {
                Console.WriteLine("     {0, 2}   |        {1, 7}        ",  keyValue[i],  deltaValue[i]);
            }
            Console.WriteLine("----------+-------------------------");
        }

        public static double Factorial(int intN)
        {
            double fact = 1;
                for (int i = 1; i <= intN; i++)
                {
                    fact *= i;
                }
                return fact;
        }

    }
}
