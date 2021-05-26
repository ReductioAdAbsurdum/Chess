using System.Collections.Generic;

namespace GameCore
{
    public static class Queen
    {
        internal static HashSet<Square> AttackingSquares(Square origin)
        {
            HashSet<Square> output = new HashSet<Square>();

            // Rook moves

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
            
            //Bishop moves

            // UpRight
            for (byte i = 1; origin.file + i <= 8 && origin.rank + i <= 8; i++)
            {
                Square tempPosition = new Square((byte)(origin.file + i), (byte)(origin.rank + i));
                output.Add(tempPosition);

                if (GameState.Board.ContainsKey(tempPosition)) break;

            } 
            // UpLeft
            for (byte i = 1; origin.file - i >= 1 && origin.rank + i <= 8; i++)
            {
                Square tempPosition = new Square((byte)(origin.file - i), (byte)(origin.rank + i));
                output.Add(tempPosition);

                if (GameState.Board.ContainsKey(tempPosition)) break;

            }
            // DownRight
            for (byte i = 1; origin.file + i <= 8 && origin.rank - i >= 1; i++)
            {
                Square tempPosition = new Square((byte)(origin.file + i), (byte)(origin.rank - i));
                output.Add(tempPosition);

                if (GameState.Board.ContainsKey(tempPosition)) break;

            }
            // DownLeft
            for (byte i = 1; origin.file - i >= 1 && origin.rank - i >= 1; i++)
            {
                Square tempPosition = new Square((byte)(origin.file - i), (byte)(origin.rank - i));
                output.Add(tempPosition);

                if (GameState.Board.ContainsKey(tempPosition)) break;

            }

            return output;
        }
        internal static HashSet<Move> LegalMoves(Square start, Color color)
        {
            HashSet<Move> output = new HashSet<Move>();
            
            //Rook Moves

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

            //Bishop Moves

            // UpRight
            for (byte i = 1; start.file + i <= 8 && start.rank + i <= 8; i++)
            {
                Square tempPosition = new Square((byte)(start.file + i), (byte)(start.rank + i));
                output.AddMoveIfValid(start, tempPosition, color);

                if (GameState.Board.ContainsKey(tempPosition)) break;
            }
            // UpLeft
            for (byte i = 1; start.file - i >= 1 && start.rank + i <= 8; i++)
            {
                Square tempPosition = new Square((byte)(start.file - i), (byte)(start.rank + i));
                output.AddMoveIfValid(start, tempPosition, color);

                if (GameState.Board.ContainsKey(tempPosition)) break;
            }
            // DownRight
            for (byte i = 1; start.file + i <= 8 && start.rank - i >= 1; i++)
            {
                Square tempPosition = new Square((byte)(start.file + i), (byte)(start.rank - i));
                output.AddMoveIfValid(start, tempPosition, color);

                if (GameState.Board.ContainsKey(tempPosition)) break;
            }
            // DownLeft
            for (byte i = 1; start.file - i >= 1 && start.rank - i >= 1; i++)
            {
                Square tempPosition = new Square((byte)(start.file - i), (byte)(start.rank - i));
                output.AddMoveIfValid(start, tempPosition, color);

                if (GameState.Board.ContainsKey(tempPosition)) break;
            }

            return output;
        }
    }
}
