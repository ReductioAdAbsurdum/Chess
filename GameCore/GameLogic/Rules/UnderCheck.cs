using System.Collections.Generic;

namespace GameCore
{
    internal static class UnderCheck
    {
        internal static bool CurrentPlayer() 
        {
            if (GameState.CurrentPlayer == Color.White) return BlackAttackingSquare(GameState.WhiteKingPosition);
            
            return WhiteAttackingSquare(GameState.BlackKingPosition);
        }
        internal static bool AfterMove(Move move) 
        {
            // Save pieces
            Piece startPiece = new(GameState.Board[move.start].color, GameState.Board[move.start].type);           
        
            Piece endPiece = new Piece();  
            bool endHavePiece = GameState.Board.ContainsKey(move.end);
            if (endHavePiece) endPiece = new(GameState.Board[move.end].color, GameState.Board[move.end].type);

            // Make move
            if (startPiece.type == PieceType.King)
            {
                if (startPiece.color == Color.White)
                {
                    GameState.WhiteKingPosition = move.end;
                }
                else 
                {
                    GameState.BlackKingPosition = move.end;
                }
            }

            if (endHavePiece) GameState.Board.Remove(move.end);
            GameState.Board.Remove(move.start);
            GameState.Board.Add(move.end, startPiece);

            // Check 
            bool underCheck = CurrentPlayer();

            // Back to normal
            if (startPiece.type == PieceType.King)
            {
                if (startPiece.color == Color.White)
                {
                    GameState.WhiteKingPosition = move.start;
                }
                else
                {
                    GameState.BlackKingPosition = move.start;
                }
            }
            GameState.Board.Remove(move.end);
            GameState.Board.Add(move.start, startPiece);
            
            if(endHavePiece) GameState.Board.Add(move.end, endPiece);

            return underCheck;
        }

        internal static bool WhiteAttackingSquare(Square square) 
        {
            foreach (KeyValuePair<Square, Piece> pair in GameState.Board)
            {
                if (pair.Value.color == Color.Black) continue;

                if (PieceAttackingSquare(pair.Key, square)) return true;
            }

            return false;
        }
        internal static bool BlackAttackingSquare(Square square)
        {
            foreach (KeyValuePair<Square, Piece> pair in GameState.Board)
            {
                if (pair.Value.color == Color.White) continue;

                if (PieceAttackingSquare(pair.Key, square)) return true;
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

                case PieceType.Knight: return Knight.AttackingSquare(origin, target);

                case PieceType.King: return King.AttackingSquares(origin).Contains(target);

                case PieceType.Queen: return Queen.AttackingSquares(origin).Contains(target);
            }

            return false;
        }    
    }
}


