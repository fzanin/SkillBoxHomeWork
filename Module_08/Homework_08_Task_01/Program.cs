using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_08_Task_01
{
    class Program
    {
        static void Main(string[] args)
        {

            Organization organization = CreateOrganization(2, 10);

            int action = 0;

            do
            {
                Console.Clear();
                PrintMenu();
                Console.Write("Please select action [0]: ");

                int.TryParse(Console.ReadLine(), out action);

                if (action < 0 || action > 11)
                    action = 0; //set default value

                string locDepartmentName;
                string locWorkerName;


                switch (action)
                {
                    #region Print Departments
                    case 0:
                        PrintDepartmentHeader();
                        foreach (Department d in organization.Departments)
                        {
                            Console.WriteLine(d.Print());
                        }
                        Console.ReadLine();
                        break;
                    #endregion

                    #region Print workers
                    case 1:
                        Console.Write("Please input Name/Part of Department where workers are work to print or [Enter] to print all: ");

                        locDepartmentName = Console.ReadLine();

                        if (!String.IsNullOrEmpty(locDepartmentName) & !String.IsNullOrWhiteSpace(locDepartmentName))
                        {
                            #region Print Workers of Department
                            Console.Clear();
                            PrintWorkerHeader();
                            foreach (Worker w in organization.Workers)
                            {
                                if (w.DepartmentName.Contains(locDepartmentName))
                                    Console.WriteLine(w.Print());
                            }
                            Console.ReadLine();
                            #endregion
                        }
                        else
                        {
                            #region Print All Workers
                            Console.Clear();
                            PrintWorkerHeader();
                            foreach (Worker w in organization.Workers)
                            {
                                Console.WriteLine(w.Print());
                            }
                            Console.ReadLine();
                            #endregion
                        }
                        break;
                    #endregion

                    #region Create Department
                    case 2:
                        Console.Write("Please input Department name: ");
                        locDepartmentName = Console.ReadLine();

                        organization.AddDepartment(locDepartmentName);
                        break;
                    #endregion

                    #region Delete Department
                    case 3:
                        Console.Write("Please input Department name: ");
                        locDepartmentName = Console.ReadLine();

                        organization.DeleteDepartment(locDepartmentName);
                        break;
                    #endregion

                    #region Edit Department
                    case 4:
                        Console.Write("Please input Department old name: ");
                        var oldName = Console.ReadLine();
                        Console.Write("Please input Department new name: ");
                        var newName = Console.ReadLine();

                        organization.EditDepartment(oldName, newName);
                        break;
                    #endregion

                    #region Create Worker
                    case 5:
                        Console.Write("Please input Department name: ");
                        locDepartmentName = Console.ReadLine();

                        Console.Write("Please input Worker First name: ");
                        string workerName = Console.ReadLine();

                        Console.Write("Please input Worker Last name: ");
                        string workerFamily = Console.ReadLine();

                        //Console.Write("Please input Worker Age: ");
                        //int.TryParse(Console.ReadLine(), out int workerAge);
                        int workerAge = GetIntFromConsole("Age");

                        //Console.Write("Please input Worker Salary: ");
                        //int.TryParse(Console.ReadLine(), out int workerSalary);
                        int workerSalary = GetIntFromConsole("Salary");

                        //Console.Write("Please input Worker Projects: ");
                        //int.TryParse(Console.ReadLine(), out int workerProjects);
                        int workerProjects = GetIntFromConsole("Projects");

                        organization.AddWorker(workerName,
                                               workerFamily,
                                               workerAge,
                                               locDepartmentName,
                                               workerSalary,
                                               workerProjects);
                        break;
                    #endregion

                    #region Delete Worker
                    case 6:
                        Console.Write("Please input Worker First name to delete: ");
                        locWorkerName = Console.ReadLine();

                        organization.DeleteWorker(locWorkerName);
                        break;
                    #endregion

                    #region Edit Worker
                    case 7:

                        //Console.Write("Please input Worker old First name: ");
                        //var oldWorkerName = Console.ReadLine();
                        //int currWorkerIndex = organization.GetWorkerIndex(oldWorkerName);


                        int oldWorkerId = GetIntFromConsole($"Worker ID for edit: ");
                        int currWorkerIndex = organization.GetWorkerIndex(oldWorkerId);

                        var oldWorkerName = organization.Workers[currWorkerIndex].FirstName;


                        Console.Write("Please input Worker new First name or press [Enter] to leave [{0}]: ", organization.Workers[currWorkerIndex].FirstName);
                        var newWorkerName = Console.ReadLine();
                        if (newWorkerName == "")
                            newWorkerName = organization.Workers[currWorkerIndex].FirstName;

                        Console.Write("Please input Department name or press [Enter] to leave [{0}]: ", organization.Workers[currWorkerIndex].DepartmentName);
                        locDepartmentName = Console.ReadLine();
                        if (locDepartmentName == "")
                            locDepartmentName = organization.Workers[currWorkerIndex].DepartmentName;

                        Console.Write("Please input Worker Last name or press [Enter] to leave [{0}]: ", organization.Workers[currWorkerIndex].LastName);
                        string locWorkerFamily = Console.ReadLine();
                        if (locWorkerFamily == "")
                            locWorkerFamily = organization.Workers[currWorkerIndex].LastName;

                        //Console.Write("Please input Worker Age or press [Enter] to leave [{0}]: ", organization.Workers[currWorkerIndex].Age);
                        //int.TryParse(Console.ReadLine(), out int locWorkerAge);
                        int locWorkerAge = GetIntFromConsole($"Worker Age or press [Enter] to leave [{organization.Workers[currWorkerIndex].Age}]", 
                                                             organization.Workers[currWorkerIndex].Age);
                        if (locWorkerAge == 0)
                            locWorkerAge = organization.Workers[currWorkerIndex].Age;

                        //Console.Write("Please input Worker Salary or press [Enter] to leave [{0}]: ", organization.Workers[currWorkerIndex].Salary);
                        //int.TryParse(Console.ReadLine(), out int locWorkerSalary);
                        int locWorkerSalary = GetIntFromConsole($"Worker Salary  or press [Enter] to leave [{organization.Workers[currWorkerIndex].Salary}]",
                                                                organization.Workers[currWorkerIndex].Salary);
                        if (locWorkerSalary == 0)
                            locWorkerSalary = organization.Workers[currWorkerIndex].Salary;

                        //Console.Write("Please input Worker Projects or press [Enter] to leave [{0}]: ", organization.Workers[currWorkerIndex].ProjectsCounter);
                        //int.TryParse(Console.ReadLine(), out int locWorkerProjects);
                        int locWorkerProjects = GetIntFromConsole($"Worker Projects  or press [Enter] to leave [{organization.Workers[currWorkerIndex].ProjectsCounter}]",
                                                                  organization.Workers[currWorkerIndex].ProjectsCounter);
                        if (locWorkerProjects == 0)
                            locWorkerProjects = organization.Workers[currWorkerIndex].ProjectsCounter;


                        //organization.EditWorker(oldWorkerName, newWorkerName, locWorkerFamily, locDepartmentName, locWorkerAge, locWorkerSalary, locWorkerProjects);
                        organization.EditWorker(oldWorkerId, newWorkerName, locWorkerFamily, locDepartmentName, locWorkerAge, locWorkerSalary, locWorkerProjects);
                        break;
                    #endregion

                    #region Create organization
                    case 8:
                        //Console.Write("Please input count of Departments: ");
                        //int.TryParse(Console.ReadLine(), out int cntDepartments);
                        int cntDepartments = GetIntFromConsole("count of Departments");


                        //Console.Write("Please input count of Workers in each department: ");
                        //int.TryParse(Console.ReadLine(), out int cntWorkers);
                        int cntWorkers = GetIntFromConsole("count of Workers in each department");


                        organization = CreateOrganization(cntDepartments, cntWorkers);
                        break;
                    #endregion


                    #region Print workers Sorted
                    case 11:
                        Console.Write("Please input Name/Part of Department where workers are work to print or [Enter] to print all: ");

                        locDepartmentName = Console.ReadLine();

                        if (!String.IsNullOrEmpty(locDepartmentName) & !String.IsNullOrWhiteSpace(locDepartmentName))
                        {
                            #region Print Workers of Department
                            Console.Clear();
                            PrintWorkerHeader();
                            foreach (Worker w in organization.SortWorkersAsc(organization.Workers))
                            {
                                if (w.DepartmentName.Contains(locDepartmentName))
                                    Console.WriteLine(w.Print());
                            }
                            Console.ReadLine();
                            #endregion
                        }
                        else
                        {
                            #region Print All Workers
                            Console.Clear();
                            PrintWorkerHeader();
                            foreach (Worker w in organization.SortWorkersAsc(organization.Workers))
                            {
                                Console.WriteLine(w.Print());
                            }
                            Console.ReadLine();
                            #endregion
                        }
                        break;
                        #endregion




                }


                Console.WriteLine("Press any key to continue ...");
                Console.ReadLine();

            } while (action != 9);



        }

        /// <summary>
        /// Create organization
        /// </summary>
        /// <returns></returns>
        static Organization CreateOrganization(long departCount, long workerCount)
        {
            Organization organization = new Organization();
            Random rand = new Random();

            for (long dx = 1; dx <= departCount; dx++)  // loop by departments
            {
                organization.AddDepartment($"Department_{dx}");

                for (long wx = 1; wx <= workerCount; wx++) // loop by workers
                {
                    organization.AddWorker($"Name_{dx}{wx}",
                                $"Family_{dx}{wx}",
                                rand.Next(21, 65),
                                $"Department_{dx}",
                                rand.Next(1, 5) * 15000,
                                rand.Next(1, 5));

                    organization.Departments[organization.Departments.FindIndex(d => d.Name.Equals($"Department_{dx}"))].IncrementWorkerCount();
                }
            }

            return organization;
        }

        /// <summary>
        /// Print header ow department
        /// </summary>
        private static void PrintDepartmentHeader()
        {
            Console.WriteLine($"{"DEPARTMENT ID",20} {"DEPARTMENT NAME",20} {"DATE",20} {"TOTAL WORKERS",20}");
        }

        /// <summary>
        /// Print header ow worker
        /// </summary>
        private static void PrintWorkerHeader()
        {
            Console.WriteLine($"{"WORKER ID",10} {"NAME",15} {"FAMILY NAME",15} {"AGE",5} {"DEPARTMENT",15} {"SALARY",10} {"PROJECTS",10}");
        }

        /// <summary>
        /// Print menu 
        /// </summary>
        private static void PrintMenu()
        {
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                               Main menu                                              ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║   0 - Print Departments                                                                              ║");
            Console.WriteLine("║   1 - Print Workers / 11 - Print Sorted Workers                                                      ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║   2 - Create Department                                                                              ║");
            Console.WriteLine("║   3 - Delete Department                                                                              ║");
            Console.WriteLine("║   4 - Edit   Department                                                                              ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║   5 - Create Worker                                                                                  ║");
            Console.WriteLine("║   6 - Delete Worker                                                                                  ║");
            Console.WriteLine("║   7 - Edit   Worker                                                                                  ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║   8 - Create Organization                                                                            ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║   9 - Exit                                                                                           ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════════════╝");
        }

        /// <summary>
        /// Read number from console and try to convert to int value
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static int GetIntFromConsole(string text = "Number")
        {
            Console.WriteLine("Please input {0}: ", text);
            int number;

            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Wrong input of {0}. Try again: ", text);
            }

            return number;
        }

        private static int GetIntFromConsole(string text = "Number", int defaultNumber = -9999)
        {
            Console.WriteLine("Please input {0}: ", text);
            int number;

            while (!int.TryParse(Console.ReadLine(), out number))
            {
                if (defaultNumber != -9999)
                {
                    number = defaultNumber;
                    break;
                }

                Console.WriteLine("Wrong input of {0}. Try again: ", text);
            }

            return number;
        }


    }
}
