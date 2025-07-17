/*
 * Channel: 데이터 생산자와 소비자 사이의 병목이 발생했을 때 흐름을 제어해서 데이터 범람을 방지하는 경량 비동기 큐 시스템
 */

using System.Threading.Channels;

namespace _05_ChannelPipeline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Channel<int> channel = Channel.CreateBounded<int>(10);

            // 생산자 작업
            Task prouducer = Task.Run(async () =>
            {
                for (int i = 0; i < 10; i++)
                {
                    await channel.Writer.WriteAsync(i);
                    Console.WriteLine($"[생산자] : 데이터 {i} 생성");
                }

                channel.Writer.Complete(); // 생산자 작업 완료
                Console.WriteLine("[생산자] : 모든 데이터 생성 완료");
            });


            // 소비자 작업
            Task consumer = Task.Run(async () =>
            {
                await foreach (int item in channel.Reader.ReadAllAsync())
                {
                    Console.WriteLine($"[소비자] : 데이터 {item} 처리");
                    await Task.Delay(100); // 데이터 처리 시간 시뮬레이션
                }

                Console.WriteLine($"[소비자] : 모든 데이터 처리 완료");
            });

            Task.WaitAll(prouducer, consumer);
        }
    }
}
