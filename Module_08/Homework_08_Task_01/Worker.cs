using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_08_Task_01
{
    struct Worker
    {

        #region Internal Fields

        /// <summary>
        /// Worker Id
        /// </summary>
        private long id;

        /// <summary>
        /// Worker first name
        /// </summary>
        private string firstName;

        /// <summary>
        /// Worker last name
        /// </summary>
        private string lastName;

        /// <summary>
        /// Worker age
        /// </summary>
        private int age;

        /// <summary>
        /// Worker department
        /// </summary>
        private string department;

        /// <summary>
        /// Worker salary
        /// </summary>
        private int salary;

        /// <summary>
        /// Worker projects counter
        /// </summary>
        private int projectsCounter;

        #endregion

        #region Properties
        public long Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int Age { get => age; set => age = value; }
        public string Department { get => department; set => department = value; }
        public int  Salary { get => salary; set => salary = value; }
        public int ProjectsCounter { get => projectsCounter; set => projectsCounter = value; }

        #endregion

        #region Constuctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Age"></param>
        /// <param name="Department"></param>
        /// <param name="Salary"></param>
        /// <param name="ProjectsCounter"></param>
        public Worker(long Id = 0, string FirstName = "", string LastName = "", int Age = 0, string Department = "",
                      int Salary = 0, int ProjectsCounter = 0)
        {
            this.id = Id;
            this.firstName = FirstName;
            this.lastName = LastName;
            this.age = Age;
            this.department = Department;
            this.salary = Salary;
            this.projectsCounter = ProjectsCounter;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Print worker data
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            return $"{this.Id, 10} {this.FirstName, 15} {this.LastName, 15} {this.Age, 5} {this.Department, 15} {this.Salary, 10} {this.ProjectsCounter, 10}";
        }


        #endregion

    }
}
