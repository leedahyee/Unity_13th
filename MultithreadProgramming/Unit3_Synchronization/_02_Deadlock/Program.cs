/*
 * Deadlock: 작업이 진행되기 위한 자원을 서로 잠금하고 있어서 영원히 빠져나오지 못하는 상태
 */

namespace _02_Deadlock
{
    internal class Program
    {
        static readonly object s_gate1 = new object();
        static readonly object s_gate2 = new object();

        static void Main(string[] args)
        {
            Thread t1 = new Thread(() => Work(s_gate1, s_gate2));
            Thread t2 = new Thread(() => Work(s_gate2, s_gate1));

            t1.Start();
            t2.Start(); 

            Thread.Sleep(1000);
        }

        static void Work(object gate1, object gate2)
        {
            lock (gate1)
            {
                Thread.Sleep(100);
                lock (gate2)
                {
                    Console.WriteLine("작업 완료");
                }
            }
        }
    }
}
