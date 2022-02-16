namespace Classes;

public static class Breakfast
{
    public static Dictionary<int, MenuItem> Menu 
    { 
        get {
            return new Dictionary<int, MenuItem>() {
                { 1, new MenuItem("Eggs", ItemCategory.Main) },
                { 2, new MenuItem("Toast", ItemCategory.Side) },
                { 3, new MenuItem("Coffee", ItemCategory.Drink) }
            };
        } 
    }
    public static string ProcessItems(int[] items) {
        Dictionary<ItemCategory, string> placedOrder = new Dictionary<ItemCategory, string>();
        int coffeeCount = 1;

        for (int i = 0; i < items.Length; i++)
        {
            MenuItem item = Menu[1];
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
            catch (System.ArgumentException)
            {
                if (item.ItemCat == ItemCategory.Drink & item.Name == "Coffee") {
                    coffeeCount++;
                }
                else {
                    throw new InvalidOperationException($"{item.Name} cannot be ordered more than once");
                }
            }
        }

        if (!placedOrder.ContainsKey(ItemCategory.Main)) {
            throw new System.InvalidOperationException("Main dish is missing");
        }
        if (!placedOrder.ContainsKey(ItemCategory.Side)) {
            throw new System.InvalidOperationException("Side is missing");
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
