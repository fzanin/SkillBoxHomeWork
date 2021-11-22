using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_09_Task_01
{
    class PhraseHelper
    {

        private List<string> phraseList;

        public PhraseHelper()
        {
            phraseList = new List<string>();

            using (var sr = new StreamReader("Resources\\StatementBase.dat"))
            {
                while (sr.Peek() >= 0)
                {
                    phraseList.Add(sr.ReadLine());
                }
            }
        }

            
        public string GetPhraseByIndex(int index)
        {
            return phraseList[index].ToString();
        }

        private int GetRandomPhraseNumber()
        {
            Random rand = new Random();

            return rand.Next(0, phraseList.Count);
        }


        public string GetRandomPhrase()
        {
            return GetPhraseByIndex(GetRandomPhraseNumber());
        }


    }
}
