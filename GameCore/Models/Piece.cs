
namespace GameCore
{
    public struct Piece
    {
        public readonly Color color;
        public readonly PieceType type;

        internal Piece(Color color, PieceType type)
        {
            this.color = color;
            this.type = type;
        }
    }
}
