using GameCore;
using System;
using System.Diagnostics;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Fen.SetBoardByFen("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");

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
