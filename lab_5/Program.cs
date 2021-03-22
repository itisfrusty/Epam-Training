using System;

namespace lab_5
{
    class Program
    {
        class Matrix
        {
            public float[,] array { get; }
            public int cols { get; }
            public int rows { get; }
            public Matrix(int cols, int rows)
            {
                this.cols = cols;
                this.rows = rows;
                array = new float[cols, rows];
            }
            public void Fill()
            {
                Random r = new Random();
                for (int i = 0; i < cols; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        array[i, j] = r.Next(100);
                    }
                }
            }
            public void Show()
            {
                for (int i = 0; i < cols; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        Console.Write(array[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
            public void Addition(float[,] array2)
            {
                if (array.Length == array2.Length)
                {
                    for (int i = 0; i < cols; i++)
                    {
                        for (int j = 0; j < rows; j++)
                        {
                            array[i, j] += array2[i, j];
                        }
                    }
                }
                else
                {
                    throw new Exception("Ваша ошибка.");
                }
            }
            public void Multiplication(float[,] array2)
            {
                if (array.Length == array2.Length)
                {
                    for (int i = 0; i < cols; i++)
                    {
                        for (int j = 0; j < rows; j++)
                        {
                            array[i, j] *= array2[i, j];
                        }
                    }
                }
                else
                {
                    throw new Exception("Ваша ошибка.");
                }
            }
        }
    }
}
