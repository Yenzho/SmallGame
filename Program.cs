
using System.Xml.Linq;


namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the extended version of Rock, Paper, Scissors!");

            int numberOfMoves = Moves.GetNumberOfMoves();
            List<string> moves = Moves.GetMoves(numberOfMoves);

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