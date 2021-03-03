using System;

namespace lab_1_ex_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число в десятичной системе: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ваше число в двоичной системе: ");
            Console.WriteLine(Convert.ToString(a, 2));
        }
    }
}
