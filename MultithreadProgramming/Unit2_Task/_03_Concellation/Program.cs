namespace _03_Concellation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            // 입력 처리
            _ = Task.Run(() =>
            {
                if (Console.ReadKey(intercept: true).Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("다운로드 취소 요청 감지: 작업을 시작합니다.");
                    cts.Cancel();
                }
            });

            // 작업 시작
            //Task.Run(() =>
            //{
                //_ = FakeLoadSomethingAsync();
            //}, cts.Token);

            try {
                Task load = FakeLoadSomethingAsync(cts.Token);
                Task timeOut = Task.Delay(5000, cts.Token);

                int index = Task.WaitAny(new Task[] { load, timeOut }, cts.Token);

                if (index == 0)
                {
                    Console.WriteLine("다운로드 완료!");
                }
                else if (index == 1)
                {
                    Console.WriteLine("다운로드 시간 초과. 연결 상태를 확인하세요.");
                }
            }
            catch (AggregateException ex)
            {
                if (ex.InnerException is TaskCanceledException)
                {
                    Console.WriteLine("다운로드 취소됨.");
                }
                else
                {

                }
            }
        }

        static async Task FakeLoadSomethingAsync(CancellationToken cancellationToken)
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                DrawProgressBar(i);
                await Task.Delay(random.Next(250, 750));
            }
        }

        static void DrawProgressBar(int progress)
        {
            Console.Clear();
            for (int i = 0; i < 10; i++)
            {
                char ch = i < progress ? '■' : '□';
                Console.Write($"{ch}");
            }
            Console.WriteLine();
            Console.WriteLine($"리소스 다운로드 중... {progress + 1} / 10");
        }
    }
}
