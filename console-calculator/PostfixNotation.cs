using System;
using System.Collections.Generic;

namespace console_calculator {
    public enum PRIORITY_LEVEL { HIGH = 3, MEDIUM = 2, LOW = 1, LOWEST = 0};
    
    class PostfixNotation {
        Common f = new Common();

        public List<char> getPostfixNotation(string exp) {
            List<char> postfixForm = new List<char>();
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < exp.Length; i++) {
                if (f.isNumber(exp[i])) {
                    postfixForm.Add(exp[i]);
                }
                else if (stack.Count == 0 || stack.Peek() == '(') {
                    stack.Push(exp[i]);
                }
                else if ((getPriority(exp[i]) > getPriority(stack.Peek())) && getPriority(exp[i]) != PRIORITY_LEVEL.LOWEST) {
                    stack.Push(exp[i]);
                }
                else if ((getPriority(exp[i]) <= getPriority(stack.Peek())) && getPriority(exp[i]) != PRIORITY_LEVEL.LOWEST) {
                    while (getPriority(exp[i]) <= getPriority(stack.Peek())) {
                        postfixForm.Add(stack.Pop());
                        if (stack.Count == 0) {
                            break;
                        }
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


        private PRIORITY_LEVEL getPriority(char operation) {
            if (operation == '^') {
                return PRIORITY_LEVEL.HIGH;
            }
            else if (operation == '*' || operation == '/') {
                return PRIORITY_LEVEL.MEDIUM;
            }
            else if (operation == '+' || operation == '-') {
                return PRIORITY_LEVEL.LOW;
            }
            else {
                return PRIORITY_LEVEL.LOWEST;
            }
        }
    }
}
