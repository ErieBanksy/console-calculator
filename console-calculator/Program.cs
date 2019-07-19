using System;
using System.Collections.Generic;

namespace console_calculator {
    class Program {
        static void Main(string[] args) {
            //Tests t = new Tests();
            //t.testExamples();

            TokenSequence ts = new TokenSequence();
            PostfixNotation pn = new PostfixNotation();
            Calculation calc = new Calculation();

            bool exitFlag = false;

            while (!exitFlag) {
                Console.WriteLine("Введите выражение для вычисления:");
                string expression = Console.ReadLine();

                List<string> tokenSeqList = ts.getTokenSeq(expression);

                tokenSeqList = pn.getPostfixNotation(tokenSeqList);

                Stack<double> result = calc.getResult(tokenSeqList);

                Console.Write("Результат: ");
                foreach (float f in result) {
                    Console.Write(f);
                }
                Console.WriteLine("\n");

                if (Console.ReadKey().Key == ConsoleKey.Escape) {
                    exitFlag = true;
                }
            }

            return;
        }
    }
    
}
