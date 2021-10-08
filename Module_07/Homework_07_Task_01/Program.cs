using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_07_Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int action = 0;
            Diary diary = new Diary(@"data.txt"); //Create diary

            do
            {
                Console.Clear();

                Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                                               Main menu                                              ║");
                Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║   0 - Print diary                                                                                    ║");
                Console.WriteLine("║   1 - Load all data from file                                                                        ║");
                Console.WriteLine("║   2 - Load data from file filtered by date                                                           ║");
                Console.WriteLine("║   3 - Save data to file                                                                              ║");
                Console.WriteLine("║   4 - Add record                                                                                     ║");
                Console.WriteLine("║   5 - Edit record selected by ID of record                                                           ║");
                Console.WriteLine("║   6 - Delete record selected by ID of record                                                         ║");
                Console.WriteLine("║   7 - Sort records by field                                                                          ║");
                Console.WriteLine("╠══════════════════════════════════════════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║   8 - Exit                                                                                           ║");
                Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════════════════════╝");

                Console.Write("Please select action [0]: ");

                int.TryParse(Console.ReadLine(), out action);

                if (action < 0 || action > 8)
                    action = 0; //set default value

                switch (action)
                {
                    case 0: 
                        diary.PrintDiary();
                        break;

                    case 1:
                        diary.Load();
                        break;

                    case 2:
                        Console.Write("Please input start date [dd.mm.yyyy]: ");
                        DateTime.TryParse(Console.ReadLine(), out DateTime fromDateFilter);

                        Console.Write("Please input stop date [dd.mm.yyyy]: ");
                        DateTime.TryParse(Console.ReadLine(), out DateTime toDateFilter);
                        toDateFilter = toDateFilter.AddHours(23);
                        toDateFilter = toDateFilter.AddMinutes(59);
                        toDateFilter = toDateFilter.AddSeconds(59);

                        diary.Load(fromDateFilter, toDateFilter);
                        break;

                    case 3:
                        diary.Save();
                        break;

                    case 4:
                        Note note = new Note();
                        note.GetNoteFromConsole(diary.GetNextIndex());

                        diary.Add(note);
                        break;

                    case 5:
                        Console.Write("Please input ID which to edit: ");
                        int.TryParse(Console.ReadLine(), out int idToEdit);

                        diary.Edit(Math.Max(0, idToEdit - 1));
                        break;

                    case 6:
                        Console.Write("Please input ID to delete: ");
                        int.TryParse(Console.ReadLine(), out int idToDelete);
                                                                                          
                        diary.Delete(idToDelete);
                        break;

                    case 7:
                        Console.Write("Please input field number for sorting [1 - ID; 2 - DATE]: ");
                        int.TryParse(Console.ReadLine(), out int fieldToSort);

                        if (fieldToSort == 1)
                            diary.SortById();
                        else if (fieldToSort == 2)
                            diary.SortByDate();

                        break;
                }

                Console.WriteLine("Press any key to continue ...");
                Console.ReadLine();

            } while (action != 8);

        }
    }
}
