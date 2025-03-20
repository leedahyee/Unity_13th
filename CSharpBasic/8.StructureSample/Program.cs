namespace _8.StructureSample {
    internal class Program {
        static void Main(string[] args) {
            Vector3 velocity = new Vector3(3, 5, 2);
            velocity.setX(velocity.getX() + 1f);
            velocity.X += 1;

            Console.WriteLine($"Magnitude : {velocity.Magnitude}");


            Vector3 target1Position = new Vector3(5f, 2f, 3f);

            Console.WriteLine();

   
        }
    }
}
