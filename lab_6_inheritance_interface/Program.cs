using System;

namespace lab_6
{
    internal class Program
    {
        private static void Main()
        {

            ProgramConverter[] programConverter = new ProgramConverter[3];
            programConverter[0] = new ProgramConverter();
            programConverter[1] = new ProgramHelper();
            programConverter[2] = new ProgramHelper();

            foreach (ProgramConverter element in programConverter)
            {
                // The operation ID for mapping to the called classes.
                Console.WriteLine("\nId {0}:", TransactionID.idOperation++);

                // We lead a ProgramConverter object to the ProgramHelper type.
                ProgramHelper programHelper = element as ProgramHelper;

                // Converting VB code to C#.
                string vbCode = element.ConvertToCSharp("VB CODE");
                Console.WriteLine(vbCode);

                // Checking the availability of the CodeCheckSyntax method of the ProgramHelper class.
                if (programHelper != null) // if casting is possible...
                {
                    programHelper.CodeCheckSyntax(vbCode, "C#");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка проверки синтаксиса C#. Модуль CodeCheckSyntax недоступен!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                // Converting C# code to VB.
                string csharpCode = element.ConvertToVB("C# CODE");
                Console.WriteLine(csharpCode);

                // Checking the availability of the CodeCheckSyntax method of the ProgramHelper class.
                if (programHelper != null) // if casting is possible...
                {
                    programHelper.CodeCheckSyntax(csharpCode, "VB");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка проверки синтаксиса VB. Модуль CodeCheckSyntax недоступен!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }

            Console.ReadKey();
        }
    }
}
