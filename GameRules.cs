using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameRules
    {
        public string GetResult(int playerMove, int computerMove, int numMoves)
        {
            int p = numMoves / 2;
            int result = (playerMove - computerMove + p + numMoves) % numMoves - p;
            return result > 0 ? "Player wins" : result < 0 ? "Computer wins" : "Draw";
        }
    }
}
