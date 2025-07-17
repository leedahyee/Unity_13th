namespace _02_AsyncExmple_Breakfast
{
    internal class Cook
    {
        AutoResetEvent _dishResetEvent = new AutoResetEvent(false);
        /*  
         * Task vs Task<T>  
         *   
         * 결과 리턴시 리턴값이 있다면, 해당 리턴 값 타입을 T에 대입하여 사용하는 제네릭 Task 써여함  
         */
        internal async Task<Cup> PourCoffee()
        {
            Console.WriteLine($"커피를 따르기 시작 {Thread.CurrentThread.ManagedThreadId}");
            Cup cup = new Cup()
            {
                Capacity = 200,
                FillRatio = 0,
                Filled = Beverage.Coffee
            };

            Console.WriteLine("커피를 따르는 중...");

            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(150); // 천천히 따르도록 지연시간 증가
                cup.FillRatio += 10f / cup.Capacity;

                int fillPercent = (int)(cup.FillRatio * 100);
                //string progressBar = new string('■', i + 1).PadRight(10, ' ');
                //Console.WriteLine($"[{progressBar}] {fillPercent}%");
            }

            Console.WriteLine($"커피 따르기 완료! {Thread.CurrentThread.ManagedThreadId}\n");

            return cup;
        }

        internal async Task<Dish> BunOnDish(Dish dish)
        {
            for (int i =0; i < 10; i++)
            {
                await Task.Delay(100);
            }

            if (dish.TryPutIngredients(Ingredients.Bun))
            {
                Console.WriteLine($"빵을 접시에 올렸습니다. {Thread.CurrentThread.ManagedThreadId}");
            }
            return dish;
        }

        internal async Task<Dish> MeatPattyOnDish(Dish dish)
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(100);
            }
            if (dish.TryPutIngredients(Ingredients.MeatPatty))
            {
                Console.WriteLine($"고기 패티를 접시에 올렸습니다.{Thread.CurrentThread.ManagedThreadId}");
            }
            return dish;
        }

        internal async Task<Dish> TomatoOnDish(Dish dish)
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(100);
            }
            if (dish.TryPutIngredients(Ingredients.Tomato))
            {
                Console.WriteLine($"토마토를 접시에 올렸습니다.{Thread.CurrentThread.ManagedThreadId}");
            }
            return dish;
        }
    }
}
