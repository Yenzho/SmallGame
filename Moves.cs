using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Moves
    {
        public static int GetNumberOfMoves()
        {
            int number;
            do
            {
                Console.WriteLine("Enter an odd number of moves, minimum 3:");
                if (!int.TryParse(Console.ReadLine(), out number) || number < 3 || number % 2 == 0)
                {
                    Console.WriteLine("Invalid number. Please enter an odd number greater than or equal to 3.");
                }
                else
                {
                    return number;
                }
            } while (true);
        }

        public static List<string> GetMoves(int numberOfMoves)
        {
            HashSet<string> moves = new HashSet<string>();
            while (moves.Count < numberOfMoves)
            {
                Console.WriteLine($"Enter a unique name for move {moves.Count + 1} of {numberOfMoves}:");
                string move = Console.ReadLine().Trim();
                if (!moves.Add(move))
                {
                    Console.WriteLine("This move has already been added. Please enter a different one.");
                }
            }
            return new List<string>(moves);
        }
    }
}
