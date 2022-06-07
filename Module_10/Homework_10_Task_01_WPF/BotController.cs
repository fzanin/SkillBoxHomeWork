using System;
using System.Collections.Generic;
using System.Text;

using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using System.IO;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace Homework_10_Task_01_WPF
{
    class BotController
    {
        #region Private/Public Fields
        private static string downloadFolder;                                   // where we save downloaded files
        private static TelegramBotClient botClient;                             // bot client definition
        private static LogHelper Logger;                                        // helper for messages logging
        private static PhraseHelper phraser;                                    // helper for phrase generating
        private MainWindow w;                                                   // Provides access to MainWindow
        public ObservableCollection<MessageLog> botMessageLog { get; set; }     // List of messages
        #endregion


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="W"></param>
        /// <param name="pathToken"></param>
        [Obsolete]
        public BotController(MainWindow W, string pathToken = @"d:\BotToken.txt")
        {
            // get bot token
            string botToken = "";
            if (File.Exists(pathToken))
            {
                botToken = File.ReadAllText(pathToken);
            }

            // initialize MainWindow and List to keep bot messages
            this.w = W;
            this.botMessageLog = new ObservableCollection<MessageLog>();

            // here we will save all received files
            downloadFolder = "Downloads";

            if (!Directory.Exists(downloadFolder))
            {
                Directory.CreateDirectory(downloadFolder);
            }


            // initialize the LOGGER
            //Logger = new LogHelper();

            // initialize the PHRASER
            phraser = new PhraseHelper();


            // initialize Telegram Bot
            botClient = new TelegramBotClient(botToken);
            botClient.OnMessage += BotOnMessageReceiver;


            // get result
            //var bcResult = botClient.GetMeAsync().Result;
            //Logger.Logging($"[{bcResult.FirstName}] entered to running state");

            // start client
            botClient.StartReceiving();
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
                string filePathName = $"{downloadFolder}/{fileName}";

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
        /// Upload file
        /// </summary>
        /// <param name="chatId"></param>
        static async void UploadFile(long chatId, string fileName)
        {
            try
            {
                string filePathName = $"{downloadFolder}/{fileName}";

                using (var fs = new FileStream(filePathName, FileMode.Open))
                {
                    InputOnlineFile inputOnlineFile = new InputOnlineFile(fs, filePathName);
                    await botClient.SendDocumentAsync(chatId, inputOnlineFile);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error uploading: " + ex.Message);
            }
        }


        /// <summary>
        /// Get list of files inside current folder
        /// </summary>
        /// <returns></returns>
        static List<string> GetFilesList()
        {
            List<string> files = new List<string>();

            DirectoryInfo dir = new DirectoryInfo(downloadFolder);

            FileInfo[] Files = dir.GetFiles("*.*");

            foreach (FileInfo file in Files)
            {
                files.Add(file.Name);

            }

            return files;
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

            string fileSuffix = "_File";

            ////Logger.Logging($"chat:[{msg.Chat.Id}] user:[{msg.From.FirstName} {msg.From.LastName}] message:[{msg.Text}]");

            switch (msg.Type)
            {
                case MessageType.Text:

                    var messageText = e.Message.Text;

                    w.Dispatcher.Invoke(() =>
                    {
                        botMessageLog.Add(new MessageLog(DateTime.Now.ToLongTimeString(), messageText, msg.Chat.FirstName, msg.Chat.Id));

                    });

                    CheckTextMessage(msg.Text.ToLower(), msg.Chat.Id);
                    break;

                case MessageType.Document:
                    DownloadFile(msg.Document.FileId, msg.Type.ToString(), msg.Document.FileName, msg.Chat.Id);
                    break;

                case MessageType.Audio:
                    string audioType = msg.Audio.MimeType.Replace(@"audio/", "");

                    DownloadFile(msg.Audio.FileId, msg.Type.ToString(), $@"{msg.Type}{fileSuffix}.{audioType}", msg.Chat.Id);
                    break;

                case MessageType.Photo:
                    DownloadFile(msg.Photo[msg.Photo.Length - 1].FileId, msg.Type.ToString(), $@"/{msg.Type.ToString()}{fileSuffix}.jpg", msg.Chat.Id);
                    break;

                case MessageType.Video:
                    string vidoType = msg.Video.MimeType.Replace(@"video/", "");

                    DownloadFile(msg.Video.FileId, msg.Type.ToString(), $@"{msg.Type.ToString()}{fileSuffix}.{vidoType}", msg.Chat.Id);
                    break;

                default:
                    break;
            }

        }

        /// <summary>
        /// Show the string message
        /// </summary>
        /// <param name="textMessage"></param>
        /// <param name="chatId"></param>
        public void ShowTextMessagae(string textMessage, long chatId)
        {
            w.Dispatcher.Invoke(() =>
            {
                MessageLog newMessage = new MessageLog(DateTime.Now.ToLongTimeString(), textMessage, "Origin!", chatId);
                botMessageLog.Add(newMessage);

                LogTextMessageToJson(newMessage);
            });
        }

        /// <summary>
        /// Save new message in Json file
        /// </summary>
        /// <param name="newMessage"></param>
        private void LogTextMessageToJson(MessageLog newMessage)
        {
            string json = JsonConvert.SerializeObject(newMessage);

            if (File.Exists(@"BotLog.json"))
                File.AppendAllText(@"BotLog.json", json);
            else
                File.WriteAllText(@"BotLog.json", json);
        }


        /// <summary>
        /// Checker for received text messages
        /// </summary>
        /// <param name="textMessage"></param>
        /// <param name="chatId"></param>
        public async void CheckTextMessage(string textMessage, long chatId)
        {
            string replyMessage = "";

            switch (textMessage)
            {
                case "/start":
                    replyMessage = "Хоп-хей ла-ла-лей! \nНу погнали чтоли ..." +
                                   "Можем поболтать или покидаться друг в дружку файлами.\n" +
                                   "Для просмотра списка файлов жмакни /list";
                    break;

                case "/list":
                    replyMessage = ""; 

                    List<string> listOfFiles = GetFilesList();

                    var rkm = new ReplyKeyboardMarkup();
                    var rows = new List<KeyboardButton[]>();
                    var cols = new List<KeyboardButton>();

                    foreach (string f in listOfFiles)
                    {
                        cols.Add(new KeyboardButton(f));
                        rows.Add(cols.ToArray());
                        cols = new List<KeyboardButton>();
                    }

                    rkm.Keyboard = rows.ToArray();
                    await botClient.SendTextMessageAsync(chatId, "Нажми на кнопку - получишь результат ...", replyMarkup: rkm);

                    break;

                default:

                    // check if it's command to upload the file
                    if (textMessage.Contains(".txt") || textMessage.Contains(".jpg") || textMessage.Contains(".mp4") || textMessage.Contains(".mpeg"))
                        UploadFile(chatId, textMessage);
                    else if (!phraser.IsRussian(textMessage))
                        replyMessage = "Hop-hey, la-la-lay! \nI don't know what else to say... \nНо на будущее - говори по русски...)))";
                    else
                        replyMessage = phraser.GetRandomPhrase();

                    break;

            }

            if (replyMessage.Length > 0)
                await botClient.SendTextMessageAsync(chatId, replyMessage);

            w.Dispatcher.Invoke(() =>
            {
                MessageLog newMessage = new MessageLog(DateTime.Now.ToLongTimeString(), replyMessage, "Just Bot!", chatId);
                botMessageLog.Add(newMessage);
                LogTextMessageToJson(newMessage);
            });

        }

    }
}
