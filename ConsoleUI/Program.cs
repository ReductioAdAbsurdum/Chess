using GameCore;
using System;
using System.Diagnostics;

namespace ConsoleUI
{
    class Program
    {
        // Get legal moves 65 µs Start
        // 59 µs Bishop L
        // 58.5 µs King branchless
        // 53.9 µs King castle fix
        // 37.8 µs With KingStar Method

        static void Main(string[] args)
        {
            Fen.SetBoardByFen("rnbqkbnr/pppppppp/8/8/PPPPPPPP/PPPPPPPP/PPPPPPPP/RNBQKBNR w KQkq - 0 1");

            Stopwatch s = new Stopwatch();
            
            var y = LegalMoves.GetAll(); 

            s.Start();

            for (int i = 0; i < 25_000; i++)
            {
                var X = LegalMoves.GetAll();
            }

            s.Stop();
            Console.WriteLine((decimal)s.ElapsedMilliseconds / 25 + " µs");
            
            s.Reset();
            s.Start();

            for (int i = 0; i < 25_000; i++)
            {
                var X = LegalMoves.GetAll();
            }
            
            s.Stop();
            Console.WriteLine((decimal)s.ElapsedMilliseconds / 25 + " µs");

        }
    }
}
