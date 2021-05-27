using System;
using System.Collections.Generic;

namespace GameCore
{
    internal static class King
    {
        internal static bool AttackingSquare(Square start, Square end)
        {
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

            if (UnderCheck.CurrentPlayer() == false)
            {
                if (color == Color.White) // White
                {
                    if (GameState.CastleWhite_OO)
                    {
                        if (UnderCheck.BlackAttackingSquare(new Square(6, 1))) return output;
                        if (UnderCheck.BlackAttackingSquare(new Square(7, 1))) return output;
                        output.Add(new Move(start, new Square(7, 1), MoveInfo.White_OO));
                    }
                    if (GameState.CastleWhite_OOO)
                    {
                        if (UnderCheck.BlackAttackingSquare(new Square(4, 1))) return output;
                        if (UnderCheck.BlackAttackingSquare(new Square(3, 1))) return output;
                        output.Add(new Move(start, new Square(3, 1), MoveInfo.White_OOO));
                    }
                }
                else // Black
                {
                    if (GameState.CastleBlack_OO)
                    {
                        if (UnderCheck.WhiteAttackingSquare(new Square(6, 8))) return output;
                        if (UnderCheck.WhiteAttackingSquare(new Square(7, 8))) return output;
                        output.Add(new Move(start, new Square(7, 8), MoveInfo.Black_OO));
                    }
                    if (GameState.CastleBlack_OOO)
                    {
                        if (UnderCheck.WhiteAttackingSquare(new Square(4, 8))) return output;
                        if (UnderCheck.WhiteAttackingSquare(new Square(3, 8))) return output;
                        output.Add(new Move(start, new Square(3, 8), MoveInfo.Black_OOO));
                    }
                }
            }

            return output;
        }
    }
}
