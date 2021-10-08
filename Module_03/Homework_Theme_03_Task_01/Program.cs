using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_03_Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Create game objects
            // create game for 2 players
            GameEngine gameEngine = new GameEngine(2);

            // create game rules object
            GameRules gameRules = new GameRules();
            #endregion

            string pressedKey = "";

            do
            {
                #region New game initialization
                Console.Clear();

                // initialize new game
                gameEngine.NewGameInit();

                // show game rules
                gameRules.ShowAnimatedGameRules();

                // show question marks
                gameEngine.ShowPlayerMessage("", 0, 2, 4, "С Д Е Л А Й   Н О Л Ь !", true, ConsoleColor.Red);

                // show question marks
                gameEngine.ShowPlayerMessage("", 6, 2, 4, "Game Number", true, ConsoleColor.Green);

                // ask players to input name
                for (int i = 1; i < gameEngine.totalPlayers + 1; i++)
                {
                    switch (i)
                    {
                        case 1:
                            gameEngine.playerOneName = gameEngine.InputPlayerName($"Игрок {i}, Имя: ", 6, 1, gameEngine.totalPlayers + 2);
                            break;
                        case 2:
                            gameEngine.playerTwoName = gameEngine.InputPlayerName($"Игрок {i}, Имя: ", 6, 3, gameEngine.totalPlayers + 2);
                            break;
                        case 3:
                            gameEngine.playerThreeName = gameEngine.InputPlayerName($"Игрок {i}, Имя: ", 6, 3, gameEngine.totalPlayers + 2);
                            break;
                        case 4:
                            gameEngine.playerFourName = gameEngine.InputPlayerName($"Игрок {i}, Имя: ", 6, 3, gameEngine.totalPlayers + 2);
                            break;
                    }
                }

                gameEngine.ShowPlayerMessage("", 7, 2, 4, $"  {gameEngine.gameNumber}  ", true, ConsoleColor.Green);
                #endregion

                #region Play game
                // start game
                gameEngine.PlayOneGame();
                #endregion

                // ask for revange
                gameEngine.ShowPlayerMessage("", Console.CursorTop, 2, 4, "Хотите сыграть реванш? Если да, то нажмите [Y]", false, ConsoleColor.Cyan);
                pressedKey = Console.ReadLine();

            } while ((pressedKey == "Y") || (pressedKey == "y"));
        }
    }
}
