using System;

namespace GameCore
{
    public static class Fen
    {
        public static void SetBoardByFen(string record)
        {

            string[] fields = record.Split(' ');

            // Field #1 - Board

            byte rank = 8;
            byte file = 1;

            for (byte letter = 0; letter < fields[0].Length; letter++)
            {
                if (fields[0][letter] == '/')
                {
                    rank--;
                    file = 1;
                    continue;
                }

                if (byte.TryParse(fields[0][letter].ToString(), out byte number))
                {
                    file += number;
                    continue;
                }

                GameState.Board.Add(new Square(file,rank), LetterToPiece(fields[0][letter]));

                file++;
            }

            // Field #2 - On the move
            switch (fields[1])
            {
                case "w": GameState.CurrentPlayer = Color.White;
                    break;
                case "b": GameState.CurrentPlayer = Color.Black;
                    break;
            }

            // Field #3 - Castling availability
            if (fields[2] != "-")
            {
                if (fields[2].Contains("K")) GameState.CastleWhite_OO = true;
                if (fields[2].Contains("Q")) GameState.CastleWhite_OOO = true;
                if (fields[2].Contains("k")) GameState.CastleBlack_OO = true;
                if (fields[2].Contains("q")) GameState.CastleBlack_OOO = true;
            }

            // Field #4 - En passant file
            if (fields[3] != "-")
            {
                GameState.EnPassantFile = byte.Parse(fields[3][1].ToString());
            }
            else 
            {
                GameState.EnPassantFile = 20;
            }

            // Field #5 - Halfmove number
            GameState.HalfmoveNumber = byte.Parse(fields[4]);

            // Field #6 - Move number
            GameState.MoveNumber = short.Parse(fields[5]);
        }
        public static string GetCurrentFen()
        {
            string output = "";

            // Field #1 - Board
            output += BoardToString();
            output += " ";

            // Field #2 - On the move

            if (GameState.CurrentPlayer == Color.White) output += "w";

            else output += "b";

            output += " ";

            // Field #3 - Castling availability
            if (GameState.CastleWhite_OO) output += "K";
            if (GameState.CastleWhite_OOO) output += "Q";
            if (GameState.CastleBlack_OO) output += "k";
            if (GameState.CastleBlack_OOO) output += "q";

            output += " ";

            // Field #4 - En passant file

            if (GameState.EnPassantFile == 20)
            {
                output += "-";
            }
            else
            {
                output += FileToLetter(GameState.EnPassantFile);
                if (GameState.CurrentPlayer == Color.White && GameState.EnPassantFile != 0) output += "6";
                if (GameState.CurrentPlayer == Color.Black && GameState.EnPassantFile != 0) output += "6";
            }

            output += " ";

            // Field #5 - Halfmove number
            output += GameState.HalfmoveNumber.ToString();

            output += " ";

            // Field #6 - Move number
            output += GameState.MoveNumber.ToString();

            return output;
        }
        public static bool ValidFen() 
        {
            // TODO - Implement Fen validator
            throw new NotImplementedException();
        }

        internal static string BoardToString()
        {
            string output = "";

            for (byte rank = 8; rank >= 1; rank--)
            {
                byte counter = 0;

                for (byte file = 1; file <= 8; file++)
                {
                    Square tempSquare = new Square(file, rank);

                    if (GameState.Board.ContainsKey(tempSquare))

                    {
                        if (counter != 0)
                        {
                            output += counter.ToString();
                            counter = 0;
                        }

                        output += PieceToLetter(GameState.Board[tempSquare]);
                    }
                    else
                    {
                        counter++;
                    }
                }
                if (counter != 0)
                {
                    output += counter.ToString();
                }
                output += "/";
            }
            output = output.Substring(0, output.Length - 1);

            return output;
        }
        private static char PieceToLetter(Piece piece)
        {
            switch (piece.type)
            {
                case PieceType.Pawn: return piece.color == Color.White ? 'P' : 'p';
                case PieceType.Rook: return piece.color == Color.White ? 'R' : 'r';
                case PieceType.Bishop: return piece.color == Color.White ? 'B' : 'b';
                case PieceType.Knight: return piece.color == Color.White ? 'N' : 'n';
                case PieceType.King: return piece.color == Color.White ? 'K' : 'k';
                case PieceType.Queen: return piece.color == Color.White ? 'Q' : 'q';
            }

            throw new InvalidOperationException();
        }
        private static Piece LetterToPiece(char letter)
        {
            switch (letter)
            {
                case 'r': return new Piece(Color.Black, PieceType.Rook);
                case 'n': return new Piece(Color.Black, PieceType.Knight);
                case 'b': return new Piece(Color.Black, PieceType.Bishop);
                case 'q': return new Piece(Color.Black, PieceType.Queen);
                case 'k': return new Piece(Color.Black, PieceType.King);
                case 'p': return new Piece(Color.Black, PieceType.Pawn);

                case 'R': return new Piece(Color.White, PieceType.Rook);
                case 'N': return new Piece(Color.White, PieceType.Knight);
                case 'B': return new Piece(Color.White, PieceType.Bishop);
                case 'Q': return new Piece(Color.White, PieceType.Queen);
                case 'K': return new Piece(Color.White, PieceType.King);
                case 'P': return new Piece(Color.White, PieceType.Pawn);
            }

            throw new InvalidOperationException();
        }
        private static char FileToLetter(byte file)
        {
            switch (file)
            {
                case 1: return 'a';
                case 2: return 'b';
                case 3: return 'c';
                case 4: return 'd';
                case 5: return 'e';
                case 6: return 'f';
                case 7: return 'g';
                case 8: return 'h';
            }

            return '-';
        }
    }
}
