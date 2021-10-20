﻿using System;
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
            //Organization organization = new Organization();


            //organization.AddDepartment("Depart_1");
            //organization.AddDepartment("Depart_2");

            //organization.Departments.FindIndex(d => d.Name.Equals("Depart_1"))

            //organization.AddWorker("Name_1", "Family_1", 18, organization.Departments[organization.Departments.FindIndex(d => d.Name.Equals("Depart_1"))], 15000, 3);
            //organization.AddWorker("Name_2", "Family_2", 19, organization.Departments[organization.Departments.FindIndex(d => d.Name.Equals("Depart_1"))], 15000, 3);
            //organization.AddWorker("Name_3", "Family_3", 20, organization.Departments[organization.Departments.FindIndex(d => d.Name.Equals("Depart_1"))], 15000, 3);

            //PrintDepartmentHeader();
            //foreach (Department d in organization.Departments)
            //{
            //    Console.WriteLine(d.Print());
            //}
            //Console.ReadLine();

            //Department curDept = organization.Departments[organization.Departments.FindIndex(d => d.Name.Equals("Depart_1"))];
            //curDept.IncrementWorkerCount();
            //organization.Departments[organization.Departments.FindIndex(d => d.Name.Equals("Depart_1"))] = curDept;


            //PrintDepartmentHeader();
            //foreach (Department d in organization.Departments)
            //{
            //    Console.WriteLine(d.Print());
            //}
            //Console.ReadLine();



            //organization.Departments[0].IncrementWorkerCount();

            //organization.AddWorker("Name_4", "Family_4", 22, organization.Departments[organization.Departments.FindIndex(d => d.Name.Equals("Depart_2"))], 15000, 3);
            //organization.AddWorker("Name_5", "Family_5", 23, organization.Departments[organization.Departments.FindIndex(d => d.Name.Equals("Depart_2"))], 15000, 3);
            //organization.AddWorker("Name_6", "Family_6", 24, organization.Departments[organization.Departments.FindIndex(d => d.Name.Equals("Depart_2"))], 15000, 3);

            /// Create Organization dictionary
            //List<Department> departments = new List<Department>();
            //departments = CreateOrganization(2, 10);



            Organization organization = CreateOrganization(2, 10);

            //#region Print Departments
            //PrintDepartmentHeader();
            //foreach (Department d in organization.Departments)
            //{
            //    Console.WriteLine(d.Print());
            //}
            //Console.ReadLine();
            //#endregion

            //#region Print Workers
            //Console.Clear();
            //PrintWorkerHeader();
            //foreach (Worker w in organization.Workers)
            //{
            //    Console.WriteLine(w.Print());
            //}
            //Console.ReadLine();
            //#endregion


            int action = 0;

            do
            {

                Console.Clear();

                Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                                               Main menu                                              ║");
                Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║   0 - Print Departments                                                                              ║");
                Console.WriteLine("║   1 - Print Workers                                                                                  ║");
                Console.WriteLine("║   2 - Create new Worker                                                                              ║");
                Console.WriteLine("║   3 - Save data to file                                                                              ║");
                Console.WriteLine("║   4 - Add record                                                                                     ║");
                Console.WriteLine("║   5 - Edit record selected by ID of record                                                           ║");
                Console.WriteLine("║   6 - Delete record selected by ID of record                                                         ║");
                Console.WriteLine("║   7 - Sort ascending                                                                                 ║");
                Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║   8 - Create new Organization  (fill with dummy data)                                                ║");
                Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║   9 - Exit                                                                                           ║");
                Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════════════╝");

                Console.Write("Please select action [0]: ");

                int.TryParse(Console.ReadLine(), out action);

                if (action < 0 || action > 9)
                    action = 0; //set default value




                switch (action)
                {
                    case 0:
                        #region Print Departments
                        PrintDepartmentHeader();
                        foreach (Department d in organization.Departments)
                        {
                            Console.WriteLine(d.Print());
                        }
                        Console.ReadLine();
                        #endregion

                        break;

                    case 1:
                        Console.Write("Please input Name of Department where workers are work to print or [Enter] to print all: ");

                        string tmpString = Console.ReadLine();

                        if (!String.IsNullOrEmpty(tmpString) & !String.IsNullOrWhiteSpace(tmpString))
                        {
                            //int.TryParse(tmpString, out int idToPrint);

                            #region Print Workers of Department
                            Console.Clear();
                            PrintWorkerHeader();
                            foreach (Worker w in organization.Workers)
                            {
                                if (w.Department.Name == tmpString)
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

                    //case 2:
                    //    Console.Write("Please input count of Departments: ");
                    //    int.TryParse(Console.ReadLine(), out int cntDepartments);

                    //    departments.wo
                    //    departments.Add(new Department(dx, $"Department_{dx}", workers));




                    //    break;





                    case 8:
                        Console.Write("Please input count of Departments: ");
                        int.TryParse(Console.ReadLine(), out int cntDepartments);

                        Console.Write("Please input count of Workers in each department: ");
                        int.TryParse(Console.ReadLine(), out int cntWorkers);

                        organization = CreateOrganization(cntDepartments, cntWorkers);
                        break;





                }







                Console.WriteLine("Press any key to continue ...");
                Console.ReadLine();

            } while (action != 9);







            //List<Department> departments = new List<Department>();
            //Random rand = new Random();


            //for (long dx = 1; dx < 4; dx++)  // loop by departments
            //{

            //    List<Worker> workers = new List<Worker>();

            //    for (long wx = 1; wx < 11; wx++) // loop by workers
            //    {
            //        workers.Add(new Worker(wx, $"Name_{wx}", $"Family_{wx}", 17, $"Department_{dx}", rand.Next(1000, 2000), rand.Next(1, 5)));
            //    }

            //    departments.Add(new Department($"Department_{dx}", workers));
            //}


            //Worker worker = new Worker(workerCounter, $"Name_{workerCounter}", $"Family_{workerCounter}", 17, $"Department_{departCounter}", rand.Next(1000,2000), rand.Next(1, 5));

            //Department department = new Department();
            //department.Name = $"Department_{departCounter}";
            //department.Date = DateTime.Now;
            //department.Workers.Add(worker);



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
                    //workers.Add(new Worker(dx * (long)Math.Pow(10, workerCount.ToString().Length) + wx,
                    //            $"Name_{wx}",
                    //            $"Family_{wx}",
                    //            rand.Next(21, 65),
                    //            $"Department_{dx}",
                    //            rand.Next(1000, 2000),
                    //            rand.Next(1, 5)));


                    organization.AddWorker($"Name_{wx}",
                                $"Family_{wx}",
                                rand.Next(21, 65),
                                organization.Departments[organization.Departments.FindIndex(d => d.Name.Equals($"Department_{dx}"))],
                                rand.Next(1, 3) * 15000,
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

    }
}