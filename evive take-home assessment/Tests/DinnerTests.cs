using Microsoft.VisualStudio.TestTools.UnitTesting;
using Classes;

namespace Tests;

[TestClass]
public class DinnerTests
{
    [TestMethod]
    public void Dinner_WithValidItems_WritesOutput()
    {
        Meal meal = Meal.Dinner;
        string[] items = {"1","2","3","4"};

        Order testOrder = new Order(meal,items);

        string actual = testOrder.Output;
        Assert.AreEqual<string>("Steak, Potatoes, Wine, Water, Cake", actual);
    }

    [TestMethod]
    public void Dinner_ValidItemsOutOfOrder_WritesOutputInCorrectOrder()
    {
        Meal meal = Meal.Dinner;
        string[] items = {"2","4","3","1"};

        Order testOrder = new Order(meal,items);

        string actual = testOrder.Output;
        Assert.AreEqual<string>("Steak, Potatoes, Wine, Water, Cake", actual);
    }

    [TestMethod]
    public void Dinner_NoDrink_WritesOutputWithWater()
    {
        Meal meal = Meal.Dinner;
        string[] items = {"1","2","4"};

        Order testOrder = new Order(meal,items);

        string actual = testOrder.Output;
        Assert.AreEqual<string>("Steak, Potatoes, Water, Cake", actual);
    }

    [TestMethod]
    public void Dinner_ItemNotOnMenu_ShouldThrowArgumentOutOfRange()
    {
        Meal meal = Meal.Dinner;
        string[] items = {"1","2","3","4","Pudding"};

        Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => new Order(meal,items));
    }

    [TestMethod]
    public void Dinner_MultipleMains_ShouldThrowArgument()
    {
        Meal meal = Meal.Dinner;
        string[] items = {"1","2","3","4","1"};

        Assert.ThrowsException<System.ArgumentException>(() => new Order(meal,items));
    }

    [TestMethod]
    public void Dinner_NoMain_ShouldThrowArgument()
    {
        Meal meal = Meal.Dinner;
        string[] items = {"2","3","4"};

        Assert.ThrowsException<System.ArgumentException>(() => new Order(meal,items));
    }

    [TestMethod]
    public void Dinner_MultipleSides_ShouldThrowArgument()
    {
        Meal meal = Meal.Dinner;
        string[] items = {"1","2","3","4","2"};

        Assert.ThrowsException<System.ArgumentException>(() => new Order(meal,items));
    }

    [TestMethod]
    public void Dinner_NoSides_ShouldThrowArgument()
    {
        Meal meal = Meal.Dinner;
        string[] items = {"1","3","4"};

        Assert.ThrowsException<System.ArgumentException>(() => new Order(meal,items));
    }

    [TestMethod]
    public void Dinner_MultipleDesserts_ShouldThrowArgument()
    {
        Meal meal = Meal.Dinner;
        string[] items = {"1","2","3","4","4"};

        Assert.ThrowsException<System.ArgumentException>(() => new Order(meal,items));
    }

    [TestMethod]
    public void Dinner_NoDessert_ShouldThrowArgument()
    {
        Meal meal = Meal.Dinner;
        string[] items = {"1","2","3"};

        Assert.ThrowsException<System.ArgumentException>(() => new Order(meal,items));
    }
}
