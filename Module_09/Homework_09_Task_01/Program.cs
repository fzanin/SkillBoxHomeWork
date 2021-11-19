using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Threading;

using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot.Args;

namespace Homework_09_Task_01
{
    class Program
    {


        //////static TelegramBotClient tbClient;

        [Obsolete]
        static void Main(string[] args)
        {

            BotController botController = new BotController("2063385048:AAExMggPQfFvRov0ckLf3y1hdickAci6Zlw");
            Console.ReadLine();




            //////tbClient = new TelegramBotClient("2063385048:AAExMggPQfFvRov0ckLf3y1hdickAci6Zlw");

            //////tbClient.OnMessage += BotOnMessageReceiver;
            //////tbClient.OnCallbackQuery += TbClient_OnCallbackQueryReceiver;


            //////var tbMe = tbClient.GetMeAsync().Result;

            //////Console.WriteLine(tbMe.FirstName);

            //////tbClient.StartReceiving();


            //////Console.ReadLine();

            //////tbClient.StopReceiving();


            //WebClient wc = new WebClient() { Encoding = Encoding.UTF8 };

            ////string token = "2063385048:AAH20WE4MftspR9hu0Q_C4dxZCm4sz9rrPg";
            //string token = "2063385048:AAExMggPQfFvRov0ckLf3y1hdickAci6Zlw";

            //int update_id = 0;
            //string startUrl = $@"https://api.telegram.org/bot{token}/";



            //while (true)
            //{
            //    string url = $"{startUrl}getUpdates?offset={update_id}";
            //    var r = wc.DownloadString(url);

            //    Console.WriteLine(r);
            //    Console.ReadLine();

            //    var msgs = JObject.Parse(r)["result"].ToArray();

            //    foreach (dynamic msg in msgs)
            //    {
            //        update_id = Convert.ToInt32(msg.update_id) + 1;

            //        string userMessage = msg.message.text;
            //        string userId = msg.message.from.id;
            //        string useFirstrName = msg.message.from.first_name;

            //        string text = $"{useFirstrName} {userId} {userMessage}";

            //        Console.WriteLine(text);

            //        if (userMessage == "hi")
            //        {
            //            string responseText = $"Здравствуйте, {useFirstrName}";
            //            url = $"{startUrl}sendMessage?chat_id={userId}&text={responseText}";
            //            //Console.WriteLine("+");
            //            Console.WriteLine(wc.DownloadString(url));
            //        }
            //    }


            //    Thread.Sleep(100);
            //}



            ////Console.WriteLine("Status string");




        }

//////        [Obsolete]
//////        private static async void TbClient_OnCallbackQueryReceiver(object sender, /*Telegram.Bot.Args.*/CallbackQueryEventArgs e)
//////        {
//////            string buttonText = e.CallbackQuery.Data;
//////            string name = $"{e.CallbackQuery.From.FirstName} {e.CallbackQuery.From.LastName}";
//////            Console.WriteLine($"{name} press command: {buttonText}");

//////            await tbClient.AnswerCallbackQueryAsync(e.CallbackQuery.Id, $"You press command {buttonText}");



//////        }

//////        [Obsolete]
//////        private static async void BotOnMessageReceiver(object sender, MessageEventArgs e)
//////        {
//////            var message = e.Message;

//////            if (message == null || message.Type != MessageType.Text)
//////                return;


//////            string name = $"{message.From.FirstName} {message.From.LastName}";

//////            Console.WriteLine($"{name} sent message: {message.Text}");

//////            switch (message.Text)
//////            {
//////                case "/start":
//////                    string text = @"List of commands: 
//////                                    /start    - bot start 
//////                                    /menu     - show menu
//////                                    /keyboard - show keyboard";
//////                    await tbClient.SendTextMessageAsync(message.From.Id, text);

//////                    break;

//////                case "/menu":

//////                    var inLineKeyboard = new InlineKeyboardMarkup(new[]
//////                    {
//////                        new[]
//////                        {
//////                            InlineKeyboardButton.WithUrl("Google", "https://google.com"),
//////                            InlineKeyboardButton.WithUrl("Telegram", "https://t.me")
//////                        },
//////                        new []
//////                        {
//////                            InlineKeyboardButton.WithCallbackData("Item #1"),
//////                            InlineKeyboardButton.WithCallbackData("Item #2")

//////                        }
//////                    });

//////                    await tbClient.SendTextMessageAsync(message.From.Id, "Select", replyMarkup: inLineKeyboard);


//////                    break;
//////                case "/keyboard":

//////                    var replyKeyboard = new ReplyKeyboardMarkup(new[]
//////{
//////                        new[]
//////                        {
//////                            new KeyboardButton("Hi"),
//////                            new KeyboardButton("How are you?")
//////                        },
//////                        new []
//////                        {
//////                            new KeyboardButton("Contact") {RequestContact = true},
//////                            new KeyboardButton("Location") {RequestLocation = true}

//////                        }
//////                    });

//////                    await tbClient.SendTextMessageAsync(message.Chat.Id, "Message", replyMarkup: replyKeyboard);

//////                    break;

//////                default:
//////                    break;
//////            }




//////        }
    }
}
