using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_02_Task_04
{
    /// <summary>
    /// Class definition for company worker. Describes main entities of worker
    /// </summary>
    class Worker
    {
        /// <summary>
        /// The minimum age limit
        /// </summary>
        private readonly int MinAgeLimit;
        /// <summary>
        /// The maximum age limit
        /// </summary>
        private readonly int MaxAgeLimit;
        /// <summary>
        /// The minimum height limit
        /// </summary>
        private readonly int MinHeightLimit;
        /// <summary>
        /// The maximum height limit
        /// </summary>
        private readonly int MaxHeightLimit;
        /// <summary>
        /// The minimum score limit
        /// </summary>
        private readonly int MinScoreLimit;
        /// <summary>
        /// The maximum score limit
        /// </summary>
        private readonly int MaxScoreLimit;

        /// <summary>
        /// Name of worker
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Age of worker (years)
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Height of worker 
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Height of worker 
        /// </summary>
        public int ScoreRussian { get; set; }

        /// <summary>
        /// Height of worker 
        /// </summary>
        public int ScoreHistory { get; set; }

        /// <summary>
        /// Height of worker 
        /// </summary>
        public int ScoreMathematics { get; set; }

        /// <summary>
        /// Gets or sets the score average.
        /// </summary>
        /// <value>
        /// The score average.
        /// </value>
        public double ScoreAverage { get; set; }


        /// <summary>
        /// Create the object with default age
        /// </summary>
        public Worker()
        {
            this.Age = 0;               // Set default value of worker age

            this.MinAgeLimit = 18;      // Set minimum limit of Age
            this.MaxAgeLimit = 99;      // Set maximum limit of Age

            this.MinHeightLimit = 120;  // Set minimum limit of Height
            this.MaxHeightLimit = 220;  // Set maximum limit of Height

            this.MinScoreLimit = 1;     // Set minimum limit of Score
            this.MaxScoreLimit = 5;     // Set maximum limit of Score
        }

        /// <summary>
        /// Inputs the name of the worker.
        /// </summary>
        public void InputWorkerName()
        {
            Console.Write("Name: ");                                // Request to input Name
            this.FirstName = Console.ReadLine();                    // Read worker's name from input
        }

        /// <summary>
        /// Inputs the Age of the worker.
        /// </summary>
        public void InputWorkerAge()
        {
            while (this.Age < this.MinAgeLimit || this.Age > this.MaxAgeLimit)          // organize loop for Age input
            {
                Console.Write("Age: ");                                                 // Request to input Age
                this.Age = Convert.ToInt32(Console.ReadLine());                         // Read worker's age from input

                if (this.Age < this.MinAgeLimit || this.Age > this.MaxAgeLimit)         // Check if age out of range Min - Max
                {
                    this.Age = 0;                                                       // reset age value to 0
                    Console.WriteLine($"Worker age must be in the ranage {this.MinAgeLimit} - {this.MaxAgeLimit}. Please repeat input. "); // show warning message
                }
            }
        }

        /// <summary>
        /// Inputs the Height of the worker.
        /// </summary>
        public void InputWorkerHeight()
        {
            while (this.Height < this.MinHeightLimit || this.Height > this.MaxHeightLimit)  // organize loop for Height input
            {
                Console.Write("Height: ");                                                  // Request to input Height
                this.Height = Convert.ToInt32(Console.ReadLine());                          // Read worker's Height from input

                if (this.Height < this.MinHeightLimit || this.Height > this.MaxHeightLimit) // Check if Height out of range Min - Max
                {
                    this.Height = 0;                                                        // reset Height value to 0
                    Console.WriteLine($"Worker Height must be in the ranage {this.MinHeightLimit} - {this.MaxHeightLimit}. Please repeat input. "); // show warning message
                }
            }
        }

        /// <summary>
        /// Inputs the worker score russian.
        /// </summary>
        public void InputWorkerScoreRussian()
        {
            while (this.ScoreRussian < this.MinScoreLimit || this.ScoreRussian > this.MaxScoreLimit)    // organize loop for Score Russian input
            {
                Console.Write("Score Russian: ");                                                       // Request to input Score Russian
                this.ScoreRussian = Convert.ToInt32(Console.ReadLine());                                // Read worker's Score Russian from input

                if (this.ScoreRussian < this.MinScoreLimit || this.ScoreRussian > this.MaxScoreLimit)   // Check if Score Russian out of range Min - Max
                {
                    this.ScoreRussian = 0;                                                              // reset ScoreRussian value to 0
                    Console.WriteLine($"Worker Score Russian must be in the ranage {this.MinScoreLimit} - {this.MaxScoreLimit}. Please repeat input. "); // show warning message
                }
            }
        }

        /// <summary>
        /// Inputs the worker score history.
        /// </summary>
        public void InputWorkerScoreHistory()
        {
            while (this.ScoreHistory < this.MinScoreLimit || this.ScoreHistory > this.MaxScoreLimit)    // organize loop for ScoreHistory input
            {
                Console.Write("Score History: ");                                                       // Request to input ScoreHistory
                this.ScoreHistory = Convert.ToInt32(Console.ReadLine());                                // Read worker's ScoreHistory from input

                if (this.ScoreHistory < this.MinScoreLimit || this.ScoreHistory > this.MaxScoreLimit)   // Check if ScoreHistory out of range Min - Max
                {
                    this.ScoreHistory = 0;                                                              // reset ScoreHistory value to 0
                    Console.WriteLine($"Worker Score History must be in the ranage {this.MinScoreLimit} - {this.MaxScoreLimit}. Please repeat input. "); // show warning message
                }
            }
        }
        /// <summary>
        /// Inputs the worker score mathematics.
        /// </summary>
        public void InputWorkerScoreMathematics()
        {
            while (this.ScoreMathematics < this.MinScoreLimit || this.ScoreMathematics > this.MaxScoreLimit)    // organize loop for ScoreMathematics input
            {
                Console.Write("Score Mathematics: ");                                                           // Request to input ScoreMathematics
                this.ScoreMathematics = Convert.ToInt32(Console.ReadLine());                                    // Read worker's ScoreMathematics from input

                if (this.ScoreMathematics < this.MinScoreLimit || this.ScoreMathematics > this.MaxScoreLimit)   // Check if ScoreMathematics out of range Min - Max
                {
                    this.ScoreMathematics = 0;                                                                  // reset ScoreMathematics value to 0
                    Console.WriteLine($"Worker Score Mathematics must be in the ranage {this.MinScoreLimit} - {this.MaxScoreLimit}. Please repeat input. "); // show warning message
                }
            }
        }

        /// <summary>
        /// Gets the worker average score.
        /// </summary>
        /// <returns></returns>
        public double GetWorkerAverageScore()
        {
            return ((double)this.ScoreRussian + (double)this.ScoreHistory + (double)this.ScoreMathematics) / 3;     // calculate average score of worker
        }

        /// <summary>
        /// Calculates the worker average score.
        /// </summary>
        public void CalculateWorkerAverageScore()
        {
            this.ScoreAverage = GetWorkerAverageScore();    // get aerage score and assign to worker property
        }


    }
}
