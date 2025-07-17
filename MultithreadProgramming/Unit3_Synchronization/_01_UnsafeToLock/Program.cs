namespace _01_UnSafeToLock
{
    internal class Program
    {
        class Counter
        {
            public int Value => _value;

            private int _value;
            private readonly object _gate = new object();

            public void Increment_ThreadUnsafe()
            {
                _value++;
            }

            public void Increment_ThreadSafe()
            {
                /*
                 * lock 키워드
                 * 현재 Application 내에서 쓰레드간 동기화를 하기위한 키워드
                 */
                lock (_gate)
                // <CrieicalSection>
                {
                    _value++;
                }
                // </CrieicalSection>
            }
        }


        static void Main(string[] args)
        {
            int n = 100_000;

            Counter counter_ThreadUnsafe = new Counter();

            Thread t1 = new Thread(() =>
            {
                for (int i = 0; i < n; i++)
                {
                    counter_ThreadUnsafe.Increment_ThreadUnsafe();
                }
            });

            Thread t2 = new Thread(() =>
            {
                for (int i = 0; i < n; i++)
                {
                    counter_ThreadUnsafe.Increment_ThreadUnsafe();
                }
            });

            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();

            Console.WriteLine($"Increment_ThreadUnsafe 결과 : {counter_ThreadUnsafe.Value}, 기댓값 : {n * 2}");

            Counter counter_Threadsafe = new Counter();

            t1 = new Thread(() =>
            {
                for (int i = 0; i < n; i++)
                {
                    counter_Threadsafe.Increment_ThreadUnsafe();
                }
            });

            t2 = new Thread(() =>
            {
                for (int i = 0; i < n; i++)
                {
                    counter_Threadsafe.Increment_ThreadUnsafe();
                }
            });

            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();

            Console.WriteLine($"Increment_ThreadUnsafe 결과 : {counter_Threadsafe.Value}, 기댓값 : {n * 2}");
        }
    }
}