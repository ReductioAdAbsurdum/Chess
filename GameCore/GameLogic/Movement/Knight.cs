using System;
using System.Collections.Generic;

namespace GameCore
{
    internal static class Knight
    {
        internal static bool AttackingSquare(Square start, Square end)
        {
            // Oposite color check
            if ((start.file + start.rank + end.file + end.rank) % 2 == 0) return false;

            // Two-up/down or one-left/right
            if (Math.Abs(start.rank - end.rank) == 2 && Math.Abs(start.file - end.file) == 1) return true;

            // Two-left/right or one-up/down
            if (Math.Abs(start.rank - end.rank) == 1 && Math.Abs(start.file - end.file) == 2) return true;

            return false;
        }
        
        internal static List<Move> LegalMoves(Square start, Color color)
        {
            List<Move> output = new List<Move>();

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

