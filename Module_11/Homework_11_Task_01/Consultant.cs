using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11_Task_01
{
    public class Consultant : IClientInfo
    {


        public Client GetClientInfo()
        {
            return new Client("name-1", "name-2", "name-3", 12345467, "xxx", 123456);
        }

    }
}
