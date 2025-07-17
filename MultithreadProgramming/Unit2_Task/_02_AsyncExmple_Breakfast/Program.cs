using System.Diagnostics;
using System.Threading.Tasks;

namespace _02_AsyncExmple_Breakfast
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Console.WriteLine("아침 준비를 시작합니다...");

            Task.Run(PrepareBreakfastAsync).Wait();

            stopwatch.Stop();
            Console.WriteLine($"아침 식사가 {stopwatch.ElapsedMilliseconds}ms 만에 준비 완료!");
        }

        static async Task PrepareBreakfastAsync()
        {
            Cook cook1 = new Cook();

            Cup cupOfCoffee = await cook1.PourCoffee();

            Dish dish = new Dish();
            // 작업을 하나씩 실행
            // ------------------------------------------
            //dish = await cook1.BunOnDish(dish);
            //dish = await cook1.MeatPattyOnDish(dish);
            //dish = await cook1.TomatoOnDish(dish);
            //dish = await cook1.BunOnDish(dish);

            // 작업을 병렬로 동시에 실행
            // ------------------------------------------
            Task<Dish> task1 = cook1.BunOnDish(dish);
            Task<Dish> task2 = cook1.MeatPattyOnDish(dish);
            Task<Dish> task3 = cook1.TomatoOnDish(dish);
            Task<Dish> task4 = cook1.BunOnDish(dish);
             
            await Task.WhenAll(task1, task2, task3, task4); 
            
            Console.WriteLine($"{dish.Meal}가 준비되었습니다.");
        }
    }
}
