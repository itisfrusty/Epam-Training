using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GemFigure;
using System.IO;

namespace lab_8_collections
{
    class EllipseCollection<TKey, TValue> where TValue : Ellipse                           // Задание 1
    {
        public int Length { get; private set; } = 0;

        public Element[] Elements;

        private int index = -1;

        private bool IsLimitedCollection;

        public Element this[int Index]
        {
            get
            {
                return Elements[Index];
            }
            private set
            {
                Elements[Index] = value;
            }
        }

        public EllipseCollection(int NumberOfElements)
        {
            Length = NumberOfElements;
            IsLimitedCollection = true;
        }

        public EllipseCollection()
        {
            Length = 0;
            IsLimitedCollection = false;
        }

        ~EllipseCollection()
        {
            Elements = null;
        }

        public void Add(TKey Key, TValue Value)
        {
            if (!IsLimitedCollection)
            {
                Length++;
                if (Elements != null)
                {
                    Element[] Buff = new Element[Length];
                    Array.Copy(Elements, Buff, Elements.Length);
                    Elements = new Element[Buff.Length];
                    Array.Copy(Buff, Elements, Buff.Length);
                }
                else
                {
                    Elements = new Element[Length];
                }
                this[Length - 1] = new Element(Key, Value);
            }
            else
            {
                this[Length - 1] = new Element(Key, Value);
            }
        }

        public void Remove(TKey Key)
        {
            Element[] Buff = new Element[Length - 1];
            int j = 0;
            Array.Copy(Elements, Buff, Buff.Length);
            for (int i = 0; i <= Buff.Length; i++)
            {
                try
                {
                    if (Equals(Elements[i].Key, Key))
                    {
                        continue;
                    }
                    else
                    {
                        Buff[j] = Elements[i];
                        j++;
                    }
                }
                catch
                {
                    continue;
                }
            }
            Elements = Buff;
        }

        public void SortByArea()
        {
            for (int i = 0; i < Elements.Length; i++)
            {
                for (int j = Elements.Length - 1; j > i; j--)
                {
                    if (Elements[j].Value.S_Ellipse < Elements[j - 1].Value.S_Ellipse)
                    {
                        Element Buff = new Element(Elements[0].Key, Elements[0].Value);
                        Buff.Key = Elements[j].Key;
                        Buff.Value = Elements[j].Value;
                        Elements[j].Key = Elements[j - 1].Key;
                        Elements[j].Value = Elements[j - 1].Value;
                        Elements[j - 1].Key = Buff.Key;
                        Elements[j - 1].Value = Buff.Value;
                    }
                }
            }
        }

        public bool MoveNext()
        {
            if (index == Elements.Length - 1)
            {
                return false;
            }
            index++;
            return true;
        }

        public void Reset()
        {
            index = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return Elements.GetEnumerator();
        }

        public object Current
        {
            get
            {
                return Elements[index];
            }
        }

        public void WriteToFile()
        {
            using (var File = new StreamWriter(Path.GetFullPath("Outlet.txt")))
            {
                foreach (var item in Elements)
                {
                    File.Write("Ellipse " + item.Key + ": ");
                    File.Write("Diametres: " + item.Value.D1_DataChecking + ", " + item.Value.D2_DataChecking + "; ");
                    File.Write("Area: " + item.Value.S_Ellipse + "; ");
                    File.Write("SomeNumber: " + item.Value.SomeNumber + "; ");
                    File.Write("Perimetre: " + item.Value.P_Ellipse + "\n");
                }
                File.Dispose();
            }
        }

        public class Element
        {
            public TKey Key;
            public TValue Value;

            public Element(TKey Key, TValue Value)
            {
                this.Key = Key;
                this.Value = Value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            EllipseCollection<int, Ellipse> Collection = new EllipseCollection<int, Ellipse>();

            Random Rand = new Random();

            for (int i = 0; i < Rand.Next(10, 30); i++)
            {
                Collection.Add(Rand.Next(10, 30), new Ellipse(Rand.Next(1, 10), Rand.Next(1, 10)));
            }

            var CollectionElements = Collection.Elements;

            Console.WriteLine("Площади эллипсов:");

            foreach (var item in CollectionElements)
            {
                Console.WriteLine(item.Value.S_Ellipse);
            }

            Console.WriteLine("\nСортированнный вариант: ");

            Collection.SortByArea();

            foreach (var item in CollectionElements)
            {
                Console.WriteLine(item.Value.S_Ellipse);
            }

            Collection.WriteToFile();

            var NegativeColletion = CollectionElements.Where(i => i.Value.SomeNumber < 0);                 //
            var MinValue = NegativeColletion.Min(num => num.Value.SomeNumber);                            //    Задание 2
            var MaxValue = NegativeColletion.Max(num => num.Value.SomeNumber);                           //
            Console.WriteLine("\nЧисла из класса Ellipse: ");
            foreach (var item in CollectionElements)
            {
                Console.WriteLine(item.Value.SomeNumber);
            }
            Console.WriteLine("\n\nОтрицательные числа из класса Ellipse: ");
            foreach (var item in NegativeColletion)
            {
                Console.WriteLine(item.Value.SomeNumber);
            }

            Console.WriteLine($"\nМаксимальное отрицательное число: {MaxValue}\n" +
                $"Минимальное отрицательное число: {MinValue}");

            var GeneraCollection = CollectionElements.Where(i => i.Value.SomeNumber > 0).                                      //Задание 3
                OrderBy(i => i.Value.SomeNumber).Distinct().Take(CollectionElements.Length);

            Console.WriteLine("\n\nПоложительные элементы коллекции без повторений, расположенные по возрастанию: ");
            foreach (var item in GeneraCollection)
            {
                Console.WriteLine(item.Value.SomeNumber);
            }

            Console.WriteLine("\n\nCompareTo: " + CollectionElements[Rand.Next(0, CollectionElements.Length - 1)].
                Value.CompareTo(new Ellipse(Rand.Next(1, 10), Rand.Next(1, 10))));                                            //CompareTo()
        }
    }
}
