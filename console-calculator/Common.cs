
namespace console_calculator {
    class Common {
        public bool isNumber(string symbol) {
            double o;
            if (double.TryParse(symbol, out o)) {
                return true;
            }

            return false;
        }
    }
}
