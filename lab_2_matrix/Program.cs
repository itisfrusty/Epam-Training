using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace lab_2_matrix
{
    class Program
    {
        static StreamReader inputfile = new StreamReader(@"C:\git\lab_2_matrix\Inlet.txt");
        static StreamWriter outputFile = new StreamWriter(@"C:\git\lab_2_matrix\Outlet.txt");
        static void Main(string[] args)
        {
            string[] N_M_ = inputfile.ReadLine().Trim().Split(' ');
            int N = int.Parse(N_M_[0]);
            int M = int.Parse(N_M_[1]);
            int CZ = int.Parse(N_M_[2]);
            int CV = int.Parse(N_M_[3]);
            int UZ = int.Parse(N_M_[4]);
            int UV = int.Parse(N_M_[5]);
            for (int i = 0; i < N; i++)
            {
                string textline = "";
                if (i + 1 <= N / 2)
                {
                    for (int j = 0; j < M; j++)
                    {
                        if (j + 1 <= M / 2)
                        {
                            textline = textline + CZ.ToString() + " ";
                        }
                        else
                        {
                            if (M % 2 == 1 && j == M / 2)
                            {
                                textline = textline + (CZ + CV).ToString() + " ";
                            }
                            else
                            {
                                textline = textline + CV.ToString() + " ";
                            }
                        }
                    }
                }
                else
                {
                    if (N % 2 == 1 && i == N / 2)
                    {
                        for (int j = 0; j < M; j++)
                        {
                            if (j + 1 <= M / 2)
                            {
                                textline = textline + (CZ + UZ).ToString() + " ";
                            }
                            else
                            {
                                if (M % 2 == 1 && j == M / 2)
                                {
                                    textline = textline + (CZ + CV + UZ + UV).ToString() + " ";
                                }
                                else
                                {
                                    textline = textline + (CV + UV).ToString() + " ";
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j < M; j++)
                        {
                            if (j + 1 <= M / 2)
                            {
                                textline = textline + UZ.ToString() + " ";
                            }
                            else
                            {
                                if (M % 2 == 1 && j == M / 2)
                                {
                                    textline = textline + (UZ + UV).ToString() + " ";
                                }
                                else
                                {
                                    textline = textline + UV.ToString() + " ";
                                }
                            }
                        }
                    }
                }
                if (i != N - 1)
                {// Это не последняя строка
                    outputFile.WriteLine(textline.Trim());
                }
                else
                { // Это последняя строка
                    outputFile.Write(textline.Trim());
                }
            }
            outputFile.Close();
        }
    }
}

