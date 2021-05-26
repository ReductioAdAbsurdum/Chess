using System;

namespace GameCore
{
    public struct Move : IEquatable<Move>
    {
        public readonly Square start;
        public readonly Square end;
        public readonly PieceType promotionPiece;

        internal Move(Square origin, Square end)
        {
            this.start = origin;
            this.end = end;
            promotionPiece = PieceType.Pawn;
        }
        internal Move(Square origin, Square end, PieceType promotionPiece)
        {
            this.start = origin;
            this.end = end;
            this.promotionPiece = promotionPiece;
        }
        public bool Equals(Move other)
        {
            return start.Equals(other.start) && end.Equals(other.end) && promotionPiece.Equals(other.promotionPiece);
        }
        public override int GetHashCode()
        {
            return start.GetHashCode() * 1000 + end.GetHashCode() * 10 + (int)promotionPiece;
        }
    }
}
