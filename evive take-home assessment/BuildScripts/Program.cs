using Classes;
namespace BuildScripts
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order1 = new Order(Meal.Breakfast, 1,2,3,3,3,3);
            Order order2 = new Order(Meal.Lunch, 2,1,2);
            Order order3 = new Order(Meal.Dinner, 1,2,3,4);
        }
    }
}
