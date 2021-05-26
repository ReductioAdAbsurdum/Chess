using System;

namespace GameCore
{
    public struct Square : IEquatable<Square>
    {
        public readonly byte file;
        public readonly byte rank;

        public Square(byte file, byte rank)
        {
            this.file = file;
            this.rank = rank;
        }
        public bool Equals(Square other)
        {
            return file == other.file && rank == other.rank;
        }
        public override int GetHashCode()
        {
            return file * 10 + rank;
        }
    }
}
