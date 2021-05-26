using System.Collections.Generic;

namespace GameCore
{
    internal static class Pawn
    {
        internal static HashSet<Square> AttackingSquares(Square origin)
        {
            HashSet<Square> output = new HashSet<Square>();

            // White pawn

            if (GameState.Board[origin].color == Color.White)
            {
                if (origin.file >= 2) output.Add(new Square((byte)(origin.file - 1), (byte)(origin.rank + 1)));
                if (origin.file <= 7) output.Add(new Square((byte)(origin.file + 1), (byte)(origin.rank + 1)));
            }
            // Black pawn
            else
            {
                if (origin.file >= 2) output.Add(new Square((byte)(origin.file - 1), (byte)(origin.rank - 1)));
                if (origin.file <= 7) output.Add(new Square((byte)(origin.file + 1), (byte)(origin.rank - 1)));
            }

            return output;
        }

        internal static HashSet<Square> MoveSquares(Square origin)
        {
            HashSet<Square> output = new HashSet<Square>();

            // White pawn
            if (GameState.Board[origin].color == Color.White)
            {
                Square tempPositionOneUp = new Square(origin.file, (byte)(origin.rank + 1));
                if (!GameState.Board.ContainsKey(tempPositionOneUp))
                {
                    output.Add(tempPositionOneUp);

                    Square tempPositionTwoUp = new Square(origin.file, (byte)(origin.rank + 2));

                    if (!GameState.Board.ContainsKey(tempPositionTwoUp)) output.Add(tempPositionTwoUp);                   

                }
            }
            // Black pawn
            else
            {
                Square tempPositionOneDown = new Square(origin.file, (byte)(origin.rank - 1));

                if (!GameState.Board.ContainsKey(tempPositionOneDown))

                {
                    output.Add(tempPositionOneDown);

                    Square tempPositionTwoDown = new Square(origin.file, (byte)(origin.rank - 2));

                    if (!GameState.Board.ContainsKey(tempPositionTwoDown)) output.Add(tempPositionTwoDown);

                }
            }

            return output;
        }

        internal static HashSet<Square> EnPassantSquare(Square origin)
        {
            HashSet<Square> output = new HashSet<Square>();

            // White pawn
            if (GameState.Board[origin].color == Color.White)
            {
                if (origin.file + 1 == GameState.EnPassantFile) output.Add(new Square((byte)(origin.rank + 1), (byte)(origin.file + 1)));
                if (origin.file - 1 == GameState.EnPassantFile) output.Add(new Square((byte)(origin.rank + 1), (byte)(origin.file - 1)));

            }
            // Black pawn
            else
            {

                if (origin.file + 1 == GameState.EnPassantFile) output.Add(new Square((byte)(origin.rank - 1), (byte)(origin.file + 1)));
                if (origin.file - 1 == GameState.EnPassantFile) output.Add(new Square((byte)(origin.rank - 1), (byte)(origin.file - 1)));
            }

            return output;
        }
    }
}
