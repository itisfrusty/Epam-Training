using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab_4
{

    /// Создаем класс для операций над векторами.
    class Vector
    {
        private int x;
        private int y;
        private int z;


        /// Создаем конструктор для инициализации компонент вектора.
        public Vector(int X, int Y, int Z)
        {
            x = X;
            y = Y;
            z = Z;
        }

        /// Х-компонента
        public int X
        {
            get
            {
                return x;
            }
        }

        /// Y-компонента
        public int Y
        {
            get
            {
                return y;
            }
        }

        /// Z-компонента.
        public int Z
        {
            get
            {
                return z;
            }
        }


        /// Метод возвращающий сумму 2-х векторов.
        public static Vector operator +(Vector V1, Vector V2)
        {
            return new Vector(V1.X + V2.X, V1.Y + V2.Y, V1.Z + V2.Z);
        }

        /// Метод, возвращающий вектор равный произведение 2-х векторов.
        public static Vector operator *(Vector V1, Vector V2)
        {
            return new Vector(V1.X * V2.X, V1.Y * V2.Y, V1.Z * V2.Z);
        }

        /// Метод, возвращающий разность 2-х векторов.
        public static Vector operator -(Vector V1, Vector V2)
        {
            return new Vector(V1.X - V2.X, V1.Y - V2.Y, V1.Z - V2.Z);
        }

        /// Метод, возвращающий вектор умноженый на скаляр.
        public static Vector operator *(Vector V1, int scalar)
        {
            return new Vector(V1.X * scalar, V1.Y * scalar, V1.Z * scalar);
        }

        /// Метод, возвращающий скалярное произведение двух векторов.
        public static int ScalarProduct(Vector V1, Vector V2)
        {
            return (V1.X * V2.X + V1.Y * V2.Y + V1.Z * V2.Z);
        }

        /// Метод, возращающий векторное произведение двух векторов.
        public static int VectorProduct(Vector V1, Vector V2)
        {
            return ((V1.Y * V2.Z - V1.Z * V2.Y) - (V1.X * V2.Z - V1.Z * V2.X) + (V1.X * V2.Y - V1.Y * V2.X));
        }

        /// Метод, возвращающий модуль вектора.
        public static double ModulVector(Vector V1)
        {
            return (Math.Sqrt(V1.X * V1.X + V1.Y * V1.Y + V1.Z * V1.Z));
        }

        public override string ToString()
        {
            return "{" + X + ", " + Y + ", " + Z + "}";
        }

    }

    class VectorDemo
    {
        static void Main(string[] args)
        {
            int x0, y0, z0, x1, y1, z1;

            Console.WriteLine("Введите значение первого вектора x0 y0 z0: ");
            string textV1 = Console.ReadLine();
            string[] numbers1 = textV1.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            x0 = Convert.ToInt32(numbers1 [0]);
            y0 = Convert.ToInt32(numbers1 [1]); 
            z0 = Convert.ToInt32(numbers1 [2]);

            Console.WriteLine("Введите значение первого вектора x1 y1 z1: ");
            string textV2 = Console.ReadLine();
            string[] numbers2 = textV2.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            x1 = Convert.ToInt32(numbers2 [0]);
            y1 = Convert.ToInt32(numbers2 [1]);
            z1 = Convert.ToInt32(numbers2 [2]);

            Console.WriteLine("Введите скаляр: ");
            int scale = Convert.ToInt32(Console.ReadLine());

            Vector v0 = new Vector(x0, y0, z0);
            Vector v1 = new Vector(x1, y1, z1);
            Vector SumVectors = v0 + v1;
            Vector Substraction = v0 - v1;
            Vector ScalarProduct1 = v0 * scale;
            Vector ScalarProduct2 = v1 * scale;
            Vector VectorProduct = v0 * v1;
            int ScalarProductVectors = Vector.VectorProduct(v0, v1);
            double ModulVector1 = Vector.ModulVector(v0);
            double ModulVector2 = Vector.ModulVector(v1);
            Console.WriteLine("Первый исходный вектор: " + v0 +
                               "\nВторой исходный вектор: " + v1 +
                               "\nСумма этих векторов: " + SumVectors +
                               "\nРазность этих векторов: " + Substraction +
                               "\nПервый вектор умноженный на скаляр: " + ScalarProduct1 +
                               "\nВторой вектор умноженный на скаляр: " + ScalarProduct2 +
                               "\nСкалярное произведение векторов: " + ScalarProductVectors +
                               "\nВекторное произведение векторов: " + VectorProduct +
                               "\nМодуль первого вектора: " + ModulVector1 +
                               "\nМодуль второго вектора: " + ModulVector2);
            Console.ReadKey();
        }
    }

}