namespace _02_AsyncExmple_Breakfast
{
    internal enum Beverage
    {
        None,
        Water,
        Coffee,
        Milk,
    }

    internal struct Cup
    {
        internal float Capacity;
        internal float FillRatio;
        internal Beverage Filled;
    }

    [Flags]
    internal enum Ingredients
    {
        None = 0 << 0,
        Bun = 1 << 0,
        MeatPatty = 1 << 1,
        Tomato = 1 << 2,
        Bacon = 1 << 3,
        Egg = 1 << 4,
        Toast = 1 << 5,
    }

    internal enum Meal
    {
        None,
        Hamburger,
    }

    internal class Dish
    {
        internal Ingredients Ingredients;
        internal Meal Meal;

        internal bool TryPutIngredients(Ingredients ingredients)
        {
            if (TryConvertToMeal(ingredients))
                return true;

            if (Ingredients < ingredients)
            {
                Ingredients |= ingredients;
                return true;
            }

            return false;
        }

        internal bool TryConvertToMeal(Ingredients ingredients)
        {
            if (Ingredients == (Ingredients.Bun | Ingredients.MeatPatty | Ingredients.Tomato))
            {
                if (ingredients == Ingredients.Bun)
                {
                    Meal = Meal.Hamburger;
                    Ingredients = Ingredients.None;
                    return true;
                }
            }
            return false;
        }
    }

    internal struct Bacon { }
    internal struct Egg { }
    internal struct Toast { }
    internal struct Coffee { }
    internal struct Juice { }
}
