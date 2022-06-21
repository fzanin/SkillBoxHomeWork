using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_11_BankA_Proxy_Example
{
    //Proxy Class
    class ProxyBank : IBank
    {
        Bank bank;
        bool Login;
        string UserName, Password;
        public ProxyBank(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
        }

        bool Lodin()
        {
            if (UserName.Equals("user") && Password.Equals("1234"))
            {
                bank = new Bank();
                Login = true;
                Console.WriteLine("Account Login.");
                return true;
            }
            else
                Console.WriteLine("Please make sure you entered your username and password correctly.");

            Login = false;
            return false;
        }

        public bool ToPay(double Amount)
        {
            Lodin();

            if (!Login)
            {
                Console.WriteLine("We can't get paid because the account is not registered.");
                return false;
            }

            bank.ToPay(Amount);
            return true;
        }
    }
}
