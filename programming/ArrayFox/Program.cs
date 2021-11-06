using System.Collections.ObjectModel;
using System;

namespace ArrayFox
{
    class Program
    {
        public static int[] collection { get; set; }
        static void Main(string[] args)
        {
            int[] collectionFirst = GenerationArray();
            int[] collectionLast = new int[5] { -1, 10, -23, 2, -4 };
            int[] collectionThree = GenerationArray();

            Console.WriteLine("Первый массив: ");
            foreach (var item in collectionFirst)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(Check(collectionFirst) ? "Первый массив удовлетворяет условию" : "Первый массив не удовлетворяет условию");
            Console.WriteLine("Второй массив: ");
            foreach (var item in collectionLast)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(Check(collectionLast) ? "Второй массив удовлетворяет условию" : "Второй массив не удовлетворяет условию");
            Console.WriteLine("Третий массив");
            foreach (var item in collectionThree)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(Check(collectionThree) ? "Третий массив удовлетворяет условию" : "Третий массив не удовлетворяет условию");
        }

        public static int[] GenerationArray()
        {
            Console.Write("Введите длину массива: ");
            int lenght = int.Parse(Console.ReadLine());
            collection = new int[lenght];
            Console.WriteLine("В каком диапазоне заполнить массив?");
            Console.Write("От: ");
            int indexAt = int.Parse(Console.ReadLine());
            Console.Write("До: ");
            int indexEnd = int.Parse(Console.ReadLine());
            Random random = new Random();
            for (int i = 0; i < lenght; i++)
            {
                collection[i] = random.Next(indexAt, indexEnd);
            }
            return collection;
        }

        public static bool Check(int[] collection)
        {
            if (collection[0] > 0)
                return false;

            for (int i = 1; i < collection.Length; i++)
            {
                if (collection[i] >= 0 && collection[i - 1] >= 0)
                    return false;
            }

            return true;
        }
    }
}
