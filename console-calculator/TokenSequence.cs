using System;
using System.Collections.Generic;

namespace console_calculator {
    class TokenSequence {
        Common comFunc = new Common();

        public List<char> getTokenSeq(string expression) {
            List<char> tokenSeq = new List<char>();
            for (int i = 0; i < expression.Length; i++) {
                tokenSeq.Add(expression[i]);
            }

            if (tokenSeq[0] == '-') {
                tokenSeq[0] = 'm';
            }

            for (int i = 1; i < tokenSeq.Count; i++) {
                if ((tokenSeq[i - 1] == '*' || tokenSeq[i - 1] == '/' || 
                    tokenSeq[i - 1] == '+' || tokenSeq[i - 1] == '-' || 
                    tokenSeq[i - 1] == 'm' || tokenSeq[i - 1] == '(' ||
                    tokenSeq[i - 1] == '^') && tokenSeq[i] == '-') {
                    tokenSeq[i] = 'm';
                }
                else {
                    tokenSeq[i] = expression[i];
                }
            }

            return tokenSeq;
        }
    }
}
