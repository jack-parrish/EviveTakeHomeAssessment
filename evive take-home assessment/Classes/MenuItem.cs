namespace Classes;

public enum ItemCategory {
    Main,
    Side,
    Drink,
    Dessert
}

public class MenuItem {
    public string Name { get; set; }
    public ItemCategory ItemCat { get; set; }

    public MenuItem(string name, ItemCategory itemCat) {
        this.Name = name;
        this.ItemCat = itemCat;
    }

}