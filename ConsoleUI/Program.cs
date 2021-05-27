using GameCore;
using System;
using System.Diagnostics;

namespace ConsoleUI
{
    class Program
    {
        // 0.219 ms --- Start

        // 0.161 ms -> Bishop
        // 0.115 ms -> Queen
        // 0.105 ms -> King
        // 0.090 ms -> Pawn

        // 0.1 - 0.09 Current
        static void Main(string[] args)
        {
            Fen.SetBoardByFen("rnbqkbnr/8/8/8/8/8/8/RNBQKBNR w KQkq - 0 1");

            Stopwatch s = new Stopwatch();
            
            var y = LegalMoves.GetAll(); 

            s.Start();

            for (int i = 0; i < 100000; i++)
            {
                var X = LegalMoves.GetAll();
            }

            Console.WriteLine(s.ElapsedMilliseconds);
            s.Reset();
            s.Start();
            for (int i = 0; i < 100000; i++)
            {
                var X = LegalMoves.GetAll();
            }

            Console.WriteLine(s.ElapsedMilliseconds);

        }
    }
}
