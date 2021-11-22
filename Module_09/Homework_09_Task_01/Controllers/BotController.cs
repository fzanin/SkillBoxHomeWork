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
        private static string downloadFolder;           // where we save downloaded files

        private static TelegramBotClient botClient;     // bot client definition
        private static LogHelper Logger;                // helper for messages logging
        private static PhraseHelper phraser;            // helper for phrase generating

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="token"></param>
        [Obsolete]
        public BotController(string token)
        {
            // here we will save all received files
            downloadFolder = "Downloads";

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

        /// <summary>
        /// Download file
        /// </summary>
        /// <param name="fileId"></param>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <param name="chatId"></param>
        static async void DownloadFile(string fileId, string filePath, string fileName, long chatId)
        {
            try
            {
                string filePathName = $"{downloadFolder}/{fileName}"; //$"Downloads/{filePath}/{fileName}";

                // check if folder is exists
                if (!Directory.Exists(downloadFolder))
                    Directory.CreateDirectory(downloadFolder);


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

        /// <summary>
        /// Messages handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                case MessageType.Text:
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
                    DownloadFile(msg.Document.FileId, msg.Type.ToString(), msg.Document.FileName,  msg.Chat.Id);
                    break;

                case MessageType.Audio:
                    //if (!Directory.Exists($"{downloadPath}/{msg.Type}"))
                    //    Directory.CreateDirectory($"{downloadPath}/{msg.Type}");

                    string audioType = msg.Audio.MimeType.Replace(@"audio/", "");

                    DownloadFile(msg.Audio.FileId, $@"{msg.Type}", $@"{msg.Type}_{00/*itemsCount*/}.{audioType}", msg.Chat.Id);
                    break;

                case MessageType.Photo:
                    DownloadFile(msg.Photo[msg.Photo.Length - 1].FileId, msg.Type.ToString()/*$@"{msg.Type}"*/, $@"/{msg.Type.ToString()}_{00/*itemsCount*/}.jpg", msg.Chat.Id);
                    break;

                case MessageType.Video:
                    //if (!Directory.Exists($"{downloadPath}/{msg.Type}"))
                    //    Directory.CreateDirectory($"{downloadPath}/{msg.Type}");

                    string vidoType = msg.Video.MimeType.Replace(@"video/", "");

                    DownloadFile(msg.Video.FileId, $@"{msg.Type}", $@"Video_{00/*itemsCount*/}.{vidoType}", msg.Chat.Id);
                    break;

                default:
                    break;
            }

        }

        /// <summary>
        /// Checker for received text messages
        /// </summary>
        /// <param name="textMessage"></param>
        /// <param name="chatId"></param>
        public async void CheckTextMessage(string textMessage, long chatId)
        {
            string replyMessage = "";

            //if (!phraser.IsRussian(textMessage))
            //    textMessage = "/english";


            switch (textMessage)
            {
                case "/start":
                    replyMessage = "Хоп-хей ла-ла-лей! \nНу погнали чтоли ..." +
                                   "Можем поболтать или покидаться друг в дружку файлами.\n" +
                                   "Для просмотра списка файлов жмакни /list";
                    break;

                case "/english":
                    replyMessage = "Hop-hey, la-la-lay! \nI don't know what else to say... \nНо на будущее - говори по русски...)))";
                    break;

                case "/list":
                    replyMessage = "Хоп-хей ла-ла-лей! \nТут будет список...)))";
                    break;


                default:
                    if (!phraser.IsRussian(textMessage))
                        replyMessage = "Hop-hey, la-la-lay! \nI don't know what else to say... \nНо на будущее - говори по русски...)))";
                    else
                        replyMessage = phraser.GetRandomPhrase();

                    break;

            }

            await botClient.SendTextMessageAsync(chatId, replyMessage);
        }


    }
}
