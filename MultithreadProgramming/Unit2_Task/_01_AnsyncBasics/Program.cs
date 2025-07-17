
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace _01_AnsyncBasics
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            AutoResetEvent autoResetEvent = new AutoResetEvent(false);
            Task task1 = new Task(() =>
            {
                FakeDownload("File A", 1000);
                autoResetEvent.Set();
            });
            task1.Start();
            autoResetEvent.WaitOne();

            Task task2 = Task.Factory.StartNew(() =>
            {
                FakeDownload("File B", 1500);
            });

            Task.WaitAll(task2);

            Task task3 = Task.Run(() =>
            {
                FakeDownload("File C", 1000);
            });

            Task.WaitAll(task1, task2, task3);

            await FakeDownloadAsync("File D", 1500);

            Console.WriteLine("10초 후 프로그램 종료됨");

            Thread.Sleep(1000);
        }

        static void FakeDownload(string resourceName, int simulationTimeMS)
        {
            Console.WriteLine($"{resourceName} 다운로드 시작... {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(simulationTimeMS);
            Console.WriteLine($"{resourceName} 다운로드 완료! {simulationTimeMS}");
        }


        // async - await . Task 기반 비동기 함수 정의시 사용하는 패턴
        // async 한정자: 현재 함수를 비동기 함수로 정의함
        // await 한정자: async 실행 중 다른 Task를 대기하기 위한 키워드

        // async 함수는 첫번째 await를 만나기 전까지는 일반적인 동기 함수와 동일하게 작동함.
        // await 한정자를 만나는 순간 쓰레드를 상위 작업에 양보하고 await machine 조건을 대기함.

        static async Task FakeDownloadAsync(string resourceName, int simulationTimeMS)
        {
            Console.WriteLine($"{resourceName} 다운로드 시작... {Thread.CurrentThread.ManagedThreadId}");

            // Thread.Sleep: 내가 자고온다 (그 동안 아무것도 안 함)
            // Task.Delay: 다른 사람한테 자고 오라고 한다. 내 일은 계속 진행함.
            // await Task.Delay: 다른 사람한테 자고 오라고 하고, 나는 그 사람 다 자고 올 때까지 대기함.

            Thread.Sleep(simulationTimeMS);
            await Task.Delay(simulationTimeMS);

            Console.WriteLine($"{resourceName} 다운로드 완료! {simulationTimeMS}");
        }

        private struct FackeDownloadAsyncMachine : IAsyncStateMachine
        {
            public int State;
            public AsyncTaskMethodBuilder Builder;

            public string ResourceName;
            public int SimulationTimeMS;    

            private TaskAwaiter _awaiter;

            public void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                Builder.SetStateMachine(stateMachine);
            }

            void IAsyncStateMachine.MoveNext()
            {
                int state = State;

                switch (state)
                {
                    case -1:
                        Console.WriteLine($"{ResourceName} 다운로드 시작... {Thread.CurrentThread.ManagedThreadId}");

                        TaskAwaiter awaiter = Task.Delay(SimulationTimeMS).GetAwaiter();

                        if (!awaiter.IsCompleted)
                        {
                            State = 0;
                            _awaiter = awaiter;
                            Builder.AwaitUnsafeOnCompleted(ref _awaiter, ref this);
                            return; // 비동기 함수는 여기서 빠져나가고, 대기 상태로 전환됨
                        }

                        _awaiter.GetResult();
                        State = -1; // 상태를 초기화
                        Console.WriteLine($"{ResourceName} 다운로드 완료! {SimulationTimeMS}");

                        break;
                    case 0:
                        _awaiter.GetResult();
                        State = -1;
                        Console.WriteLine($"{ResourceName} 다운로드 완료! {SimulationTimeMS}");
                        break;
                }

                if (State == -2)
                {
                    Builder = new AsyncTaskMethodBuilder();
                }
            }
        }
    }
}
