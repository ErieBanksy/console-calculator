using System;
using System.Collections.Generic;

namespace console_calculator {
    class Program {
        static void Main(string[] args) {
            algorithmDijkstra algDij = new algorithmDijkstra();

            Console.Write("Example 1: ");
            string expression = "2+3*4";
            Console.Write(expression + "\n Result: ");
            List<char> pf = algDij.infixToPostfixTranslation(expression);
            foreach (char el in pf) {
                Console.Write(el);
            }
            Console.WriteLine("\n");

            Console.Write("Example 2: ");
            expression = "(1+2*4)/2";
            Console.Write(expression + "\n Result: ");
            pf = algDij.infixToPostfixTranslation(expression);
            foreach (char el in pf) {
                Console.Write(el);
            }
            Console.WriteLine("\n");

            Console.Write("Example 3: ");
            expression = "(8+2*5)/(1+3*2-4)";
            Console.Write(expression + "\n Result: ");
            pf = algDij.infixToPostfixTranslation(expression);
            foreach (char el in pf) {
                Console.Write(el);
            }
            Console.WriteLine("\n");

            return;
        }
    }

    class Calculation {

    }

    public enum PRIORITY_LEVEL { LOW = 0, HIGH = 1, NONE = -1};

    class algorithmDijkstra {
        
        public List<char> infixToPostfixTranslation(string exp) {
            List<char> postfixForm = new List<char>();
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < exp.Length; i++) {
                if (isNumber(exp[i])) {
                    postfixForm.Add(exp[i]);
                }
                else if (stack.Count == 0 || stack.Peek() == '(') {
                    stack.Push(exp[i]);
                }
                else if (getPriority(exp[i]) > getPriority(stack.Peek()) && getPriority(exp[i]) != PRIORITY_LEVEL.NONE) {
                    stack.Push(exp[i]);
                }
                else if (getPriority(exp[i]) <= getPriority(stack.Peek()) && getPriority(exp[i]) != PRIORITY_LEVEL.NONE) {
                    while (stack.Peek() != '(' || getPriority(exp[i]) <= getPriority(stack.Peek())) {
                        postfixForm.Add(stack.Pop());
                    }
                    stack.Push(exp[i]);
                }
                else if (exp[i] == '(') {
                    stack.Push(exp[i]);
                }
                else if (exp[i] == ')') {
                    while (stack.Peek() != '(') {
                        postfixForm.Add(stack.Pop());
                    }
                    stack.Pop();
                }
            }

            while (stack.Count != 0) {
                postfixForm.Add(stack.Pop());
            }

            return postfixForm;
        }


        private bool isNumber(char symbol) {
            if (symbol >= '0' && symbol <= '9') {
                return true;
            }

            return false;
        }


        private PRIORITY_LEVEL getPriority(char operation) {
            if (operation == '*' || operation == '/') {
                return PRIORITY_LEVEL.HIGH;
            }
            else if (operation == '+' || operation == '-') {
                return PRIORITY_LEVEL.LOW;
            }

            return PRIORITY_LEVEL.NONE;
        }
    }
}
