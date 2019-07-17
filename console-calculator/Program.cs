using System;
using System.Collections.Generic;

namespace console_calculator {
    class Program {
        static void Main(string[] args) {
            PostfixNotation postfixNot = new PostfixNotation();

            Console.Write("Example 1: ");
            string expression = "2+3*4";
            Console.Write(expression + "\n Result: ");
            List<char> pf = postfixNot.getPostfixNotation(expression);
            foreach (char el in pf) {
                Console.Write(el);
            }
            Console.WriteLine("\n");

            Console.Write("Example 2: ");
            expression = "(1+2*4)/2";
            Console.Write(expression + "\n Result: ");
            pf = postfixNot.getPostfixNotation(expression);
            foreach (char el in pf) {
                Console.Write(el);
            }
            Console.WriteLine("\n");

            Console.Write("Example 3: ");
            expression = "(8+2*5)/(1+3*2-4)";
            Console.Write(expression + "\n Result: ");
            pf = postfixNot.getPostfixNotation(expression);
            foreach (char el in pf) {
                Console.Write(el);
            }
            Console.WriteLine("\n");

            Console.Write("Example 4: ");
            expression = "3+4*2/(1-5)^2";
            Console.Write(expression + "\n Result: ");
            pf = postfixNot.getPostfixNotation(expression);
            foreach (char el in pf) {
                Console.Write(el);
            }
            Console.WriteLine("\n");

            return;
        }
    }

    class Calculation {

    }
    
}
