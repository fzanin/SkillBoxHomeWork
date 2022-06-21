using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11_Protection_Proxy_Example
{
    public class RealClient : IClient
    {
        private string accountNo = "AB-111111";
        public RealClient()
        {
            Console.WriteLine("RealClient: Initialized");
        }
        public string GetAccountNo()
        {
            Console.WriteLine("RealClient's AccountNo: " + accountNo);
            return accountNo;
        }
    }
}
