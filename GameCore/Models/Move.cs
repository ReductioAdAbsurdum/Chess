using System;

namespace GameCore
{
    public struct Move : IEquatable<Move>
    {
        public readonly Square origin;
        public readonly Square end;
        public readonly PieceType promotionPiece;

        internal Move(Square origin, Square end)
        {
            this.origin = origin;
            this.end = end;
            promotionPiece = PieceType.Pawn;
        }
        internal Move(Square origin, Square end, PieceType promotionPiece)
        {
            this.origin = origin;
            this.end = end;
            this.promotionPiece = promotionPiece;
        }
        public bool Equals(Move other)
        {
            return origin.Equals(other.origin) && end.Equals(other.end) && promotionPiece.Equals(other.promotionPiece);
        }
        public override int GetHashCode()
        {
            return origin.GetHashCode() * 1000 + end.GetHashCode() * 10 + (int)promotionPiece;
        }
    }
}
