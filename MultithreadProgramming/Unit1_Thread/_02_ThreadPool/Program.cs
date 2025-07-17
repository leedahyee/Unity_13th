using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Diagnostics;

namespace _02_ThreadPool
{
    internal class Program
    {
        static bool s_workloadFinished;
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchMarks>();
            return;
            // QueueUserWorkItem이란?
            // ThreadPool은 관리되는 쓰레드 풀에 쓰레드에서 실행할 작업을 대기시키고, 사용 가능한 쓰레드를 가져오는 알고리즘에 따라
            // 전달한 함수가 해당 쓰레드에서 실행된다.

            // Thread 성능
            Measure("Thread - Join", () =>
            {
                Thread thread = new Thread(() =>
                {
                    Workload.Compute();
                });
                thread.Start();
                thread.Join();
            });

            // ThreadPool 성능
            Measure("ThreadPool - AutoResetEvent", () =>
            {
                AutoResetEvent autoResetEvent = new AutoResetEvent(false);
                ThreadPool.QueueUserWorkItem(_ => 
                {
                    Workload.Compute();
                    autoResetEvent.Set();
                });

                autoResetEvent.WaitOne(); 
            });

        }
        static void Measure(string label, Action action)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers(); // 소멸자, 소멸자가 호출되는 타이밍은 GD가 된 이후 사용됨

            Stopwatch stopwatch = Stopwatch.StartNew();
            action.Invoke();
            stopwatch.Stop();

            Console.WriteLine($"{label} : {stopwatch.ElapsedMilliseconds} ms");
        }
    }

    /// <summary>
    /// 작업 부하 테스트용
    /// </summary>
    public static class Workload
    {
        internal static void Compute()
        {
            int limit = 100_000;

            long result = 0;

            for (int i = 1; i < limit; i++)
            {
                result += i;
            }
        }
    }

    [SimpleJob]
    public class BenchMarks
    {
        [Benchmark] public void Workload_Thread() => Workload.Compute();
        [Benchmark] public void WorkloadThreadPool() => ThreadPool.QueueUserWorkItem(_ => Workload.Compute());
    }
}
