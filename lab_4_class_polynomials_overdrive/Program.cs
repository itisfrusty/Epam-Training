using System;
using System.Text;
using System.IO;

namespace lab_4_class_polunomials_overdrive
{
    class Polinom
    {
        private int[] Power;
        private int Number = 0;
        private int[] Q;
        private int NumberOfX
        {
            get
            {
                int Counter = 0;
                for (int i = 0; i < p.Length; i++)
                {
                    if (p[i] == 'x')
                    {
                        Counter++;
                    }
                }
                return Counter;
            }
        }
        private int NumberOfMonimials
        {
            get
            {
                string str = p;
                Transform(ref str);
                string[] Buff = str.Split(' ');
                return Buff.Length;
            }
        }
        private string p;

        public Polinom(string p1)
        {
            StringBuilder buff = new StringBuilder();
            p1 = buff.Append("+ " + p1).ToString();
            this.p = p1;
            Transform(ref p1);
            PutToArrays(p1.Split(' '));
        }

        private static void FillUp(ref Polinom p1, ref Polinom p2)
        {
            StringBuilder str = new StringBuilder();
            int num1 = p1.NumberOfMonimials;
            int num2 = p2.NumberOfMonimials;
            if (p1.NumberOfMonimials == p2.NumberOfMonimials)
            {
                return;
            }
            else if (p1.NumberOfMonimials < p2.NumberOfMonimials)
            {
                str.Append(p1.p);
                while (num1 < num2)
                {
                    str.Append(" +0");
                    num1++;
                }
                p1.p = str.ToString();
                return;
            }
            str.Append(p2.p);
            while (num1 > num2)
            {
                str.Append(" +0");
                num2++;
            }
            p2.p = str.ToString();
            return;
        }

        private void PutToArrays(string[] str)
        {
            int aux, Counter = 0;
            char[] buff;
            Power = new int[NumberOfX];
            Q = new int[NumberOfX];
            for (int i = 0; i < str.Length; i++)
            {
                if (int.TryParse(str[i], out aux))
                {
                    this.Number += aux;
                    continue;
                }
                buff = str[i].ToCharArray();
                bool parse = int.TryParse(buff[(Array.IndexOf(buff, 'x') + 1)..buff.Length], out Power[Counter]);
                if (!parse)
                {
                    Power[Counter] = 1;
                }
                parse = int.TryParse(buff[0..Array.IndexOf(buff, 'x')], out Q[Counter]);
                if (!parse)
                {
                    if (buff[0] == '+')
                    {
                        Q[Counter] = 1;
                    }
                    else
                    {
                        Q[Counter] = -1;
                    }
                }
                Counter++;
            }
        }

        private static void Transform(ref string str)
        {
            str = str.Replace("*", "");
            str = str.Replace("^", "");
            for (int i = 0; i < str.Length; i++)
            {
                if (IsOperation(str[i]))
                {
                    str = str.Remove((i + 1), 1);
                }
            }
        }

        private static bool IsOperation(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                case '/':
                case '*':
                    return true;
                default:
                    return false;
            }
        }

        private static string Leftover(Polinom P1, Polinom P2)
        {
            bool Access = false;
            StringBuilder Left = new StringBuilder();
            for (int i = 0; i < P1.NumberOfX; i++)
            {
                Access = false;
                for (int j = 0; j < P2.NumberOfX; j++)
                {
                    if (P1.Power[i] == P2.Power[j])
                    {
                        Access = true;
                    }
                }
                if (!Access)
                {
                    Left.Append(P1.Q[i] + "x^" + P1.Power[i] + " + ");
                }
            }
            return Left.ToString();
        }

        public static string operator +(Polinom p1, Polinom p2)
        {
            StringBuilder ResultPolinom = new StringBuilder();
            bool Access = false;
            for (int i = 0; i < p1.NumberOfX; i++)
            {
                Access = false;
                for (int j = 0; j < p2.NumberOfX; j++)
                {
                    if (p1.Power[i] == p2.Power[j])
                    {
                        ResultPolinom.Append((p1.Q[i] + p2.Q[j]).ToString() + "x^" + p1.Power[i] + " + ");
                        Access = true;
                    }
                }
                if (!Access)
                {
                    ResultPolinom.Append(p1.Q[i].ToString() + "x^" + p1.Power[i] + " + ");
                }
            }
            ResultPolinom.Append(Leftover(p2, p1));
            ResultPolinom.Append((p1.Number + p2.Number).ToString());
            return ResultPolinom.ToString();
        }

        public static string operator -(Polinom p1, Polinom p2)
        {
            StringBuilder ResultPolinom = new StringBuilder();
            bool Access = false;
            FillUp(ref p1, ref p2);
            for (int i = 0; i < p2.Q.Length; i++)
            {
                p2.Q[i] = -p2.Q[i];
            }
            p2.Number = -p2.Number;
            for (int i = 0; i < p1.NumberOfX; i++)
            {
                Access = false;
                for (int j = 0; j < p2.NumberOfX; j++)
                {
                    if (p1.Power[i] == p2.Power[j])
                    {
                        ResultPolinom.Append((p1.Q[i] + p2.Q[j]).ToString() + "x^" + p1.Power[i] + " + ");
                        Access = true;
                    }
                }
                if (!Access)
                {
                    ResultPolinom.Append(p1.Q[i].ToString() + "x^" + p1.Power[i] + " + ");
                }
            }
            ResultPolinom.Append(Leftover(p2, p1));
            ResultPolinom.Append((p1.Number + p2.Number).ToString());
            for (int i = 0; i < p2.Q.Length; i++)
            {
                p2.Q[i] = -p2.Q[i];
            }
            p2.Number = -p2.Number;
            return ResultPolinom.ToString();
        }

        public static string operator *(Polinom p1, Polinom p2)
        {
            StringBuilder ResultString = new StringBuilder();
            for (int i = 0; i < p1.NumberOfX + 1; i++)
            {
                for (int j = 0; j < p2.NumberOfX + 1; j++)
                {
                    try
                    {
                        ResultString.Append(p1.Q[i] * p2.Q[j] + "x^" + (p1.Power[i] + p2.Power[j]) + " + ");
                    }
                    catch
                    {
                        if (i == p1.NumberOfX && j == p2.NumberOfX)
                        {
                            ResultString.Append(p1.Number * p2.Number);
                        }
                        else if (i == p1.NumberOfX)
                        {
                            if (j != p2.NumberOfX)
                            {
                                ResultString.Append(p1.Number * p2.Q[j] + "x^" + p2.Power[j] + " + ");
                            }
                        }
                        else if (j == p2.NumberOfX)
                        {
                            ResultString.Append(p1.Q[i] * p2.Number + "x^" + p1.Power[i] + " + ");
                        }
                    }
                }
            }
            return ResultString.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string str1;
            string str2;
            using (var file = new StreamReader(Path.GetFullPath("Inlet.in")))
            {
                str1 = file.ReadLine();
                str2 = file.ReadLine();
                file.Close();
            }
            Polinom p1 = new Polinom(str1);
            Polinom p2 = new Polinom(str2);
            Console.WriteLine(str1);
            Console.WriteLine(str2);
            Console.WriteLine("Sum: " + (p1 + p2));
            Console.WriteLine("Diff: " + (p1 - p2));
            Console.WriteLine("Multiply: " + p1 * p2);
            using (var file = new StreamWriter(Path.GetFullPath("Outlet.out")))
            {
                file.WriteLine(str1);
                file.WriteLine(str2);
                file.WriteLine("Sum: " + (p1 + p2));
                file.WriteLine("Diff: " + (p1 - p2));
                file.Write("Multiply: " + p1 * p2);
                file.Close();
            }
        }
    }
}
