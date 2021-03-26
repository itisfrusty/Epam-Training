using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_6
{
        internal class ProgramConverter : IConvertible
        {
            public ProgramConverter()
            {
                Console.WriteLine("\nId {0}:", TransactionID.idClass++);
                Console.WriteLine("Class ProgramConverter");
            }

            public virtual string ConvertToCSharp(string textOnVB)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("Завершена ");
                return $"конвертация [{textOnVB}] в C#";
            }

            public virtual string ConvertToVB(string textOnCSharp)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("Завершена ");
                return $"конвертация [{textOnCSharp}] в VB";
            }
        }
}
