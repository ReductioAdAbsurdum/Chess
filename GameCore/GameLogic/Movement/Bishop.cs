using System.Collections.Generic;

namespace GameCore
{
    internal static class Bishop
    {
        internal static bool AttackingSquare(Square start, Square end)
        {
            if ((start.file + start.rank + end.file + end.rank) % 2 != 0) return false;

            if (start.rank < end.rank)
            {
                if (start.file < end.file) // UpRight
                {
                    for (byte i = 1; start.rank + i <= end.rank && start.file <= end.file; i++)
                    {
                        Square s = new Square((byte)(start.file + i), (byte)(start.rank + i));
                        if (s.Equals(end)) return true;

                        if (GameState.Board.ContainsKey(s)) return false;
                    }
                    return false;
                }
                else // UpLeft
                {
                    for (byte i = 1; start.rank + i <= end.rank && start.file >= end.file; i++)
                    {
                        Square s = new Square((byte)(start.file - i), (byte)(start.rank + i));
                        if (s.Equals(end)) return true;

                        if (GameState.Board.ContainsKey(s)) return false;
                    }
                    return false;
                }
            }
            else
            {
                if (start.file < end.file) 
                {
                    // DownRight
                    for (byte i = 1; start.rank - i >= end.rank && start.file <= end.file; i++)
                    {
                        Square s = new Square((byte)(start.file + i), (byte)(start.rank - i));
                        if (s.Equals(end)) return true;

                        if (GameState.Board.ContainsKey(s)) return false;
                    }
                    return false;
                }
                // DownLeft
                for (byte i = 1; start.rank - i >= end.rank && start.file >= end.file; i++)
                {
                    Square s = new Square((byte)(start.file - i), (byte)(start.rank - i));
                    if (s.Equals(end)) return true;

                    if (GameState.Board.ContainsKey(s)) return false;
                }
                return false;
            }
        }

        internal static List<Move> LegalMoves(Square start, Color color)
        {
            List<Move> output = new List<Move>();

            // UpRight
            for (byte i = 1; start.file + i <= 8 && start.rank + i <= 8; i++)
            {
                Square s = new Square((byte)(start.file + i), (byte)(start.rank + i));
                output.AddMove(start, s, color);

                if (GameState.Board.ContainsKey(s)) break;
            }
            // UpLeft
            for (byte i = 1; start.file - i  >= 1 && start.rank + i <= 8; i++)
            {
                Square s = new Square((byte)(start.file - i), (byte)(start.rank + i));
                output.AddMove(start, s, color);

                if (GameState.Board.ContainsKey(s)) break;
            }
            // DownRight
            for (byte i = 1; start.file + i <= 8 && start.rank - i >=1 ; i++)
            {
                Square s = new Square((byte)(start.file + i), (byte)(start.rank - i));
                output.AddMove(start, s, color);

                if (GameState.Board.ContainsKey(s)) break;
            }
            // DownLeft
            for (byte i = 1; start.file - i >= 1 && start.rank - i >= 1 ; i++)
            {
                Square s = new Square((byte)(start.file - i), (byte)(start.rank - i));
                output.AddMove(start, s, color);

                if (GameState.Board.ContainsKey(s)) break;
            }

            return output;
        }
    }
}
