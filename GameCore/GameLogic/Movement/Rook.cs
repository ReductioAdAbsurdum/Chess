using System.Collections.Generic;

namespace GameCore
{
    internal static class Rook
    {
        internal static bool AttackingSquare(Square start, Square end)
        {
            if (start.rank != end.rank && start.file != end.file) return false;

            if (start.rank == end.rank) 
            {
                if (start.file < end.file)
                {
                    // Right
                    for (byte i = 1; start.file + i <= end.file; i++)
                    {
                        Square tempPosition = new Square((byte)(start.file + i), start.rank);
                        if (tempPosition.Equals(end)) return true;

                        if (GameState.Board.ContainsKey(tempPosition)) break;
                    }
                }
                else
                {
                    // Left
                    for (byte i = 1; start.file - i >= end.file; i++)
                    {
                        Square tempPosition = new Square((byte)(start.file - i), start.rank);
                        if (tempPosition.Equals(end)) return true;

                        if (GameState.Board.ContainsKey(tempPosition)) break;
                    }
                }
            }
            if (start.file == end.file)
            {
                if (start.rank < end.rank)
                {
                    // Up
                    for (byte i = 1; start.rank + i <= end.rank; i++)
                    {
                        Square tempPosition = new Square(start.file, (byte)(start.rank + i));
                        if (tempPosition.Equals(end)) return true;

                        if (GameState.Board.ContainsKey(tempPosition)) break;
                    }
                }
                else
                {
                    // Down
                    for (byte i = 1; start.rank - i >= end.rank; i++)
                    {
                        Square tempPosition = new Square(start.file, (byte)(start.rank - i));
                        if (tempPosition.Equals(end)) return true;

                        if (GameState.Board.ContainsKey(tempPosition)) break;
                    }
                }
            }

            return false;
        }
        internal static HashSet<Move> LegalMoves(Square start, Color color)
        {
            HashSet<Move> output = new HashSet<Move>();

            // Right
            for (byte i = 1; start.file + i <= 8; i++)
            {
                Square tempPosition = new Square((byte)(start.file + i), start.rank);
                output.AddMove(start, tempPosition, color);

                if (GameState.Board.ContainsKey(tempPosition)) break;
            }
            // Left
            for (byte i = 1; start.file - i >= 1; i++)
            {
                Square tempPosition = new Square((byte)(start.file - i), start.rank);
                output.AddMove(start, tempPosition, color);

                if (GameState.Board.ContainsKey(tempPosition)) break;
            }
            // Up
            for (byte i = 1; start.rank + i <= 8; i++)
            {
                Square tempPosition = new Square(start.file, (byte)(start.rank + i));
                output.AddMove(start, tempPosition, color);

                if (GameState.Board.ContainsKey(tempPosition)) break;
            }
            // Down
            for (byte i = 1; start.rank - i >= 1; i++)
            {
                Square tempPosition = new Square(start.file, (byte)(start.rank - i));
                output.AddMove(start, tempPosition, color);

                if (GameState.Board.ContainsKey(tempPosition)) break;
            }

            return output;
        }
    }
}
