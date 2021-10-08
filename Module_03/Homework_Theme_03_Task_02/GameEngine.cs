using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_03_Task_02
{
    class GameEngine
    {
        //string playerComputer;

        // variables of player names (better to use list)
        public string playerOneName;
        public string playerTwoName;
        public string playerThreeName;
        public string playerFourName;
        public string playerFiveName;

        // game variables
        public int userTry;
        public int userTryMin;
        public int userTryMax;

        public int totalPlayers;
        public int totalScreenPositions;
        string currentPlayerName;
        int currentPlayerScreenPos;
        int currentPlayerCounter;

        public int gameNumber;
        public int gameNumberMin;
        public int gameNumberMax;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="setNumberOfPlayers"></param>
        public GameEngine()
        {

            gameNumberMin = 12;
            gameNumberMax = 120;

            //NewGameInit();
        }

        /// <summary>
        /// Initialize new game variables
        /// </summary>
        public void NewGameInit()
        {
            currentPlayerCounter = 1;
            //totalScreenPositions = 1;

            totalPlayers = GetPlayersNumber("Введите число игроков [2-5]: ", 1, totalScreenPositions);

            totalScreenPositions = totalPlayers + 2;

            gameNumberMin = GetIntInput("Введите минимальное  игровое число: ", Console.CursorTop, 1, totalScreenPositions);
            gameNumberMax = GetIntInput("Введите максимальное игровое число: ", Console.CursorTop, 1, totalScreenPositions);

            userTryMin = GetIntInput("Введите минимальный  ход: ", Console.CursorTop, 1, totalScreenPositions);
            userTryMax = GetIntInput("Введите максимальный ход: ", Console.CursorTop, 1, totalScreenPositions);


            // generate random game number
            Random randomize = new Random();
            gameNumber = randomize.Next(gameNumberMin, gameNumberMax + 1);
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

            if (totalPosition != 0)
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
            if (totalPosition != 0)
                Console.CursorLeft = Math.Max(Console.WindowWidth * textPosition / totalPosition - ($"{playerName}{playerMessage}").Length / 2, 0);

            Console.ForegroundColor = textColor;

            if (newLineFlag)
                Console.WriteLine($"{playerName}{playerMessage}");
            else
                Console.Write($"{playerName}{playerMessage}");
        }


        public int GetIntInput(string text, int textTop, int textPosition, int totalPosition, bool newLineFlag = false, ConsoleColor textColor = ConsoleColor.White)
        {
            int intTry = -1;

            //Console.CursorTop = textTop;
            //Console.CursorLeft = Console.WindowWidth * textPosition / totalPosition - ($"{text}").Length / 2;
            //Console.ForegroundColor = textColor;

            while (intTry == -1)
            {
                ShowPlayerMessage("", textTop, textPosition, totalPosition, text, newLineFlag, textColor);

                intTry = ValidateIntInput(Console.ReadLine());

            }

            return intTry;
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

                intTry = ValidateIntInput(Console.ReadLine());

                // check, if input was not correct ask user to make input again
                if ((intTry == -1) || (intTry < userTryMin) || (intTry > userTryMax))
                {
                    ShowPlayerMessage(playerName, Console.CursorTop, playerPosition, totalPosition, ", ошибка ввода. Попробуйте еще раз. ", true, ConsoleColor.Red);
                    intTry = -1;
                }
            }

            return intTry;
        }


        public int GetPlayersNumber(string text, int textPosition, int totalPosition)
        {
            int intTry = -1;
            while (intTry == -1)
            {
                ShowPlayerMessage(text, Console.CursorTop, textPosition, totalPosition, "");

                intTry = ValidateIntInput(Console.ReadLine());

                // check, if input was not correct ask user to make input again
                if ((intTry == -1) || (intTry < 2) || (intTry > 5))
                {
                    ShowPlayerMessage("Ошибка ввода. Число игроков должно быть от 2 до 5. ", Console.CursorTop, textPosition, totalPosition, "Еще раз. ", true, ConsoleColor.Red);
                    intTry = -1;
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
        /// Validate input for number
        /// </summary>
        /// <param name="inputToCheck"></param>
        /// <returns></returns>
        public int ValidateIntInput(string inputToCheck)
        {
            bool success = Int32.TryParse(inputToCheck, out int number);

            if (success)
                return number;
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

                switch (currentPlayerCounter)
                {
                    case 1:
                        currentPlayerName = playerOneName;
                        currentPlayerScreenPos = 1;
                        break;
                    case 2:
                        currentPlayerName = playerTwoName;
                        currentPlayerScreenPos = 1;
                        break;
                    case 3:
                        currentPlayerName = playerThreeName;
                        currentPlayerScreenPos = 1;
                        break;
                    case 4:
                        currentPlayerName = playerFourName;
                        currentPlayerScreenPos = 1;
                        break;
                    case 5:
                        currentPlayerName = playerFiveName;
                        currentPlayerScreenPos = 1;
                        break;
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

                if (currentPlayerCounter == totalPlayers)
                    currentPlayerCounter = 1; // reset player counter
                else
                    currentPlayerCounter++;   // increment player counter
            }

        }

    }
}
