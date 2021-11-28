using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Homework_10_Task_01_Core.Helpers
{
    class PhraseHelper
    {
        private List<string> phraseList;

        /// <summary>
        /// Constructor
        /// </summary>
        public PhraseHelper()
        {
            // initialize the phraser
            phraseList = new List<string>();

            // load phrases from data file
            using (var sr = new StreamReader("Resources\\StatementBase.dat"))
            {
                while (sr.Peek() >= 0)
                {
                    phraseList.Add(sr.ReadLine());
                }
            }
        }

        /// <summary>
        /// Get the phrase from list by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetPhraseByIndex(int index)
        {
            return phraseList[index].ToString();
        }

        /// <summary>
        /// Generate randomize index inside phrases range
        /// </summary>
        /// <returns></returns>
        private int GetRandomPhraseNumber()
        {
            Random rand = new Random();

            return rand.Next(0, phraseList.Count);
        }

        /// <summary>
        /// Generate randomize phrase
        /// </summary>
        /// <returns></returns>
        public string GetRandomPhrase()
        {
            return GetPhraseByIndex(GetRandomPhraseNumber());
        }

        /// <summary>
        /// Check if all chars in string are in russian language
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool IsRussian(string text)
        {
            bool rus = true;

            text = text.ToLower();

            byte[] Ch = Encoding.Default.GetBytes(text);
            foreach (byte ch in Ch)
            {
                if ((ch >= 97) && (ch <= 122)) rus = false; // check if even one char is english
                //if ((ch >= 224) && (ch <= 255)) rus = true; // here we can check for rus chars
            }

            return rus;
        }
    }
}
