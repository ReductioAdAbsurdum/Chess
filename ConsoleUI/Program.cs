using GameCore;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Fen.SetBoardByFen("rnbqkbnr/8/8/8/8/8/8/RNBQKBNR w KQkq - 0 1");

            var y = LegalMoves.GetAll(); // 26ms
            var X = LegalMoves.GetAll();


            var x = Fen.GetCurrentFen();
        }
    }
}
