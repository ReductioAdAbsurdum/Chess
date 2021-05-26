using System.Collections.Generic;


namespace GameCore
{
    public static class HashSet
    {
        internal static void AddMoveIfValid(this HashSet<Move> h, Square start, Square end, Color color) 
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
    }
}
