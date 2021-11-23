using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Threading;

//using Telegram.Bot;
//using Telegram.Bot.Types.Enums;
//using Telegram.Bot.Types.InlineQueryResults;
//using Telegram.Bot.Types.ReplyMarkups;
//using Telegram.Bot.Types;
//using Telegram.Bot.Args;

namespace Homework_09_Task_01
{
    class Program
    {

        [Obsolete]
        static void Main(string[] args)
        {
            string path = @"d:\BotToken.txt";

            if (File.Exists(path))
            {
                string botToken = File.ReadAllText(path);
                BotController botController = new BotController(botToken);
            }
            else
            {
                Console.WriteLine($"Can't find token file: {path} \nPress any key for Exit!");
            }


            Console.ReadLine();

        }

    }
}
