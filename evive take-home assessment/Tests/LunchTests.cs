using Microsoft.VisualStudio.TestTools.UnitTesting;
using Classes;

namespace Tests;

[TestClass]
public class LunchTests
{
    [TestMethod]
    public void Lunch_WithValidItems_WritesOutput()
    {
        Meal meal = Meal.Lunch;
        string[] items = {"1","2","3"};

        Order testOrder = new Order(meal,items);

        string actual = testOrder.Output;
        Assert.AreEqual<string>("Sandwich, Chips, Soda", actual);
    }

    [TestMethod]
    public void Lunch_MultipleSides_WritesOutputWithNumSides()
    {
        Meal meal = Meal.Lunch;
        string[] items = {"1","2","2","2","2","2","2","3"};

        Order testOrder = new Order(meal,items);

        string actual = testOrder.Output;
        Assert.AreEqual<string>("Sandwich, Chips(6), Soda", actual);
    }

    [TestMethod]
    public void Lunch_ValidItemsOutOfOrder_WritesOutputInCorrectOrder()
    {
        Meal meal = Meal.Lunch;
        string[] items = {"2","3","1"};

        Order testOrder = new Order(meal,items);

        string actual = testOrder.Output;
        Assert.AreEqual<string>("Sandwich, Chips, Soda", actual);
    }

    [TestMethod]
    public void Lunch_NoDrink_WritesOutputWithWater()
    {
        Meal meal = Meal.Lunch;
        string[] items = {"1","2"};

        Order testOrder = new Order(meal,items);

        string actual = testOrder.Output;
        Assert.AreEqual<string>("Sandwich, Chips, Water", actual);
    }

    [TestMethod]
    public void Lunch_ItemNotOnMenu_ShouldThrowArgumentOutOfRange()
    {
        Meal meal = Meal.Lunch;
        string[] items = {"1","2","3","4"};

        Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => new Order(meal,items));
    }

    [TestMethod]
    public void Lunch_MultipleMains_ShouldThrowArgument()
    {
        Meal meal = Meal.Lunch;
        string[] items = {"1","2","3","1"};

        Assert.ThrowsException<System.ArgumentException>(() => new Order(meal,items));
    }

    [TestMethod]
    public void Lunch_NoMain_ShouldThrowArgument()
    {
        Meal meal = Meal.Lunch;
        string[] items = {"2","3"};

        Assert.ThrowsException<System.ArgumentException>(() => new Order(meal,items));
    }

    [TestMethod]
    public void Lunch_MultipleDrinks_ShouldThrowArgument()
    {
        Meal meal = Meal.Lunch;
        string[] items = {"1","2","3","3"};

        Assert.ThrowsException<System.ArgumentException>(() => new Order(meal,items));
    }

    [TestMethod]
    public void Lunch_NoSides_ShouldThrowArgument()
    {
        Meal meal = Meal.Lunch;
        string[] items = {"1","3"};

        Assert.ThrowsException<System.ArgumentException>(() => new Order(meal,items));
    }
}