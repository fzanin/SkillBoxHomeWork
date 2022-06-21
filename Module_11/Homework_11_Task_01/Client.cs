using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11_Task_01
{
    /// <summary>
    /// Client defenition
    /// </summary>
    public class Client
    {
        #region Private Fields
        protected string firstName;
        protected string lastName;
        protected string? middleName;
        protected Int64 phoneNumber;
        protected string? passportSerie;
        protected int passportNumber;
        #endregion

        /// <summary>
        /// Gets or sets the FirstName
        /// </summary>
        public string FirstName
        { 
            get { return firstName; } 
            set { firstName = value; } 
        }

        /// <summary>
        /// Gets or sets the LastName
        /// </summary>
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        /// <summary>
        /// Gets or sets the MiddleName
        /// </summary>
        public string MiddleName
        {
            get { return String.IsNullOrEmpty(middleName) ? "N/A" : middleName; }
            set { middleName = value; }
        }

        /// <summary>
        /// Gets or sets the PhoneNumber
        /// </summary>
        public Int64 PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        /// <summary>
        /// Gets or sets the PassportSerie
        /// </summary>
        public string PassportSerie
        {
            get { return String.IsNullOrEmpty(passportSerie) ? "---" : passportSerie; }
            set
            {
                passportSerie = value;
            }
        }

        /// <summary>
        /// Gets or sets the PassportNumber
        /// </summary>
        public int PassportNumber
        {
            get { return passportNumber; }
            set { passportNumber = value; }
        }

        static Client()
        {

        }

        /// <summary>
        /// Client's Constructor
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="middleName"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="passportSerie"></param>
        /// <param name="passportNumber"></param>
        public Client(string firstName, string lastName, string middleName, Int64 phoneNumber, string passportSerie, int passportNumber)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.middleName = middleName;
            this.phoneNumber = phoneNumber;
            this.passportSerie = passportSerie;
            this.passportNumber = passportNumber;
        }


    }
}
