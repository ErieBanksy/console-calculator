using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace console_calculator {
    class Common {
        public bool isNumber(char symbol) {
            if (symbol >= '0' && symbol <= '9') {
                return true;
            }

            return false;
        }
    }
}
