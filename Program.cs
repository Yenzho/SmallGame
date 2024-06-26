﻿
using System.Xml.Linq;


namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 3 || args.Length % 2 == 0)
            {
                Console.WriteLine("Error: An odd number of moves greater than or equal to 3 must be provided.");
                return;
            }

            if (args.Distinct().Count() != args.Length)
            {
                Console.WriteLine("Error: Duplicate moves are not allowed. Each move must be unique.");
                return;
            }

            Console.WriteLine("Welcome to the extended version of Rock, Paper, Scissors!");

            List<string> moves = new List<string>(args);
            GameOptions options = new GameOptions(moves);
            CryptoGenerator crypto = new CryptoGenerator();

            do
            {
                Console.WriteLine("\n================== New Game ==================\n");
                string computerChoice = options.GetRandomMove();
                string hmac = crypto.GenerateHMAC(computerChoice);

                Console.WriteLine($"HMAC: {hmac}");
                Console.WriteLine("Available moves:");
                for (int i = 0; i < options.Options.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {options.Options[i]}");
                }
                Console.WriteLine("0 - Exit");
                Console.WriteLine("? - Help");

                Console.Write("Enter your move (or '?' for help): ");
                string userInput = Console.ReadLine();

                if (userInput == "?")
                {
                    Console.WriteLine("The table below describes the outcomes from the user's perspective.");
                    HelpTable.PrintHelpTable(options);
                    continue;
                }

                if (int.TryParse(userInput, out int userMove))
                {
                    if (userMove == 0)
                    {
                        Console.WriteLine("Game exited.");
                        break;
                    }
                    else if (userMove > 0 && userMove <= options.Options.Count)
                    {
                        string userChoice = options.Options[userMove - 1];
                        Console.WriteLine($"Your move: {userChoice}");
                        Console.WriteLine($"Computer move: {computerChoice}");

                        GameRules rules = new GameRules();
                        string result = rules.GetResult(userMove - 1, options.Options.IndexOf(computerChoice), options.Options.Count);
                        Console.WriteLine(result);

                        Console.WriteLine($"HMAC key: {crypto.GetKey()}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid move. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid move number.");
                }

            } while (true);
        }
    }
}