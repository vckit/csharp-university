using System;
using System.Collections.Generic;
using System.Linq;

namespace Element
{
    class Program
    {
        public static Random random = new Random();
        public static int count { get; set; }
        public static List<Int32> collection { get; set; }
        static void Main(string[] args)
        {

            collection = new List<int>();
            foreach (var item in GenerationElement(collection))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Сортировка по возрастанию");
            foreach (var item in Sort(collection))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Сортировка по убыванию: ");

            foreach (var item in Descending(collection))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Множества");
            foreach (var item in SetOperation(GenerationElement(collection), GenerationElement(collection)))
            {
                Console.WriteLine(item);
            }
        }


        //  Метод генерации сулчайных целечисленных элементов
        public static List<Int32> GenerationElement(List<Int32> collection)
        {
            Console.Write("Введите количество элементов: ");
            count = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите диапазон чисел");
            Console.Write("От: ");
            int indexAt = int.Parse(Console.ReadLine());
            Console.Write("До: ");
            int indexEnd = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                int item = random.Next(indexAt, indexEnd);
                collection.Add(item);
            }
            return collection;
        }

        public static List<Int32> Sort(List<Int32> collection)
        {
            int center = collection.Count() / 2;
            int item = 0;
            List<Int32> collectionFirst = new List<int>();
            for (int i = 0; i < center; i++)
            {
                item = collection[i];
                collectionFirst.Add(item);
            }
            collectionFirst.Sort();

            return collectionFirst;
        }

        public static List<Int32> Descending(List<Int32> collection)
        {
            int center = collection.Count() / 2;
            int item = 0;
            List<Int32> collectionLast = new List<int>();
            for (int i = center; i < collection.Count(); i++)
            {
                item = collection[i];
                collectionLast.Add(item);
            }
            // Сортировка позырьком
            for (int i = 0; i < collectionLast.Count; i++)
            {
                for (int j = i + 1; j < collectionLast.Count; j++)
                {
                    if (collectionLast[i] < collectionLast[j])
                    {
                        int element = collectionLast[i];
                        collectionLast[i] = collectionLast[j];
                        collectionLast[j] = element;
                    }
                }

            }
            return collectionLast;
        }

        public static List<Int32> SetOperation(List<Int32> collectionFirst, List<Int32> collectionLast)
        {
            Console.WriteLine("Выберите действие: ");
            Console.WriteLine("1. Объдинение");
            Console.WriteLine("2. Разность");
            Console.WriteLine("3. Пересечение");
            Console.WriteLine("4. Симметрическая разностьтри");
            Console.Write("Введите команду: ");
            List<Int32> collectionSet = new List<int>();
            int action = int.Parse(Console.ReadLine());
            switch (action)
            {
                case 1:
                    collectionSet = collectionFirst.Union<Int32>(collectionLast).ToList<Int32>();
                    break;
                case 2:
                    collectionSet = collectionFirst.Intersect<Int32>(collectionLast).ToList<Int32>();
                    break;
                case 3:
                    collectionSet = collectionFirst.Except<Int32>(collectionLast).ToList<Int32>();
                    break;
                case 4:
                    collectionSet = (from index in collectionFirst.Union<int>(collectionLast) where !collectionFirst.Intersect<int>(collectionLast).Contains<int>(index) select index).ToList<int>();
                    break;
            }
            return collectionSet;
        }
    }
}