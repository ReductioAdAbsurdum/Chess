using System;
using System.Collections.Generic;

namespace GameCore
{
    internal static class Knight
    {
        internal static bool AttackingSquare(Square origin, Square target)
        {
            if ((origin.file + origin.rank + target.file + target.rank) % 2 == 0) return false;

            if (Math.Abs(origin.rank - target.rank) == 2 && Math.Abs(origin.file - target.file) == 1) return true;

            if (Math.Abs(origin.rank - target.rank) == 1 && Math.Abs(origin.file - target.file) == 2) return true;

            return false;
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
                    output.AddMove(start, new Square((byte)(start.file + 2), (byte)(start.rank + 1)), color);
                }
                // Down
                if (start.rank >= 2)
                {
                    output.AddMove(start, new Square((byte)(start.file + 2), (byte)(start.rank - 1)), color);
                }
            }
            // Two Left
            if (start.file >= 3)
            {
                // Up
                if (start.rank <= 7)
                {
                    output.AddMove(start, new Square((byte)(start.file - 2), (byte)(start.rank + 1)), color);
                }
                // Down
                if (start.rank >= 2)
                {
                    output.AddMove(start, new Square((byte)(start.file - 2), (byte)(start.rank - 1)), color);
                }
            }
            // Two Up
            if (start.rank <= 6)
            {
                // Right
                if (start.file <= 7)
                {
                    output.AddMove(start, new Square((byte)(start.file + 1), (byte)(start.rank + 2)), color);
                }
                // Left
                if (start.file >= 2)
                {
                    output.AddMove(start, new Square((byte)(start.file - 1), (byte)(start.rank + 2)), color);
                }
            }
            // Two Down
            if (start.rank >= 3)
            {
                // Right
                if (start.file <= 7)
                {
                    output.AddMove(start, new Square((byte)(start.file + 1), (byte)(start.rank - 2)), color);
                }
                // Left
                if (start.file >= 2)
                {
                    output.AddMove(start, new Square((byte)(start.file - 1), (byte)(start.rank - 2)), color);
                }
            }

            return output;
        }
    }
 }

