using GameCore;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Fen.SetBoardByFen("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");

            var x = Fen.GetCurrentFen();
        }
    }
}
