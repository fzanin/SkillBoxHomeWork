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
        /// <param name="workerId"></param>
        public void Edit(int workerId, Worker newWorker)
        {
            int workerIdx = -1;

            // get the worker's index which to be edited
            for (int i = 0; i < this.workers.Length; i++)
            {
                if (this.workers[i].WorkerId == workerId)
                {
                    workerIdx = i;
                    break;
                }
            }
            
            if (workerIdx >= 0 & workerIdx < this.workers.Length)
            {
                this.workers[workerIdx].WorkerName = newWorker.WorkerName;
                this.workers[workerIdx].WorkerAge = newWorker.WorkerAge;
                this.workers[workerIdx].WorkerHeight = newWorker.WorkerHeight;
                this.workers[workerIdx].WorkerDateOfBirth = newWorker.WorkerDateOfBirth;
                this.workers[workerIdx].WorkerPlaceOfBirth = newWorker.WorkerPlaceOfBirth;

                this.workers[workerIdx].WorkerDate = DateTime.Now;
            }
        }

        /// <summary>
        /// Load jurnal from file
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        public void Load(DateTime? fromDate = null, DateTime? toDate = null)
        {
            // check if file exits. If not then create it
            if (!File.Exists(this.filePath))
            {
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
        /// Show jurnal content
        /// </summary>
        public void PrintJurnal(int? idToPrint = null)
        {
            //PrintHeader();

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
