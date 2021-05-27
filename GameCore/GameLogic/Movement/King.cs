using System;
using System.Collections.Generic;

namespace GameCore
{
    internal static class King
    {
        internal static bool AttackingSquare(Square start, Square end)
        {
            if ((start.file + start.rank + end.file + end.rank) % 2 == 0) return false;

            if (
                (Math.Abs(start.file - end.file) == 1 || Math.Abs(start.file - end.file) == 0) &&
                (Math.Abs(start.rank - end.rank) == 1 || Math.Abs(start.rank - end.rank) == 0)
                ) return true;


            return false;
        }

        internal static List<Move> LegalMoves(Square start, Color color)
        {
            List<Move> output = new List<Move>();

            // Up
            if (start.rank <= 7) 
            {
                output.AddMove(start, new Square((byte)(start.file), (byte)(start.rank + 1)), color);
            }
            // Down
            if (start.rank >= 2) 
            {
                output.AddMove(start, new Square((byte)(start.file), (byte)(start.rank - 1)), color);
            }

            if (start.file <= 7)
            {
                //Right
                output.AddMove(start, new Square((byte)(start.file + 1), (byte)(start.rank)), color);

                // UpRight
                if (start.rank <= 7)
                {
                    output.AddMove(start, new Square((byte)(start.file + 1), (byte)(start.rank + 1)), color);
                }

                // DownRight
                if (start.rank >= 2) 
                {
                    output.AddMove(start, new Square((byte)(start.file + 1), (byte)(start.rank - 1)), color);
                }
            }
            if (start.file >= 2)
            {
                //Left
                output.AddMove(start, new Square((byte)(start.file - 1), (byte)(start.rank)), color);

                // UpLeft
                if (start.rank <= 7) 
                {
                    output.AddMove(start, new Square((byte)(start.file - 1), (byte)(start.rank + 1)), color);
                }

                // DownLeft
                if (start.rank >= 2) 
                {
                    output.AddMove(start, new Square((byte)(start.file - 1), (byte)(start.rank - 1)), color);
                }
            }

            return output;
        }
    }
}
