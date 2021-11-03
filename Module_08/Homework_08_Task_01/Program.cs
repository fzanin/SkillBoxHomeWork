using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json;

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

                if (action < 0 || action > 15)
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

                        int workerAge = GetIntFromConsole("Age");

                        int workerSalary = GetIntFromConsole("Salary");

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

                        int locWorkerAge = GetIntFromConsole($"Worker Age or press [Enter] to leave [{organization.Workers[currWorkerIndex].Age}]", 
                                                             organization.Workers[currWorkerIndex].Age);
                        if (locWorkerAge == 0)
                            locWorkerAge = organization.Workers[currWorkerIndex].Age;

                        int locWorkerSalary = GetIntFromConsole($"Worker Salary  or press [Enter] to leave [{organization.Workers[currWorkerIndex].Salary}]",
                                                                organization.Workers[currWorkerIndex].Salary);
                        if (locWorkerSalary == 0)
                            locWorkerSalary = organization.Workers[currWorkerIndex].Salary;

                        int locWorkerProjects = GetIntFromConsole($"Worker Projects  or press [Enter] to leave [{organization.Workers[currWorkerIndex].ProjectsCounter}]",
                                                                  organization.Workers[currWorkerIndex].ProjectsCounter);
                        if (locWorkerProjects == 0)
                            locWorkerProjects = organization.Workers[currWorkerIndex].ProjectsCounter;

                        organization.EditWorker(oldWorkerId, newWorkerName, locWorkerFamily, locDepartmentName, locWorkerAge, locWorkerSalary, locWorkerProjects);
                        break;
                    #endregion

                    #region Create organization
                    case 8:
                        int cntDepartments = GetIntFromConsole("count of Departments");

                        int cntWorkers = GetIntFromConsole("count of Workers in each department");

                        organization = CreateOrganization(cntDepartments, cntWorkers);
                        break;
                    #endregion

                    #region Serialize to XML
                    case 9:

                        SerializeOrganization(organization, "zfv_organ.xml");
                        SerializeDepartmentList(organization.Departments, "zfv_departs.xml");
                        SerializeWorkerList(organization.Workers, "zfv_workers.xml");

                        break;
                    #endregion

                    #region Deserialize from XML
                    case 10:

                        organization = DeserializeOrganization("zfv_organ.xml");
                        organization.Departments = DeserializeDepartmentList("zfv_departs.xml");
                        organization.Workers = DeserializeWorkerList("zfv_workers.xml");

                        break;
                    #endregion

                    #region Serialize to JSON
                    case 12:

                        SerializeOrganizationJson(organization, "zfv_organ.json");
                        SerializeWorkersJson(organization.Workers, "zfv_workers.json");
                        SerializeDepartmentsJson(organization.Departments, "zfv_departs.json");

                        break;
                    #endregion

                    #region Deserialize from JSON
                    case 13:

                        organization = DeserializeOrganizationJson("zfv_organ.json");
                        organization.Departments = DeserializeDepartmentsJson("zfv_departs.json");
                        organization.Workers = DeserializeWorkersJson("zfv_workers.json");

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

            } while (action != 15);

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
            Console.WriteLine("║   1 - Print Workers /       11 - Print Sorted Workers                                                ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║   2 - Create Department      5 - Create Worker                                                       ║");
            Console.WriteLine("║   3 - Delete Department      6 - Delete Worker                                                       ║");
            Console.WriteLine("║   4 - Edit   Department      7 - Edit   Worker                                                       ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║   8 - Create Organization                                                                            ║");
            Console.WriteLine("║   9 - to XML                10 - from XML                                                            ║");
            Console.WriteLine("║  12 - to JSON               13 - from JSON                                                           ║");
            Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║  15 - Exit                                                                                           ║");
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

        /// <summary>
        /// Read number from console and try to convert to int value or set with defaut value
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultNumber"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Serialize Organization to XML
        /// </summary>
        /// <param name="Organ"></param>
        /// <param name="Path"></param>
        static void SerializeOrganization(Organization Organ, string Path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Organization));

            Stream fStream = new FileStream(Path, FileMode.Create, FileAccess.Write);

            xmlSerializer.Serialize(fStream, Organ);

            fStream.Close();
        }

        /// <summary>
        /// Deserialize Organization from XML
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        static Organization DeserializeOrganization(string Path)
        {
            Organization tempOrgan = new Organization();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Organization));

            Stream fStream = new FileStream(Path, FileMode.Open, FileAccess.Read);

            tempOrgan = xmlSerializer.Deserialize(fStream) as Organization;

            fStream.Close();

            return tempOrgan;
        }

        /// <summary>
        /// Serialize Organization to Json
        /// </summary>
        /// <param name="Organ"></param>
        /// <param name="Path"></param>
        static void SerializeOrganizationJson(Organization Organ, string Path)
        {
            string json = JsonConvert.SerializeObject(Organ);
            File.WriteAllText(Path, json);
        }

        /// <summary>
        /// Deserialize Organization from Json
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        static Organization DeserializeOrganizationJson(string Path)
        {
            string json = File.ReadAllText(Path);
            Organization tempOrgan = JsonConvert.DeserializeObject<Organization>(json);

            return tempOrgan;
        }

        /// <summary>
        /// Serialize WorkerList to XML
        /// </summary>
        /// <param name="WorkerList"></param>
        /// <param name="Path"></param>
        static void SerializeWorkerList(List<Worker> WorkerList, string Path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Worker>));

            Stream fStream = new FileStream(Path, FileMode.Create, FileAccess.Write);

            xmlSerializer.Serialize(fStream, WorkerList);

            fStream.Close();
        }

        /// <summary>
        /// Deserialize WorkerList from XML
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        static List<Worker> DeserializeWorkerList(string Path)
        {
            List<Worker> tempWorkerCol = new List<Worker>();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Worker>));

            Stream fStream = new FileStream(Path, FileMode.Open, FileAccess.Read);

            tempWorkerCol = xmlSerializer.Deserialize(fStream) as List<Worker>;

            fStream.Close();

            return tempWorkerCol;
        }

        /// <summary>
        /// Serialize DepartmentList to XML
        /// </summary>
        /// <param name="DepartmentList"></param>
        /// <param name="Path"></param>
        static void SerializeDepartmentList(List<Department> DepartmentList, string Path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Department>));

            Stream fStream = new FileStream(Path, FileMode.Create, FileAccess.Write);

            xmlSerializer.Serialize(fStream, DepartmentList);

            fStream.Close();
        }

        /// <summary>
        /// Deserialize DepartmentList from XML
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        static List<Department> DeserializeDepartmentList(string Path)
        {
            List<Department> tempDepartCol = new List<Department>();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Department>));

            Stream fStream = new FileStream(Path, FileMode.Open, FileAccess.Read);

            tempDepartCol = xmlSerializer.Deserialize(fStream) as List<Department>;

            fStream.Close();

            return tempDepartCol;
        }

        /// <summary>
        /// Serialize Workers to Json
        /// </summary>
        /// <param name="WorkerList"></param>
        /// <param name="Path"></param>
        static void SerializeWorkersJson(List<Worker> WorkerList, string Path)
        {
            string json = JsonConvert.SerializeObject(WorkerList);
            File.WriteAllText(Path, json);
        }

        /// <summary>
        /// Serialize Departments to Json
        /// </summary>
        /// <param name="DepartmentList"></param>
        /// <param name="Path"></param>
        static void SerializeDepartmentsJson(List<Department> DepartmentList, string Path)
        {
            string json = JsonConvert.SerializeObject(DepartmentList);
            File.WriteAllText(Path, json);
        }

        /// <summary>
        /// Deserialize Workers from Json
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        static List<Worker> DeserializeWorkersJson(string Path)
        {
            string json = File.ReadAllText(Path);
            List<Worker> tempWorkers = JsonConvert.DeserializeObject<List<Worker>>(json);

            return tempWorkers;
        }

        /// <summary>
        /// Deserialize Departments from Json
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        static List<Department> DeserializeDepartmentsJson(string Path)
        {
            string json = File.ReadAllText(Path);
            List<Department> tempDepartments = JsonConvert.DeserializeObject<List<Department>>(json);

            return tempDepartments;
        }


    }
}
