
using System.Collections.Generic;

namespace GameCore
{
    public static class LegalMoves
    {
        public static List<Move> GetAll()
        {
            var output = new List<Move>(); 

            foreach (Square s in GameState.Board.Keys)
            {
                Color c = GameState.Board[s].color;
                if (c != GameState.CurrentPlayer) continue;
                
                PieceType p = GameState.Board[s].type;

                output.AddRange(PieceLegalMoves(s, c, p));
            }

            return output;
        }

        private static List<Move> PieceLegalMoves(Square start, Color color , PieceType piece)
        {
            switch (piece)
            {
                case PieceType.Pawn: return Pawn.LegalMoves(start, color);
                case PieceType.Rook: return Rook.LegalMoves(start, color);
                case PieceType.Bishop: return Bishop.LegalMoves(start, color);
                case PieceType.Knight: return Knight.LegalMoves(start, color);
                case PieceType.King: return King.LegalMoves(start, color);
                case PieceType.Queen: return Queen.LegalMoves(start, color);
            }

            return new List<Move>();
        }
    }
}
