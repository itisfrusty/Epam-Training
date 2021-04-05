using System;
using System.Collections.Generic;
using System.Text;

namespace Ping_Pong
{
    public delegate void Delegate();

    partial class Ping
    {
        public event Delegate ping = null;

        public static void PrintPing()
        {
            Console.WriteLine("Ping received Ping");
        }

        public void OnPing()
        {
            ping = Pong.PrintPong;
            ping();
        }
    }

    partial class Pong
    {
        public event Delegate pong = null;

        public static void PrintPong()
        {
            Console.WriteLine("Pong received Ping");
        }

        public void OnPong()
        {
            pong = Ping.PrintPing;
            pong();
        }

    }
}
