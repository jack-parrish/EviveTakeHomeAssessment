namespace Classes;

public static class Dinner
{
    public static Dictionary<string, MenuItem> Menu 
    { 
        get {
            return new Dictionary<string, MenuItem>() {
                { "1", new MenuItem("Steak", ItemCategory.Main) },
                { "2", new MenuItem("Potatoes", ItemCategory.Side) },
                { "3", new MenuItem("Wine", ItemCategory.Drink) },
                { "4", new MenuItem("Cake", ItemCategory.Dessert) }
            };
        } 
    }
    public static string ProcessItems(string[] items) {
        Dictionary<ItemCategory, string> placedOrder = new Dictionary<ItemCategory, string>();
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
        if (!placedOrder.ContainsKey(ItemCategory.Dessert)) {
            throw new System.ArgumentException("Dessert is missing");
        }

        if (placedOrder.ContainsKey(ItemCategory.Drink)) {
            return $"{placedOrder[ItemCategory.Main]}, {placedOrder[ItemCategory.Side]}, {placedOrder[ItemCategory.Drink]}, Water, {placedOrder[ItemCategory.Dessert]}";
        }
        
        return $"{placedOrder[ItemCategory.Main]}, {placedOrder[ItemCategory.Side]}, Water, {placedOrder[ItemCategory.Dessert]}";
    }
}
