using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11_Task_01
{
    public class Client
    {
        protected string firstName;
        protected string lastName;
        protected string? middleName;
        protected Int64 phoneNumber;
        protected string? passportSerie;
        protected int passportNumber;

        public string FirstName
        { 
            get { return firstName; } 
            set { firstName = value; } 
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string MiddleName
        {
            get { return middleName; }
            set { middleName = value; }
        }

        public Int64 PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string PassportSerie
        {
            get { return passportSerie; }
            set
            {
                passportSerie = value;
            }

        }


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
