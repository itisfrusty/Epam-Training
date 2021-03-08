using System;
using System.IO;
using System.Threading.Tasks;

namespace lab_2_strings
{
    class Program
    {
        static void Main(string[] args)
            {
            StreamReader infile = new StreamReader(@"C:\git\lab_2_strings\Inlet.txt");
            StreamWriter outfile = new StreamWriter(@"C:\git\lab_2_strings\Outlet.txt");

            int minInd = 0;
            string intext = infile.ReadToEnd();
            string[] dd = intext.Split(' ');
                int min = dd[0].Length;

                for (int i = 0; i < dd.Length; i++)
                    if (min > dd[i].Length) 
                { 
                    min = dd[i].Length; minInd = i; 
                }

            outfile.Write("самое кроткое слово: {0} ", dd[minInd]);
            outfile.Write("индекс самого кроткого слова: {0} ", minInd);
            
            Console.ReadLine();
            }
    }
}
