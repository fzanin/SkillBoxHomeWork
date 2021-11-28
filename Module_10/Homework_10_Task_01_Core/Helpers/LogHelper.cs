using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_10_Task_01_Core.Helpers
{
    public class LogHelper
    {
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
