using System.Collections.Generic;

namespace GameCore
{
    internal static class Rook
    {
        internal static HashSet<Square> AttackingSquares(Square start)
        {
            HashSet<Square> output = new HashSet<Square>();

            // Right
            for (byte i = 1; start.file + i <= 8; i++)
            {
                Square tempPosition = new Square((byte)(start.file + i), start.rank);
                output.Add(tempPosition);

                if (GameState.Board.ContainsKey(tempPosition)) break;
            }
            // Left
            for (byte i = 1; start.file - i >= 1; i++)
            {
                Square tempPosition = new Square((byte)(start.file - i), start.rank);
                output.Add(tempPosition);

                if (GameState.Board.ContainsKey(tempPosition)) break;
            }
            // Up
            for (byte i = 1; start.rank + i <= 8; i++)
            {
                Square tempPosition = new Square(start.file, (byte)(start.rank + i));
                output.Add(tempPosition);

                if (GameState.Board.ContainsKey(tempPosition)) break;
            }
            // Down
            for (byte i = 1; start.rank - i >= 1; i++)
            {
                Square tempPosition = new Square(start.file, (byte)(start.rank - i));
                output.Add(tempPosition);

                if (GameState.Board.ContainsKey(tempPosition)) break;
            }

            return output;
        }
        internal static HashSet<Move> LegalMoves(Square start, Color color)
        {
            HashSet<Move> output = new HashSet<Move>();

            // Right
            for (byte i = 1; start.file + i <= 8; i++)
            {
                Square tempPosition = new Square((byte)(start.file + i), start.rank);
                output.AddMoveIfValid(start, tempPosition, color);

                if (GameState.Board.ContainsKey(tempPosition)) break;
            }
            // Left
            for (byte i = 1; start.file - i >= 1; i++)
            {
                Square tempPosition = new Square((byte)(start.file - i), start.rank);
                output.AddMoveIfValid(start, tempPosition, color);

                if (GameState.Board.ContainsKey(tempPosition)) break;
            }
            // Up
            for (byte i = 1; start.rank + i <= 8; i++)
            {
                Square tempPosition = new Square(start.file, (byte)(start.rank + i));
                output.AddMoveIfValid(start, tempPosition, color);

                if (GameState.Board.ContainsKey(tempPosition)) break;
            }
            // Down
            for (byte i = 1; start.rank - i >= 1; i++)
            {
                Square tempPosition = new Square(start.file, (byte)(start.rank - i));
                output.AddMoveIfValid(start, tempPosition, color);

                if (GameState.Board.ContainsKey(tempPosition)) break;
            }

            return output;
        }
    }
}
