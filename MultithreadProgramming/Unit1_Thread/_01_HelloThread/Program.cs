namespace _01_HelloThread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 쓰레드 생성시 쓰레드 첫 시작 함수를 할당해야함. (메인쓰레드는 첫 시작함수가 메인 함수임)
            Thread t1 = new Thread(Sum) { Name = "Worker - 1", IsBackground = true};
            Thread t2 = new Thread(Sum) { Name = "Worker - 2", IsBackground = true};

            t1.Start(2_000_000);
            t2.Start(2_000_000);

            t1.Join(); // t1 인스턴스가 나타내는 쓰레드가 종료될 때까지 호출 쓰레드를 차단
            t2.Join(); // t2 쓰레드가 종료될 때까지 대기

            Console.WriteLine($"[Main Thread] Finished");
        }

        static void Sum(object? Objlimit)
        {
            int limit = Objlimit is int n ? n : 1_000_000;
            long result = 0;

            for (int i = 1; i < limit; i++)
            {
                result += i;
                //Thread.Sleep(10); // 쓰레드가 10초간 멈춤
            }

            Console.WriteLine($"[{Thread.CurrentThread.Name}] Sum(0~{limit}) = {result}");
        }
    }
}
