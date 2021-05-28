using System;
using System.Collections.Generic;

namespace GameCore
{
    internal static class Bishop
    {
        internal static bool AttackingSquare(Square start, Square end, Square block, Square empty)
        {
            // Oposite color square check
            if ((start.file + start.rank + end.file + end.rank) % 2 != 0) return false;

            // Not on L
            if(Math.Abs(start.file-end.file) != Math.Abs(start.rank - end.rank)) return false;

            if (start.rank < end.rank)
            {
                if (start.file < end.file) // UpRight
                {
                    for (byte i = 1; start.rank + i <= end.rank && start.file <= end.file; i++)
                    {
                        Square s = new Square((byte)(start.file + i), (byte)(start.rank + i));
                        if (s.Equals(end)) return true;

                        // Run into a piece
                        if (GameState.Board.ContainsKey(s))
                        {
                            if (GameState.Board[s].color != GameState.Board[start].color && GameState.Board[s].type == PieceType.King) continue;
                            if (s.Equals(empty)) continue;

                            return false;
                        }
                        // Run into a block
                        if (s.Equals(block))
                        {
                            return false;
                        }
                    }
                    return false;
                }
                else // UpLeft
                {
                    for (byte i = 1; start.rank + i <= end.rank && start.file >= end.file; i++)
                    {
                        Square s = new Square((byte)(start.file - i), (byte)(start.rank + i));
                        if (s.Equals(end)) return true;

                        // Run into a piece
                        if (GameState.Board.ContainsKey(s))
                        {
                            if (GameState.Board[s].color != GameState.Board[start].color && GameState.Board[s].type == PieceType.King) continue;
                            if (s.Equals(empty)) continue;

                            return false;
                        }
                        // Run into a block
                        if (s.Equals(block))
                        {
                            return false;
                        }
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

                        // Run into a piece
                        if (GameState.Board.ContainsKey(s))
                        {
                            if (GameState.Board[s].color != GameState.Board[start].color && GameState.Board[s].type == PieceType.King) continue;
                            if (s.Equals(empty)) continue;

                            return false;
                        }
                        // Run into a block
                        if (s.Equals(block))
                        {
                            return false;
                        }
                    }
                    return false;
                }
                // DownLeft
                for (byte i = 1; start.rank - i >= end.rank && start.file >= end.file; i++)
                {
                    Square s = new Square((byte)(start.file - i), (byte)(start.rank - i));
                    if (s.Equals(end)) return true;

                    // Run into a piece
                    if (GameState.Board.ContainsKey(s))
                    {
                        if (GameState.Board[s].color != GameState.Board[start].color && GameState.Board[s].type == PieceType.King) continue;
                        if (s.Equals(empty)) continue;

                        return false;
                    }
                    // Run into a block
                    if (s.Equals(block))
                    {
                        return false;
                    }
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
