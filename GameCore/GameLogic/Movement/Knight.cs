using System.Collections.Generic;

namespace GameCore
{
    internal static class Knight
    {
        internal static HashSet<Square> AttackingSquares(Square origin)
        {
            HashSet<Square> output = new HashSet<Square>();

            // Two Right
            if (origin.file <= 6)
            {
                // Up
                if (origin.rank <= 7) output.Add(new Square((byte)(origin.file + 2), (byte)(origin.rank + 1)));
                // Down
                if (origin.rank >= 2) output.Add(new Square((byte)(origin.file + 2), (byte)(origin.rank - 1)));             
            }
            // Two Left
            if (origin.file >= 3)
            {
                // Up
                if (origin.rank <= 7) output.Add(new Square((byte)(origin.file - 2), (byte)(origin.rank + 1)));
                // Down
                if (origin.rank >= 2) output.Add(new Square((byte)(origin.file - 2), (byte)(origin.rank - 1)));
            }
            // Two Up
            if (origin.rank <= 6)
            {
                // Right
                if (origin.file <= 7) output.Add(new Square((byte)(origin.file + 1), (byte)(origin.rank + 2)));
                // Left
                if (origin.file >= 2) output.Add(new Square((byte)(origin.file - 1), (byte)(origin.rank + 2)));
            }
            // Two Down
            if (origin.rank >= 3)
            {
                // Right
                if (origin.file <= 7) output.Add(new Square((byte)(origin.file + 1), (byte)(origin.file - 2)));
                // Left
                if (origin.file >= 2) output.Add(new Square((byte)(origin.file - 1), (byte)(origin.rank - 2)));
            }

            return output;
        }

        internal static HashSet<Move> LegalMoves(Square origin, Color color)
        {
            HashSet<Move> output = new HashSet<Move>();

            // Two Right
            if (origin.file <= 6)
            {
                // Up
                if (origin.rank <= 7)
                {
                    Square end = new Square((byte)(origin.file + 2), (byte)(origin.rank + 1));

                    if (GameState.Board.ContainsKey(end) == false)
                    {
                        Move m = new Move(origin, end);
                        if (!UnderCheck.AfterMove(m)) output.Add(m);
                    }
                    else if (GameState.Board[end].color != color)
                    {
                        Move m = new Move(origin, end);
                        if (!UnderCheck.AfterMove(m)) output.Add(m);
                    }

                }
                // Down
                if (origin.rank >= 2)
                {
                    Square end = new Square((byte)(origin.file + 2), (byte)(origin.rank - 1));

                    if (GameState.Board.ContainsKey(end) == false)
                    {
                        Move m = new Move(origin, end);
                        if (!UnderCheck.AfterMove(m)) output.Add(m);
                    }
                    else if (GameState.Board[end].color != color)
                    {
                        Move m = new Move(origin, end);
                        if (!UnderCheck.AfterMove(m)) output.Add(m);
                    }
                }
            }
            // Two Left
            if (origin.file >= 3)
            {
                // Up
                if (origin.rank <= 7)
                {
                    Square end = new Square((byte)(origin.file - 2), (byte)(origin.rank + 1));

                    if (GameState.Board.ContainsKey(end) == false)
                    {
                        Move m = new Move(origin, end);
                        if (!UnderCheck.AfterMove(m)) output.Add(m);
                    }
                    else if (GameState.Board[end].color != color)
                    {
                        Move m = new Move(origin, end);
                        if (!UnderCheck.AfterMove(m)) output.Add(m);
                    }
                }
                // Down
                if (origin.rank >= 2)
                {
                    Square end = new Square((byte)(origin.file - 2), (byte)(origin.rank - 1));

                    if (GameState.Board.ContainsKey(end) == false)
                    {
                        Move m = new Move(origin, end);
                        if (!UnderCheck.AfterMove(m)) output.Add(m);
                    }
                    else if (GameState.Board[end].color != color)
                    {
                        Move m = new Move(origin, end);
                        if (!UnderCheck.AfterMove(m)) output.Add(m);
                    }
                }
            }
            // Two Up
            if (origin.rank <= 6)
            {
                // Right
                if (origin.file <= 7)
                {
                    Square end = new Square((byte)(origin.file + 1), (byte)(origin.rank + 2));

                    if (GameState.Board.ContainsKey(end) == false)
                    {
                        Move m = new Move(origin, end);
                        if (!UnderCheck.AfterMove(m)) output.Add(m);
                    }
                    else if (GameState.Board[end].color != color)
                    {
                        Move m = new Move(origin, end);
                        if (!UnderCheck.AfterMove(m)) output.Add(m);
                    }
                }
                // Left
                if (origin.file >= 2)
                {
                    Square end = new Square((byte)(origin.file - 1), (byte)(origin.rank + 2));

                    if (GameState.Board.ContainsKey(end) == false)
                    {
                        Move m = new Move(origin, end);
                        if (!UnderCheck.AfterMove(m)) output.Add(m);
                    }
                    else if (GameState.Board[end].color != color)
                    {
                        Move m = new Move(origin, end);
                        if (!UnderCheck.AfterMove(m)) output.Add(m);
                    }
                }
            }
            // Two Down
            if (origin.rank >= 3)
            {
                // Right
                if (origin.file <= 7)
                {
                    Square end = new Square((byte)(origin.file + 1), (byte)(origin.rank - 2));

                    if (GameState.Board.ContainsKey(end) == false)
                    {
                        Move m = new Move(origin, end);
                        if (!UnderCheck.AfterMove(m)) output.Add(m);
                    }
                    else if (GameState.Board[end].color != color)
                    {
                        Move m = new Move(origin, end);
                        if (!UnderCheck.AfterMove(m)) output.Add(m);
                    }
                }
                // Left
                if (origin.file >= 2)
                {
                    Square end = new Square((byte)(origin.file - 1), (byte)(origin.rank - 2));

                    if (GameState.Board.ContainsKey(end) == false)
                    {
                        Move m = new Move(origin, end);
                        if (!UnderCheck.AfterMove(m)) output.Add(m);
                    }
                    else if (GameState.Board[end].color != color)
                    {
                        Move m = new Move(origin, end);
                        if (!UnderCheck.AfterMove(m)) output.Add(m);
                    }
                }
            }

            return output;
        }
    }
 }

