using System.Collections.Generic;

namespace GameCore
{
    internal static class King
    {
        internal static HashSet<Square> AttackingSquares(Square origin)
        {
            HashSet<Square> output = new HashSet<Square>();

            // Up
            if (origin.rank <= 7) output.Add(new Square(origin.file, (byte)(origin.rank + 1)));
            // Down
            if (origin.file >= 2) output.Add(new Square(origin.file, (byte)(origin.rank - 1)));

            if (origin.file <= 7)
            {
                //Right
                output.Add(new Square((byte)(origin.file + 1), origin.rank));

                // UpRight
                if (origin.rank <= 7) output.Add(new Square((byte)(origin.file + 1), (byte)(origin.rank + 1)));

                // DownRight
                if (origin.rank >= 2) output.Add(new Square((byte)(origin.file + 1), (byte)(origin.rank - 1)));
            }
            if (origin.file >= 2)
            {
                //Left
                output.Add(new Square((byte)(origin.file - 1), origin.rank));

                // UpLeft
                if (origin.rank <= 7) output.Add(new Square((byte)(origin.file - 1), (byte)(origin.rank + 1)));

                // DownLeft
                if (origin.rank >= 2) output.Add(new Square((byte)(origin.file - 1), (byte)(origin.rank - 1)));
            }

            return output;
        }
    }
}
