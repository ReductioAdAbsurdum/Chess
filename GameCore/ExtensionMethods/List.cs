using System.Collections.Generic;


namespace GameCore
{
    public static class List
    {
        internal static void AddMove(this List<Move> h, Square start, Square end, Color color) 
        {
            if (GameState.Board.ContainsKey(end) == false)
            {
                Move m = new Move(start, end);
                if (!UnderCheck.AfterMove(m)) h.Add(m);
            }
            else if (GameState.Board[end].color != color)
            {
                Move m = new Move(start, end);
                if (!UnderCheck.AfterMove(m)) h.Add(m);
            }
        }
        internal static void AddPawnMove(this List<Move> h, Square start, Square end, Color color)
        {
            if (GameState.Board.ContainsKey(end) == false)
            {                              
                if (end.rank == 8 && color == Color.White) // White Promotion square
                {
                    Move b = new Move(start, end, PieceType.Bishop);
                    if (!UnderCheck.AfterMove(b)) h.Add(b);

                    Move r = new Move(start, end, PieceType.Rook);
                    if (!UnderCheck.AfterMove(r)) h.Add(r);

                    Move k = new Move(start, end, PieceType.Knight);
                    if (!UnderCheck.AfterMove(k)) h.Add(k);

                    Move q = new Move(start, end, PieceType.Queen);
                    if (!UnderCheck.AfterMove(q)) h.Add(q);

                    return;
                }
                if (end.rank == 0 && color == Color.Black) // Black Promotion square
                {
                    Move b = new Move(start, end, PieceType.Bishop);
                    if (!UnderCheck.AfterMove(b)) h.Add(b);

                    Move r = new Move(start, end, PieceType.Rook);
                    if (!UnderCheck.AfterMove(r)) h.Add(r);

                    Move k = new Move(start, end, PieceType.Knight);
                    if (!UnderCheck.AfterMove(k)) h.Add(k);

                    Move q = new Move(start, end, PieceType.Queen);
                    if (!UnderCheck.AfterMove(q)) h.Add(q);

                    return;
                }

                Move m = new Move(start, end);
                if (!UnderCheck.AfterMove(m)) h.Add(m);
            }          
        }
        internal static void AddPawnAttackMove(this List<Move> h, Square start, Square end, Color color)
        {
            if (GameState.Board.ContainsKey(end)) 
            {
                if (GameState.Board[end].color != color)
                {
                    if (end.rank == 8 && color == Color.White) // White Promotion square
                    {
                        Move b = new Move(start, end, PieceType.Bishop);
                        if (!UnderCheck.AfterMove(b)) h.Add(b);

                        Move r = new Move(start, end, PieceType.Rook);
                        if (!UnderCheck.AfterMove(r)) h.Add(r);

                        Move k = new Move(start, end, PieceType.Knight);
                        if (!UnderCheck.AfterMove(k)) h.Add(k);

                        Move q = new Move(start, end, PieceType.Queen);
                        if (!UnderCheck.AfterMove(q)) h.Add(q);

                        return;
                    }
                    if (end.rank == 0 && color == Color.Black) // Black Promotion square
                    {
                        Move b = new Move(start, end, PieceType.Bishop);
                        if (!UnderCheck.AfterMove(b)) h.Add(b);

                        Move r = new Move(start, end, PieceType.Rook);
                        if (!UnderCheck.AfterMove(r)) h.Add(r);

                        Move k = new Move(start, end, PieceType.Knight);
                        if (!UnderCheck.AfterMove(k)) h.Add(k);

                        Move q = new Move(start, end, PieceType.Queen);
                        if (!UnderCheck.AfterMove(q)) h.Add(q);

                        return;
                    }

                    Move m = new Move(start, end);
                    if (!UnderCheck.AfterMove(m)) h.Add(m);
                }
            }
        }
    }
}
