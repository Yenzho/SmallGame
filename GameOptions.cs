using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameOptions
    {
        public List<string> Options { get; private set; }
        public GameOptions(List<string> moves)
        {
            Options = moves;
        }
        public string GetRandomMove()
        {
            Random random = new Random();
            int index = random.Next(Options.Count);
            return Options[index];
        }
    }

}
