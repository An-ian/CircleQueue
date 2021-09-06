using System;

namespace CircleQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = 5;
            CircleQueue<int> queue = new CircleQueue<int>(size);

            for (int i = 0;i < 10;i++)
            {
                queue.Enqueue(i);
            }
            queue.Print();

            queue.Capacity(10);
            for (int i = 0; i < 3; i++)
            {
              queue.Dequeue();
            }
            queue.Print();
        }
    }
}
