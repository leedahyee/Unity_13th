using System.Collections.Concurrent;

namespace _05_ConcurrentCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ConcurrentBag
            // Doubly-linked list를 쓰레드마다 가지고 있음
            // 그래서 쓰레드 별로 아이템 추가할 때 RaceCondition이 발생하지 않음
            // --------------------------------------------------------------

            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            bag.Add(1);
            bag.Add(2);
            bag.Add(3);

            // 순서가 보장되지 않은 무작위 아이템을 반환함
            // TryTake를 호출한 스레드에 대한 리스트가 ConcurrentBag에 있으면 해당 리스트에서 가장 최근 것을 반환 (LIFO)
            // 없으면 다른 스레드 리스트 암거나들 중에서 가져옴
            // 즉, 순서가 어떻게 되든 상관없이 아이템만 저장하고 꺼내쓰면 될 때 사용
            if (bag.TryTake(out int result))
            {
                Console.WriteLine(result);
            }


            // ConcurrentQueue
            // 생산자-소비자 패턴으로 큐 관리

            ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
            bool isFinished = false;

            // 생산자 1명
            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    queue.Enqueue(i);
                }

                isFinished = true;
            }).Start();

            // 소비자 1명
            new Thread(() =>
            {
                while (isFinished == false)
                {
                    if (queue.TryDequeue(out int result))
                    {
                        Console.WriteLine(result);
                    }
                }
            }).Start();

            // 생산 작업 10개
            Parallel.For(0, 10, i =>
            {
                queue.Enqueue(i);
            });

            // 소비 작업 10개
            Parallel.For(0, 10, _ =>
            {
                if (queue.TryDequeue(out int result))
                {
                    Console.WriteLine(result);
                }
            });

            // ConcurrentStack
            // ConcurrentDictionary
        }
    }
}
