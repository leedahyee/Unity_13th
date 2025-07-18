/*
 * SpinLock
 * 작업이 빨리 끝날 것 같아서 다른 동기화 구문을 쓰는 것보다 잠깐 while 문으로 작업 와료까지 돌고 있는데 비용이 더 쌀 때 끔
 * 내부적으로 보면 1ms 단위로 thread.sleep 하면서 while문을 반복하기 때문에, 임계구역이 ms 단위 작업일 대 busy-wait 하는게 더 나을 때 채택함
 * 
 * ReaderWriterLockSlim
 * 다중 읽기 & 단일 쓰기 상황에서 즉, 읽기만 병렬성을 가질때 쓰는 동안 짧은 SpinLock을 통해서 스레드 대기 및 깨움을 실행
 */

using System.Diagnostics;

namespace _07_SpinLock
{
    internal class Program
    {
        static SpinLock s_spin = new SpinLock();
        static readonly object s_gate = new object();   
        static ReaderWriterLockSlim s_rwslim = new ReaderWriterLockSlim();
        static int s_data = 0;
        static void Main(string[] args)
        {
            Benchmark("Write with spinlock", WriteSpin);
            Benchmark("Write with lock", WriteLock);
            Benchmark("Write with RWSlim", WriteRWSlim);
            Benchmark("Read with RWSlim", ReadRWSlim);
        }

        static void WriteSpin()
        {
            bool taken = false;
            s_spin.Enter(ref taken);
            s_data++; // Critical Section

            if (taken)
                s_spin.Exit();
        }

        static void WriteLock()
        {
            lock (s_gate)
            {
                s_data++;
            }
        }

        static void WriteRWSlim()
        {
            s_rwslim.EnterWriteLock();
            s_data++;
            s_rwslim.ExitWriteLock();
        }

        static void ReadRWSlim()
        {
            s_rwslim.EnterReadLock();
            _ = s_data; 
            s_rwslim.ExitReadLock();
        }

        static void Benchmark(string tag, Action action)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Parallel.For(0, 500_000, _ => action.Invoke());
            Console.WriteLine($"{tag} : {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
