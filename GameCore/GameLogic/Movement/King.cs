using System.Collections.Generic;

namespace GameCore
{
    internal static class King
    {
        internal static HashSet<Square> AttackingSquares(Square start)
        {
            HashSet<Square> output = new HashSet<Square>();

            // Up
            if (start.rank <= 7) output.Add(new Square(start.file, (byte)(start.rank + 1)));
            // Down
            if (start.rank >= 2) output.Add(new Square(start.file, (byte)(start.rank - 1)));

            if (start.file <= 7)
            {
                //Right
                output.Add(new Square((byte)(start.file + 1), start.rank));

                // UpRight
                if (start.rank <= 7) output.Add(new Square((byte)(start.file + 1), (byte)(start.rank + 1)));

                // DownRight
                if (start.rank >= 2) output.Add(new Square((byte)(start.file + 1), (byte)(start.rank - 1)));
            }
            if (start.file >= 2)
            {
                //Left
                output.Add(new Square((byte)(start.file - 1), start.rank));

                // UpLeft
                if (start.rank <= 7) output.Add(new Square((byte)(start.file - 1), (byte)(start.rank + 1)));

                // DownLeft
                if (start.rank >= 2) output.Add(new Square((byte)(start.file - 1), (byte)(start.rank - 1)));
            }

            return output;
        }

        internal static HashSet<Move> LegalMoves(Square start, Color color)
        {
            HashSet<Move> output = new HashSet<Move>();

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
