using System;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace Homework_09_Task_01_Core
{
    class Program
    {
        static void Main(string[] args)
        {

            WebClient wc = new WebClient() { Encoding = Encoding.UTF8 };

            string token = "2063385048:AAH20WE4MftspR9hu0Q_C4dxZCm4sz9rrPg";

            int update_id = 0;
            string startUrl = $@"https://api.telegram.org/bot{token}/";



            while (true)
            {
                string url = $"{startUrl}getUpdates?offset={update_id}";
                var r = wc.DownloadString(url);

                Console.WriteLine(r);
                Console.ReadLine();

                var msgs = JObject.Parse(r)["result"];//.to.ToArray();

                foreach (dynamic msg in msgs)
                {
                    update_id = Convert.ToInt32(msg.update_id) + 1;

                    string userMessage = msg.message.text;
                    string userId = msg.message.from.id;
                    string useFirstrName = msg.message.from.first_name;

                    string text = $"{useFirstrName} {userId} {userMessage}";

                    Console.WriteLine(text);

                    if (userMessage == "hi")
                    {
                        string responseText = $"Здравствуйте, {useFirstrName}";
                        url = $"{startUrl}sendMessage?chat_id={userId}&text={responseText}";
                        //Console.WriteLine("+");
                        Console.WriteLine(wc.DownloadString(url));
                    }
                }


                Thread.Sleep(100);
            }



            Console.WriteLine("Status string");
        }
    }
}
