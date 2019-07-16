using System;

namespace console_calculator {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine("Введите ваше имя:");

            string sName = Console.ReadLine();

            Console.WriteLine("Привет, " + sName);

            Console.WriteLine("Нажмите ENTER что бы выйти из программы");

            Console.Read();
        }
    }
}
