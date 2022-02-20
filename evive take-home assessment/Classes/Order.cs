namespace Classes;

public enum Meal {
    Breakfast,
    Lunch,
    Dinner
}

public class Order
{
    public string Output { get; private set; }
    public Meal Meal { get; private set; }
    public string[] Items { get; private set;}

    public Order(Meal meal, params string[] items) {
        this.Meal = meal;
        this.Items = items;
        try
        {
            ProcessOrder();
            Console.WriteLine($"Here's what you ordered: {Output}");
        }
        catch (System.Exception e)
        {
            Output = e.Message;
            Console.WriteLine($"Unable to place order: {Output}");
            throw;
        }
    }

    private void ProcessOrder() {
        switch(Meal)
        {
            case Meal.Breakfast:
                Output = Breakfast.ProcessItems(Items);
                break;
            case Meal.Lunch:
                Output = Lunch.ProcessItems(Items);
                break;
            case Meal.Dinner:
                Output = Dinner.ProcessItems(Items);
                break;
        }
    }
}
