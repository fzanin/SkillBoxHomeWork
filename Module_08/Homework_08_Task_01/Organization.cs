using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_08_Task_01
{
    public class Organization
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
        public Organization()
        {
            this.organizationName = "ZFV_org";
            this.departments = new List<Department>();
            this.workers = new List<Worker>();
        }

        /// <summary>
        /// Check if department is exists in the list
        /// </summary>
        /// <param name="deptName"></param>
        /// <returns></returns>
        public bool IsDepartmentExist(string deptName)
        {
            return this.departments.Exists(x => x.Name == deptName);
        }

        /// <summary>
        /// Add new department to organization
        /// </summary>
        /// <param name="deptName"></param>
        public void AddDepartment(string deptName = "")
        {
            if (!this.departments.Exists(x => x.Name == deptName)) // create new department if it's not exist only
            {
                this.departments.Add(new Department(this.Departments.Count + 1, deptName, 0));
            }
        }

        /// <summary>
        /// Delete department by name
        /// </summary>
        /// <param name="deptName"></param>
        public void DeleteDepartment(string deptName)
        {
            if (this.departments.Exists(x => x.Name == deptName)) // delete department if it's exist only
            {
                this.departments.Remove(this.Departments[this.Departments.FindIndex(d => d.Name.Equals(deptName))]);
            }
        }

        /// <summary>
        /// Edit Department Name
        /// </summary>
        /// <param name="deptOldName"></param>
        /// <param name="deptNewName"></param>
        public void EditDepartment(string deptOldName = "", string deptNewName = "")
        {
            if (this.departments.Exists(x => x.Name == deptOldName)) // edit department if it's exist only
            {
                Department curDept = this.Departments[this.Departments.FindIndex(d => d.Name.Equals(deptOldName))];
                curDept.Name = deptNewName;

                var idxDept = this.Departments.FindIndex(d => d.Name == deptOldName); // get index of department

                this.Departments[idxDept] = curDept;
            }
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
        public void AddWorker(string firstName = "", string lastName = "", int age = 0, string departmentName = "",
                      int salary = 0, int projectsCounter = 0)
        {

            if (!IsDepartmentExist(departmentName))
                AddDepartment(departmentName);

            this.workers.Add(new Worker(this.Workers.Count + 1, firstName, lastName, age, departmentName, salary, projectsCounter));

            var idxDept = this.Departments.FindIndex(d => d.Name == departmentName); // get index of department

            Department curDept = this.Departments[this.Departments.FindIndex(d => d.Name.Equals(departmentName))];
            curDept.IncrementWorkerCount();
            this.Departments[idxDept] = curDept;
        }

        /// <summary>
        /// Add worker with known ID
        /// </summary>
        /// <param name="workerId"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="age"></param>
        /// <param name="departmentName"></param>
        /// <param name="salary"></param>
        /// <param name="projectsCounter"></param>
        public void AddWorker(int workerId, string firstName = "", string lastName = "", int age = 0, string departmentName = "",
              int salary = 0, int projectsCounter = 0)
        {

            if (!IsDepartmentExist(departmentName))
                AddDepartment(departmentName);

            this.workers.Add(new Worker(workerId, firstName, lastName, age, departmentName, salary, projectsCounter));

            var idxDept = this.Departments.FindIndex(d => d.Name == departmentName); // get index of department

            Department curDept = this.Departments[this.Departments.FindIndex(d => d.Name.Equals(departmentName))];
            curDept.IncrementWorkerCount();
            this.Departments[idxDept] = curDept;
        }

        /// <summary>
        /// Edit worker
        /// </summary>
        /// <param name="workerOldName"></param>
        /// <param name="workerNewName"></param>
        /// <param name="workerLastName"></param>
        /// <param name="workerDepartmentName"></param>
        /// <param name="workerAge"></param>
        /// <param name="workerSalary"></param>
        /// <param name="workerProjectsCounter"></param>
        public void EditWorker(string workerOldName, string workerNewName, string workerLastName, string workerDepartmentName, int workerAge, int workerSalary, int workerProjectsCounter)
        {
            //if (this.departments.Exists(x => x.Name == deptOldName)) 
            //{
            //    Department curDept = this.Departments[this.Departments.FindIndex(d => d.Name.Equals(deptOldName))];
            //    curDept.Name = deptNewName;

            //    var idxDept = this.Departments.FindIndex(d => d.Name == deptOldName); // get index of department

            //    this.Departments[idxDept] = curDept;
            //}


            var idxWork = this.Workers.FindIndex(w => w.FirstName == workerOldName); // get index of worker

            //this.

            DeleteWorker(workerOldName);

            AddWorker(workerNewName, workerLastName, workerAge, workerDepartmentName, workerSalary, workerProjectsCounter);

        }

        /// <summary>
        /// Edit worker
        /// </summary>
        /// <param name="workerId"></param>
        /// <param name="workerNewName"></param>
        /// <param name="workerLastName"></param>
        /// <param name="workerDepartmentName"></param>
        /// <param name="workerAge"></param>
        /// <param name="workerSalary"></param>
        /// <param name="workerProjectsCounter"></param>
        public void EditWorker(int workerId, string workerNewName, string workerLastName, string workerDepartmentName, int workerAge, int workerSalary, int workerProjectsCounter)
        {
            var idxWork = this.Workers.FindIndex(w => w.Id == workerId); // get index of worker

            DeleteWorker(workerId/*idxWork*/);

            AddWorker(workerId, workerNewName, workerLastName, workerAge, workerDepartmentName, workerSalary, workerProjectsCounter);
        }

        /// <summary>
        /// Get worker index by First Name
        /// </summary>
        /// <param name="workerName"></param>
        /// <returns></returns>
        public int GetWorkerIndex(string workerName)
        {

            return this.Workers.FindIndex(w => w.FirstName == workerName);
        }

        /// <summary>
        /// Get worker index by Id
        /// </summary>
        /// <param name="workerId"></param>
        /// <returns></returns>
        public int GetWorkerIndex(int workerId)
        {

            return this.Workers.FindIndex(w => w.Id == workerId);
        }

        /// <summary>
        /// Get worker index by First Name and Lats Name
        /// </summary>
        /// <param name="workerName"></param>
        /// <param name="workerLastname"></param>
        /// <returns></returns>
        public int GetWorkerIndex(string workerName, string workerLastname)
        {

            return this.Workers.FindIndex(w => w.FirstName == workerName && w.LastName == workerLastname);
        }

        /// <summary>
        /// Get list of workers in one department
        /// </summary>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public List<Worker> GetWorkersByDepartment(string departmentName)
        {
            List<Worker> workers = new List<Worker>();

            foreach(Worker w in this.Workers)
            {
                if (w.DepartmentName == departmentName)
                    workers.Add(w);
            }

            return workers;
        }

        /// <summary>
        /// Sort workers by Age and Salary
        /// </summary>
        /// <param name="workers"></param>
        /// <returns></returns>
        public List<Worker> SortWorkersAsc(List<Worker> workers)
        {
            List<Worker> workersSorted = new List<Worker>();

            workersSorted = workers.OrderBy(w => w.Age).ThenBy(w => w.Salary).ToList();

            return workersSorted;
        }
        

        /// <summary>
        /// Delete worker by name
        /// </summary>
        /// <param name="firstName"></param>
        public void DeleteWorker(string firstName)
        {
            //this.workers.Add(new Worker(this.Workers.Count + 1, firstName, lastName, age, department, salary, projectsCounter));

            var idxWork = this.Workers.FindIndex(w=> w.FirstName == firstName); // get index of worker

            Department curDept = this.Departments[this.Departments.FindIndex(d => d.Name.Equals(this.Workers[idxWork].DepartmentName))]    ;
            curDept.DecrementWorkerCount();

            var idxDept = this.Departments.FindIndex(d => d.Name == curDept.Name); // get index of department


            // remove worker
            if (this.Workers.Exists(x => x.FirstName == firstName)) // delete worker if it's exist only
            {
                this.Workers.Remove(this.Workers[this.Workers.FindIndex(w => w.FirstName.Equals(firstName))]);
            }


            // update department
            this.Departments[idxDept] = curDept;


        }

        /// <summary>
        /// Delete worker by Id
        /// </summary>
        /// <param name="workerId"></param>
        public void DeleteWorker(int workerId)
        {
            //this.workers.Add(new Worker(this.Workers.Count + 1, firstName, lastName, age, department, salary, projectsCounter));

            var idxWork = this.Workers.FindIndex(w => w.Id == workerId); // get index of worker

            Department curDept = this.Departments[this.Departments.FindIndex(d => d.Name.Equals(this.Workers[idxWork].DepartmentName))];
            curDept.DecrementWorkerCount();

            var idxDept = this.Departments.FindIndex(d => d.Name == curDept.Name); // get index of department


            // remove worker
            if (this.Workers.Exists(x => x.Id == workerId)) // delete worker if it's exist only
            {
                this.Workers.Remove(this.Workers[this.Workers.FindIndex(w => w.Id.Equals(workerId))]);
            }


            // update department
            this.Departments[idxDept] = curDept;
        }


    }
}
