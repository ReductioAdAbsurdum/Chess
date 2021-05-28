using System;
using System.Collections.Generic;

namespace GameCore
{
    internal static class King
    {
        internal static bool AttackingSquare(Square start, Square end)
        {
            return (
                (Math.Abs(start.file - end.file) == 1 || Math.Abs(start.file - end.file) == 0) &&
                (Math.Abs(start.rank - end.rank) == 1 || Math.Abs(start.rank - end.rank) == 0)
                );
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

            // Castle

            if (color == Color.White) // White
            {
                // King under check
                if (GameState.UnderCheckWhite) return output;

                if (GameState.CastleWhite_OO)
                {
                    Square s1 = new Square(6, 1);
                    Square s2 = new Square(7, 1);

                    // Free squares
                    if (GameState.Board.ContainsKey(s1)) return output;
                    if (GameState.Board.ContainsKey(s2)) return output;

                    // Not attacked squares
                    if (UnderCheck.AttackingSquareBlack(s1)) return output;
                    if (UnderCheck.AttackingSquareBlack(s2)) return output;

                    output.Add(new Move(start, s2, MoveInfo.White_OO));
                }
                if (GameState.CastleWhite_OOO)
                {
                    Square s1 = new Square(4, 1);
                    Square s2 = new Square(3, 1);

                    // Free squares
                    if (GameState.Board.ContainsKey(s1)) return output;
                    if (GameState.Board.ContainsKey(s2)) return output;

                    // Not attacked squares
                    if (UnderCheck.AttackingSquareBlack(s1)) return output;
                    if (UnderCheck.AttackingSquareBlack(s2)) return output;

                    output.Add(new Move(start, s2, MoveInfo.White_OOO));
                }
            }
            else // Black
            {
                // King under check
                if (GameState.UnderCheckBlack) return output;

                if (GameState.CastleBlack_OO)
                {
                    Square s1 = new Square(6, 8);
                    Square s2 = new Square(7, 8);

                    // Free squares
                    if (GameState.Board.ContainsKey(s1)) return output;
                    if (GameState.Board.ContainsKey(s2)) return output;

                    // Not attacked squares
                    if (UnderCheck.AttackingSquareWhite(s1)) return output;
                    if (UnderCheck.AttackingSquareWhite(s2)) return output;

                    output.Add(new Move(start, s2, MoveInfo.Black_OO));
                }
                if (GameState.CastleBlack_OOO)
                {
                    Square s1 = new Square(6, 8);
                    Square s2 = new Square(7, 8);

                    // Free squares
                    if (GameState.Board.ContainsKey(s1)) return output;
                    if (GameState.Board.ContainsKey(s2)) return output;

                    // Not attacked squares
                    if (UnderCheck.AttackingSquareWhite(s1)) return output;
                    if (UnderCheck.AttackingSquareWhite(s2)) return output;

                    output.Add(new Move(start, s2, MoveInfo.Black_OOO));
                }

            }

            return output;
        }
    }
}
