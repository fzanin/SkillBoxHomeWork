using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_05_Task_05
{
    class Program
    {

        /// <summary>
        ///  Function of Ackermann
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        static long Ackermann(long n, long m)
        {
            if (n == 0)
                return m + 1;
            else
                if (n != 0 & m == 0)
                    return Ackermann(n - 1, 1);
                else
                    return Ackermann(n - 1, Ackermann(n, m - 1));
        }


        static void Main(string[] args)
        {
            Console.Clear();
            Console.Write("Введите первое числово N: ");
            int locN = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите первое числово M: ");
            int locM = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Результат вычисления Функции Аккермана: {0}", Ackermann(locN, locM));
            Console.ReadKey();
        }
    }
}
