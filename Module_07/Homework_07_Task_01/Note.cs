using System;

namespace Homework_07_Task_01
{
    /// <summary>
    /// The structure to hold the data about one note
    /// </summary>
    struct Note
    {

        #region Internal Fields

        /// <summary>
        /// Id identificator of note
        /// </summary>
        private int noteId;

        /// <summary>
        /// Date of creation of note
        /// </summary>
        private DateTime noteDate;

        /// <summary>
        /// Creator of note (can be name)
        /// </summary>
        private string noteCreator;

        /// <summary>
        /// Detailed description
        /// </summary>
        private string noteDescription;

        /// <summary>
        /// Status of note - NEW/PROGRESS/DONE
        /// </summary>
        private Statuses noteStatus;

        #endregion

        #region Properties

        /// <summary>
        /// Note ID
        /// </summary>
        public int NoteId { get { return this.noteId; } set { this.noteId = value; } }

        /// <summary>
        /// Note date
        /// </summary>
        public DateTime NoteDate { get { return this.noteDate; } set { this.noteDate = value; } }

        /// <summary>
        /// Note creator 
        /// </summary>
        public string NoteCreator { get { return this.noteCreator; } set { this.noteCreator = value; } }

        /// <summary>
        /// Note description
        /// </summary>
        public string NoteDescription { get { return this.noteDescription; } set { this.noteDescription = value; } }

        /// <summary>
        /// Note status
        /// </summary>
        public Statuses NoteStatus { get { return this.noteStatus; } set { this.noteStatus = value; } }

        #endregion

        #region Constuctor

        /// <summary>
        /// Note constructor
        /// </summary>
        /// <param name="NoteId"></param>
        /// <param name="NoteDate"></param>
        /// <param name="NoteCreator"></param>
        /// <param name="NoteDescription"></param>
        /// <param name="NoteStatus"></param>
        public Note(int NoteId = 0, DateTime NoteDate = default(DateTime), string NoteCreator = "", string NoteDescription = "", Statuses NoteStatus = Statuses.New)
        {
            this.noteId = NoteId;
            this.noteDate = NoteDate;
            this.noteCreator = NoteCreator;
            this.noteDescription = NoteDescription;
            this.noteStatus = NoteStatus;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Print note content
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            return $"|{this.noteId, 7}|{this.noteDate, 20}|{this.noteCreator, 15}|{this.noteStatus, 10}|{this.noteDescription, 46}|";
        }

        /// <summary>
        /// Receive fields of record from console
        /// </summary>
        /// <returns></returns>
        public Note GetNoteFromConsole(int newId)
        {
            Console.Write("Please input Creator Name: ");
            this.noteCreator = Console.ReadLine();

            Console.Write("Please input Text of Note: ");
            this.noteDescription = Console.ReadLine();

            this.noteId = newId;
            this.noteDate = DateTime.Now;
            this.noteStatus = Statuses.New;

            return this;
        }


        #endregion

    }
}
