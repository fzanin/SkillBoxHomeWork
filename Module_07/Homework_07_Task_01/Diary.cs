using System;
using System.IO;

namespace Homework_07_Task_01
{
    struct Diary
    {

        private Note[] notes;       //arraya of notes
        private string filePath;    //path where we store diary
        private int index;          //internal counter

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Path"></param>
        public Diary(string Path)
        {
            this.filePath = Path;
            this.index = 0;
            this.notes = new Note[1];
        }

        /// <summary>
        /// Extend size of array
        /// </summary>
        /// <param name="Flag"></param>
        private void Extend(bool Flag)
        {
            if (Flag)
            {
                Array.Resize(ref this.notes, this.notes.Length + 1);
            }
        }

        private void Reset()
        {
            Array.Resize(ref this.notes, 0);
            this.index = 0;
        }

        /// <summary>
        /// Add new note into local array
        /// </summary>
        /// <param name="newNote"></param>
        public void Add(Note newNote)
        {
            this.Extend(index >= this.notes.Length);
            this.notes[index] = newNote;
            this.index++;
        }

        /// <summary>
        /// Delete note from diary
        /// </summary>
        /// <param name="noteId"></param>
        public void Delete(int noteId)
        {
            if (noteId >= 0 & noteId < this.index)
            {
                for (int i = 0 + noteId - 1; i < index - 1; i++)
                {
                    this.notes[i] = this.notes[i + 1];
                    this.notes[i].NoteId--;
                }
            }

            Array.Resize(ref this.notes, this.notes.Length - 1);
            this.index--;
        }

        /// <summary>
        /// Make sort by ID field
        /// </summary>
        public void SortById()
        {
            for (int i = 0; i < this.notes.Length; i++)
            {
                for (int j = i +  1; j < this.notes.Length; j++)
                {
                    if (this.notes[i].NoteId > this.notes[j].NoteId)
                    {
                        Note tmpNote = new Note();
                        tmpNote = this.notes[i];
                        this.notes[i] = this.notes[j];
                        this.notes[j] = tmpNote;
                    }
                }
            }
        }

        /// <summary>
        /// Make sort by DATE field
        /// </summary>
        public void SortByDate()
        {
            for (int i = 0; i < this.notes.Length; i++)
            {
                for (int j = i + 1; j < this.notes.Length; j++)
                {
                    if (this.notes[i].NoteDate > this.notes[j].NoteDate)
                    {
                        Note tmpNote = new Note();
                        tmpNote = this.notes[i];
                        this.notes[i] = this.notes[j];
                        this.notes[j] = tmpNote;
                    }
                }
            }
        }


        /// <summary>
        /// Edit note
        /// </summary>
        /// <param name="noteId"></param>
        public void Edit(int noteId)
        {
            if (noteId >= 0 & noteId <= this.index)
            {
                Console.Write("Please input Editor Name: ");
                this.notes[noteId].NoteCreator = Console.ReadLine();

                Console.Write("Please input Text of Note: ");
                this.notes[noteId].NoteDescription = Console.ReadLine();

                this.notes[noteId].NoteDate = DateTime.Now;
                this.notes[noteId].NoteStatus = Statuses.Update;

            }
        }

        /// <summary>
        /// Load notes from file
        /// </summary>
        public void Load(DateTime? fromDate = null, DateTime? toDate = null)
        {
            // check if file exits. If not then create it
            if (!File.Exists(this.filePath))
            {
                Console.WriteLine($"File {this.filePath} is not exists! Press any key to create new file...");
                Console.ReadLine();
                //Environment.Exit(0);

                File.WriteAllText(this.filePath, "");
            }

            this.Reset(); //reset notes array

            using (StreamReader sr = new StreamReader(this.filePath))
            {
                Note curNote = new Note();

                while (!sr.EndOfStream)
                {
                    string[] noteFileds = sr.ReadLine().Split(',');

                    if (noteFileds.Length <= 1) //skip empty line
                        continue;

                    curNote.NoteId = Convert.ToInt32(noteFileds[0]);
                    curNote.NoteDate = Convert.ToDateTime(noteFileds[1]);
                    curNote.NoteCreator = noteFileds[2];
                    curNote.NoteDescription = noteFileds[3];
                    curNote.NoteStatus = (Statuses)Enum.Parse(typeof(Statuses), noteFileds[4]);

                    if (fromDate != null & toDate != null)
                    {
                        if (curNote.NoteDate < fromDate || curNote.NoteDate > toDate)
                            continue; //skip the record which is out of period
                    }

                    Add(curNote);
                }
            }
        }

        /// <summary>
        /// Save notes into the file
        /// </summary>
        /// <param name="Path"></param>
        public void Save()
        {
            using (StreamWriter sw = new StreamWriter(this.filePath))
            {
                for (int i = 0; i < this.index; i++)
                {
                    string temp = String.Format("{0},{1},{2},{3},{4}",
                                            this.notes[i].NoteId,
                                            this.notes[i].NoteDate,
                                            this.notes[i].NoteCreator,
                                            this.notes[i].NoteDescription,
                                            this.notes[i].NoteStatus);

                    sw.WriteLine($"{temp}");
                }
            }
        }

        /// <summary>
        /// Show diary content
        /// </summary>
        public void PrintDiary()
        {
            Console.WriteLine($"|-------|--------------------|---------------|----------|----------------------------------------------|");
            Console.WriteLine($"|{"ID",7}|{"DATE",20}|{"CREATOR",15}|{"STATUS",10}|{"DESCRIPTION",46}|");
            Console.WriteLine($"|-------|--------------------|---------------|----------|----------------------------------------------|");

            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(this.notes[i].Print());
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
