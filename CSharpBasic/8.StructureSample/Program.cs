namespace _8.StructureSample {
    internal class Program {
        static void Main(string[] args) {
            int a = 3; // 그냥 값 타입 변수는 리터럴상수나 다른 변수 대입해서 초기화하면 됨
            Vector3 velocity = new Vector3(3, 5, 2); // 구조체 변수는 구조체 생성자를 통해서 초기화 로직을 수행해야함. (다른 구조체 변수 대입도 가능)
            velocity.setX(velocity.getX() + 1f);
            velocity.X += 1;

            Console.WriteLine($"Magnitude : {velocity.Magnitude}");


            Vector3 target1Position = new Vector3(5f, 2f, 3f);
            Vector3 target2Position = new Vector3(-5f, 3.4f, 1.2f);
            // 프로퍼티 : 외부에 노출시키는 용도

            Console.WriteLine();

            float dot = Vector3Extensions.Dot(target1Position, target2Position);
            //target1Position.Dot = target2Position;
        }
    }
}
