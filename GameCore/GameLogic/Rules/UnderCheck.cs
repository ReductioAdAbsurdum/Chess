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
            // White player
            if (GameState.CurrentPlayer == Color.White) 
            {
                // King's move
                if (move.start.Equals(GameState.WhiteKingPosition)) 
                {
                    return BlackAttackingSquare(move.end);
                }

                // Other's move
                return BlackAttackingSquareWithoutPiece(GameState.WhiteKingPosition, move.end, move.end, move.start);
            }
            // Black player
            else
            {
                // King's move
                if (move.start.Equals(GameState.BlackKingPosition))
                {
                    return WhiteAttackingSquare(move.end);
                }

                // Other's move
                return WhiteAttackingSquareWithoutPiece(GameState.BlackKingPosition, move.end, move.end, move.start);
            }
        }

        // When we move King
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
        private static bool PieceAttackingSquare(Square start, Square end)
        {
            switch (GameState.Board[start].type)
            {
                case PieceType.Pawn: return Pawn.AttackingSquare(start, end);

                case PieceType.Rook: return Rook.AttackingSquare(start, end, new Square(20, 20), new Square(20, 20));

                case PieceType.Bishop: return Bishop.AttackingSquare(start, end, new Square(20, 20), new Square(20, 20));

                case PieceType.Knight: return Knight.AttackingSquare(start, end);

                case PieceType.King: return King.AttackingSquare(start, end);

                case PieceType.Queen: return Queen.AttackingSquare(start, end, new Square(20, 20), new Square(20, 20));
            }

            return false;
        }

        // When we move other piece
        internal static bool WhiteAttackingSquareWithoutPiece(Square target, Square pieceSquare, Square block, Square empty)
        {
            foreach (KeyValuePair<Square, Piece> pair in GameState.Board)
            {
                if (pair.Value.color == Color.Black) continue;
                if (pair.Key.Equals(pieceSquare)) continue;

                if (PieceAttackingSquare(pair.Key, target, block, empty)) return true;
            }

            return false;
        }
        internal static bool BlackAttackingSquareWithoutPiece(Square target, Square pieceSquare, Square block, Square empty)
        {
            foreach (KeyValuePair<Square, Piece> pair in GameState.Board)
            {
                if (pair.Value.color == Color.White) continue;
                if (pair.Key.Equals(pieceSquare)) continue;

                if (PieceAttackingSquare(pair.Key, target, block, empty)) return true;
            }

            return false;
        }        
        private static bool PieceAttackingSquare(Square start, Square end, Square block, Square empty) 
        {
            switch (GameState.Board[start].type)
            {
                case PieceType.Pawn: return Pawn.AttackingSquare(start, end);

                case PieceType.Rook: return Rook.AttackingSquare(start, end, block, empty);

                case PieceType.Bishop: return Bishop.AttackingSquare(start, end, block, empty);

                case PieceType.Knight: return Knight.AttackingSquare(start, end);

                case PieceType.King: return King.AttackingSquare(start, end);

                case PieceType.Queen: return Queen.AttackingSquare(start, end, block, empty);
            }

            return false;
        }
        
        
    }
}


