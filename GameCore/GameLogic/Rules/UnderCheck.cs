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

        internal static bool CheckAfterMove(Move move) 
        {

            // Save pieces
            Piece startPiece = new(GameState.Board[move.start].color, GameState.Board[move.start].type);
        
            Piece endPiece = new Piece();  
            bool endHavePiece = GameState.Board.ContainsKey(move.end);
            if (endHavePiece) endPiece = new(GameState.Board[move.end].color, GameState.Board[move.end].type);

            // Make move
            if (endHavePiece) GameState.Board.Remove(move.end);
            GameState.Board.Remove(move.start);
            GameState.Board.Add(move.end, startPiece);

            // Check 
            bool underCheck = startPiece.color == Color.White ? White() : Black();

            // Back to normal
            GameState.Board.Remove(move.end);
            GameState.Board.Add(move.start, startPiece);
            
            if(endHavePiece) GameState.Board.Add(move.end, endPiece);

            return underCheck;
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


