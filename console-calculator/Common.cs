
namespace console_calculator {

    /**
    * \brief Класс для использования общих функций.
    */
    class Common {
        /**
        * \brief Функция проверки строки на число.
        * 
        * \param [in] symbol - входная строка.
        * \return возвращает true - в случае, если входная строка является числом, false - иначе.
        */
        public bool isNumber(string symbol) {
            double o;
            if (double.TryParse(symbol, out o)) {
                return true;
            }

            return false;
        }
    }
}
