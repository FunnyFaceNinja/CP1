// Written by Dr. Shane Wilson.
// The author licenses this file to you under the MIT license.
// See the LICENSE file in the solution root for more information.

namespace GamblersRuin
{
    /// <summary>
    /// This example of Gambler's ruin has been written incorrectly to demonstrate code analysis and formatting tools within visual studio. This line is therefore excessively long for a reason!
    /// 
    /// The class Gambler provides a simple implementation of Gambler's ruin. The code starts by asking
    /// the player for their starting pot, then their target goal.The game should then simulate the
    ///throwing of two dice.If the value of the dice thrown is <6 then the player wins €1, otherwise
    /// they loose €1. The game continues until the value of their pot = goal, or they lose all of their
    ///money.After each game the player should be asked if they would like to play again. If they do,
    ///then they should be asked once again for their starting pot and goal.For more information see:
    ///https://en.wikipedia.org/wiki/Gambler%27s_ruin
    /// </summary>
    public static class Gambler
    {

        private static int s_bets = 0;
        private static int s_gameWins = 0;
        private static int s_winningThrows = 0;
        private static string s_play_again_response = "Y";

        public static void Play_Game()
        {
            while (s_play_again_response == "Y")
            {
                int pot = GetPot();
                int goal = GetGoal();
                while (pot > 0 && pot < goal)
                {
                    //gameplay
                    s_bets++;
                    int roll = Rolldice();
                    Console.WriteLine("\nThrowing the dice....");
                    Console.WriteLine("You threw a:  " + roll);

                    if (roll < 6)
                    {
                        pot++;
                        s_winningThrows++;
                        Console.WriteLine($"Congratulations you won 1 and you now have: {pot}");
                    }
                    else
                    {
                        pot--;
                        Console.WriteLine($"Bad luck, you lost 1 and you now have: {pot}");
                    }

                }
                if (pot == goal)
                {
                    s_gameWins++;
                    Console.Write(
                        "\n\nCongratulations, you beat Gambler's Ruin. Would you like to try your luck again?"
                            + " y/n: ");
                }
                else
                {
                    Console.Write("\n\nToo bad, you lost to Gambler's Ruin. "
                        + "Would you like to try your luck again? y/n: ");
                }
                string response = Console.ReadLine()!.ToUpper();
                s_play_again_response = response;
            }
            PrintStats();
        }

        static void PrintStats()
        {
            Console.WriteLine("Thank you for playing Gambler's Ruin");
            Console.WriteLine("\n\nYour game statistics are:");
            Console.WriteLine("Number of throws: " + s_bets);
            Console.WriteLine("Number of winning throws: " + s_winningThrows);
            Console.WriteLine("Percentage wins : " + 100.0 * s_winningThrows / s_bets);
            Console.WriteLine("Winning games : " + s_gameWins);
        }


        static int GetPot()
        {

            Console.Write("How what is your opening pot:");
            short openingPot = Convert.ToInt16(Console.ReadLine());
            return openingPot;
        }

        static int GetGoal()
        {

            Console.Write("What is your goal amount:");
            short goal = Convert.ToInt16(Console.ReadLine());
            return goal;
        }

        static int Rolldice()
        {
            var rand = new Random();
            return rand.Next(2, 12);
        }

    }
}


