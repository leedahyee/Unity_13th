using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace _06_ValueTaskBenchmark
{
    internal class Program
    {
        static int s_accumulation1;
        static bool s_isDone1;

        static int s_accumulation2;
        static bool s_isDone2;
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmarks>();
            return;

            _ = Task.Run(async () =>
            {
                Stopwatch stopwatch = new Stopwatch();

                for (int i = 0; i < 10; i++)
                {
                    stopwatch.Start();
                    await AccumlateAsyne1();
                    stopwatch.Stop();
                    Console.WriteLine($"{s_accumulation1}, {stopwatch.ElapsedMilliseconds} ms");
                    stopwatch.Reset();
                }
            });
        }

        public static async Task<int> AccumlateAsyne1()
        {
            if (s_isDone1)
            {
                return s_accumulation1;
            }

            int accumulation = 0;

            for (int i = 0; i < 100; i++)
            {
                accumulation += i;
                await Task.Delay(10); // 비동기 작업 시뮬레이션
            }


            s_isDone1 = true;
            s_accumulation1 = accumulation;
            return accumulation;
        }

        public static async ValueTask<int> AccumlateAsyne2()
        {
            if (s_isDone2)
            {
                return s_accumulation2;
            }

            int accumulation = 0;

            for (int i = 0; i < 100; i++)
            {
                accumulation += i;
                await Task.Delay(10); // 비동기 작업 시뮬레이션
            }


            s_isDone2 = true;
            s_accumulation2 = accumulation;
            return accumulation;
        }
    }

    public class Benchmarks
    {
        [Benchmark]
        public ValueTask<int> AccumuateWithValueTask1()
        {
            return Program.AccumlateAsyne2();
        }

        [Benchmark]
        public Task<int> AccumuateWithValueTask2()
        {
            return Program.AccumlateAsyne1();
        }
    }
}