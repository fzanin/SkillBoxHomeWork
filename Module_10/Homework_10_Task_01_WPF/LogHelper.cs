using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_10_Task_01_WPF
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
