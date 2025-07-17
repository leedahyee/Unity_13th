namespace _06_ThreadSafeSingleton
{
    public class Singleton<T>
        where T : Singleton<T>, new()
    {
        public static T Instance
        {
            get
            {
                if (s_instance == null)
                {
                    lock (s_gate)
                    {
                        s_instance = new T();
                    }
                }

                return s_instance;
            }
        }

        // volatile은 쓰레드 안전을 보장하는 키워드가 아님
        // 이 필드를 읽을 때는 캐시 메모리에서 확인하지 않고 주메모리에서 직접 값을 가져와야함
        private volatile static T s_instance; 
        private static object s_gate = new object();    
    }
}
