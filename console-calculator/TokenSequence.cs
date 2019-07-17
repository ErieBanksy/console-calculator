using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console_calculator {
    class TokenSequence {
        Common comFunc = new Common();

        public List<char> getTokenSeq(string expression) {
            List<char> tokenSeq = new List<char>();
            for (int i = 0; i < expression.Length; i++) {
                tokenSeq.Add(expression[i]);
            }

            for (int i = 1; i < tokenSeq.Count; i++) {
                if (i - 1 == 0 && tokenSeq[i] == '-') {
                    tokenSeq[i] = 'm';
                }
                else if ((tokenSeq[i - 1] == '*' || tokenSeq[i - 1] == '/' || tokenSeq[i - 1] == '+' || tokenSeq[i - 1] == '-') && !comFunc.isNumber(tokenSeq[i])) {
                    tokenSeq[i] = 'm';
                }
                else {
                    tokenSeq[i] = expression[i];
                }
            }

            //foreach (char el in exp) {
            //    Console.Write(el);
            //}
            //Console.WriteLine("\n");

            return tokenSeq;
        }
    }
}
