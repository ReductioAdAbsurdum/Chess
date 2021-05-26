using System.Collections.Generic;

namespace GameCore
{
    internal static class Rook
    {
        internal static HashSet<Square> AttackingSquares(Square origin)
        {
            HashSet<Square> output = new HashSet<Square>();

            // Right
            for (byte i = 1; origin.file + i <= 8; i++)
            {
                Square tempPosition = new Square((byte)(origin.file + i), origin.rank);
                output.Add(tempPosition);

                if (GameState.Board.ContainsKey(tempPosition)) break;
            }
            // Left
            for (byte i = 1; origin.file - i >= 1; i++)
            {
                Square tempPosition = new Square((byte)(origin.file - i), origin.rank);
                output.Add(tempPosition);

                if (GameState.Board.ContainsKey(tempPosition)) break;
            }
            // Up
            for (byte i = 1; origin.rank + i <= 8; i++)
            {
                Square tempPosition = new Square(origin.file, (byte)(origin.rank + i));
                output.Add(tempPosition);

                if (GameState.Board.ContainsKey(tempPosition)) break;
            }
            // Down
            for (byte i = 1; origin.rank - i >= 1; i++)
            {
                Square tempPosition = new Square(origin.file, (byte)(origin.rank - i));
                output.Add(tempPosition);

                if (GameState.Board.ContainsKey(tempPosition)) break;
            }

            return output;
        }
    }
}
