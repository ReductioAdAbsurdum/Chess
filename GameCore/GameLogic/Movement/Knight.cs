using System.Collections.Generic;

namespace GameCore
{
    internal static class Knight
    {
        internal static HashSet<Square> AttackingSquares(Square origin)
        {
            HashSet<Square> output = new HashSet<Square>();

            // Two Right
            if (origin.file <= 6)
            {
                // Up
                if (origin.rank <= 7) output.Add(new Square((byte)(origin.file + 2), (byte)(origin.rank + 1)));
                // Down
                if (origin.rank >= 2) output.Add(new Square((byte)(origin.file + 2), (byte)(origin.rank - 1)));             
            }
            // Two Left
            if (origin.file >= 3)
            {
                // Up
                if (origin.rank <= 7) output.Add(new Square((byte)(origin.file - 2), (byte)(origin.rank + 1)));
                // Down
                if (origin.rank >= 2) output.Add(new Square((byte)(origin.file - 2), (byte)(origin.rank - 1)));
            }
            // Two Up
            if (origin.rank <= 6)
            {
                // Right
                if (origin.file <= 7) output.Add(new Square((byte)(origin.file + 1), (byte)(origin.rank + 2)));
                // Left
                if (origin.file >= 2) output.Add(new Square((byte)(origin.file - 1), (byte)(origin.rank + 2)));
            }
            // Two Down
            if (origin.rank >= 3)
            {
                // Right
                if (origin.file <= 7) output.Add(new Square((byte)(origin.file + 1), (byte)(origin.file - 2)));
                // Left
                if (origin.file >= 2) output.Add(new Square((byte)(origin.file - 1), (byte)(origin.rank - 2)));
            }

            return output;
        }

        internal static HashSet<Move> LegalMoves(Square start, Color color)
        {
            HashSet<Move> output = new HashSet<Move>();

            // Two Right
            if (start.file <= 6)
            {
                // Up
                if (start.rank <= 7)
                {
                    output.AddMoveIfValid(start, new Square((byte)(start.file + 2), (byte)(start.rank + 1)), color);
                }
                // Down
                if (start.rank >= 2)
                {
                    output.AddMoveIfValid(start, new Square((byte)(start.file + 2), (byte)(start.rank - 1)), color);
                }
            }
            // Two Left
            if (start.file >= 3)
            {
                // Up
                if (start.rank <= 7)
                {
                    output.AddMoveIfValid(start, new Square((byte)(start.file - 2), (byte)(start.rank + 1)), color);
                }
                // Down
                if (start.rank >= 2)
                {
                    output.AddMoveIfValid(start, new Square((byte)(start.file - 2), (byte)(start.rank - 1)), color);
                }
            }
            // Two Up
            if (start.rank <= 6)
            {
                // Right
                if (start.file <= 7)
                {
                    output.AddMoveIfValid(start, new Square((byte)(start.file + 1), (byte)(start.rank + 2)), color);
                }
                // Left
                if (start.file >= 2)
                {
                    output.AddMoveIfValid(start, new Square((byte)(start.file - 1), (byte)(start.rank + 2)), color);
                }
            }
            // Two Down
            if (start.rank >= 3)
            {
                // Right
                if (start.file <= 7)
                {
                    output.AddMoveIfValid(start, new Square((byte)(start.file + 1), (byte)(start.rank - 2)), color);
                }
                // Left
                if (start.file >= 2)
                {
                    output.AddMoveIfValid(start, new Square((byte)(start.file - 1), (byte)(start.rank - 2)), color);
                }
            }

            return output;
        }
    }
 }

