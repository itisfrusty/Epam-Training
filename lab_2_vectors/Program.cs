using System;
using System.IO;
using System.Linq;

namespace lab_2_vectors
{
    class Program
    {
            static void Main()
            {
                Console.WriteLine("Введите делитель делитель: ");
                int c = int.Parse(Console.ReadLine());
                File.WriteAllText(@"C:\git\lab_2_vectors\Outlet.txt", String.Join(Environment.NewLine, File.ReadAllText(@"C:\git\lab_2_vectors\Inlet.txt")
                    .Split(' ').ToArray().Where((v, i) => c % (i + 1) == 0).ToArray()));
            }
        
    }
}
