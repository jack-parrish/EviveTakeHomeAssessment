using Classes;
namespace BuildScripts
{
    class Program
    {

        static void Main(string[] args)
        {
            MainMenu();
        }

        public static Dictionary<string,string> MainMenuOptions {
            get 
            {
                return new Dictionary<string, string>() {
                    {"1", "Place New Order"},
                    {"2", "Exit"}
                };
            }
        }
        static void MainMenu() {
            Console.WriteLine("Please select an option:");
            foreach (KeyValuePair<string,string> option in MainMenuOptions)
            {
                Console.WriteLine($"{option.Key} - {option.Value}");
            }
            string? optionChosen = Console.ReadLine();
            if ((optionChosen != null) & (optionChosen !="")) {
                try
                {
                    ValidateConsoleInput(optionChosen, MainMenuOptions);
                    if (optionChosen == "1") {
                        OrderMealMenu();
                    }
                }
                catch (System.ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    MainMenu();
                }
            } 
        }

        static Dictionary<string,Meal> MealOptions {
            get 
            {
                return new Dictionary<string, Meal>() {
                    {"1", Meal.Breakfast},
                    {"2", Meal.Lunch},
                    {"3", Meal.Dinner}
                };
            }
        }

        static void OrderMealMenu() {
            Console.WriteLine("Please select an meal to order:");
            foreach (KeyValuePair<string,Meal> option in MealOptions)
            {
                Console.WriteLine($"{option.Key} - {option.Value}");
            }
            string? optionChosen = Console.ReadLine();
            if ((optionChosen != null) & (optionChosen != "")) {
                try
                {
                    ValidateConsoleInput(optionChosen, MealOptions);
                    OrderItemsMenu(MealOptions[optionChosen]);
                }
                catch (System.ArgumentOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    OrderMealMenu();
                }
            } 
        }

        static void OrderItemsMenu(Meal meal) {
            Console.WriteLine($"Here's our {meal} menu:");

            switch (meal)
            {
                case Meal.Breakfast:
                    WriteMenuItems(Breakfast.Menu);
                    break;
                case Meal.Lunch:
                    WriteMenuItems(Lunch.Menu);
                    break;
                case Meal.Dinner:
                    WriteMenuItems(Dinner.Menu);
                    break;
            }

            Console.WriteLine("Enter a comma-separated list of items to order.");
            Console.WriteLine("e.g. 1,2,3");
            string? itemsOrdered = Console.ReadLine();

                if (itemsOrdered != null & itemsOrdered != "") {
                    string[] itemsArray = itemsOrdered.Split(",");
                    try
                    {
                        Order orderPlaced = new Order(meal, itemsArray);                        
                    }
                    catch (System.ArgumentException)
                    {
                        OrderItemsMenu(meal);
                    }
                }             

        }

        static void WriteMenuItems(Dictionary<string,MenuItem> menu) {
            foreach (KeyValuePair<string,MenuItem> item in menu)
            {
                Console.WriteLine($"{item.Key} - {item.Value.Name}");
            }
        }

        

        static void ValidateConsoleInput(string input, Dictionary<string,string> Options) {
            if (!Options.ContainsKey(input)) {
                throw new System.ArgumentOutOfRangeException(input, "Invalid selection: ");
            }
        }
        static void ValidateConsoleInput(string input, Dictionary<string,Meal> Options) {
            if (!Options.ContainsKey(input)) {
                throw new System.ArgumentOutOfRangeException(input, "Invalid selection: ");
            }
        }
    }
}
