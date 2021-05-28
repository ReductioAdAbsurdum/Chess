using System.Collections.Generic;


namespace GameCore
{
    public static class List
    {
        /// <summary>
        /// Adds move if board conditions are met.
        /// </summary>
        internal static void AddMove(this List<Move> list, Square start, Square end, Color color) 
        {          
            if (GameState.Board.ContainsKey(end) == false)
            {
                Move m = new Move(start, end);
                if (!UnderCheck.AfterMove(m)) list.Add(m);
            }
            else if (GameState.Board[end].color != color)
            {
                Move m = new Move(start, end);
                if (!UnderCheck.AfterMove(m)) list.Add(m);
            }
        }

        /// <summary>
        /// Adds move that contains MoveInfo if its legal. Don't check for other board condition.
        /// </summary>
        internal static void AddMoveInfo(this List<Move> list, Square start, Square end, Color color, MoveInfo info) 
        {
            Move m = new Move(start, end, info);
            if (!UnderCheck.AfterMove(m)) list.Add(m);
        }

        /// <summary>
        /// Adds pawn's push move if board conditions are met.
        /// </summary>
        internal static void AddPawnMove(this List<Move> list, Square start, Square end, Color color)
        {
            if (GameState.Board.ContainsKey(end) == false)
            {                              
                if (end.rank == 8 && color == Color.White) // White Promotion
                {
                    Move b = new Move(start, end, MoveInfo.Promotion_Bishop);
                    if (!UnderCheck.AfterMove(b)) list.Add(b);

                    Move r = new Move(start, end, MoveInfo.Promotion_Rook);
                    if (!UnderCheck.AfterMove(r)) list.Add(r);

                    Move k = new Move(start, end, MoveInfo.Promotion_Knight);
                    if (!UnderCheck.AfterMove(k)) list.Add(k);

                    Move q = new Move(start, end, MoveInfo.Promotion_Queen);
                    if (!UnderCheck.AfterMove(q)) list.Add(q);

                    return;
                }
                if (end.rank == 0 && color == Color.Black) // Black Promotion
                {
                    Move b = new Move(start, end, MoveInfo.Promotion_Bishop);
                    if (!UnderCheck.AfterMove(b)) list.Add(b);

                    Move r = new Move(start, end, MoveInfo.Promotion_Rook);
                    if (!UnderCheck.AfterMove(r)) list.Add(r);

                    Move k = new Move(start, end, MoveInfo.Promotion_Knight);
                    if (!UnderCheck.AfterMove(k)) list.Add(k);

                    Move q = new Move(start, end, MoveInfo.Promotion_Queen);
                    if (!UnderCheck.AfterMove(q)) list.Add(q);

                    return;
                }

                // Pawn push
                Move m = new Move(start, end);
                if (!UnderCheck.AfterMove(m)) list.Add(m);
            }          
        }

        /// <summary>
        /// Adds pawn's capture move if board conditions are met.
        /// </summary>
        internal static void AddPawnAttackMove(this List<Move> list, Square start, Square end, Color color)
        {
            if (GameState.Board.ContainsKey(end)) 
            {
                if (GameState.Board[end].color != color)
                {
                    if (end.rank == 8 && color == Color.White) // White promotion
                    {
                        Move b = new Move(start, end, MoveInfo.Promotion_Bishop);
                        if (!UnderCheck.AfterMove(b)) list.Add(b);

                        Move r = new Move(start, end, MoveInfo.Promotion_Rook);
                        if (!UnderCheck.AfterMove(r)) list.Add(r);

                        Move k = new Move(start, end, MoveInfo.Promotion_Knight);
                        if (!UnderCheck.AfterMove(k)) list.Add(k);

                        Move q = new Move(start, end, MoveInfo.Promotion_Queen);
                        if (!UnderCheck.AfterMove(q)) list.Add(q);

                        return;
                    }
                    if (end.rank == 0 && color == Color.Black) // Black promotion
                    {
                        Move b = new Move(start, end, MoveInfo.Promotion_Bishop);
                        if (!UnderCheck.AfterMove(b)) list.Add(b);

                        Move r = new Move(start, end, MoveInfo.Promotion_Rook);
                        if (!UnderCheck.AfterMove(r)) list.Add(r);

                        Move k = new Move(start, end, MoveInfo.Promotion_Knight);
                        if (!UnderCheck.AfterMove(k)) list.Add(k);

                        Move q = new Move(start, end, MoveInfo.Promotion_Queen);
                        if (!UnderCheck.AfterMove(q)) list.Add(q);

                        return;
                    }

                    // Regular capture
                    Move m = new Move(start, end);
                    if (!UnderCheck.AfterMove(m)) list.Add(m);
                }
            }
        }       
    }
}
