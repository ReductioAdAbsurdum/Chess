
namespace GameCore
{
    public struct Piece
    {
        public readonly Color color;
        public readonly PieceType type;

        public Piece(Color color, PieceType type)
        {
            this.color = color;
            this.type = type;
        }
    }
}
