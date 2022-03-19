using System;

namespace Counting_Sort
{
    class Program
    {
        static int MaxInQueue(Queue _queue) // Максимальное число в очереди
        {
            Queue tempqueue = new Queue();
            int temp = 0;

            int max = _queue.Pop();
            tempqueue.Push(max);

            int size = _queue.QueueSize;

            for (int i = 0; i < size; ++i)
            {
                temp = _queue.Pop();
                tempqueue.Push(temp);
                if (max < temp)
                {
                    max = temp;
                }
            }

            size = tempqueue.QueueSize;

            for (int i = 0; i < size; ++i)
            {
                _queue.Push(tempqueue.Pop());
            }

            return max;
        }

        static int MinInQueue(Queue _queue) // Минимальное число в очереди
        {
            Queue tempqueue = new Queue();
            int temp = 0;

            int min = _queue.Pop();
            tempqueue.Push(min);

            int size = _queue.QueueSize;

            for (int i = 0; i < size; ++i)
            {
                temp = _queue.Pop();
                tempqueue.Push(temp);
                if (min > temp)
                {
                    min = temp;
                }
            }

            size = tempqueue.QueueSize;

            for (int i = 0; i < size; ++i)
            {
                _queue.Push(tempqueue.Pop());
            }

            return min;
        }

        static void SortQueue(Queue _queue) // Сортировка
        {
            int max = MaxInQueue(_queue);
            int min = MinInQueue(_queue);
            int[] nums = new int[max + 1];

            // Массив для отрицательных значений
            int[] nnums = new int[0];
            if (min < 0)
            {
                min = min * -1;
                nnums = new int[min + 1];
            }

            for (int i = 0; i < max + 1; ++i)
            {
                nums[i] = 0; // Заполняем массив ноликами
            }

            for (int i = 0; i < min + 1; ++i)
            {
                nnums[i] = 0; // Заполняем массив ноликами
            }

            int size = _queue.QueueSize;

            for (int i = 0; i < size; ++i)
            {
                int pop = _queue.Pop();
                if (pop < 0)
                {
                    nnums[pop * -1] += 1;
                }
                else
                {
                    nums[pop] += 1;
                }
            }

            for (int i = min; i >= 0; --i)
            {
                for (int j = 0; j < nnums[i]; ++j)
                {
                    _queue.Push(i * -1);
                }
            }

            for (int i = 0; i < max + 1; ++i)
            {
                for (int j = 0; j < nums[i]; ++j)
                {
                    _queue.Push(i);
                }
            }
        }

        static void Reverse(int[] sortedTmp)
        {
            int swap = 0;
            for (int i = 0; i < sortedTmp.Length / 2; ++i)
            {
                swap = sortedTmp[i];
                sortedTmp[i] = sortedTmp[sortedTmp.Length - 1 - i];
                sortedTmp[sortedTmp.Length - 1 - i] = swap;
            }
        }

        static void Heap_print(int[] sortedTmp)
        {
            foreach (int item in sortedTmp)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------");
        }

        static void Main()
        {
            
            Queue tmp = new Queue();
            Random randomNumber = new Random();
            HeapSort heapSort = new HeapSort();
            

            Console.WriteLine("Введите количество чисел и интервал генерации (всё через пробел)");
            string[] input = Console.ReadLine().Split(' ');

            for (int i = 0; i < Convert.ToInt32(input[0]); ++i)
            {
                tmp.Push(randomNumber.Next(Convert.ToInt32(input[1]), Convert.ToInt32(input[2]))); // Переводим в int интервал 
            }
            Console.WriteLine("Исходная очередь:");
            tmp.Print();

            SortQueue(tmp);

            Console.WriteLine("Отсортированная очередь(Сортировка подсчётом): ");
            tmp.Print();

            int[] sortedTmp = heapSort.HeapSortmethod(tmp);

            Console.WriteLine("Отсортированная очередь(Пирамидальная сортировка): ");

            Reverse(sortedTmp);

            Heap_print(sortedTmp);
        }
    }
}
