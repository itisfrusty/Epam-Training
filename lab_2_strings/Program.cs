using System;
using System.IO;
using System.Threading.Tasks;

namespace lab_2_strings
{
    class Program
    {
        static void Main(string[] args)
            {
            StreamReader infile = new StreamReader("Inlet.txt");

            int minInd = 0;
            string intext = infile.ReadToEnd();
            string[] dd = intext.Split(' ');
                int min = dd[0].Length;

                for (int i = 0; i < dd.Length; i++)
                    if (min > dd[i].Length) 
                { 
                    min = dd[i].Length; minInd = i; 
                }

            StreamWriter outfile = new StreamWriter("Outlet.txt");
            outfile.WriteLine("Самое кроткое слово: {0} ", dd[minInd]);
            outfile.WriteLine("Индекс самого кроткого слова: {0} ", minInd);
            outfile.Close();
            }
    }
}
