using System;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число, из которого вычислять корень: ");
            double y = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите корень: ");
            double z = double.Parse(Console.ReadLine());

            Console.WriteLine("Ответ методом Ньютона: ");
            Console.WriteLine(SqrtN(z, y));

            Console.WriteLine("Ответ методом Math.Pow: ");
            double v = Math.Pow(y, 1/z);
            Console.WriteLine(v);
            Console.ReadKey();
        }

        static double Pow(double a, int pow)
        {
            double result = 1;
            for (int i = 0; i < pow; i++) result *= a;
            return result;
        }

        static double SqrtN(double n, double A, double eps = 0.0001)
        {
            var x0 = A / n;
            var x1 = (1 / n) * ((n - 1) * x0 + A / Pow(x0, (int)n - 1));

            while (Math.Abs(x1 - x0) > eps)
            {
                x0 = x1;
                x1 = (1 / n) * ((n - 1) * x0 + A / Pow(x0, (int)n - 1));
            }

            return x1;
        }
    }
}