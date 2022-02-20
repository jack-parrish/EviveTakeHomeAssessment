namespace Classes;

public static class Breakfast
{
    public static Dictionary<string, MenuItem> Menu 
    { 
        get {
            return new Dictionary<string, MenuItem>() {
                { "1", new MenuItem("Eggs", ItemCategory.Main) },
                { "2", new MenuItem("Toast", ItemCategory.Side) },
                { "3", new MenuItem("Coffee", ItemCategory.Drink) }
            };
        } 
    }
    public static string ProcessItems(string[] items) {
        Dictionary<ItemCategory, string> placedOrder = new Dictionary<ItemCategory, string>();
        int coffeeCount = 1;
        MenuItem item = Menu["1"];
        for (int i = 0; i < items.Length; i++)
        {
            try
            {
                if (Menu.ContainsKey(items[i])) {
                    item = Menu[items[i]];
                    placedOrder.Add(item.ItemCat, item.Name);
                }
                else {
                    throw new System.ArgumentOutOfRangeException(items[i].ToString(), "Item not found in the menu - ");
                }
            }
            catch (System.ArgumentException e)
            {
                if (e is ArgumentOutOfRangeException) {
                    throw;
                }
                else if (item.ItemCat == ItemCategory.Drink & item.Name == "Coffee") {
                    coffeeCount++;
                }
                else {
                    throw new ArgumentException($"{item.Name} cannot be ordered more than once");
                }
            }
        }

        if (!placedOrder.ContainsKey(ItemCategory.Main)) {
            throw new System.ArgumentException("Main dish is missing");
        }
        if (!placedOrder.ContainsKey(ItemCategory.Side)) {
            throw new System.ArgumentException("Side is missing");
        }
        if (!placedOrder.ContainsKey(ItemCategory.Drink)) {
            placedOrder.Add(ItemCategory.Drink, "Water");
        }
        else if (placedOrder[ItemCategory.Drink] == "Coffee" & coffeeCount > 1) {
            placedOrder[ItemCategory.Drink] += $"({coffeeCount})";
        }

        return $"{placedOrder[ItemCategory.Main]}, {placedOrder[ItemCategory.Side]}, {placedOrder[ItemCategory.Drink]}";
    }
}
