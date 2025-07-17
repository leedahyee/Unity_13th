namespace _03_MonitorSignal
{
    internal class Program
    {
        static readonly Queue<int> s_items = new Queue<int>();
        static readonly object s_gate = new();
        static bool s_isRunning;  

        static void Main(string[] args)
        {
            // 수신
            new Thread(Receive).Start();

            // 송신 테스트
            for (int item =0; item < 10; item++)
            {
                new Thread(Send).Start(item);
            }

            Thread.Sleep(1000);
            s_isRunning = false;

            lock (s_gate)
            {
                Monitor.PulseAll(s_gate);
            }

            // lock이 실제로 하는 것: Monitoe, Enter외 Exit
            //Monitor.Enter(s_gate);
            //Monitor.PulseAll (s_gate);
            //Monitor.Exit(s_gate);
        }

        static void Send(object? itemObject)
        {
            int item = itemObject is int n ? n : 0;
            lock (s_gate)
            {
                s_items.Enqueue(item);
                Console.WriteLine($"Send: {item}");
                Monitor.Pulse(s_gate); // Send 했으니까 임시 대기해주고 있던 Recevice에게 자원을 다시 쓰면 된다고 알려줌
            }

        }

        static void Receive()
        {
            while (true)
            {
                lock (s_gate)
                {
                    while (s_items.Count == 0 && s_isRunning)
                        Monitor.Wait(s_gate); // 아직 받을 데이터가 있는데 도착을 안했다면 Send 작업이 원할하게 재개될 수 있록 임시 대기힘

                    if (s_items.Count == 0 && s_isRunning == false)
                        break;

                    if (s_items.Count > 0)
                    {
                        int item = s_items.Dequeue();
                        Console.WriteLine($"Receive: {item}");
                    }
                }
            }
        }
    }
}
