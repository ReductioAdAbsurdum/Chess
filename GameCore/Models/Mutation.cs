using System.Collections.Generic;

namespace GameCore
{
    internal class Mutation
    {
        internal  Dictionary<Square, Piece> Added = new();
        internal  HashSet<Square> Removed = new();

        internal bool CastleWhite_OO = true;
        internal bool CastleWhite_OOO = true;
        internal bool CastleBlack_OO = true;
        internal bool CastleBlack_OOO = true;
        
        internal byte EnPassantFile = 20;
        
        internal Color CurrentPlayer = Color.White;

        internal Square KingPositionWhite = new(5, 1);
        internal Square KingPositionBlack = new(5, 8);

        internal bool UnderCheckWhite = false;
        internal bool UnderCheckBlack = false;
    }
}
