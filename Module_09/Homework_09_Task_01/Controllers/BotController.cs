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
        private static PhraseHelper phraser;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="token"></param>
        [Obsolete]
        public BotController(string token)
        {
            // initialize the LOGGER
            /*LogHelper*/ Logger = new LogHelper();

            // initialize the PHRASER
            phraser = new PhraseHelper();

            // initialize Telegram Bot
            botClient = new TelegramBotClient(token);


            botClient.OnMessage += BotOnMessageReceiver;
            //botClient.OnCallbackQuery += BotOnCallbackQueryReceiver;


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


        static async void DownloadFile(string fileId, string filePath, string fileName, long chatId)
        {
            try
            {
                string filePathName = $"Downloads/{filePath}/{fileName}";

                // check if folder is exists
                if (!Directory.Exists(filePathName))
                    Directory.CreateDirectory(filePathName);


                var file = await botClient.GetFileAsync(fileId);

                using (var fs = new FileStream(filePathName, FileMode.Create))
                {
                    await botClient.DownloadFileAsync(file.FilePath, fs);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error downloading: " + ex.Message);
            }
        }




        [Obsolete]
        private void BotOnMessageReceiver(object sender, MessageEventArgs e)
        {
            var msg = e.Message;

            if (msg == null /*|| msg.Type != MessageType.Text || msg.Type != MessageType.Document*/)
                return;


            //if (msg.Type == MessageType.Document)
            //{
            //    //var locPath = Directory.GetCurrentDirectory();

            //    string locPath = "D:\\";

            //    DownloadFile(botClient, msg.Document.FileId, locPath);
            //}

            //string downloadPath = "Downloads";

            Logger.Logging($"chat:[{msg.Chat.Id}] user:[{msg.From.FirstName} {msg.From.LastName}] message:[{msg.Text}]");

            //switch (msg.Text)
            switch (msg.Type)
            {


                case MessageType.Text://"/start":
                    //string text = "List of commands:            \n " +
                    //              "  /start    - bot start      \n " +
                    //              "  /menu     - show menu      \n " +
                    //              "  /keyboard - show keyboard  ";
                    //await botClient.SendTextMessageAsync(msg.From.Id, text);

                    CheckTextMessage(msg.Text.ToLower(), msg.Chat.Id);


                    break;

                    //case "/menu":

                    //    var inLineKeyboard = new InlineKeyboardMarkup(new[]
                    //    {
                    //        new[]
                    //        {
                    //            InlineKeyboardButton.WithUrl("Google", "https://google.com"),
                    //            InlineKeyboardButton.WithUrl("Telegram", "https://t.me")
                    //        },
                    //        new []
                    //        {
                    //            InlineKeyboardButton.WithCallbackData("Item #1"),
                    //            InlineKeyboardButton.WithCallbackData("Item #2")
                    //        }
                    //    });

                    //    await botClient.SendTextMessageAsync(msg.From.Id, "Select", replyMarkup: inLineKeyboard);

                    //    break;

                    

                case MessageType.Document:
                    //if (!Directory.Exists($"Downloads/{msg.Type}"))
                    //    Directory.CreateDirectory($"Downloads/{msg.Type}");

                    //DownloadFile(msg.Document.FileId, $@"{downloadPath}/{msg.Type}/{msg.Document.FileName}",  msg.Chat.Id);
                    DownloadFile(msg.Document.FileId, msg.Type.ToString(), msg.Document.FileName,  msg.Chat.Id);

                    //return;
                    break;

                case MessageType.Audio:
                    //if (!Directory.Exists($"{downloadPath}/{msg.Type}"))
                    //    Directory.CreateDirectory($"{downloadPath}/{msg.Type}");

                    string audioType = msg.Audio.MimeType.Replace(@"audio/", "");

                    DownloadFile(msg.Audio.FileId, $@"{msg.Type}", $@"{msg.Type}_{00/*itemsCount*/}.{audioType}", msg.Chat.Id);
                    break;

                case MessageType.Photo:
                    //if (!Directory.Exists($"{downloadPath}/{msg.Type}"))
                    //    Directory.CreateDirectory($"{downloadPath}/{msg.Type}"); 

                    DownloadFile(msg.Photo[msg.Photo.Length - 1].FileId, $@"{msg.Type}", $@"/Img_{00/*itemsCount*/}.jpg", msg.Chat.Id);
                    break;

                case MessageType.Video:
                    //if (!Directory.Exists($"{downloadPath}/{msg.Type}"))
                    //    Directory.CreateDirectory($"{downloadPath}/{msg.Type}");

                    string vidoType = msg.Video.MimeType.Replace(@"video/", "");

                    DownloadFile(msg.Video.FileId, $@"{msg.Type}", $@"Video_{00/*itemsCount*/}.{vidoType}", msg.Chat.Id);
                    break;



                //                case "/keyboard":

                //                    var replyKeyboard = new ReplyKeyboardMarkup(new[]
                //{
                //                        new[]
                //                        {
                //                            new KeyboardButton("Hi"),
                //                            new KeyboardButton("How are you?")
                //                        },
                //                        new []
                //                        {
                //                            new KeyboardButton("Contact") {RequestContact = true},
                //                            new KeyboardButton("Location") {RequestLocation = true}
                //                        }
                //                    });

                //                    await botClient.SendTextMessageAsync(msg.Chat.Id, "Message", replyMarkup: replyKeyboard);

                //                    break;

                default:
                    break;
            }

        }


        public async void CheckTextMessage(string textMessage, long chatId)
        {
            string replyMessage = "";
            switch (textMessage)
            {
                case "hi":
                    replyMessage = "Hop-hey, la-la-lay! \nI don't know how else to say...";//"Hello. How are you... Но на будущее - говори по русски...)))";
                    break;




                default:
                    replyMessage = phraser.GetRandomPhrase();//"Hop-hey, la-la-lay! \nI don't know how else to say...";
                    break;

            }

            await botClient.SendTextMessageAsync(chatId, replyMessage);
        }




    }
}
