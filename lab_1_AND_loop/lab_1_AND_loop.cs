using System;

namespace lab_1_AND_loop
{
    class Program
    {
        static long Fact(long value)
        {
            return (value == 0) ? 1 : value * Fact(value - 1);
        }
            static void Main(string[] args)
        {
            Console.WriteLine("Input k: ");
            int k = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Input x: ");
            double x = double.Parse (Console.ReadLine());
            double s = 0;

            for (int n = 0; n <= k; n++)
                s += Math.Pow(-1, n) * Math.Pow(x, 2*n + 1) / Fact(2*n + 1);

            Console.WriteLine("Result of given sum: {0}", s.ToString());
            Console.ReadKey();

        }
    }
}
