using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1_I_loop_example
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, eps;
            Console.WriteLine("Введите начальное значение а отрезка [a,b]:");
            a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите конечное значение b отрезка [a,b]:");
            b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите точность eps:");
            eps = Convert.ToDouble(Console.ReadLine());

            double approximatione = fInitialapproximationе(a, b);
            double c = fFixedpoint(a, b);
            double x0;
            int k = 0;
            do
            {
                k++;
                x0 = approximatione;
                approximatione = x0 - ((f(x0) * (x0 - c)) / (f(x0) - f(c)));
            }
            while (Math.Abs(x0 - approximatione) > eps);
            Console.WriteLine($"Приближение равно {approximatione} в результате {k} итераций:");
            Console.ReadKey();

        }
        static double f(double x)
        {
            return Math.Tan(x) + 1 / 3 * Math.Pow(Math.Tan(x), 3) + 1 / 5 * Math.Pow(Math.Tan(x), 5) - 1 / 3;
        }
        static double fDerivative(double x)
        {
            return 1 / Math.Pow(Math.Cos(x), 2) + Math.Pow(Math.Tan(x), 2) / Math.Pow(Math.Cos(x), 2) + Math.Pow(Math.Tan(x), 4) / Math.Pow(Math.Cos(x), 2);
        }
        static double fSecondDerivative(double x)
        {
            return 2 * Math.Sin(x) * Math.Pow(Math.Tan(x), 2) / Math.Pow(Math.Cos(x), 3) + ((2 * Math.Pow(Math.Tan(x), 2) + 2) * Math.Tan(x)) / Math.Pow(Math.Cos(x), 2);
        }
        static double fInitialapproximationе(double a, double b)
        {
            return f(a) * fSecondDerivative(a) > 0 ? b : a;
        }

        static double fFixedpoint(double a, double b)
        {
            return f(a) * fSecondDerivative(a) > 0 ? a : b;
        }

    }
}
