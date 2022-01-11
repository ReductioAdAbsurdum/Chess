
using System.Collections.Generic;

namespace GameCore
{
    public static class LegalMoves
    {
        public static List<Move> GetAll()
        {
            // Update king under check at the start of the move
            if (GameState.CurrentPlayer == Color.White)
            {
                GameState.UnderCheckWhite = UnderCheck.AttackingSquareBlack(GameState.KingPositionWhite);
            }
            else
            {
                GameState.UnderCheckBlack = UnderCheck.AttackingSquareWhite(GameState.KingPositionBlack);
            }

            var output = new List<Move>(); 

            foreach (Square s in GameState.Board.Keys)
            {
                Color c = GameState.Board[s].color;
                if (c != GameState.CurrentPlayer) continue;
                
                PieceType p = GameState.Board[s].type;

                output.AddRange(PieceLegalMoves(s, c, p));
            }

            return output;
        }
        internal static List<Move> GetAll(Mutation mutation)
        {
            // Update king under check at the start of the move
            if (GameState.CurrentPlayer == Color.White)
            {
                GameState.UnderCheckWhite = UnderCheck.AttackingSquareBlack(mutation.KingPositionWhite, mutation);
            }
            else
            {
                GameState.UnderCheckBlack = UnderCheck.AttackingSquareWhite(mutation.KingPositionBlack, mutation);
            }

            var output = new List<Move>();

            foreach (Square s in GameState.Board.Keys)
            {
                Color c = GameState.Board[s].color;
                if (c != mutation.CurrentPlayer) continue;
                // Dont check if piece has been removed;
                if (mutation.Removed.Contains(s)) continue;

                PieceType p = GameState.Board[s].type;

                output.AddRange(PieceLegalMoves(s, c, p, mutation));
            }

            // Check for added pieces
            foreach (Square s in mutation.Added.Keys)
            {
                Color c = mutation.Added[s].color;
                if (c != mutation.CurrentPlayer) continue;
                
                PieceType p = GameState.Board[s].type;

                output.AddRange(PieceLegalMoves(s, c, p, mutation));
            }

            return output;
        }
        public static void MakeMove(Move move)
        {
            // Break if there is no legal move
            if (!GetAll().Contains(move)) return;

            switch (move.info)
            {
                case MoveInfo.None: MovePiece(move);
                    break;
                case MoveInfo.Promotion_Bishop: PromotePawn(move, PieceType.Bishop);
                    break;
                case MoveInfo.Promotion_Rook: PromotePawn(move, PieceType.Rook);
                    break;
                case MoveInfo.Promotion_Knight: PromotePawn(move, PieceType.Knight);
                    break;
                case MoveInfo.Promotion_Queen: PromotePawn(move, PieceType.Queen);
                    break;
                case MoveInfo.EnPassant: EnPassant(move);
                    break;
                case MoveInfo.White_OO: CastleWhiteOO(move);
                    break;
                case MoveInfo.White_OOO: CastleWhiteOOO(move);
                    break;
                case MoveInfo.Black_OO: CastleBlackOO(move);
                    break;
                case MoveInfo.Black_OOO: CastleBlackOOO(move);
                    break;
            }

            if (GameState.CurrentPlayer == Color.White)
            {
                GameState.CurrentPlayer = Color.Black;
            }
            else 
            {
                GameState.CurrentPlayer = Color.White;
            }
            GameState.HalfmoveNumber++;
            GameState.MoveNumber++;
            GameState.EnPassantFile = 20;
           
        }
        private static void MovePiece(Move move) 
        {
            // Accaunts for King and or Rook move for White
            if (move.start.Equals(GameState.KingPositionWhite) || move.start.Equals(new Square(1, 1)) || move.start.Equals(new Square(8, 1)))
            {
                GameState.CastleWhite_OO = false;
                GameState.CastleWhite_OOO = false;
            }
            if (move.start.Equals(GameState.KingPositionWhite))
            {
                GameState.KingPositionWhite = move.end;
            }

            // Accaunts for King and or Rook move for Black
            if (move.start.Equals(GameState.KingPositionBlack) || move.start.Equals(new Square(1, 8)) || move.start.Equals(new Square(8, 8)))
            {
                GameState.CastleBlack_OO = false;
                GameState.CastleBlack_OOO = false;
            }
            if (move.start.Equals(GameState.KingPositionBlack))
            {
                GameState.KingPositionBlack= move.end;
            }

            GameState.Board.Remove(move.end);

            GameState.Board.Add(move.end, new Piece(GameState.Board[move.start].color, GameState.Board[move.start].type));

            GameState.Board.Remove(move.start);
        }
        private static void PromotePawn(Move move, PieceType promotion)
        {
            GameState.Board.Remove(move.end);

            GameState.Board.Add(move.end, new Piece(GameState.Board[move.start].color, promotion));

            GameState.Board.Remove(move.start);
        }
        private static void EnPassant(Move move)
        {
            GameState.Board.Add(move.end, new Piece(GameState.Board[move.start].color, PieceType.Pawn));

            GameState.Board.Remove(move.start);
            GameState.Board.Remove(new Square(move.end.file, move.start.rank));
        }
        private static void CastleWhiteOO(Move move) 
        {
            // Game state info
            GameState.KingPositionWhite = move.end;
            GameState.CastleWhite_OO = false;
            GameState.CastleWhite_OOO = false;

            // Move king
            GameState.Board.Add(move.end, new Piece(Color.White, PieceType.King));
            GameState.Board.Remove(move.start);

            // Move Rook
            GameState.Board.Add(new Square(6, 1), new Piece(Color.White, PieceType.Rook));
            GameState.Board.Remove(new Square(8,1));
        }
        private static void CastleWhiteOOO(Move move)
        {
            // Game state info
            GameState.KingPositionWhite = move.end;
            GameState.CastleWhite_OO = false;
            GameState.CastleWhite_OOO = false;

            // Move king
            GameState.Board.Add(move.end, new Piece(Color.White, PieceType.King));
            GameState.Board.Remove(move.start);

            // Move Rook
            GameState.Board.Add(new Square(4, 1), new Piece(Color.White, PieceType.Rook));
            GameState.Board.Remove(new Square(1, 1));
        }
        private static void CastleBlackOO(Move move)
        {
            // Game state info
            GameState.KingPositionBlack = move.end;
            GameState.CastleBlack_OO = false;
            GameState.CastleBlack_OOO = false;

            // Move king
            GameState.Board.Add(move.end, new Piece(Color.Black, PieceType.King));
            GameState.Board.Remove(move.start);

            // Move Rook
            GameState.Board.Add(new Square(6, 8), new Piece(Color.Black, PieceType.Rook));
            GameState.Board.Remove(new Square(8, 8));
        }
        private static void CastleBlackOOO(Move move)
        {
            // Game state info
            GameState.KingPositionBlack = move.end;
            GameState.CastleBlack_OO = false;
            GameState.CastleBlack_OOO = false;

            // Move king
            GameState.Board.Add(move.end, new Piece(Color.Black, PieceType.King));
            GameState.Board.Remove(move.start);

            // Move Rook
            GameState.Board.Add(new Square(4, 8), new Piece(Color.Black, PieceType.Rook));
            GameState.Board.Remove(new Square(1, 8));
        }
        private static List<Move> PieceLegalMoves(Square start, Color color , PieceType piece)
        {
            switch (piece)
            {
                case PieceType.Pawn: return Pawn.LegalMoves(start, color);
                case PieceType.Rook: return Rook.LegalMoves(start, color);
                case PieceType.Bishop: return Bishop.LegalMoves(start, color);
                case PieceType.Knight: return Knight.LegalMoves(start, color);
                case PieceType.King: return King.LegalMoves(start, color);
                case PieceType.Queen: return Queen.LegalMoves(start, color);
            }

            return new List<Move>();
        }
        private static List<Move> PieceLegalMoves(Square start, Color color, PieceType piece, Mutation mutation)
        {
            switch (piece)
            {
                case PieceType.Pawn: return Pawn.LegalMoves(start, color);
                case PieceType.Rook: return Rook.LegalMoves(start, color);
                case PieceType.Bishop: return Bishop.LegalMoves(start, color);
                case PieceType.Knight: return Knight.LegalMoves(start, color);
                case PieceType.King: return King.LegalMoves(start, color);
                case PieceType.Queen: return Queen.LegalMoves(start, color);
            }

            return new List<Move>();
        }
    }
}
