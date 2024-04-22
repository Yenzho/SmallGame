using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Moves
    {
        public static List<string> GetMovesFromArgs(string[] args)
        {
            if (args.Length < 3 || args.Length % 2 == 0)
            {
                Console.WriteLine("Error: Invalid number of moves provided. Please provide an odd number of moves greater than or equal to 3.");
                return null; 
            }

            return new List<string>(args);
        }
    }
}
