using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_07_Task_02
{

    class Program
    {

        private static Worker GetWorkerFromConsole(int workerId)
        {
            Worker workerData = new Worker();

            Console.Write("Please input Name: ");
            workerData.WorkerName = Console.ReadLine();

            Console.Write("Please input Age: ");
            int.TryParse(Console.ReadLine(), out int age);
            workerData.WorkerAge = age;

            Console.Write("Please input Height: ");
            int.TryParse(Console.ReadLine(), out int height);
            workerData.WorkerHeight = height;

            Console.Write("Please input Date Of Birth [dd.mm.yyyy]: ");
            DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth);
            workerData.WorkerDateOfBirth = dateOfBirth;

            Console.Write("Please input Place Of Birth: ");
            workerData.WorkerPlaceOfBirth = Console.ReadLine();

            workerData.WorkerId = workerId;
            workerData.WorkerDate = DateTime.Now;

            return workerData;
        }


        /// <summary>
        /// Print header
        /// </summary>
        private static void PrintHeader()
        {
            Console.WriteLine($"|-----|------------------|------------------------------|-------|-------|------------------|--------------------|");
            Console.WriteLine($"|{"ID",5}|{"DATE",18}|{"NAME",30}|{"AGE",7}|{"HEIGHT",7}|{"DATE OF BIRTH",18}|{"PLACE  OF BIRTH",20}|");
            Console.WriteLine($"|-----|------------------|------------------------------|-------|-------|------------------|--------------------|");
        }


        static void Main(string[] args)
        {
            int action = 0;
            Jurnal jurnal = new Jurnal(@"data.txt"); //Create jurnal

            do
            {

                Console.Clear();

                Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                                               Main menu                                              ║");
                Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║   0 - Print jurnal                                                                                   ║");
                Console.WriteLine("║   1 - Load all data from file                                                                        ║");
                Console.WriteLine("║   2 - Load data from file filtered by date                                                           ║");
                Console.WriteLine("║   3 - Save data to file                                                                              ║");
                Console.WriteLine("║   4 - Add record                                                                                     ║");
                Console.WriteLine("║   5 - Edit record selected by ID of record                                                           ║");
                Console.WriteLine("║   6 - Delete record selected by ID of record                                                         ║");
                Console.WriteLine("║   7 - Sort ascending                                                                                 ║");
                Console.WriteLine("║   8 - Sort descending                                                                                ║");
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
                        Console.Write("Please input ID to print or [Enter] to print all: ");

                        string tmpString = Console.ReadLine();

                        PrintHeader();

                        if (!String.IsNullOrEmpty(tmpString) & !String.IsNullOrWhiteSpace(tmpString))
                        {
                            int.TryParse(tmpString, out int idToPrint);
                            jurnal.PrintJurnal(idToPrint);
                        }
                        else
                        {
                            jurnal.PrintJurnal();
                        }

                        break;

                    case 1:
                        jurnal.Load();
                        break;

                    case 2:
                        Console.Write("Please input start date [dd.mm.yyyy]: ");
                        DateTime.TryParse(Console.ReadLine(), out DateTime fromDateFilter);

                        Console.Write("Please input stop date [dd.mm.yyyy]: ");
                        DateTime.TryParse(Console.ReadLine(), out DateTime toDateFilter);
                        toDateFilter = toDateFilter.AddHours(23);
                        toDateFilter = toDateFilter.AddMinutes(59);
                        toDateFilter = toDateFilter.AddSeconds(59);

                        jurnal.Load(fromDateFilter, toDateFilter);
                        break;

                    case 3:
                        jurnal.Save();
                        break;

                    case 4:

                        jurnal.Add(GetWorkerFromConsole(jurnal.GetNextIndex()));

                        break;

                    case 5:
                        Console.Write("Please input ID which to edit: ");
                        int.TryParse(Console.ReadLine(), out int idToEdit);

                        // show data of worker which will be edited
                        PrintHeader();
                        jurnal.PrintJurnal(idToEdit);

                        jurnal.Edit(idToEdit, GetWorkerFromConsole(idToEdit));

                        break;

                    case 6:
                        Console.Write("Please input ID to delete: ");
                        int.TryParse(Console.ReadLine(), out int idToDelete);

                        jurnal.Delete(idToDelete);
                        break;

                    case 7:
                        jurnal.SortByDateAsc();
                        break;


                    case 8:
                        jurnal.SortByDateDesc();
                        break;
                }

                Console.WriteLine("Press any key to continue ...");
                Console.ReadLine();

            } while (action != 9);

                                                                           
        }


    }
}
