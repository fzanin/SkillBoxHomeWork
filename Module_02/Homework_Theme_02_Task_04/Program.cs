using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_02_Task_04
{
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            #region Worker #1
            Worker worker01 = new Worker();                             // Create object of 1st worker

            /*  ===========================================
             *  Here is example of multi line comment
             *  In first line of output we just show
             *  the invitation for user to start data input
                ===========================================*/

            Console.WriteLine("Please input data of worker #1 =>");     // Show invitation for worker 01

            worker01.InputWorkerName();                                 // input name #1
            worker01.InputWorkerAge();                                  // input age  #1
            worker01.InputWorkerHeight();                               // input Height  #1
            worker01.InputWorkerScoreRussian();                         // input ScoreRussian #1
            worker01.InputWorkerScoreHistory();                         // input ScoreHistory #1
            worker01.InputWorkerScoreMathematics();                     // input ScoreMathematics #1

            worker01.CalculateWorkerAverageScore();                     // calculate average score
            Console.WriteLine("Worker "+ worker01.FirstName + " has average score equal " +  worker01.ScoreAverage);
            Console.ReadKey();  // wait for press any key
            
            #endregion

            Console.Clear();    // clear console 

            #region Worker #2
            Worker worker02 = new Worker();                             // Create object of 2nd worker

            Console.WriteLine("Please input data of worker #2 =>");     // Show invitation for worker 02

            worker02.InputWorkerName();                                 // input name #2
            worker02.InputWorkerAge();                                  // input age  #2
            worker02.InputWorkerHeight();                               // input Height  #2
            worker02.InputWorkerScoreRussian();                         // input ScoreRussian #2
            worker02.InputWorkerScoreHistory();                         // input ScoreHistory #2
            worker02.InputWorkerScoreMathematics();                     // input ScoreMathematics #2

            worker02.CalculateWorkerAverageScore();                     // calculate average score
            Console.WriteLine("Worker {0} has average score equal {1:0.00}", worker02.FirstName, worker02.ScoreAverage);
            Console.ReadKey();  // wait for press any key

            #endregion


            Console.Clear();    // clear console 

            #region Worker #3
            Worker worker03 = new Worker();                             // Create object of 3rd worker

            Console.WriteLine("Please input data of worker #3 =>");     // Show invitation for worker 03

            worker03.InputWorkerName();                                 // input name #3
            worker03.InputWorkerAge();                                  // input age  #3
            worker03.InputWorkerHeight();                               // input Height  #3
            worker03.InputWorkerScoreRussian();                         // input ScoreRussian #3
            worker03.InputWorkerScoreHistory();                         // input ScoreHistory #3
            worker03.InputWorkerScoreMathematics();                     // input ScoreMathematics #3

            worker03.CalculateWorkerAverageScore();                     // calculate average score
            Console.WriteLine($"Worker {worker03.FirstName} has average score equal {worker03.ScoreAverage:F2}");
            Console.ReadKey();  // wait for press any key

            #endregion

        }
    }
}
