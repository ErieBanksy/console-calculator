using System.Collections.Generic;

namespace console_calculator {
    public enum PRIORITY_LEVEL { HIGH = 3, MEDIUM = 2, LOW = 1, LOWEST = 0, NONE = -1};

    /**
    * \brief Класс для получения последовательности, содержащей постфиксную запись.
    */
    class PostfixNotation {
        Common f = new Common();

        /**
        * \brief Функция получения постфиксной записи.
        * 
        * Алгоритм перевода выражения в постфиксную запись следующий.
        *
        * 1. Константы и переменные кладутся в формируемую запись в порядке их появления в исходном массиве.
        * 2. При появлении операции в исходном массиве:
        *   2.1. Если в стеке нет операций или верхним элементом стека является открывающая скобка, операции кладётся в стек;
        *   2.2. Если новая операции имеет больший* приоритет, чем верхняя операции в стеке, то новая операции кладётся в стек;
        *   2.3. Если новая операция имеет меньший или равный приоритет, чем верхняя операции в стеке, то операции, находящиеся 
        *        в стеке, до ближайшей открывающей скобки или до операции с приоритетом меньшим, чем у новой операции, перекладываются
        *        в формируемую запись, а новая операции кладётся в стек.
        * 3. Открывающая скобка кладётся в стек.
        * 4. Закрывающая скобка выталкивает из стека в формируемую запись все операции до ближайшей открывающей скобки, открывающая 
        *    скобка удаляется из стека.
        * 5. После того, как достигнут конец исходного выражения, операции, оставшиеся в стеке, перекладываются в формируемое выражение.
        * 
        * \param [in] exp - список токенов, полученный их входной строки.
        * \return возвращает список, содержащий постфиксную запись в требуемом порядке.
        */
        public List<string> getPostfixNotation(List<string> exp) {
            List<string> postfixForm = new List<string>();
            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < exp.Count; i++) {
                if (f.isNumber(exp[i])) {
                    postfixForm.Add(exp[i]);
                }
                else if (exp[i] == "m") {
                    stack.Push(exp[i]);
                }
                else if (stack.Count == 0 || stack.Peek() == "(") {
                    stack.Push(exp[i]);
                }
                else if ((getPriority(exp[i]) > getPriority(stack.Peek())) && getPriority(exp[i].ToString()) != PRIORITY_LEVEL.NONE) {
                    stack.Push(exp[i]);
                }
                else if ((getPriority(exp[i]) <= getPriority(stack.Peek())) && getPriority(exp[i]) != PRIORITY_LEVEL.NONE) {
                    while (getPriority(exp[i]) <= getPriority(stack.Peek())) { 
                        postfixForm.Add(stack.Pop());
                        if (stack.Count == 0) {
                            break;
                        }
                    }
                    stack.Push(exp[i]);
                }
                else if (exp[i] == "(") {
                    stack.Push(exp[i]);
                }
                else if (exp[i] == ")") {
                    while (stack.Peek() != "(") {
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



        /**
        * \brief Функция получения приоритета математической операции.
        * 
        * \param [in] operation - математическая операция.
        * \return возвращает значение приоритета для входной математической операции.
        */
        private PRIORITY_LEVEL getPriority(string operation) {
            if (operation == "^") {
                return PRIORITY_LEVEL.HIGH;
            }
            else if (operation == "m") {
                return PRIORITY_LEVEL.MEDIUM;
            }
            else if (operation == "*" || operation == "/") {
                return PRIORITY_LEVEL.LOW;
            }
            else if (operation == "+" || operation == "-") {
                return PRIORITY_LEVEL.LOWEST;
            }
            else {
                return PRIORITY_LEVEL.NONE;
            }
        }
    }
}
