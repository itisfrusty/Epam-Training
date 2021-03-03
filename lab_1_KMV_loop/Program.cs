﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1_KMV_loop
{
    class Program
    {
        static long Fact(long x)
        {
            return (x == 0) ? 1 : x * Fact(x - 1);
        }

        static void Main(string[] args)
        {
            double x, eps;
            Console.WriteLine("Введите х: ");
            x = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите точность eps: ");
            eps = Convert.ToDouble(Console.ReadLine());
            double term = 1, result = 0;
            int n = 0;

            do
            {
                result += (Math.Pow(Math.Log(3), n++)/Fact(n++) * term);
                term *= x;

            } while (Math.Abs(Math.Pow(Math.Log(3), n + 1) / Fact(n + 1) * term) - (Math.Pow(Math.Log(3), n) / Fact(n) * term) > eps);

            Console.WriteLine("Значение суммы: ");
            Console.WriteLine(result);
            Console.ReadKey();

        }
    }
}