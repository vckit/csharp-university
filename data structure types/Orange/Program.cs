using System;
using System.Collections.Generic;
using System.Linq;

namespace Orange
{
    class Program
    {
        // Объявим коллекцию целых чисел
        public static List<Int32> collection { get; set; }
        // Объявляем переменные для сохранения количества интераций
        public static int interationSort { get; set; }
        public static int interationSortLast { get; set; }
        public static int interationDescending { get; set; }
        static void Main(string[] args)
        {
            // Вводим данные студента
            Console.Write("Введите своё ФИО полностью: ");
            string name = Console.ReadLine();
            Console.Write("Введите от: ");
            int indexAt = int.Parse(Console.ReadLine());
            Console.Write("Введите до: ");
            int indexEnd = int.Parse(Console.ReadLine());

            collection = GenerationList(collection, indexAt, indexEnd, name);
            Console.WriteLine("Количество символов: " + name.Length);

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Отсортирован по возрастанию: ");
            foreach (var item in Sort(collection))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Отсортирован по возрастанию: ");
            foreach (var item in SortLast(collection))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Отсортирован по убыванию: ");
            foreach (var item in Descending(collection))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Iteration Sort: " + interationSort);
            Console.WriteLine("Iteration Sort Last: " + interationSortLast);
            Console.WriteLine("Iteration Descending: " + interationDescending);
        }

        // Написал метод сортировки первой половины списка по возрастанию с помощью средств LINQ
        public static List<Int32> Sort(List<Int32> collection)
        {
            // Вычисляем центр
            int center = collection.Count() / 2;
            // Для удобства создаю новый список чисел, чтобы отдельно зафиксировать первую половину сгенерированного списка
            List<Int32> collectionFirst = new List<Int32>();
            int item = 0;
            // Прохожу циклом, чтобы сохранить первую половину сгенерированного списка и сохранить в новый отдельный список
            for (int i = 0; i < center; i++)
            {
                item = collection[i];
                collectionFirst.Add(item);
                interationSort += i;
            }
            // Новый список сортируем средствами LINQ
            collectionFirst.Sort();
            // Возвращаю количество итераций
            return collectionFirst;
        }

        // Написал метод сортировки первой половины списка по возрастанию с помощью сортировки Пузрьком
        public static List<Int32> SortLast(List<Int32> collection)
        {
            // Вычисляем центр
            int center = collection.Count() / 2;
            // Для удобства создаю новый список чисел, чтобы отдельно зафиксировать первую половину сгенерированного списка
            List<Int32> collectionFirst = new List<Int32>();
            int item = 0;
            // Прохожу циклом, чтобы сохранить первую половину сгенерированного списка и сохранить в новый отдельный список
            for (int i = 0; i < center; i++)
            {
                item = collection[i];
                collectionFirst.Add(item);
            }
            // Новый список сортируем методом сортировки Пузырька
            for (int i = 0; i < collectionFirst.Count; i++)
            {
                for (int j = i + 1; j < collectionFirst.Count; j++)
                {
                    if (collectionFirst[i] > collectionFirst[j])
                    {
                        int a = collectionFirst[i];
                        collectionFirst[i] = collectionFirst[j];
                        collectionFirst[j] = a;
                    }
                    // Сохраняю количество итераций
                    interationSortLast += i + j;
                }
            }
            // Возвращаю отсортированный список
            return collectionFirst;
        }

        // Написал метод сортировки второй половины списка по убыванию с помощью сортировки Пузрьком
        public static List<Int32> Descending(List<Int32> collection)
        {
            // Вычисляем центр
            int center = collection.Count() / 2;
            // Для удобства создаю новый список чисел, чтобы отдельно зафиксировать вторую половину сгенерированного списка
            List<Int32> collectionFirst = new List<Int32>();
            int item = 0;
            // Прохожу циклом, чтобы сохранить вторую половину сгенерированного списка и сохранить в новый отдельный список
            for (int i = center; i < collection.Count(); i++)
            {
                item = collection[i];
                collectionFirst.Add(item);
            }
            // Сортировка позырьком
            for (int i = 0; i < collectionFirst.Count; i++)
            {
                for (int j = i + 1; j < collectionFirst.Count; j++)
                {
                    if (collectionFirst[i] < collectionFirst[j])
                    {
                        int element = collectionFirst[i];
                        collectionFirst[i] = collectionFirst[j];
                        collectionFirst[j] = element;
                    }
                    // Сохраняю количество итераций
                    interationDescending += i + j;
                }

            }
            // Возвращаю отсортированный список
            return collectionFirst;
        }
        // Написал метод генерации случайных чисел
        public static List<Int32> GenerationList(List<Int32> collection, int indexAt, int indexEnd, string name)
        {
            // Инициализирую ранее объявленный список чисел
            collection = new List<Int32>();
            int item = 0;
            // Обращаюсь к классу Random
            Random random = new Random();
            // Перебираю список и заполняю рандомными числами в указанном пользователем диапазоне чисел
            for (int i = 0; i < name.Length; i++)
            {
                item = random.Next(indexAt, indexEnd);
                collection.Add(item);
            }
            // Возвращаб сгенерированный список
            return collection;
        }
    }
}
