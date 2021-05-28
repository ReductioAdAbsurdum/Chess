using GameCore;
using System;
using System.Diagnostics;

namespace ConsoleUI
{          
    // Fen.SetBoardByFen("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
    class Program
    {
        static void Main(string[] args)
        {
            Fen.SetBoardByFen("rnbqkbnr/pppppppp/8/QQQQQQQQ/8/8/8/4K3 w KQkq - 0 1");

            var y = LegalMoves.GetAll();

            MesureLegalMovesGetAll();
        }
        static void MesureLegalMovesGetAll() 
        {
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
