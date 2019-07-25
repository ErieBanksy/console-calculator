using System;
using System.Collections.Generic;

namespace console_calculator {

    /**
    * \brief Класс для вычисления результата математического выражения.
    */
    class Calculation {

        Common f = new Common();

        /**
        * \brief Функция вычисления значения входного математического выражения.
        * 
        * \param [in] pfnt - список содержащий элементы постфиксной записи, полученной из входной строки.
        * \return возвращает полученое значение математического выражения.
        */
        public Stack<double> getResult(List<string> pfnt) {
            Stack<double> resStack = new Stack<double>();
            double a, b, res, outRes;
            foreach (string c in pfnt) {
                if (f.isNumber(c)) {
                    if (double.TryParse(c, out outRes)) {
                        resStack.Push(outRes);
                    }
                    else {
                        Console.WriteLine("Error in TryParse string");
                    }
                }
                else if (c == "+") {
                    a = resStack.Pop();
                    b = resStack.Pop();
                    res = b + a;
                    resStack.Push(res);
                }
                else if (c == "-") {
                    a = resStack.Pop();
                    b = resStack.Pop();
                    res = b - a;
                    resStack.Push(res);
                }
                else if (c == "*") {
                    a = resStack.Pop();
                    b = resStack.Pop();
                    res = b * a;
                    resStack.Push(res);
                }
                else if (c == "/") {
                    a = resStack.Pop();
                    b = resStack.Pop();
                    res = b / a;
                    resStack.Push(res);
                }
                else if (c == "^") {
                    a = resStack.Pop();
                    b = resStack.Pop();
                    res = Math.Pow(b, a);
                    resStack.Push(res);
                }
                else if (c == "m") {
                    a = resStack.Pop();
                    res = a * (-1);
                    resStack.Push(res);
                }
            }
            return resStack;
        }
    }
}
