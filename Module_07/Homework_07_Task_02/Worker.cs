using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_07_Task_02
{
    /// <summary>
    /// The structure to hold the worker data
    /// </summary>
    struct Worker
    {

        #region Internal Fields

        /// <summary>
        /// Worker Id
        /// </summary>
        private int workerId;

        /// <summary>
        /// Date of creation
        /// </summary>
        private DateTime workerDate;

        /// <summary>
        /// Worker first name
        /// </summary>
        private string workerName;

        /// <summary>
        /// Worker age
        /// </summary>
        private int workerAge;

        /// <summary>
        /// Worker height
        /// </summary>
        private int workerHeight;

        /// <summary>
        /// Date of birth
        /// </summary>
        private DateTime workerDateOfBirth;

        /// <summary>
        /// Place of Birth
        /// </summary>
        private string workerPlaceOfBirth;

        #endregion

        #region Properties
        public int WorkerId { get => workerId; set => workerId = value; }
        public DateTime WorkerDate { get => workerDate; set => workerDate = value; }
        public string WorkerName { get => workerName; set => workerName = value; }
        public int WorkerAge { get => workerAge; set => workerAge = value; }
        public int WorkerHeight { get => workerHeight; set => workerHeight = value; }
        public DateTime WorkerDateOfBirth { get => workerDateOfBirth; set => workerDateOfBirth = value; }
        public string WorkerPlaceOfBirth { get => workerPlaceOfBirth; set => workerPlaceOfBirth = value; }

        #endregion

        #region Constuctor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="WorkerId"></param>
        /// <param name="WorkerDate"></param>
        /// <param name="WorkerFirstName"></param>
        /// <param name="WorkerLastName"></param>
        /// <param name="WorkerMiddleName"></param>
        /// <param name="WorkerAge"></param>
        /// <param name="WorkerDateOfBirth"></param>
        /// <param name="WorkerPlaceOfBirth"></param>
        public Worker(int WorkerId = 0, DateTime WorkerDate = default(DateTime), string WorkerName = "", int WorkerAge = 0, int WorkerHeight = 0, 
                      DateTime WorkerDateOfBirth = default(DateTime), string WorkerPlaceOfBirth = "")
        {
            this.workerId = WorkerId;
            this.workerDate = WorkerDate;
            this.workerName = WorkerName;
            this.workerAge = WorkerAge;
            this.workerHeight = WorkerHeight;
            this.workerDateOfBirth = WorkerDateOfBirth;
            this.workerPlaceOfBirth = WorkerPlaceOfBirth;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Print worker data
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            return $"|{this.WorkerId,5}|{this.workerDate,18}|{this.workerName,30}|{this.workerAge,7}|{this.workerHeight,7}|{this.workerDateOfBirth,18}|{this.workerPlaceOfBirth,20}|";
        }

        /// <summary>
        /// Read inputs from console
        /// </summary>
        /// <param name="newId"></param>
        /// <returns></returns>
        public Worker GetWorkerFromConsole(int newId)
        {
            Console.Write("Please input Name: ");
            this.workerName = Console.ReadLine();

            Console.Write("Please input Age: ");
            int.TryParse(Console.ReadLine(), out int age);
            this.workerAge = age;

            Console.Write("Please input Height: ");
            int.TryParse(Console.ReadLine(), out int height);
            this.workerHeight = height;

            Console.Write("Please input Date Of Birth [dd.mm.yyyy]: ");
            DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth);
            this.WorkerDateOfBirth = dateOfBirth;

            Console.Write("Please input Place Of Birth: ");
            this.workerPlaceOfBirth = Console.ReadLine();

            this.workerId = newId;
            this.workerDate = DateTime.Now;

            return this;
        }


        #endregion

    }
}
