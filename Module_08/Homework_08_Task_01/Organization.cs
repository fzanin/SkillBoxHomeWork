using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_08_Task_01
{
    class Organization
    {

        #region Fields
        /// <summary>
        /// Name of Organization
        /// </summary>
        private string organizationName;

        /// <summary>
        /// Departments
        /// </summary>
        private List<Department> departments;

        /// <summary>
        /// Workers
        /// </summary>
        private List<Worker> workers;
        #endregion


        public string OrganizationName { get => organizationName; set => organizationName = value; }
        internal List<Department> Departments { get => departments; set => departments = value; }
        internal List<Worker> Workers { get => workers; set => workers = value; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Organization ()
        {
            this.organizationName = "ZFV_org";
            this.departments = new List<Department>();
            this.workers = new List<Worker>();
        }

        /// <summary>
        /// Add new department to organization
        /// </summary>
        /// <param name="deptName"></param>
        public void AddDepartment(string deptName = "")
        {
            this.departments.Add(new Department(this.Departments.Count + 1, deptName, 0));
        }

        /// <summary>
        /// Add new worker to organization
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="age"></param>
        /// <param name="department"></param>
        /// <param name="salary"></param>
        /// <param name="projectsCounter"></param>
        public void AddWorker(string firstName = "", string lastName = "", int age = 0, Department department = new Department(),
                      int salary = 0, int projectsCounter = 0)
        {
            this.workers.Add(new Worker(this.Workers.Count + 1, firstName, lastName, age, department, salary, projectsCounter));



            var idxDept = this.Departments.FindIndex(d => d.Name == department.Name); // get index of department


            Department curDept = department;
            curDept.IncrementWorkerCount();
            this.Departments[idxDept] = curDept;



            //this.departments[idxDept/*this.Departments.FindIndex(d => d.Name == department.Name)*/].IncrementWorkerCount(); ;
        }


    }
}
