/*
 * Task vs Parallel
 * 
 * Task는 작업 종류가 여러가지 일 때 각각 작업을 실행하기 위해서 사용
 *  - 반환값은 Task<T> 로 처리할 수 있음
 *  - async-await 구문으로 가독성 높은 비동기 머신 사용 가능
 * 
 * Parallel은 단일 작업 종류를 여러 개 실행하기 위해서 사용
 *  - 배열, 컬렉션의 요소들을 병렬로 처리할 때 Task보다 더 CPU 친화적으로 작업함
 *  - 반환값은 처리할 수 없음.
 *  - 작업이 전부 동일하게 병렬처리 되기 때문에 각 작업을 예외처리하기 힘듬
 *  - 모든 병렬 작업이 끝날 때까지 기다림.
 */


namespace _07_Parallel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string root = Directory.GetCurrentDirectory();
            string[] folderNames = {"Folder1", "Folder2", "Folder3", "Folder4" };
            IEnumerable<string> fileDirectories = folderNames.Select(dir => Path.Combine(root, dir));

            //foreach (string dir in fileDirectories)
            //{
            //    Task.Run(() =>
            //    {
            //        System.IO.Directory.CreateDirectory(dir);
            //    });
            //}

            Parallel.ForEach(fileDirectories, fileDirectory =>
            {
                try
                {
                    System.IO.Directory.CreateDirectory(fileDirectory);
                    Console.WriteLine($"생성 완료 : {fileDirectory} (thread: {Thread.CurrentThread.ManagedThreadId})");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"생성 실패 : {fileDirectory}, {ex}");
                }
            });         
        }
    }
}
