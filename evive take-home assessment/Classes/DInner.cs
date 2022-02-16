namespace Classes;

public static class Dinner
{
    public static Dictionary<int, MenuItem> Menu 
    { 
        get {
            return new Dictionary<int, MenuItem>() {
                { 1, new MenuItem("Steak", ItemCategory.Main) },
                { 2, new MenuItem("Potatoes", ItemCategory.Side) },
                { 3, new MenuItem("Wine", ItemCategory.Drink) },
                { 4, new MenuItem("Cake", ItemCategory.Dessert) }
            };
        } 
    }
    public static string ProcessItems(int[] items) {
        Dictionary<ItemCategory, string> placedOrder = new Dictionary<ItemCategory, string>();

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
                throw new InvalidOperationException($"{item.Name} cannot be ordered more than once");
            }
        }

        if (!placedOrder.ContainsKey(ItemCategory.Main)) {
            throw new System.InvalidOperationException("Main dish is missing");
        }
        if (!placedOrder.ContainsKey(ItemCategory.Side)) {
            throw new System.InvalidOperationException("Side is missing");
        }
        if (!placedOrder.ContainsKey(ItemCategory.Dessert)) {
            throw new System.InvalidOperationException("Dessert is missing");
        }

        return $"{placedOrder[ItemCategory.Main]}, {placedOrder[ItemCategory.Side]}, {placedOrder[ItemCategory.Drink]}, Water, {placedOrder[ItemCategory.Dessert]}";
    }
}
