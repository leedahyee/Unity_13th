/*
 * Interlock 클래스
 * 원자 연산을 매핑한 클래스
 * 하드웨어 수준에서 CPU가 단일명령으로 실행하는 최소 연산 단위이기 때문에
 * 다른 프로세스나 스레드가 연산 중간에 개입할 수 없다
 * 
 * 보통 CPU 워드 크기 까지만 원자 연산이 가능함
 * 32bit system -> 32bit 짜리 까지만 원자 연산 가능
 * 64bit system -> 64bit 짜리 까지만 원자 연산 가능
 */

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace _04_Interlock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmarks>();
            return;

            Workload workload = new Workload();

            Thread[] threads = new Thread[3];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(Workload.ComputeWithInterlocked);
                threads[i].Start();
            }

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Join();
            }

            Console.WriteLine($"결과: {Workload.Accumulator}, 기댓값: {threads.Length * Workload.N}"); 
        }
    }

    public class Workload
    {
        public const int N = 5_000_000;
        public static long Accumulator = 0;
        private static readonly object s_gate = new object();

        public static void ComputeWithInterlocked()
        {
            for (int i=0; i<N; i++)
            {
                Interlocked.Increment(ref Accumulator);
            }
        }

        public static void ComputeWithlocked()
        {
            for (int i = 0; i < N; i++)
            {
                lock (s_gate)
                {
                    Accumulator++;
                }
            }
        }
    }

    public class Benchmarks
    {
        [Benchmark]
        public void Workload_Interlocked()
        {
            for (int i = 0; i < Workload.N; i++)
            {
                Interlocked.Increment(ref Workload.Accumulator);
            }
        }

        [Benchmark]
        public void Workload_Locked()
        {
            for (int i = 0; i < Workload.N; i++)
            {
                Workload.Accumulator++;
            }
        }

    }
}
