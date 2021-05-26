using System.Collections.Generic;

namespace GameCore
{
    internal static class UnderCheck
    {
        internal static bool White()
        {
            foreach (KeyValuePair<Square, Piece> pair in GameState.Board)
            {
                if (pair.Value.color == Color.White) continue;
                  
                if (PieceAttackingSquare(pair.Key, GameState.WhiteKingPosition)) return true;
            }

            return false;
        }
        internal static bool Black()
        {
            foreach (KeyValuePair<Square, Piece> pair in GameState.Board)
            {
                if (pair.Value.color == Color.Black) continue;

                if (PieceAttackingSquare(pair.Key, GameState.WhiteKingPosition)) return true;
            }

            return false;
        }

        private static bool PieceAttackingSquare(Square origin, Square target) 
        {
            switch (GameState.Board[origin].type)
            {
                case PieceType.Pawn: return Pawn.AttackingSquares(origin).Contains(target);

                case PieceType.Rook: return Rook.AttackingSquares(origin).Contains(target);

                case PieceType.Bishop: return Bishop.AttackingSquares(origin).Contains(target);

                case PieceType.Knight: return Knight.AttackingSquares(origin).Contains(target);

                case PieceType.King: return King.AttackingSquares(origin).Contains(target);

                case PieceType.Queen: return Queen.AttackingSquares(origin).Contains(target);
            }

            return false;
        }
    }
}


