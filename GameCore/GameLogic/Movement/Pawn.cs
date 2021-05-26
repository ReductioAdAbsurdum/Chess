using System.Collections.Generic;

namespace GameCore
{
    internal static class Pawn
    {
        internal static HashSet<Square> AttackingSquares(Square start)
        {
            HashSet<Square> output = new HashSet<Square>();

            // White pawn
            if (GameState.Board[start].color == Color.White)
            {
                if (start.file >= 2) output.Add(new Square((byte)(start.file - 1), (byte)(start.rank + 1)));
                if (start.file <= 7) output.Add(new Square((byte)(start.file + 1), (byte)(start.rank + 1)));
            }
            // Black pawn
            else
            {
                if (start.file >= 2) output.Add(new Square((byte)(start.file - 1), (byte)(start.rank - 1)));
                if (start.file <= 7) output.Add(new Square((byte)(start.file + 1), (byte)(start.rank - 1)));
            }

            return output;
        }
        internal static HashSet<Move> LegalMoves(Square start, Color color)
        {
            if (color == Color.White) return WhiteLegalMoves(start, color);
            return BlackLegalMoves(start, color);
        }

        private static HashSet<Move> WhiteLegalMoves(Square start, Color color)
        {
            HashSet<Move> output = new HashSet<Move>();

            // Attacking
            if (start.file >= 2)
            {              
                output.AddPawnMoveIfValid(start, new Square((byte)(start.file - 1), (byte)(start.rank + 1)), color);
            }
            if (start.file <= 7)
            {
                output.AddPawnMoveIfValid(start, new Square((byte)(start.file + 1), (byte)(start.rank + 1)), color);
            }

            // Move           
            Square tempPositionOneUp = new Square(start.file, (byte)(start.rank + 1));
            if (!GameState.Board.ContainsKey(tempPositionOneUp))
            {
                output.AddPawnMoveIfValid(start, tempPositionOneUp, color);

                Square tempPositionTwoUp = new Square(start.file, (byte)(start.rank + 2));

                if (!GameState.Board.ContainsKey(tempPositionTwoUp))
                {
                    output.AddPawnMoveIfValid(start, tempPositionTwoUp, color);
                }
            }

            // En Passant
            if (start.file + 1 == GameState.EnPassantFile)
            {
                output.AddMoveIfValid(start, new Square((byte)(start.rank + 1), (byte)(start.file + 1)), color);
            }
            if (start.file - 1 == GameState.EnPassantFile)
            {
                output.AddMoveIfValid(start, new Square((byte)(start.rank + 1), (byte)(start.file - 1)), color);
            }

            return output;
        }
        private static HashSet<Move> BlackLegalMoves(Square start, Color color)
        {
            HashSet<Move> output = new HashSet<Move>();

            // Attacking
            if (start.file >= 2)
            {
                output.AddPawnMoveIfValid(start, new Square((byte)(start.file - 1), (byte)(start.rank - 1)), color);
            }
            if (start.file <= 7)
            {
                output.AddPawnMoveIfValid(start, new Square((byte)(start.file + 1), (byte)(start.rank - 1)), color);
            }

            // Move           
            Square tempPositionOneDown = new Square(start.file, (byte)(start.rank - 1));

            if (!GameState.Board.ContainsKey(tempPositionOneDown))
            {
                output.AddPawnMoveIfValid(start, tempPositionOneDown, color);

                Square tempPositionTwoDown = new Square(start.file, (byte)(start.rank - 2));

                if (!GameState.Board.ContainsKey(tempPositionTwoDown))
                {
                    output.AddPawnMoveIfValid(start, tempPositionTwoDown, color);
                }
            }

            // En Passant
            if (start.file + 1 == GameState.EnPassantFile)
            {
                output.AddMoveIfValid(start, new Square((byte)(start.rank - 1), (byte)(start.file + 1)), color);
            }
            if (start.file - 1 == GameState.EnPassantFile)
            {
                output.AddMoveIfValid(start, new Square((byte)(start.rank - 1), (byte)(start.file - 1)), color);
            }

            return output;
        }
    }
}