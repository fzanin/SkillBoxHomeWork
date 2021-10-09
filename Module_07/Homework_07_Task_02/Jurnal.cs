using System;
using System.IO;

namespace Homework_07_Task_02
{
    struct Jurnal
    {

        private Worker[] workers;       //arraya of workers
        private string filePath;    //path where we store jurnal
        private int index;          //internal counter

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Path"></param>
        public Jurnal(string Path)
        {
            this.filePath = Path;
            this.index = 0;
            this.workers = new Worker[1];
        }

        /// <summary>
        /// Extend size of array
        /// </summary>
        /// <param name="Flag"></param>
        private void Extend(bool Flag)
        {
            if (Flag)
            {
                Array.Resize(ref this.workers, this.workers.Length + 1);
            }
        }

        /// <summary>
        /// Reset array
        /// </summary>
        private void Reset()
        {
            Array.Resize(ref this.workers, 0);
            this.index = 0;
        }

        /// <summary>
        /// Add new worker into jurnal
        /// </summary>
        /// <param name="newWorker"></param>
        public void Add(Worker newWorker)
        {
            this.Extend(index >= this.workers.Length);
            this.workers[index] = newWorker;
            this.index++;
        }

        /// <summary>
        /// Delete worker from jurnal
        /// </summary>
        /// <param name="workerId"></param>
        public void Delete(int workerId)
        {
            if (workerId >= 0 & workerId < this.index)
            {
                for (int i = 0 + workerId - 1; i < index - 1; i++)
                {
                    this.workers[i] = this.workers[i + 1];
                    this.workers[i].WorkerId--;
                }
            }

            Array.Resize(ref this.workers, this.workers.Length - 1);
            this.index--;
        }

        /// <summary>
        /// Make ascending sort by DATE field
        /// </summary>
        public void SortByDateAsc()
        {
            for (int i = 0; i < this.workers.Length; i++)
            {
                for (int j = i + 1; j < this.workers.Length; j++)
                {
                    if (this.workers[i].WorkerDate > this.workers[j].WorkerDate)
                    {
                        Worker tmpWorker = new Worker();
                        tmpWorker = this.workers[i];
                        this.workers[i] = this.workers[j];
                        this.workers[j] = tmpWorker;
                    }
                }
            }
        }

        /// <summary>
        /// Make descending  sort by DATE field
        /// </summary>
        public void SortByDateDesc()
        {
            for (int i = 0; i < this.workers.Length; i++)
            {
                for (int j = i + 1; j < this.workers.Length; j++)
                {
                    if (this.workers[i].WorkerDate < this.workers[j].WorkerDate)
                    {
                        Worker tmpWorker = new Worker();
                        tmpWorker = this.workers[i];
                        this.workers[i] = this.workers[j];
                        this.workers[j] = tmpWorker;
                    }
                }
            }
        }

        /// <summary>
        /// Edit worker
        /// </summary>
        /// <param name="noteId"></param>
        public void Edit(int workerId)
        {
            if (workerId >= 0 & workerId <= this.index)
            {
                Console.Write("Please input Name or press [Enter]: ");
                string tmpString = Console.ReadLine();
                if (!String.IsNullOrEmpty(tmpString) & !String.IsNullOrWhiteSpace(tmpString))   // check if input greater than blank
                    this.workers[workerId].WorkerName = tmpString;

                Console.Write("Please input Age or press [Enter]: ");
                tmpString = Console.ReadLine();
                if (!String.IsNullOrEmpty(tmpString) & !String.IsNullOrWhiteSpace(tmpString))   // check if input greater than blank
                {
                    int.TryParse(tmpString, out int age);
                    this.workers[workerId].WorkerAge = age;
                }

                Console.Write("Please input Height or press [Enter]: ");
                tmpString = Console.ReadLine();
                if (!String.IsNullOrEmpty(tmpString) & !String.IsNullOrWhiteSpace(tmpString))   // check if input greater than blank
                {
                    int.TryParse(tmpString, out int height);
                    this.workers[workerId].WorkerHeight = height;
                }

                Console.Write("Please input Date Of Birth [dd.mm.yyyy] or press [Enter]: ");
                tmpString = Console.ReadLine();
                if (!String.IsNullOrEmpty(tmpString) & !String.IsNullOrWhiteSpace(tmpString))   // check if input greater than blank
                {
                    DateTime.TryParse(tmpString, out DateTime dateOfBirth);
                    this.workers[workerId].WorkerDateOfBirth = dateOfBirth;
                }

                Console.Write("Please input Place Of Birth or press [Enter]: ");
                tmpString = Console.ReadLine();
                if (!String.IsNullOrEmpty(tmpString) & !String.IsNullOrWhiteSpace(tmpString))   // check if input greater than blank
                    this.workers[workerId].WorkerPlaceOfBirth = tmpString;

                this.workers[workerId].WorkerDate = DateTime.Now;
            }
        }

        /// <summary>
        /// Load jurnal from file
        /// </summary>
        public void Load(DateTime? fromDate = null, DateTime? toDate = null)
        {
            // check if file exits. If not then create it
            if (!File.Exists(this.filePath))
            {
                Console.WriteLine($"File {this.filePath} is not exists! Press any key to create new file...");
                Console.ReadLine();

                File.WriteAllText(this.filePath, "");
            }

            this.Reset(); //reset notes array

            using (StreamReader sr = new StreamReader(this.filePath))
            {
                Worker curWorker = new Worker();

                while (!sr.EndOfStream)
                {
                    string[] noteFileds = sr.ReadLine().Split('#');

                    if (noteFileds.Length <= 1) //skip empty line
                        continue;

                    curWorker.WorkerId = Convert.ToInt32(noteFileds[0]);
                    curWorker.WorkerDate = Convert.ToDateTime(noteFileds[1]);
                    curWorker.WorkerName = noteFileds[2];
                    curWorker.WorkerAge = Convert.ToInt32(noteFileds[3]);
                    curWorker.WorkerHeight = Convert.ToInt32(noteFileds[4]);
                    curWorker.WorkerDateOfBirth = Convert.ToDateTime(noteFileds[5]);
                    curWorker.WorkerPlaceOfBirth = noteFileds[6];

                    if (fromDate != null & toDate != null)
                    {
                        if (curWorker.WorkerDate < fromDate || curWorker.WorkerDate > toDate)
                            continue; //skip the record which is out of period
                    }

                    Add(curWorker);
                }
            }
        }

        /// <summary>
        /// Save jurnal into the file
        /// </summary>
        /// <param name="Path"></param>
        public void Save()
        {
            using (StreamWriter sw = new StreamWriter(this.filePath))
            {
                for (int i = 0; i < this.index; i++)
                {
                    string temp = String.Format("{0}#{1}#{2}#{3}#{4}#{5}#{6}",
                                            this.workers[i].WorkerId,
                                            this.workers[i].WorkerDate,
                                            this.workers[i].WorkerName,
                                            this.workers[i].WorkerAge,
                                            this.workers[i].WorkerHeight,
                                            this.workers[i].WorkerDateOfBirth,
                                            this.workers[i].WorkerPlaceOfBirth);

                    sw.WriteLine($"{temp}");
                }
            }
        }

        /// <summary>
        /// Print header
        /// </summary>
        private void PrintHeader()
        {
            Console.WriteLine($"|-----|------------------|------------------------------|-------|-------|------------------|--------------------|");
            Console.WriteLine($"|{"ID",5}|{"DATE",18}|{"NAME",30}|{"AGE",7}|{"HEIGHT",7}|{"DATE OF BIRTH",18}|{"PLACE  OF BIRTH",20}|");
            Console.WriteLine($"|-----|------------------|------------------------------|-------|-------|------------------|--------------------|");
        }

        /// <summary>
        /// Show jurnal content
        /// </summary>
        public void PrintJurnal(int? idToPrint = null)
        {
            PrintHeader();

            foreach (Worker w in this.workers)
            {

                if (idToPrint != null)
                {
                    if (idToPrint == w.WorkerId)
                        Console.WriteLine(w.Print());
                }
                else
                {
                    Console.WriteLine(w.Print());
                }

            }
        }

        /// <summary>
        /// Return next value of counter
        /// </summary>
        /// <returns></returns>
        public int GetNextIndex()
        {
            return this.index + 1;
        }

    }
}
