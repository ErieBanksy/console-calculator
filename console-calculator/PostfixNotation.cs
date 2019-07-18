using System;
using System.Collections.Generic;

namespace console_calculator {
    public enum PRIORITY_LEVEL { HIGH = 3, MEDIUM = 2, LOW = 1, LOWEST = 0, NONE = -1};
    
    class PostfixNotation {
        Common f = new Common();

        public List<char> getPostfixNotation(List<char> exp) {
            List<char> postfixForm = new List<char>();
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < exp.Count; i++) {
                //Console.WriteLine("char = " + exp[i]);
                if (f.isNumber(exp[i])) {
                    //Console.WriteLine("1");
                    postfixForm.Add(exp[i]);
                }
                else if (exp[i] == 'm') {
                    stack.Push(exp[i]);
                }
                else if (stack.Count == 0 || stack.Peek() == '(') {
                    //Console.WriteLine("2");
                    stack.Push(exp[i]);
                }
                else if ((getPriority(exp[i]) > getPriority(stack.Peek())) && getPriority(exp[i]) != PRIORITY_LEVEL.NONE) {
                    //Console.WriteLine("3");
                    stack.Push(exp[i]);
                }
                else if ((getPriority(exp[i]) <= getPriority(stack.Peek())) && getPriority(exp[i]) != PRIORITY_LEVEL.NONE) {
                    //Console.WriteLine("4");
                    while (getPriority(exp[i]) < getPriority(stack.Peek())) { // < или <= 
                        postfixForm.Add(stack.Pop());
                        if (stack.Count == 0) {
                            break;
                        }
                    }
                    stack.Push(exp[i]);
                }
                else if (exp[i] == '(') {
                    //Console.WriteLine("5");
                    stack.Push(exp[i]);
                }
                else if (exp[i] == ')') {
                    //Console.WriteLine("6");
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


        private PRIORITY_LEVEL getPriority(char operation) {
            if (operation == '^') {
                return PRIORITY_LEVEL.HIGH;
            }
            else if (operation == 'm') {
                return PRIORITY_LEVEL.MEDIUM;
            }
            else if (operation == '*' || operation == '/') {
                return PRIORITY_LEVEL.LOW;
            }
            else if (operation == '+' || operation == '-') {
                return PRIORITY_LEVEL.LOWEST;
            }
            else {
                return PRIORITY_LEVEL.NONE;
            }
        }
    }
}
