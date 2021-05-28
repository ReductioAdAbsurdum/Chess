using System;
using System.Collections.Generic;

namespace GameCore
{
    internal static class Pawn
    {
        internal static bool AttackingSquare(Square start, Square end)
        {
            if ((start.file + start.rank + end.file + end.rank) % 2 != 0) return false;

            // White pawn
            if (GameState.Board[start].color == Color.White)
            {
                if (start.rank + 1 == end.rank && Math.Abs(start.file - end.file) == 1) return true;

                return false;
            }
            // Black pawn
            else
            {
                if (start.rank - 1 == end.rank && Math.Abs(start.file - end.file) == 1) return true;

                return false;
            }
        }
        internal static List<Move> LegalMoves(Square start, Color color)
        {
            if (color == Color.White) return WhiteLegalMoves(start, color);
            return BlackLegalMoves(start, color);
        }

        private static List<Move> WhiteLegalMoves(Square start, Color color)
        {
            List<Move> output = new List<Move>();

            // Attacking
            if (start.file >= 2)
            {              
                output.AddPawnAttackMove(start, new Square((byte)(start.file - 1), (byte)(start.rank + 1)), color);
            }
            if (start.file <= 7)
            {
                output.AddPawnAttackMove(start, new Square((byte)(start.file + 1), (byte)(start.rank + 1)), color);
            }

            // Push           
            Square tempPositionOneUp = new Square(start.file, (byte)(start.rank + 1));
            if (!GameState.Board.ContainsKey(tempPositionOneUp))
            {
                output.AddPawnMove(start, tempPositionOneUp, color);

                Square tempPositionTwoUp = new Square(start.file, (byte)(start.rank + 2));

                if (!GameState.Board.ContainsKey(tempPositionTwoUp) && start.rank == 2)
                {
                    output.AddPawnMove(start, tempPositionTwoUp, color);
                }
            }

            // En Passant
            if (start.file + 1 == GameState.EnPassantFile && start.rank == 5)
            {
                output.AddMoveInfo(start, new Square((byte)(start.rank + 1), (byte)(start.file + 1)), color, MoveInfo.EnPassant);
            }
            if (start.file - 1 == GameState.EnPassantFile && start.rank == 4)
            {
                output.AddMoveInfo(start, new Square((byte)(start.rank + 1), (byte)(start.file - 1)), color, MoveInfo.EnPassant);
            }

            return output;
        }
        private static List<Move> BlackLegalMoves(Square start, Color color)
        {
            List<Move> output = new List<Move>();

            // Attacking
            if (start.file >= 2)
            {
                output.AddPawnAttackMove(start, new Square((byte)(start.file - 1), (byte)(start.rank - 1)), color);
            }
            if (start.file <= 7)
            {
                output.AddPawnAttackMove(start, new Square((byte)(start.file + 1), (byte)(start.rank - 1)), color);
            }

            // Push           
            Square tempPositionOneDown = new Square(start.file, (byte)(start.rank - 1));

            if (!GameState.Board.ContainsKey(tempPositionOneDown))
            {
                output.AddPawnMove(start, tempPositionOneDown, color);

                Square tempPositionTwoDown = new Square(start.file, (byte)(start.rank - 2));

                if (!GameState.Board.ContainsKey(tempPositionTwoDown) && start.rank == 7)
                {
                    output.AddPawnMove(start, tempPositionTwoDown, color);
                }
            }

            // En Passant
            if (start.file + 1 == GameState.EnPassantFile && start.rank == 4)
            {
                output.AddMoveInfo(start, new Square((byte)(start.rank - 1), (byte)(start.file + 1)), color, MoveInfo.EnPassant);
            }
            if (start.file - 1 == GameState.EnPassantFile && start.rank == 4)
            {
                output.AddMoveInfo(start, new Square((byte)(start.rank - 1), (byte)(start.file - 1)), color, MoveInfo.EnPassant);
            }

            return output;
        }
    }
}