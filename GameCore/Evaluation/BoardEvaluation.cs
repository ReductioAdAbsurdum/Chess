using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore.Evaluation
{
    public static class BoardEvaluation
    {
        public static int Evaluate() 
        {
            int output = 0;

            foreach (Square s in GameState.Board.Keys)
            {
                Color c = GameState.Board[s].color;
                if (c != GameState.CurrentPlayer) continue;

                output += PieceEvaluation.Evaluate(s, GameState.Board[s].type, c, false);
            }

            return output;
        }
    }
}
