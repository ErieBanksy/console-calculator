using System;
using System.Collections.Generic;

namespace console_calculator {
    class Tests {

        Calculation calc = new Calculation();
        PostfixNotation postfixNot = new PostfixNotation();
        TokenSequence ts = new TokenSequence();

        public void testExamples() {
            getExample("1---2^2", 1);
            getExample("2+3*4", 2);
            getExample("(1+2*4)/2", 3);
            getExample("(8+2*5)/(1+3*2-4)", 4);
            getExample("3+4*2/(1-5)^2", 5);
            getExample("---1+--2^2*3", 6);
            getExample("2^-3", 7);
            getExample("-2^3", 8);
            getExample("2^(-2+2)", 9);
            getExample("21/7+2^1--5*42+140", 10);
        }

        private void getExample(string example, int exampleNum) {
            Console.Write("Example " + exampleNum + ": ");
            List<string> pf = ts.getTokenSeq(example);

            pf = postfixNot.getPostfixNotation(pf);

            Console.Write(example + "\n Postfix: ");
            foreach (string el in pf) {
                Console.Write(el);
            }
            Console.WriteLine();

            Stack<double> res = calc.getResult(pf);

            Console.Write("Result: ");
            foreach (float f in res) {
                Console.Write(f);
            }
            Console.WriteLine("\n");
        }

    }
}
