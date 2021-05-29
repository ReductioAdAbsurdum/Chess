using System.Collections.Generic;

namespace GameCore
{
    internal static class Rook
    {
        internal static bool AttackingSquare(Square start, Square end, Square block, Square empty)
        {
            if (start.rank != end.rank && start.file != end.file) return false;

            if (start.rank == end.rank) 
            {
                if (start.file < end.file)
                {
                    // Right
                    for (byte i = 1; start.file + i <= end.file; i++)
                    {
                        Square s = new Square((byte)(start.file + i), start.rank);
                        if (s.Equals(end)) return true;

                        // Run into a piece
                        if (GameState.Board.ContainsKey(s)) 
                        {                           
                            if (GameState.Board[s].color != GameState.Board[start].color && GameState.Board[s].type == PieceType.King) continue;
                            if (s.Equals(empty)) continue;

                            return false;
                        }
                        // Run into a block
                        if(s.Equals(block))
                        {
                            return false;
                        }
                    }
                    return false;
                }
                else
                {
                    // Left
                    for (byte i = 1; start.file - i >= end.file; i++)
                    {
                        Square s = new Square((byte)(start.file - i), start.rank);
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
                if (start.rank < end.rank)
                {
                    // Up
                    for (byte i = 1; start.rank + i <= end.rank; i++)
                    {
                        Square s = new Square(start.file, (byte)(start.rank + i));
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
                else
                {
                    // Down
                    for (byte i = 1; start.rank - i >= end.rank; i++)
                    {
                        Square s = new Square(start.file, (byte)(start.rank - i));
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
        }
        internal static bool AttackingSquare(Square start, Square end, Square block, Square empty, Mutation mutation)
        {
            if (start.rank != end.rank && start.file != end.file) return false;

            if (start.rank == end.rank)
            {
                if (start.file < end.file)
                {
                    // Right
                    for (byte i = 1; start.file + i <= end.file; i++)
                    {
                        Square s = new Square((byte)(start.file + i), start.rank);
                        if (s.Equals(end)) return true;

                        // Run into a piece
                        if (GameState.Board.ContainsKey(s) && !mutation.Removed.Contains(s))
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
                else
                {
                    // Left
                    for (byte i = 1; start.file - i >= end.file; i++)
                    {
                        Square s = new Square((byte)(start.file - i), start.rank);
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
                if (start.rank < end.rank)
                {
                    // Up
                    for (byte i = 1; start.rank + i <= end.rank; i++)
                    {
                        Square s = new Square(start.file, (byte)(start.rank + i));
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
                else
                {
                    // Down
                    for (byte i = 1; start.rank - i >= end.rank; i++)
                    {
                        Square s = new Square(start.file, (byte)(start.rank - i));
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
        }
        internal static List<Move> LegalMoves(Square start, Color color)
        {
            List<Move> output = new List<Move>();

            // Right
            for (byte i = 1; start.file + i <= 8; i++)
            {
                Square s = new Square((byte)(start.file + i), start.rank);
                output.AddMove(start, s, color);

                if (GameState.Board.ContainsKey(s)) break;
            }
            // Left
            for (byte i = 1; start.file - i >= 1; i++)
            {
                Square s = new Square((byte)(start.file - i), start.rank);
                output.AddMove(start, s, color);

                if (GameState.Board.ContainsKey(s)) break;
            }
            // Up
            for (byte i = 1; start.rank + i <= 8; i++)
            {
                Square s = new Square(start.file, (byte)(start.rank + i));
                output.AddMove(start, s, color);

                if (GameState.Board.ContainsKey(s)) break;
            }
            // Down
            for (byte i = 1; start.rank - i >= 1; i++)
            {
                Square s = new Square(start.file, (byte)(start.rank - i));
                output.AddMove(start, s, color);

                if (GameState.Board.ContainsKey(s)) break;
            }

            return output;
        }
    }
}
