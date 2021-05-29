using System;
using System.Collections.Generic;

namespace GameCore.Evaluation
{
    public static class PieceEvaluation
    {
        private static readonly Dictionary<PieceType, int> PieceValue = new();

        private static readonly Dictionary<Square, int> WhitePawn = new();
        private static readonly Dictionary<Square, int> BlackPawn = new();

        private static readonly Dictionary<Square, int> WhiteKnight = new();
        private static readonly Dictionary<Square, int> BlackKnight = new();

        private static readonly Dictionary<Square, int> WhiteBishop = new();
        private static readonly Dictionary<Square, int> BlackBishop = new();

        private static readonly Dictionary<Square, int> WhiteRook = new();
        private static readonly Dictionary<Square, int> BlackRook = new();

        private static readonly Dictionary<Square, int> WhiteQueen = new();
        private static readonly Dictionary<Square, int> BlackQueen= new();

        private static readonly Dictionary<Square, int> WhiteKingMiddleGame = new();
        private static readonly Dictionary<Square, int> BlackKingMiddleGame = new();

        private static readonly Dictionary<Square, int> WhiteKingEndGame = new();
        private static readonly Dictionary<Square, int> BlackKingEndGame = new();

        static PieceEvaluation()
        {
            SetWhitePawn();
            SetBlackPawn();

            SetWhiteKnight();
            SetBlackKnight();

            SetWhiteBishop();
            SetBlackBishop();

            SetWhiteRook();
            SetBlackRook();

            SetWhiteQueen();
            SetBlackQueen();

            SetWhiteKingMiddleGame();
            SetBlackKingMiddleGame();

            SetWhiteKingEndGame();
            SetBlackKingEndGame();

            SetPieceValue();
        }

        public static int Evaluate(Square square, PieceType piece, Color color, bool endGame) 
        {
            return color == Color.White
               ? PieceValue[piece] + EvaluateSquare(square, piece, color, endGame)
               : -PieceValue[piece] - EvaluateSquare(square, piece, color, endGame);
        }
        private static int EvaluateSquare(Square square, PieceType piece, Color color, bool endGame) 
        {
                switch (piece)
                {
                    case PieceType.Pawn: return color == Color.White ? WhitePawn[square] : BlackPawn[square];

                    case PieceType.Rook: return color == Color.White ? WhiteRook[square] : BlackRook[square];

                    case PieceType.Bishop: return color == Color.White ? WhiteBishop[square] : BlackBishop[square];

                    case PieceType.Knight: return color == Color.White ? WhiteKnight[square] : BlackKnight[square];

                    case PieceType.King:
                                        if (endGame) { return color == Color.White ? WhiteKingEndGame[square] : BlackKingEndGame[square]; } 
                                        else { return color == Color.White ? WhiteKingMiddleGame[square] : BlackKingMiddleGame[square]; }

                    case PieceType.Queen: return color == Color.White ? WhiteQueen[square] : BlackQueen[square];
                }
            
            throw new InvalidOperationException();          
        }

        private static void SetPieceValue() 
        {
            PieceValue.Add(PieceType.Pawn, 100);
            PieceValue.Add(PieceType.Bishop, 330);
            PieceValue.Add(PieceType.Knight, 320);
            PieceValue.Add(PieceType.Rook, 500);
            PieceValue.Add(PieceType.Queen, 950);
            PieceValue.Add(PieceType.King, 20_000);
        }
        private static void SetWhitePawn() 
        {
            string[] values = "5,10,10,-20,-20,10,10,5,5,-5,-10,0,0,-10,-5,5,0,0,0,20,20,0,0,0,5,5,10,25,25,10,5,5,10,10,20,30,30,20,10,10,50,50,50,50,50,50,50,50".Split(',');

            int counter = 0;
            
            for (byte rank = 2; rank <= 7 ; rank++)
            {
                for (byte file = 1; file <= 8; file++)
                {
                    WhitePawn.Add(new Square(file, rank), int.Parse(values[counter]));
                    counter++;
                }

            }
        }
        private static void SetBlackPawn()
        {
            string[] values = "5,10,10,-20,-20,10,10,5,5,-5,-10,0,0,-10,-5,5,0,0,0,20,20,0,0,0,5,5,10,25,25,10,5,5,10,10,20,30,30,20,10,10,50,50,50,50,50,50,50,50".Split(',');

            int counter = 0;

            for (byte rank = 7; rank >= 2; rank--)
            {
                for (byte file = 1; file <= 8; file++)
                {
                    BlackPawn.Add(new Square(file, rank), int.Parse(values[counter]));
                    counter++;
                }

            }
        }

        private static void SetWhiteKnight()
        {
            string[] values = "-50,-40,-30,-30,-30,-30,-40,-50,-40,-20,0,5,5,0,-20,-40,-30,5,10,15,15,10,5,-30,-30,0,15,20,20,15,0,-30,-30,5,15,20,20,15,5,-30,-30,0,10,15,15,10,0,-30,-40,-20,0,0,0,0,-20,-40,-50,-40,-30,-30,-30,-30,-40,-50".Split(',');

            int counter = 0;

            for (byte rank = 1; rank <= 8; rank++)
            {
                for (byte file = 1; file <= 8; file++)
                {
                    WhiteKnight.Add(new Square(file, rank), int.Parse(values[counter]));
                    counter++;
                }

            }
        }
        private static void SetBlackKnight()
        {
            string[] values = "-50,-40,-30,-30,-30,-30,-40,-50,-40,-20,0,5,5,0,-20,-40,-30,5,10,15,15,10,5,-30,-30,0,15,20,20,15,0,-30,-30,5,15,20,20,15,5,-30,-30,0,10,15,15,10,0,-30,-40,-20,0,0,0,0,-20,-40,-50,-40,-30,-30,-30,-30,-40,-50".Split(',');

            int counter = 0;

            for (byte rank = 8; rank >= 1; rank--)
            {
                for (byte file = 1; file <= 8; file++)
                {
                    BlackKnight.Add(new Square(file, rank), int.Parse(values[counter]));
                    counter++;
                }
            }
        }

        private static void SetWhiteBishop()
        {
            string[] values = "-20,-10,-10,-10,-10,-10,-10,-20,-10,5,0,0,0,0,5,-10,-10,10,10,10,10,10,10,-10,-10,0,10,10,10,10,0,-10,-10,5,5,10,10,5,5,-10,-10,0,5,10,10,5,0,-10,-10,0,0,0,0,0,0,-10,-20,-10,-10,-10,-10,-10,-10,-20".Split(',');

            int counter = 0;

            for (byte rank = 1; rank <= 8; rank++)
            {
                for (byte file = 1; file <= 8; file++)
                {
                    WhiteBishop.Add(new Square(file, rank), int.Parse(values[counter]));
                    counter++;
                }
            }
        }
        private static void SetBlackBishop()
        {
            string[] values = "-20,-10,-10,-10,-10,-10,-10,-20,-10,5,0,0,0,0,5,-10,-10,10,10,10,10,10,10,-10,-10,0,10,10,10,10,0,-10,-10,5,5,10,10,5,5,-10,-10,0,5,10,10,5,0,-10,-10,0,0,0,0,0,0,-10,-20,-10,-10,-10,-10,-10,-10,-20".Split(',');

            int counter = 0;

            for (byte rank = 8; rank >= 1; rank--)
            {
                for (byte file = 1; file <= 8; file++)
                {
                    BlackBishop.Add(new Square(file, rank), int.Parse(values[counter]));
                    counter++;
                }

            }
        }

        private static void SetWhiteRook()
        {
            string[] values = "0,0,0,5,5,0,0,0,-5,0,0,0,0,0,0,-5,-5,0,0,0,0,0,0,-5,-5,0,0,0,0,0,0,-5,-5,0,0,0,0,0,0,-5,-5,0,0,0,0,0,0,-5,5,10,10,10,10,10,10,5,0,0,0,0,0,0,0,0".Split(',');

            int counter = 0;

            for (byte rank = 1; rank <= 8; rank++)
            {
                for (byte file = 1; file <= 8; file++)
                {
                    WhiteRook.Add(new Square(file, rank), int.Parse(values[counter]));
                    counter++;
                }
            }
        }
        private static void SetBlackRook()
        {
            string[] values = "0,0,0,5,5,0,0,0,-5,0,0,0,0,0,0,-5,-5,0,0,0,0,0,0,-5,-5,0,0,0,0,0,0,-5,-5,0,0,0,0,0,0,-5,-5,0,0,0,0,0,0,-5,5,10,10,10,10,10,10,5,0,0,0,0,0,0,0,0".Split(',');

            int counter = 0;

            for (byte rank = 8; rank >= 1; rank--)
            {
                for (byte file = 1; file <= 8; file++)
                {
                    BlackRook.Add(new Square(file, rank), int.Parse(values[counter]));
                    counter++;
                }
            }
        }

        private static void SetWhiteQueen()
        {
            string[] values = "-20,-10,-10,-5,-5,-10,-10,-20,-10,0,5,0,0,0,0,-10,-10,5,5,5,5,5,0,-10,0,0,5,5,5,5,0,-5,-5,0,5,5,5,5,0,-5,-10,0,5,5,5,5,0,-10,-10,0,0,0,0,0,0,-10,-20,-10,-10,-5,-5,-10,-10,-20".Split(',');

            int counter = 0;

            for (byte rank = 1; rank <= 8; rank++)
            {
                for (byte file = 1; file <= 8; file++)
                {
                    WhiteQueen.Add(new Square(file, rank), int.Parse(values[counter]));
                    counter++;
                }
            }
        }
        private static void SetBlackQueen()
        {
            string[] values = "-20,-10,-10,-5,-5,-10,-10,-20,-10,0,5,0,0,0,0,-10,-10,5,5,5,5,5,0,-10,0,0,5,5,5,5,0,-5,-5,0,5,5,5,5,0,-5,-10,0,5,5,5,5,0,-10,-10,0,0,0,0,0,0,-10,-20,-10,-10,-5,-5,-10,-10,-20".Split(',');

            int counter = 0;

            for (byte rank = 8; rank >= 1; rank--)
            {
                for (byte file = 1; file <= 8; file++)
                {
                    BlackQueen.Add(new Square(file, rank), int.Parse(values[counter]));
                    counter++;
                }
            }
        }

        private static void SetWhiteKingMiddleGame()
        {
            string[] values = "20,30,10,0,0,10,30,20,20,20,0,0,0,0,20,20,-10,-20,-20,-20,-20,-20,-20,-10,-20,-30,-30,-40,-40,-30,-30,-20,-30,-40,-40,-50,-50,-40,-40,-30,-30,-40,-40,-50,-50,-40,-40,-30,-30,-40,-40,-50,-50,-40,-40,-30,-30,-40,-40,-50,-50,-40,-40,-30".Split(',');

            int counter = 0;

            for (byte rank = 1; rank <= 8; rank++)
            {
                for (byte file = 1; file <= 8; file++)
                {
                    WhiteKingMiddleGame.Add(new Square(file, rank), int.Parse(values[counter]));
                    counter++;
                }
            }
        }
        private static void SetBlackKingMiddleGame()
        {
            string[] values = "20,30,10,0,0,10,30,20,20,20,0,0,0,0,20,20,-10,-20,-20,-20,-20,-20,-20,-10,-20,-30,-30,-40,-40,-30,-30,-20,-30,-40,-40,-50,-50,-40,-40,-30,-30,-40,-40,-50,-50,-40,-40,-30,-30,-40,-40,-50,-50,-40,-40,-30,-30,-40,-40,-50,-50,-40,-40,-30".Split(',');

            int counter = 0;

            for (byte rank = 8; rank >= 1; rank--)
            {
                for (byte file = 1; file <= 8; file++)
                {
                    BlackKingMiddleGame.Add(new Square(file, rank), int.Parse(values[counter]));
                    counter++;
                }
            }
        }

        private static void SetWhiteKingEndGame()
        {
            string[] values = "-50,-30,-30,-30,-30,-30,-30,-50,-30,-30,0,0,0,0,-30,-30,-30,-10,20,30,30,20,-10,-30,-30,-10,30,40,40,30,-10,-30,-30,-10,30,40,40,30,-10,-30,-30,-10,20,30,30,20,-10,-30,-30,-20,-10,0,0,-10,-20,-30,-50,-40,-30,-20,-20,-30,-40,-50".Split(',');

            int counter = 0;

            for (byte rank = 1; rank <= 8; rank++)
            {
                for (byte file = 1; file <= 8; file++)
                {
                    WhiteKingEndGame.Add(new Square(file, rank), int.Parse(values[counter]));
                    counter++;
                }
            }
        }
        private static void SetBlackKingEndGame()
        {
            string[] values = "-50,-30,-30,-30,-30,-30,-30,-50,-30,-30,0,0,0,0,-30,-30,-30,-10,20,30,30,20,-10,-30,-30,-10,30,40,40,30,-10,-30,-30,-10,30,40,40,30,-10,-30,-30,-10,20,30,30,20,-10,-30,-30,-20,-10,0,0,-10,-20,-30,-50,-40,-30,-20,-20,-30,-40,-50".Split(',');

            int counter = 0;

            for (byte rank = 8; rank >= 1; rank--)
            {
                for (byte file = 1; file <= 8; file++)
                {
                    BlackKingEndGame.Add(new Square(file, rank), int.Parse(values[counter]));
                    counter++;
                }
            }
        }
    }
}