using GameCore;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Fen.SetBoardByFen("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");

            var y = LegalMoves.GetAll();
            var X = LegalMoves.GetAll();


            var x = Fen.GetCurrentFen();
        }
    }
}
