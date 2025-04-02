namespace GenericSample
{
    internal class Box<T, k>
    {
        public T Item1 { get; set; }
        public K Item2 { get; set; }


        public void PrintItems()
        {
            // typeof 키워드 : 이 타입의 메타데이터 정보를 포함하는 객체를 반환받는 키워드
            Console.WriteLine($"{typeof(T)} 아이템 {(Item1 == null ? "없음" : "있음")}, {typeof(K)} 아이템 {(Item1 == null ? "없음" : "있음")}");
        }

        public void Dummy<TKey, KKey>()
        {

        }
    }
}