using System;
using System.IO;

namespace lab_5_exeptions 
{
    class WrongMatrixException : Exception
    {
        public WrongMatrixException(Matrix M1, Matrix M2)
        {
            Length1 = M1.Length;
            Width1 = M1.Width;
            Length2 = M2.Length;
            Width2 = M2.Width;
            PrintData();
        }

        private int Length1;
        private int Width1;
        private int Length2;
        private int Width2;

        private string data
        {
            get
            {
                return $"Первая матрица:\nКоличество строк:" +
                    $" {Length1}\nКоличество столбцов: {Width1}\nВторая матрица:\n" +
                    $"Количество строк:" +
                    $" {Length2}\nКоличество столбцов: {Width2}";
            }
        }

        private void PrintData()
        {
            Console.WriteLine(data);
        }
    }

    class Matrix
    {
        private int[,] Matrix_;
        private int M;
        private int N;

        public int Length { get; set; }
        public int Width { get; set; }

        public Matrix(int[,] Matrix, int M, int N)
        {
            Matrix_ = Matrix;
            this.M = M;
            this.N = N;
            Length = M;
            Width = N;
        }

        public static Matrix Summ(Matrix M1, Matrix M2)
        {
            Matrix ResultMatrix, BuffMatrix;
            int[,] ResMatrix = new int[M1.M, M1.N];
            if (M1.M < M2.M)
            {
                BuffMatrix = M1;
                M1 = M2;
                M2 = BuffMatrix;
            }
            for (int i = 0; i < M1.M; i++)
            {
                for (int j = 0; j < M2.N; j++)
                {
                    try
                    {
                        ResMatrix[i, j] = M1.Matrix_[i, j] + M2.Matrix_[i, j];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Нельзя складывать матрицы разной размернсти");
                        return M1;
                    }
                }
            }
            ResultMatrix = new Matrix(ResMatrix, M1.M, M1.N);
            return ResultMatrix;
        }

        public static Matrix Diff(Matrix M1, Matrix M2)
        {
            Matrix ResultMatrix, BuffMatrix;
            int[,] ResMatrix = new int[M1.M, M1.N];
            if (M1.M < M2.M)
            {
                BuffMatrix = M1;
                M1 = M2;
                M2 = BuffMatrix;
            }
            for (int i = 0; i < M1.M; i++)
            {
                for (int j = 0; j < M2.N; j++)
                {
                    try
                    {
                        ResMatrix[i, j] = M1.Matrix_[i, j] - M2.Matrix_[i, j];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Нельзя вычитать матрицы разной размернсти");
                        return M1;
                    }
                }
            }
            ResultMatrix = new Matrix(ResMatrix, M1.M, M1.N);
            return ResultMatrix;
        }

        public static Matrix Multipication(Matrix M1, Matrix M2)
        {
            if (M1.Length != M2.Width)
            {
                Console.WriteLine("Ошибка!");
                throw new WrongMatrixException(M1, M2);
            }
            Matrix ResultMatrix;
            int[,] ResMatrix = new int[M1.M, M2.N];
            int Summ = 0, Index = 0;
            for (int i = 0; i < M1.M; i++)
            {
                for (Index = 0; Index < M2.N; Index++)
                {
                    for (int j = 0; j < M2.M; j++)
                    {
                        try
                        {
                            Summ += M1.Matrix_[i, j] * M2.Matrix_[j, Index];
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Колличество строк первой матрицы должно быть" +
                                " равно кулличеству столбцов второй матрицы");
                            return M1;
                        }
                    }
                    ResMatrix[i, Index] = Summ;
                    Summ = 0;
                }
            }
            ResultMatrix = new Matrix(ResMatrix, M1.M, M2.N);
            return ResultMatrix;
        }

        public static Matrix GetEmpty(int Length, int Width)
        {
            int[,] Matrix = new int[Length, Width];
            return new Matrix(Matrix, Length, Width);
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < this.M; i++)
            {
                for (int j = 0; j < this.N; j++)
                {
                    Console.Write(this.Matrix_[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[,] Matrix_1, Matrix_2;
            string[] FileString;
            int M1, N1 = 0, M2, N2;
            using (var file = new StreamReader(Path.GetFullPath("Inlet.txt")))
            {
                int i;
                string[] Aux;
                string CheckString = "";
                for (i = 0; ; i++)
                {
                    CheckString = file.ReadLine();
                    if (CheckString == "------")
                    {
                        break;
                    }
                    N1 = CheckString.Split(' ').Length;
                }
                M1 = i;
                for (i = 0; !file.EndOfStream; i++)
                {
                    CheckString = file.ReadLine();
                }
                M2 = i;
                Aux = CheckString.Split(' ');
                N2 = Aux.Length;
                file.Close();
            }
            using (var file = new StreamReader(Path.GetFullPath("Inlet.txt")))
            {
                Matrix_1 = new int[M1, N1];
                int i, j;
                for (i = 0; i < M1; i++)
                {
                    FileString = file.ReadLine().Split(' ');
                    for (j = 0; j < N1; j++)
                    {
                        Matrix_1[i, j] = int.Parse(FileString[j]);
                    }
                }
                file.ReadLine();
                Matrix_2 = new int[M2, N2];
                for (i = 0; i < M2; i++)
                {
                    FileString = file.ReadLine().Split(' ');
                    for (j = 0; j < N2; j++)
                    {
                        Matrix_2[i, j] = int.Parse(FileString[j]);
                    }
                }

            }
            Matrix Matrix1 = new Matrix(Matrix_1, M1, N1);
            Matrix Matrix2 = new Matrix(Matrix_2, M2, N2);
            Matrix MatrixSum, MatrixMultiplication, MatrixDifferent;
            MatrixSum = Matrix.Summ(Matrix1, Matrix2);
            MatrixDifferent = Matrix.Diff(Matrix1, Matrix2);
            MatrixMultiplication = Matrix.Multipication(Matrix1, Matrix2);
            Console.WriteLine("Сумма двух матриц: ");
            MatrixSum.PrintMatrix();
            Console.WriteLine();
            Console.WriteLine("Разность двух матриц: ");
            MatrixDifferent.PrintMatrix();
            Console.WriteLine();
            Console.WriteLine("Произведение двух матриц: ");
            MatrixMultiplication.PrintMatrix();
        }
    }
}