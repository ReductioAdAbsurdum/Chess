using System.Collections.Generic;

namespace GameCore
{
    internal static class Bishop
    {
        internal static HashSet<Square> AttackingSquares(Square origin)
        {
            HashSet<Square> output = new HashSet<Square>();

            // UpRight
            for (byte i = 1; origin.file + i <= 8 && origin.rank + i <= 8; i++)
            {
                Square tempPosition = new Square((byte)(origin.file + i), (byte)(origin.rank + i));
                output.Add(tempPosition);

                if (GameState.Board.ContainsKey(tempPosition)) break;

            }
            // UpLeft
            for (byte i = 1; origin.file - i <= 8 && origin.rank + i <= 8; i++)
            {
                Square tempPosition = new Square((byte)(origin.file - i), (byte)(origin.rank + i));
                output.Add(tempPosition);

                if (GameState.Board.ContainsKey(tempPosition)) break;

            }
            // DownRight
            for (byte i = 1; origin.file + i <= 8 && origin.rank - i <= 8; i++)
            {
                Square tempPosition = new Square((byte)(origin.file + i), (byte)(origin.rank - i));
                output.Add(tempPosition);

                if (GameState.Board.ContainsKey(tempPosition)) break;

            }
            // DownLeft
            for (byte i = 1; origin.file - i <= 8 && origin.rank - i <= 8; i++)
            {
                Square tempPosition = new Square((byte)(origin.file - i), (byte)(origin.rank - i));
                output.Add(tempPosition);

                if (GameState.Board.ContainsKey(tempPosition)) break;

            }

            return output;
        }
    }
}
