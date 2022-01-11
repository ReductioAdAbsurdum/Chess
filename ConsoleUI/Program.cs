using GameCore;
using GameCore.Evaluation;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ConsoleUI
{          
    // Fen.SetBoardByFen("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
    class Program
    {
        private delegate T MeasureFunc<T>();
        static void Main(string[] args)
        {
            Fen.SetBoardByFen("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR b KQkq - 0 1");
          
            MeasureFunc<int> d1 = BoardEvaluation.Evaluate;
            MeasureFunc<List<Move>> d2 = LegalMoves.GetAll;

            Console.WriteLine(LegalMoves.GetAll().Count);
            MeasureFunctionSpeed(d1);
            MeasureFunctionSpeed(d2);

            int x = BoardEvaluation.Evaluate();

        }        
        static void MeasureFunctionSpeed<T>(MeasureFunc<T> func)
        {
            Stopwatch s = new Stopwatch();

            func();

            s.Start();

            for (int i = 0; i < 25_000; i++)
            {
                func();
            }

            s.Stop();
            Console.WriteLine((decimal)s.ElapsedMilliseconds / 25 + " µs");

            s.Reset();
            s.Start();

            for (int i = 0; i < 25_000; i++)
            {
                func();
            }

            s.Stop();
            Console.WriteLine((decimal)s.ElapsedMilliseconds / 25 + " µs");
        }
    }
}
