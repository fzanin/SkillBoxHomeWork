using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using System.IO;

namespace Homework_09_Task_01
{
    class BotController
    {

        private static TelegramBotClient botClient;
        private static LogHelper Logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="token"></param>
        [Obsolete]
        public BotController(string token)
        {
            // initialize the LOGGER
            /*LogHelper*/ Logger = new LogHelper();

            // initialize Telegram Bot
            botClient = new TelegramBotClient(token);


            botClient.OnMessage += BotOnMessageReceiver;
            botClient.OnCallbackQuery += BotOnCallbackQueryReceiver;


            // get result
            var bcResult = botClient.GetMeAsync().Result;

            Logger.Logging($"[{bcResult.FirstName}] entered to running state");

            // start client
            botClient.StartReceiving();
        }


        [Obsolete]
        private static async void BotOnCallbackQueryReceiver(object sender, CallbackQueryEventArgs e)
        {
            string buttonText = e.CallbackQuery.Data;
            string name = $"{e.CallbackQuery.From.FirstName} {e.CallbackQuery.From.LastName}";

            Logger.Logging($"User [{name}] press command: [{buttonText}]");

            await botClient.AnswerCallbackQueryAsync(e.CallbackQuery.Id, $"You press command [{buttonText}]");
        }


        static async void DownloadFile(ITelegramBotClient botClient, string fileId, string path)
        {
            //try
            //{
                var file = await botClient.GetFileAsync(fileId);

                using (var saveImageStream = new FileStream(path, FileMode.Create))
                {
                    await botClient.DownloadFileAsync(file.FilePath, saveImageStream);
                }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Error downloading: " + ex.Message);
            //}
        }




        [Obsolete]
        private static async void BotOnMessageReceiver(object sender, MessageEventArgs e)
        {
            var msg = e.Message;

            if (msg == null || msg.Type != MessageType.Text || msg.Type != MessageType.Document)
                return;


            if (msg.Type == MessageType.Document)
            {


                var locPath = Directory.GetCurrentDirectory();

                DownloadFile(botClient, msg.Document.FileId, locPath);





            }







            Logger.Logging($"chat:[{msg.Chat.Id}] user:[{msg.From.FirstName} {msg.From.LastName}] message:[{msg.Text}]");

            switch (msg.Text)
            {
                case "/start":
                    string text = @"List of commands: 
                                    /start    - bot start 
                                    /menu     - show menu
                                    /keyboard - show keyboard";
                    await botClient.SendTextMessageAsync(msg.From.Id, text);

                    break;

                case "/menu":

                    var inLineKeyboard = new InlineKeyboardMarkup(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithUrl("Google", "https://google.com"),
                            InlineKeyboardButton.WithUrl("Telegram", "https://t.me")
                        },
                        new []
                        {
                            InlineKeyboardButton.WithCallbackData("Item #1"),
                            InlineKeyboardButton.WithCallbackData("Item #2")
                        }
                    });

                    await botClient.SendTextMessageAsync(msg.From.Id, "Select", replyMarkup: inLineKeyboard);


                    break;
                case "/keyboard":

                    var replyKeyboard = new ReplyKeyboardMarkup(new[]
{
                        new[]
                        {
                            new KeyboardButton("Hi"),
                            new KeyboardButton("How are you?")
                        },
                        new []
                        {
                            new KeyboardButton("Contact") {RequestContact = true},
                            new KeyboardButton("Location") {RequestLocation = true}
                        }
                    });

                    await botClient.SendTextMessageAsync(msg.Chat.Id, "Message", replyMarkup: replyKeyboard);

                    break;

                default:
                    break;
            }

        }




    }
}
