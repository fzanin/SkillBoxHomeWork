using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_03_Task_03
{        
    /// <summary>
    /// Class with rules of the game
    /// </summary>
    class GameRules
    {
        // local variables to keep window size
        private readonly int windowHight;
        private readonly int windowWidth;

        // define varibales to keep game rule as separate string lines
        public string RuleText01;   // line 01   
        public string RuleText02;   // line 02
        public string RuleText03;   // line 03
        public string RuleText04;   // line 04
        public string RuleTextEmpty; // empty string

        /// <summary>
        /// Constructor to create object with game rules
        /// </summary>
        public GameRules()
        {
            // get window size
            this.windowHight = Console.WindowHeight;
            this.windowWidth = Console.WindowWidth;


            // fill game rule to separate variables
            RuleText01 = "       Загадывается число от 12 до 120, причём случайным образом. Назовём его gameNumber.       ";
            RuleText02 = "Игроки по очереди выбирают число от одного до четырёх. Пусть это число обозначается как userTry.";
            RuleText03 = "   UserTry после каждого хода вычитается из gameNumber, а само gameNumber выводится на экран.   ";
            RuleText04 = " Если после хода игрока gameNumber равняется нулю, то походивший игрок оказывается победителем. ";
            RuleTextEmpty = "                                                                                                ";
        }


        /// <summary>
        /// Show animated game rules
        /// </summary>
        public void ShowAnimatedGameRules()
        {
            int idx = 4;
            int maxTextLength = 0;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.CursorTop = windowHight - 4;

            maxTextLength = Math.Max(maxTextLength, RuleText01.Length);
            maxTextLength = Math.Max(maxTextLength, RuleText02.Length);
            maxTextLength = Math.Max(maxTextLength, RuleText03.Length);
            maxTextLength = Math.Max(maxTextLength, RuleText04.Length);

            do
            {
                Console.CursorLeft = windowWidth / 2 - RuleText01.Length / 2;
                Console.WriteLine(RuleText01);

                Console.CursorLeft = windowWidth / 2 - RuleText02.Length / 2;
                Console.WriteLine(RuleText02);

                Console.CursorLeft = windowWidth / 2 - RuleText03.Length / 2;
                Console.WriteLine(RuleText03);

                Console.CursorLeft = windowWidth / 2 - RuleText04.Length / 2;
                Console.WriteLine(RuleText04);

                Console.CursorLeft = windowWidth / 2 - RuleTextEmpty.Length / 2;
                Console.Write(RuleTextEmpty);


                System.Threading.Thread.Sleep(150);

                idx++;
                Console.CursorTop = Math.Max(0, windowHight - idx);

            } while (Console.CursorTop > 0);

        }

    }
}
