using System;

namespace Practicks_TMP_1
{
    class Queue
    {
        private int[] queue = new int[0];

        public Queue()
        {

        }

        public int QueueSize //Размер очереди
        {
            get
            {
                int size = 0;

                foreach (int o in queue)
                {
                    ++size;
                }
                return size;
            }
        }

        public void Push(int _newElement)//Добавляет число _newElement в конец очереди (в начало массива)
        {
            int size = QueueSize;
            int[] temp = new int[size];
            for (int i = 0; i < size; ++i)
            {
                temp[i] = queue[i];
            }

            queue = new int[size + 1];
            queue[0] = _newElement;

            for (int i = 1; i < size + 1; ++i)
            {
                queue[i] = temp[i - 1];
            }
        }

        public int Pop()//Возвращает первый элемент в очереди (последний элемент массива) и при этом удаляет его из этой очереди
        {
            int size = QueueSize;
            int rez = queue[size - 1]; // QueueSize - 1 потому что в массиве элементы считаются с 0
            int[] temp = new int[size];
            for (int i = 0; i < size; ++i)
            {
                temp[i] = queue[i];
            }
            queue = new int[size - 1];

            for (int i = 0; i < size - 1; ++i)
            {
                queue[i] = temp[i];
            }

            return rez;
        }

        public int Back()//Возвращает первый элемент в очереди (последний в массиве) и НЕ удаляет его из очереди
        {
            int rez = queue[QueueSize - 1]; // QueueSize - 1 потому что в массиве элементы считаются с 0
            return rez;
        }

        public void Print()
        {
            foreach (int item in queue)
                Console.WriteLine(item);
            Console.WriteLine("---------");
        }
    }
}
