using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11_Protection_Proxy_Example
{
    public class ProtectionProxy : IClient
    {
        private string password = null; //password to get secret
        RealClient client = null;
        public ProtectionProxy(string pwd)
        {
            Console.WriteLine("ProtectionProxy: Initialized");
            password = pwd;
            client = new RealClient();
        }
        public String GetAccountNo()
        {
            Console.WriteLine("Password: ");
            string tmpPwd = Console.ReadLine();
            if (tmpPwd == password)
            {
                return client.GetAccountNo();
            }
            else
            {
                Console.WriteLine("ProtectionProxy: Illegal password!");
                return "";
            }
        }
    }
}
