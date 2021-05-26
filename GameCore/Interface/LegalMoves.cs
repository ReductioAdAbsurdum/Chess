using System;
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

        private static HashSet<Move> PieceLegalMoves(Square origin, Color color , PieceType piece)
        {
            switch (piece)
            {
                //case PieceType.Pawn:
                //case PieceType.Rook:
                //case PieceType.Bishop:
                case PieceType.Knight: return Knight.LegalMoves(origin, color);
                //case PieceType.King:
                //case PieceType.Queen:
            }

            return new HashSet<Move>();
        }
    }
}
