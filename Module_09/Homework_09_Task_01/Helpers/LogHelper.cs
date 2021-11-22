using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_09_Task_01
{
    public class LogHelper
    {
        // in future we can save the logs into file

        /// <summary>
        /// Logging messages to console
        /// </summary>
        /// <param name="logMessage"></param>
        public void Logging(string logMessage)
        {
            Console.WriteLine($"{DateTime.Now} - {logMessage}");
        }

    }
}
