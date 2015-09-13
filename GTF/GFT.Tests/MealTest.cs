using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.Factory;
using Framework.Meal;

namespace GFT.Tests
{
    [TestClass]
    public class MealTest
    {
        [TestMethod]
        public void Meal_Night_Factory_OK()
        {
            Meal obj = MealFactory.CreateMeal(MealType.NIGHT);

            var meal = obj.Display(1);
            Console.WriteLine(meal);
            Assert.IsTrue(obj.Name == "Night");
        }

        [TestMethod]
        public void Meal_Morning_Factory_OK()
        {
            Meal obj = MealFactory.CreateMeal(MealType.MORNING);

            var meal = obj.Display(1);
            Console.WriteLine(meal);
            Assert.IsTrue(obj.Name == "Morning");
        }
    }
}
