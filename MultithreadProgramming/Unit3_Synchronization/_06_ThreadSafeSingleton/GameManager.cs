namespace _06_ThreadSafeSingleton
{
    class GameManager : Singleton<GameManager>
    {
        public GameManager()
        {
            Console.WriteLine($"[{nameof(GameManager)}] Created.");
        }

        public void StartGame()
        {
            Console.WriteLine($"[{nameof(GameManager)}] Started Game");
        }
    }
}
