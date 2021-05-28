using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    public enum Color : byte
    {
        White,
        Black
    }
    public enum PieceType : byte
    {
        Pawn,
        Rook,
        Bishop,
        Knight,
        King,
        Queen
    }
    public enum MoveInfo : byte
    {
        None,

        Promotion_Bishop,
        Promotion_Rook,
        Promotion_Knight,
        Promotion_Queen,

        EnPassant,
        
        White_OO,
        White_OOO,
        Black_OO,
        Black_OOO,
    }
}
