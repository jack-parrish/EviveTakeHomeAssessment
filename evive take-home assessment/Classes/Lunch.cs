namespace Classes;

public static class Lunch
{
    public static Dictionary<int, MenuItem> Menu 
    { 
        get {
            return new Dictionary<int, MenuItem>() {
                { 1, new MenuItem("Sandwich", ItemCategory.Main) },
                { 2, new MenuItem("Chips", ItemCategory.Side) },
                { 3, new MenuItem("Soda", ItemCategory.Drink) }
            };
        } 
    }
    public static string ProcessItems(int[] items) {
        Dictionary<ItemCategory, string> placedOrder = new Dictionary<ItemCategory, string>();
        int sidesCount = 1;

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
                if (item.ItemCat == ItemCategory.Side) {
                    sidesCount++;
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
        if (sidesCount > 1) {
            placedOrder[ItemCategory.Side] += $"({sidesCount})";
        }

        return $"{placedOrder[ItemCategory.Main]}, {placedOrder[ItemCategory.Side]}, {placedOrder[ItemCategory.Drink]}";
    }
}
