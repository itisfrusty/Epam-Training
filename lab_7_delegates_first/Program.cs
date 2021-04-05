using System;

namespace lab_7_delegates_first
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Func<Action<char>, bool, double, double> lambda = (f, flag, x) =>
            {
                f('a');
                return (flag) ? (2 * x) : (x * x);
            };
            Action<char> TT = MyFunc;
            Console.WriteLine(lambda(TT, true, 2));
        }
        static void MyFunc(char s)
        {
            Console.WriteLine(s + " b c d e");
        }
    }
}