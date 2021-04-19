using System;

namespace lab_7_delegates_first
    {
        class Program
        {
            public static void action1(Func<int> func, char ch1, char ch2)
            {
                Console.WriteLine("Первое выполнено успешно...");
            }

            public static void action2(Func<int> func, char ch1, char ch2)
            {
                Console.WriteLine("Второе выполнено успешно...");
            }

            public static int func()
            {
                return 1;
            }

            static void Main(string[] args)
            {
                Func<int> F = func;
                Action<Func<int>, char, char> Delegate = action1;
                Delegate += action2;
                Delegate(F, 'a', 'b');
            }
        }
    }