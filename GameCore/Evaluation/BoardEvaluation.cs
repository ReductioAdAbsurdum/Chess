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
           
            bool whiteQueen = false;
            bool blackQueen = false;

            foreach (Square s in GameState.Board.Keys)
            {
                if (GameState.Board[s].type == PieceType.Queen) 
                {
                    if (GameState.Board[s].color == Color.White)
                    {
                        whiteQueen = true;
                        if (blackQueen) break;
                    }
                    else 
                    {
                        blackQueen = true;
                        if (whiteQueen) break;
                    }
                }
            }

            bool endgame = !whiteQueen && !blackQueen;

            foreach (Square s in GameState.Board.Keys)
            {
               output += PieceEvaluation.Evaluate(s, GameState.Board[s].type, GameState.Board[s].color, endgame);
            }

            return output;
        }
    }
}
