using System;

namespace Casino_Dice_Roller
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Grand Circus Casino, lets throw some dice!");

            //declaring variables
            int sides = 0;
            int dice1 = 0;
            int dice2 = 0;
            int score = 0;
            string rollingDice;
            bool keepRolling = true;
            Random randy = new Random();

            //take user input and confirm valid input
            while (keepRolling)
            {
                Console.WriteLine("How many sides would you like on your dice?");

                try
                {
                    sides = int.Parse(Console.ReadLine());
                    //user enters a number over one
                    if (sides < 1)
                    {
                        throw new Exception("A dice must have some sides!");
                    }
                    else
                    {
                        Console.WriteLine("Great!");
                    }
                }
                //user enters gibberish or anything that isnt a number
                catch (FormatException e)
                {
                    Console.WriteLine("That wasn't even a number!");
                    continue;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                //ask user to "roll" the dice

                
                    Console.WriteLine("Would you like to roll your dice? y/n");
                    rollingDice = Console.ReadLine().Trim().ToLower();
                    if (rollingDice == "n")
                    {
                        Console.WriteLine("Oh come on!");
                        break;
                    }
                    else
                    {
                        //user has rolled the dice
                        dice1 = RandomNumber(randy, sides);
                        Console.WriteLine($"Your first dice is a {dice1}");
                        dice2 = RandomNumber(randy, sides);
                        Console.WriteLine($"Your second dice is a {dice2}");
                        score = dice1 + dice2;
                        Console.WriteLine($"That gives you a score of {score}");

                    //Casino rules and dice messages
                    DealersMessage(dice1, dice2, score, sides);

                    }
                
                //ask user to roll again

                Console.WriteLine("Would you like to roll again? y/n");
                string gamble = Console.ReadLine().ToLower();
                if (gamble == "n")
                {
                    keepRolling = false;
                    break;
                }
                else if (gamble == "y")
                {
                    keepRolling = true;
                }

            }
            //method to generate our dice rolls using a random number and the amount of sides chosen
            static int RandomNumber(Random randy, int sides)
            {
                int result = randy.Next(1, sides + 1);
                return result;
            }

            static void DealersMessage(int dice1, int dice2, int score, int sides)
            {
                if (dice1 == 1 && dice2 == 1)
                {
                    Console.WriteLine("Snake Eyes! Two one's!");

                }
                else if ((dice1 == 1 && dice2 == 2) || (dice1 == 2 && dice2 == 1))
                {
                    Console.WriteLine("Ace Deuce! A one and a two!");

                }
                if (dice1 == 6 && dice2 == 6)
                {
                    Console.WriteLine("Boxcar! Two sixes!");

                }
                else if (dice1 + dice2 == 7 || dice1 + dice2 == 11)
                {
                    Console.WriteLine("Win!");

                }
                if (dice1 + dice2 == 2 || dice1 + dice2 == 3 || dice1 + dice2 == 12)
                {
                    Console.WriteLine("Craps!");
                }
            }
        }
    }
}
