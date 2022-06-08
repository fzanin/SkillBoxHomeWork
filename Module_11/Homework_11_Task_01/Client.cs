using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11_Task_01
{
    public class Client
    {
        private string firstName;
        private string lastName;
        private string? middleName;
        private int phoneNumber;
        private string? passportSerie;
        private int passportNumber;

        public string FirstName
        { 
            get { return firstName; } 
            set { firstName = value; } 
        }


        public Client(string firstName, string lastName, string middleName, int phoneNumber, string passportSerie, int passportNumber)
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
