using GameCore;
using GameCore.Evaluation;
using System;
using System.Diagnostics;

namespace ConsoleUI
{          
    // Fen.SetBoardByFen("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
    class Program
    {
        static void Main(string[] args)
        {
            Fen.SetBoardByFen("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR b KQkq - 0 1");
            MeasureBoardEvaluation();


        }
        static void MeasureLegalMovesGetAll() 
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
        static void MeasureBoardEvaluation()
        {
            Stopwatch s = new Stopwatch();

            BoardEvaluation.Evaluate();

            s.Start();

            for (int i = 0; i < 25_000; i++)
            {
                BoardEvaluation.Evaluate();
            }

            s.Stop();
            Console.WriteLine((decimal)s.ElapsedMilliseconds / 25 + " µs");

            s.Reset();
            s.Start();

            for (int i = 0; i < 25_000; i++)
            {
                BoardEvaluation.Evaluate();
            }

            s.Stop();
            Console.WriteLine((decimal)s.ElapsedMilliseconds / 25 + " µs");
        }
    }
}
