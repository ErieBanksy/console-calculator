using System;
using System.Collections.Generic;

namespace console_calculator {
    class Tests {

        Calculation calc = new Calculation();
        PostfixNotation postfixNot = new PostfixNotation();

        public void testExamples() {
            getExample("2+3*4", 1);
            getExample("(1+2*4)/2", 2);
            getExample("(8+2*5)/(1+3*2-4)", 3);
            getExample("3+4*2/(1-5)^2", 4);
        }

        private void getExample(string example, int exampleNum) {
            Console.Write("Example " + exampleNum + ": ");
            Console.Write(example + "\n Postfix: ");
            List<char> pf = postfixNot.getPostfixNotation(example);
            Stack<double> res = calc.getResult(pf);
            foreach (char el in pf) {
                Console.Write(el);
            }
            Console.WriteLine();
            Console.Write("Result: ");
            foreach (float f in res) {
                Console.Write(f);
            }
            Console.WriteLine("\n");
        }

    }
}
