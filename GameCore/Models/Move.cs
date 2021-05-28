using System;

namespace GameCore
{
    public struct Move : IEquatable<Move>
    {
        public readonly Square start;
        public readonly Square end;
        public readonly MoveInfo info;

        public Move(Square start, Square end)
        {
            this.start = start;
            this.end = end;
            this.info = MoveInfo.None;
        }
        public Move(Square start, Square end, MoveInfo info)
        {
            this.start = start;
            this.end = end;
            this.info = info;
        }
        public bool Equals(Move other)
        {
            return start.Equals(other.start) && end.Equals(other.end) && info.Equals(other.info);
        }
        public override int GetHashCode()
        {
            return start.GetHashCode() * 1000 + end.GetHashCode() * 10 + (int)info;
        }
    }
}
