﻿using System;

namespace GameCore
{
    public struct Move : IEquatable<Move>
    {
        public Square origin;
        public Square end;
        public PieceType promotionPiece;

        public Move(Square origin, Square end)
        {
            this.origin = origin;
            this.end = end;
            promotionPiece = PieceType.Pawn;
        }         
        public Move(Square origin, Square end, PieceType promotionPiece)
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