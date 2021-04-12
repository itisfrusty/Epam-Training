using System;

namespace lab_6_inheritance_interfaces
{
    interface IConvertible
    {
        string ConvertToSharp(string str);
        string ConvertToVB(string str);
    }

    interface ICodeChecker
    {
        bool CheckCodeSyntax(string str1, string str2);
    }

    class ProgramHelper : ProgramConverter, ICodeChecker
    {
        public new string ConvertToSharp(string str)
        {
            return "Конвертирование в C# выполнено успешно!";
        }

        public new string ConvertToVB(string str)
        {
            return "Конвертирование в VB выполнено успешно!";
        }

        public bool CheckCodeSyntax(string str1, string str2)
        {
            if (str2 == "C#")
            {
                if (str1[str1.Length - 1] == ';')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (str2 == "VB")
            {
                if (str1[str1.Length - 1] != ';')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }

    class ProgramConverter : IConvertible
    {
        public string ConvertToSharp(string str)
        {
            return "Конвертирование в C# выполнено успешно!";
        }

        public string ConvertToVB(string str)
        {
            return "Конвертирование в VB выполнено успешно!";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string SyntaxString, LanguageString;

            ProgramConverter[] Elements =
            {
                new ProgramHelper(),
                new ProgramConverter(),
                new ProgramConverter(),
                new ProgramHelper(),
                new ProgramConverter(),
                new ProgramHelper(),
                new ProgramHelper()
            };

            Console.Write("Введите кодовую строку: ");
            SyntaxString = Console.ReadLine();
            Console.Write("Введите язык программирования: ");
            LanguageString = Console.ReadLine();
            ProgramConverter Object;

            for (int i = 0; i < Elements.Length; i++)
            {
                Object = Elements[i] as ProgramHelper;
                if (Object != null)
                {
                    Console.WriteLine($"{i + 1}.{Elements[i].GetType()} реализует интерфейс ICodeChecker:");
                    ProgramHelper Helper = new ProgramHelper();
                    if (Helper.CheckCodeSyntax(SyntaxString, LanguageString))
                    {
                        if (LanguageString == "C#")
                        {
                            Console.WriteLine(Elements[i].ConvertToVB(SyntaxString));
                        }
                        else if (LanguageString == "VB")
                        {
                            Console.WriteLine(Elements[i].ConvertToSharp(SyntaxString));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неправильный язык программирования!");
                    }
                }
                else
                {
                    Console.WriteLine($"{i + 1}.{Elements[i].GetType()} не реализует интерфейс ICodeChecker => " +
                        $"выполняется два метода преобразования:");
                    Console.WriteLine(Elements[i].ConvertToSharp(SyntaxString));
                    Console.WriteLine(Elements[i].ConvertToVB(SyntaxString));
                }
            }
        }
    }
}
