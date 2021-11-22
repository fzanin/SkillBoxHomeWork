using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_09_Task_01
{
    public class LogHelper
    {

        public void Logging(string logMessage)
        {
            Console.WriteLine($"{DateTime.Now} - {logMessage}");
        }

    }
}
