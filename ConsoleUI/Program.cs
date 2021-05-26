using GameCore;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Fen.SetBoardByFen("rnbqkbnr/pppppppp/8/8/8/8/PPPP1PPP/RNBQKBNR w KQkq - 0 1");

            var y = LegalMoves.GetAll();
            var x = Fen.GetCurrentFen();
        }
    }
}
