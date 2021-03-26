using System;
using System.Threading;

namespace lab_7
{
    public delegate void Delegate();

    class Ping
    {
        private static int count = 1;

        public static void PrintPing()
        {
            Console.Write($"{count}. Pong received Ping\n");
            count += 2;
            Thread.Sleep(360);
        }
    }

    class Pong
    {
        private static int count = 2;

        public static void PrintPong()
        {
            Console.Write($"{count}. Ping received Pong\n");
            count += 2;
            Thread.Sleep(360);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Delegate del;
            Random random = new Random();
            del = new Delegate(Ping.PrintPing);
            del += Pong.PrintPong;
            int i = 0;
            while (i < 3)
            {
                del();
                i++;
            }
        }
    }
}
