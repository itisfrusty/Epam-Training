using System;
using System.Threading;
using Ping_Pong;

namespace lab_7_delegates_first_ping_pong_
{
    class Program
    {
        static void StartGame(Ping A, Pong B)
        {
            Random rand = new Random();
            int HitCounter = 1;
            int HitNumber = rand.Next(3, 5);
            for (int i = 0; i < HitNumber; i++)
            {
                Console.Write(HitCounter + ". ");
                A.OnPing();
                HitCounter++;
                Thread.Sleep(700);
                Console.Write(HitCounter + ". ");
                B.OnPong();
                HitCounter++;
                Thread.Sleep(700);
            }
        }

        static void Main(string[] args)
        {
            Ping A = new Ping();
            Pong B = new Pong();
            StartGame(A, B);
        }
    }

}