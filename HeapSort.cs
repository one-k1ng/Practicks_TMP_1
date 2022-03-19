using System;
using System.Collections.Generic;
using System.Text;

namespace Counting_Sort
{
    // Реализация пирамидальной сортировки на C#

    public class HeapSort
    {
        public int[] HeapSortmethod(Queue _queue)
        {
            int n = _queue.QueueSize;
            int[] nums = new int[n];
            for (int i = 0; i < n; ++i)
            {
                nums[i] = _queue.Pop();
            }

            // Построение кучи (перегруппируем массив)
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(nums, n, i);

            // Один за другим извлекаем элементы из кучи
            for (int i = n - 1; i >= 0; i--)
            {
                // Перемещаем текущий корень в конец
                int temp = nums[0];
                nums[0] = nums[i];
                nums[i] = temp;

                // вызываем процедуру heapify на уменьшенной куче
                heapify(nums, i, 0);
            }
            return nums;
        }

        // Процедура для преобразования в двоичную кучу поддерева с корневым узлом i, что является
        // индексом в nums[]. n - размер кучи

        void heapify(int[] nums, int n, int i)
        {
            int largest = i;
            // Инициализируем наибольший элемент как корень
            int l = 2 * i + 1; // left = 2*i + 1
            int r = 2 * i + 2; // right = 2*i + 2

            // Если левый дочерний элемент больше корня
            if (l < n && nums[l] > nums[largest])
            {
                largest = l;
            }

            // Если правый дочерний элемент больше, чем самый большой элемент на данный момент
            if (r < n && nums[r] > nums[largest])
                largest = r;

            // Если самый большой элемент не корень
            if (largest != i)
            {
                int swap = nums[i];
                nums[i] = nums[largest];
                nums[largest] = swap;

                // Рекурсивно преобразуем в двоичную кучу затронутое поддерево
                heapify(nums, n, largest);
            }
        }
    }
}
