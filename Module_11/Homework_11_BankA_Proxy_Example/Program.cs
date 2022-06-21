using System;

namespace Homework_11_BankA_Proxy_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string UserName = "", Password = "";
            double Amount = 0;
            while (true)
            {
                Console.WriteLine("Please enter your username.");
                UserName = Console.ReadLine();

                Console.WriteLine("Please enter your password.");
                Password = Console.ReadLine();

                Console.WriteLine("Please enter the amount to be paid.");
                Amount = Convert.ToInt32(Console.ReadLine());

                IBank bank = new ProxyBank(UserName, Password);
                bank.ToPay(Amount);

                Console.WriteLine("************");
            }
        }
    }
}
