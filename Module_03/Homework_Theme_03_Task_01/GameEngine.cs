using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_03_Task_01
{
    class GameEngine
    {
        //string playerComputer;

        // variables of player names (better to use list)
        public string playerOneName;
        public string playerTwoName;
        public string playerThreeName;
        public string playerFourName;

        // game variables
        public int userTry;
        public int stepCounter;
        public int totalPlayers;
        public int totalScreenPositions;
        public string currentPlayerName;
        public int currentPlayerScreenPos;
        public int gameNumber;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="setNumberOfPlayers"></param>
        public GameEngine(int setNumberOfPlayers)
        {
            totalPlayers = setNumberOfPlayers;
            totalScreenPositions = totalPlayers + 2;
            NewGameInit();
        }

        /// <summary>
        /// Initialize new game variables
        /// </summary>
        public void NewGameInit()
        {
            stepCounter = 1;

            // generate random game number
            Random randomize = new Random();
            gameNumber = randomize.Next(12, 121);
        }


        /// <summary>
        /// Make player name input
        /// </summary>
        /// <param name="textMessage"></param>
        /// <param name="textPosition"></param>
        /// <param name="totalPosition"></param>
        /// <param name="textColor"></param>
        /// <returns></returns>
        public string InputPlayerName(string textMessage, int textTop, int textPosition, int totalPosition, ConsoleColor textColor = ConsoleColor.White)
        {
            Console.CursorTop = textTop;
            Console.CursorLeft = Console.WindowWidth * textPosition / totalPosition - textMessage.Length / 2;
            Console.ForegroundColor = textColor;
            Console.Write(textMessage);
            return Console.ReadLine();
        }


        /// <summary>
        /// Show message to player
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="playerPosition"></param>
        /// <param name="totalPosition"></param>
        /// <param name="playerMessage"></param>
        /// <param name="newLineFlag"></param>
        public void ShowPlayerMessage(string playerName, int textTop, int textPosition, int totalPosition, string playerMessage, bool newLineFlag = false, ConsoleColor textColor = ConsoleColor.White)
        {
            Console.CursorTop = textTop;
            Console.CursorLeft = Console.WindowWidth * textPosition / totalPosition - ($"{playerName}{playerMessage}").Length / 2;
            Console.ForegroundColor = textColor;

            if (newLineFlag)
                Console.WriteLine($"{playerName}{playerMessage}");
            else
                Console.Write($"{playerName}{playerMessage}");
        }


        /// <summary>
        /// Method for player try
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="playerPosition"></param>
        /// <param name="totalPosition"></param>
        /// <returns></returns>
        public int PlayerTry(string playerName, int playerPosition, int totalPosition)
        {
            int intTry = -1;
            while (intTry == -1)
            {
                ShowPlayerMessage(playerName, Console.CursorTop, playerPosition, totalPosition, ", ваш ход: ");

                intTry = ValidatePlayerInput(Console.ReadLine());

                // check if input was not correct ask user to make input again
                if (intTry == -1) 
                {
                    ShowPlayerMessage(playerName, Console.CursorTop, playerPosition, totalPosition, ", ошибка ввода. Попробуйте еще раз. ", true, ConsoleColor.Red);
                }
            }

            return intTry;
        }

        /// <summary>
        /// Validate input of player and convert to int
        /// </summary>
        /// <param name="inputToCheck"></param>
        /// <returns></returns>
        public int ValidatePlayerInput(string inputToCheck)
        {
            if (inputToCheck == "1" || inputToCheck == "2" || inputToCheck == "3" || inputToCheck == "4")
                return Convert.ToInt32(inputToCheck);
            else
                return -1;
        }

        /// <summary>
        /// main game loop
        /// </summary>
        public void PlayOneGame()
        {

            while (gameNumber > 0)
            {

                if (stepCounter % 2 == 0)
                {
                    currentPlayerName = playerTwoName;
                    currentPlayerScreenPos = 3;
                }
                else
                {
                    currentPlayerName = playerOneName;
                    currentPlayerScreenPos = 1;
                }

                // player make next try
                userTry = PlayerTry(currentPlayerName, currentPlayerScreenPos, totalScreenPositions);

                gameNumber -= userTry;

                // check for wrong player try
                if (gameNumber < 0)
                {
                    ShowPlayerMessage(currentPlayerName, Console.CursorTop, currentPlayerScreenPos, totalScreenPositions, ", вы пропускаете ход ", true, ConsoleColor.Red);
                    gameNumber += userTry;
                }

                // check for game end
                if (gameNumber == 0)
                {
                    ShowPlayerMessage(currentPlayerName, Console.CursorTop, currentPlayerScreenPos, totalScreenPositions, ", вы выиграли!!! ", true, ConsoleColor.Yellow);
                    break;
                }

                // show new value of game number
                ShowPlayerMessage("", Console.CursorTop, 2, 4, $"  {gameNumber}  ", true, ConsoleColor.Green);

                // increment game step counter
                stepCounter++;
            }

        }

    }
}
