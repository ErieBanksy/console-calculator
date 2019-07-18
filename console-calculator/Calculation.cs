using System;
using System.Collections.Generic;

namespace console_calculator {
    class Calculation {

        Common f = new Common();

        public Stack<double> getResult(List<char> pfnt) {
            Stack<double> resStack = new Stack<double>();
            double a, b, res;
            foreach (char c in pfnt) {
                if (f.isNumber(c)) {
                    resStack.Push(char.GetNumericValue(c));
                }
                else if (c == '+') {
                    a = resStack.Pop();
                    b = resStack.Pop();
                    res = b + a;
                    resStack.Push(res);
                }
                else if (c == '-') {
                    a = resStack.Pop();
                    b = resStack.Pop();
                    res = b - a;
                    resStack.Push(res);
                }
                else if (c == '*') {
                    a = resStack.Pop();
                    b = resStack.Pop();
                    res = b * a;
                    resStack.Push(res);
                }
                else if (c == '/') {
                    a = resStack.Pop();
                    b = resStack.Pop();
                    res = b / a;
                    resStack.Push(res);
                }
                else if (c == '^') {
                    a = resStack.Pop();
                    b = resStack.Pop();
                    res = Math.Pow(b, a);
                    //for (int i = 0; i < a - 1; i++) {
                    //    b = b * b;
                    //}
                    resStack.Push(res);
                }
                else if (c == 'm') {
                    a = resStack.Pop();
                    res = a * (-1);
                    resStack.Push(res);
                }
            }
            return resStack;
        }
    }
}
