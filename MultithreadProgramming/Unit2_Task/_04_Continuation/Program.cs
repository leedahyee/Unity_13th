namespace _04_Continuation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Continuation
            // 체이닝 함수를 통해 작업을 이어서 진행하는 방식
            // 요즘 날에는 async-await 가 훨씬 단순해보이고 직관적이기 때문에 잘 안씀
            Task.Run(() => throw new InvalidOperationException())
                .ContinueWith(task => Console.WriteLine($"상태 : {task.Status}, 예외 : {task.Exception?.Message ?? "없음"}"))
                .Wait();
        }
    }
}
