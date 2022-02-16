namespace Classes;

public enum Meal {
    Breakfast,
    Lunch,
    Dinner
}

public class Order
{
    private string _output = "";
    public Meal Meal { get; private set; }
    public int[] Items { get; private set;}

    public Order(Meal meal, params int[] items) {
        this.Meal = meal;
        this.Items = items;
        try
        {
            ProcessOrder();
            Console.WriteLine(_output);
        }
        catch (System.ArgumentOutOfRangeException e)
        {
            Console.WriteLine($"Unable to process order: {e.Message} {e.ParamName}");
        }
        catch (System.InvalidOperationException e)
        {
            Console.WriteLine($"Unable to process order: {e.Message}");
        }
    }

    private void ProcessOrder() {
        switch(Meal)
        {
            case Meal.Breakfast:
                _output = Breakfast.ProcessItems(Items);
                break;
            case Meal.Lunch:
                _output = Lunch.ProcessItems(Items);
                break;
            case Meal.Dinner:
                _output = Dinner.ProcessItems(Items);
                break;
        }
    }
}
