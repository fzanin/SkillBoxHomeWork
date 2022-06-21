using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_11_BankA_Proxy_Example
{
    //Real Subject Class
    class Bank : IBank
    {
        public bool ToPay(double Amount)
        {
            if (Amount < 100)
                Console.WriteLine($"The amount you pay cannot be less than 100. Difference -> {100 - Amount}");
            else if (Amount > 100)
                Console.WriteLine($"The amount you pay cannot exceed 100. Difference -> {Amount - 100}");
            else
            {
                Console.WriteLine($"Payment successfully made. -> {Amount}");
                return true;
            }

            return false;
        }
    }
}
