using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_08_Task_01
{
    struct Department
    {

        #region Fields

        public long Id;
        public string Name;
        public DateTime Date;
        public List<Worker> Workers;
        public long WorkerCount { get { return Workers.Count; } }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Worker"></param>
        public Department(long Id, string Name, List<Worker> Worker)
        {
            this.Id = Id;
            this.Name = Name;
            this.Date = DateTime.Now;
            this.Workers = Worker;
        }

        /// <summary>
        /// Show list workers of department
        /// </summary>
        /// <returns></returns>
        public List<string> ShowWorkersInDepartment()
        {
            List<string> wl = new List<string>();

            foreach(Worker w in this.Workers)
            {
                //wl.Add($"{w.Id, 10} {w.FirstName, 15} {w.LastName, 15} {w.Age, 5} {w.Department, 15} {w.Salary,10} {w.ProjectsCounter,10}");
                wl.Add(w.Print());
            }

            return wl;
        }

        /// <summary>
        /// Print department info
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            return $"{this.Id, 20} {this.Name, 20} {this.Date, 20} {this.WorkerCount, 20}";
        }


        public void CreateNewWorker()
        {

        }




    }
}
