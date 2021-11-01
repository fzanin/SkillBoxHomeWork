using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_08_Task_01
{
    public struct Department
    {

        #region Fields
        /// <summary>
        /// Id of department
        /// </summary>
        private long id;
        /// <summary>
        /// Name of department
        /// </summary>
        private string name;
        /// <summary>
        /// Date of department creation
        /// </summary>
        private DateTime date;
        /// <summary>
        /// Count of workers in department
        /// </summary>
        private long workerCount;
        #endregion

        #region Properties
        public long Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime Date { get => date; set => date = value; }
        public long WorkerCount { get => workerCount; set => workerCount = value; }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Worker"></param>
        public Department(long Id, string Name, long WorkerCount)
        {
            this.id = Id;
            this.name = Name;
            this.date = DateTime.Now;
            this.workerCount = WorkerCount;
        }

        /// <summary>
        /// Show list workers of department
        /// </summary>
        /// <returns></returns>
        //public List<string> ShowWorkersInDepartment()
        //{
        //    List<string> wl = new List<string>();

        //    foreach(Worker w in this.Workers)
        //    {
        //        //wl.Add($"{w.Id, 10} {w.FirstName, 15} {w.LastName, 15} {w.Age, 5} {w.Department, 15} {w.Salary,10} {w.ProjectsCounter,10}");
        //        wl.Add(w.Print());
        //    }

        //    return wl;
        //}

        /// <summary>
        /// Print department info
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            return $"{this.Id,20} {this.Name,20} {this.Date,20} {this.WorkerCount,20}";
        }

        /// <summary>
        /// Increment worker counter
        /// </summary>
        public void IncrementWorkerCount()
        {
            this.WorkerCount++;
        }

        /// <summary>
        /// Decrement Worker Count
        /// </summary>
        public void DecrementWorkerCount()
        {
            this.WorkerCount--;
        }


    }
}
