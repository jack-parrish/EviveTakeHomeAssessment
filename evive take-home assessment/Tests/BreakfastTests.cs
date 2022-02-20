using Microsoft.VisualStudio.TestTools.UnitTesting;
using Classes;

namespace Tests;

[TestClass]
public class BreakfastTests
{
    [TestMethod]
    public void Breakfast_WithValidItems_WritesOutput()
    {
        Meal meal = Meal.Breakfast;
        string[] items = {"1","2","3"};

        Order testOrder = new Order(meal,items);

        string actual = testOrder.Output;
        Assert.AreEqual<string>("Eggs, Toast, Coffee", actual);
    }

    [TestMethod]
    public void Breakfast_MultipleCoffees_WritesOutputWithNumCoffees()
    {
        Meal meal = Meal.Breakfast;
        string[] items = {"1","2","3","3","3","3","3","3"};

        Order testOrder = new Order(meal,items);

        string actual = testOrder.Output;
        Assert.AreEqual<string>("Eggs, Toast, Coffee(6)", actual);
    }

    [TestMethod]
    public void Breakfast_ValidItemsOutOfOrder_WritesOutputInCorrectOrder()
    {
        Meal meal = Meal.Breakfast;
        string[] items = {"2","3","1"};

        Order testOrder = new Order(meal,items);

        string actual = testOrder.Output;
        Assert.AreEqual<string>("Eggs, Toast, Coffee", actual);
    }

    [TestMethod]
    public void Breakfast_NoDrink_WritesOutputWithWater()
    {
        Meal meal = Meal.Breakfast;
        string[] items = {"1","2"};

        Order testOrder = new Order(meal,items);

        string actual = testOrder.Output;
        Assert.AreEqual<string>("Eggs, Toast, Water", actual);
    }

    [TestMethod]
    public void Breakfast_ItemNotOnMenu_ShouldThrowArgumentOutOfRange()
    {
        Meal meal = Meal.Breakfast;
        string[] items = {"1","2","3","4"};

        Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => new Order(meal,items));
    }

    [TestMethod]
    public void Breakfast_MultipleMains_ShouldThrowArgument()
    {
        Meal meal = Meal.Breakfast;
        string[] items = {"1","2","3","1"};

        Assert.ThrowsException<System.ArgumentException>(() => new Order(meal,items));
    }

    [TestMethod]
    public void Breakfast_NoMain_ShouldThrowArgument()
    {
        Meal meal = Meal.Breakfast;
        string[] items = {"2","3"};

        Assert.ThrowsException<System.ArgumentException>(() => new Order(meal,items));
    }

    [TestMethod]
    public void Breakfast_MultipleSides_ShouldThrowArgument()
    {
        Meal meal = Meal.Breakfast;
        string[] items = {"1","2","3","2"};

        Assert.ThrowsException<System.ArgumentException>(() => new Order(meal,items));
    }

    [TestMethod]
    public void Breakfast_NoSides_ShouldThrowArgument()
    {
        Meal meal = Meal.Breakfast;
        string[] items = {"1","3"};

        Assert.ThrowsException<System.ArgumentException>(() => new Order(meal,items));
    }
}