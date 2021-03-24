using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6
{
    internal class ProgramHelper : ProgramConverter, ICodeChecker
    {
        /// A constructor that provides information on the involved classes and ID for a binding to operations.
        public ProgramHelper()
        {
            Console.WriteLine("Class ProgramHelper");
        }

        /// The CodeCheckSyntax() method verifies the correctness of converting one programming language to another.
        public bool CodeCheckSyntax(string verificationString, string languageUsed)
        {
            switch (languageUsed)
            {
                case "C#":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"Проверка операции \"{verificationString}\" ...");
                    Console.WriteLine("Пожалуйста, не выключайте компьютер до завершения проверки.");
                    return true;
                case "VB":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"Запущена проверка операции \"{verificationString}\" ...");
                    Console.WriteLine("Пожалуйста, не выключайте компьютер до завершения проверки.");
                    return true;
                default:
                    return false;
            }
        }
    }
}
