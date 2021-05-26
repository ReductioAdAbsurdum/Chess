using System.Collections.Generic;

namespace GameCore
{
    public static class LegalMoves
    {
        public static HashSet<Move> GetAll()
        {
            HashSet<Move> output = new HashSet<Move>();

            var squares = new List<Square>(GameState.Board.Keys);

            for (int i = 0; i < squares.Count; i++)
            {
                Color c = GameState.Board[squares[i]].color;
                if (c != GameState.CurrentPlayer) continue;

                Square s = squares[i];      
                
                PieceType p = GameState.Board[squares[i]].type;

                output.UnionWith(PieceLegalMoves(s, c, p));
            }

            return output;
        }

        private static HashSet<Move> PieceLegalMoves(Square start, Color color , PieceType piece)
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

            return new HashSet<Move>();
        }
    }
}
