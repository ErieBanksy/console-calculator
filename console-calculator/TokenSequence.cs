﻿using System.Collections.Generic;


namespace console_calculator {

    /**
    * \brief Класс для получения последовательности токенов из входной строки.
    */
    class TokenSequence {
        Common comFunc = new Common();

        /**
        * \brief Функция получения списка токенов.
        * 
        * Числа, математические операции и скобки добавляются в список токенов.
        * Унарный минус заменяет на токен m.
        * 
        * \param [in] expression - входная строка.
        * \return возвращает список токенов полученный из входной строки.
        */
        public List<string> getTokenSeq(string expression) {
            List<string> tmpTokenSeq = new List<string>();
            List<string> tokenSeq = new List<string>();

            for (int i = 0; i < expression.Length; i++) {
                tmpTokenSeq.Add(expression[i].ToString());
            }

            if (tmpTokenSeq[0] == "-") {
                tmpTokenSeq[0] = "m";
            }

            for (int j = 1; j < tmpTokenSeq.Count; j++) {
                if ((tmpTokenSeq[j - 1] == "*" || tmpTokenSeq[j - 1] == "/" ||
                    tmpTokenSeq[j - 1] == "+" || tmpTokenSeq[j - 1] == "-" ||
                    tmpTokenSeq[j - 1] == "m" || tmpTokenSeq[j - 1] == "(" ||
                    tmpTokenSeq[j - 1] == "^") && tmpTokenSeq[j] == "-") {
                    tmpTokenSeq[j] = "m";
                }
                else {
                    tmpTokenSeq[j] = expression[j].ToString();
                }
            }
            

            string value = "";
            for (int i = 0; i < tmpTokenSeq.Count; i++) {
                if (comFunc.isNumber(tmpTokenSeq[i])) {
                    value = value + tmpTokenSeq[i];
                }
                else {
                    tokenSeq.Add(value);
                    tokenSeq.Add(tmpTokenSeq[i]);
                    value = "";
                }
            }
            if (value.Length != 0) {
                tokenSeq.Add(value);
            }

            return tokenSeq;
        }
    }
}
