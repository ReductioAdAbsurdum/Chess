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
            //Fen.SetBoardByFen("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
            Fen.SetBoardByFen("rnbqkbnr/pppppppp/8/8/8/P/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
            //Fen.SetBoardByFen("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
            //Fen.SetBoardByFen("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
            //Fen.SetBoardByFen("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
          
            MeasureFunc<int> evaluation = BoardEvaluation.Evaluate;
            MeasureFunc<List<Move>> legalMoves = LegalMoves.GetAll;

            Console.WriteLine($"Number of legal moves is: {LegalMoves.GetAll().Count}");
            
            Console.Write($"Average time to execute board evaluation is: ");
            MeasureFunctionSpeed(evaluation);
            Console.WriteLine();

            Console.Write($"Average time to get legal moves is: ");
            MeasureFunctionSpeed(legalMoves);
            Console.WriteLine();

            Console.WriteLine($"Board evaluation is: {BoardEvaluation.Evaluate()}");

        }        
        static void MeasureFunctionSpeed<T>(MeasureFunc<T> func)
        {
            // WarmUp first!!!
            Stopwatch s = new Stopwatch();

            func();

            s.Start();

            for (int i = 0; i < 25_000; i++)
            {
                func();
            }

            s.Stop();            
            s.Reset();
            s.Start();

            for (int i = 0; i < 25_000; i++)
            {
                func();
            }

            s.Stop();
            Console.Write((decimal)s.ElapsedMilliseconds / 25 + " µs");
        }
    }
}
