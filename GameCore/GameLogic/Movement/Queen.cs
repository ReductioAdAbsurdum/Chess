using System.Collections.Generic;

namespace GameCore
{
    public static class Queen
    {
        internal static bool AttackingSquare(Square start, Square end, Square block, Square empty)
        {
            return Bishop.AttackingSquare(start, end, block, empty) || Rook.AttackingSquare(start, end, block, empty);
        }
        internal static List<Move> LegalMoves(Square start, Color color)
        {
            List<Move> output = new List<Move>();
            
            //Rook Moves

            // Right
            for (byte i = 1; start.file + i <= 8; i++)
            {
                Square tempPosition = new Square((byte)(start.file + i), start.rank);
                output.AddMove(start, tempPosition, color);

                if (GameState.Board.ContainsKey(tempPosition)) break;
            }
            // Left
            for (byte i = 1; start.file - i >= 1; i++)
            {
                Square tempPosition = new Square((byte)(start.file - i), start.rank);
                output.AddMove(start, tempPosition, color);

                if (GameState.Board.ContainsKey(tempPosition)) break;
            }
            // Up
            for (byte i = 1; start.rank + i <= 8; i++)
            {
                Square tempPosition = new Square(start.file, (byte)(start.rank + i));
                output.AddMove(start, tempPosition, color);

                if (GameState.Board.ContainsKey(tempPosition)) break;
            }
            // Down
            for (byte i = 1; start.rank - i >= 1; i++)
            {
                Square tempPosition = new Square(start.file, (byte)(start.rank - i));
                output.AddMove(start, tempPosition, color);

                if (GameState.Board.ContainsKey(tempPosition)) break;
            }

            //Bishop Moves

            // UpRight
            for (byte i = 1; start.file + i <= 8 && start.rank + i <= 8; i++)
            {
                Square tempPosition = new Square((byte)(start.file + i), (byte)(start.rank + i));
                output.AddMove(start, tempPosition, color);

                if (GameState.Board.ContainsKey(tempPosition)) break;
            }
            // UpLeft
            for (byte i = 1; start.file - i >= 1 && start.rank + i <= 8; i++)
            {
                Square tempPosition = new Square((byte)(start.file - i), (byte)(start.rank + i));
                output.AddMove(start, tempPosition, color);

                if (GameState.Board.ContainsKey(tempPosition)) break;
            }
            // DownRight
            for (byte i = 1; start.file + i <= 8 && start.rank - i >= 1; i++)
            {
                Square tempPosition = new Square((byte)(start.file + i), (byte)(start.rank - i));
                output.AddMove(start, tempPosition, color);

                if (GameState.Board.ContainsKey(tempPosition)) break;
            }
            // DownLeft
            for (byte i = 1; start.file - i >= 1 && start.rank - i >= 1; i++)
            {
                Square tempPosition = new Square((byte)(start.file - i), (byte)(start.rank - i));
                output.AddMove(start, tempPosition, color);

                if (GameState.Board.ContainsKey(tempPosition)) break;
            }

            return output;
        }
    }
}
