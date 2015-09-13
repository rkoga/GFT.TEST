using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Framework.Meal;
using GFT.Business;

namespace GFT.Tests
{
    [TestClass]
    public class OrderingTest
    {
        #region Input Tests
        [TestMethod]
        public void Input_MealType_Error()
        {
            string input = "MORaiNG";
            MealType c = new OrderingValidator().GetMealType(input);
            Assert.IsTrue(c == MealType.NOTAVAILABLE);
        }

        [TestMethod]
        public void Input_MealType_Morning_OK()
        {
            string input = "MORniNG";
            MealType c = new OrderingValidator().GetMealType(input);
            Assert.IsTrue(c == MealType.MORNING);
        }

        [TestMethod]
        public void Input_MealType_Night_OK()
        {
            string input = "Night";
            MealType c = new OrderingValidator().GetMealType(input);
            Assert.IsTrue(c == MealType.NIGHT);
        }
        #endregion

        #region Ordering Tests
        [TestMethod]
        public void Order_OrderMorning123_ShowseggsToastCoffeeSucessfully()
        {
            var c = new Ordering();
            string input = "morning,1,2,3";
            c.CreateMeal(input);
            var orderResult = c.DisplayMeal();

            Assert.IsTrue(orderResult == "eggs, toast, coffee");
        }

        [TestMethod]
        public void Order_MorningUpperCase_ShowseggsToastCoffeeSucessfully()
        {
            var c = new Ordering();
            string input = "MORNING,1,2,3";
            c.CreateMeal(input);
            var orderResult = c.DisplayMeal(); 

            Assert.IsTrue(orderResult == "eggs, toast, coffee");
        }

        [TestMethod]
        public void Order_OrderMorning231_ShowseggsToastCoffeeSucessfully()
        {
            var c = new Ordering();
            string input = "morning,2,3,1";
            c.CreateMeal(input);
            var orderResult = c.DisplayMeal(); 

            Assert.IsTrue(orderResult == "eggs, toast, coffee");
        }

        [TestMethod]
        public void Order_OrderMorning1223_StopAfterEgg()
        {
            var c = new Ordering();
            string input = "morning,1,2,2,3";
            c.CreateMeal(input);
            var orderResult = c.DisplayMeal(); 
            
            Assert.IsTrue(orderResult == "eggs, error");
        }

        [TestMethod]
        public void Order_OrderMorningNotApplicableDish_ShowErrorMessageAfterValidMessages()
        {
            var c = new Ordering();
            string input = "morning,1,2,3,4";
            c.CreateMeal(input);
            var orderResult = c.DisplayMeal(); 

            Assert.IsTrue(orderResult == "eggs, toast, coffee, error");
        }

        [TestMethod]
        public void Order_OrderMorningMultipleDrinks_ReturnDrinkWithMultiplicitySignal()
        {
            var c = new Ordering();
            string input = "morning,1,2,3,3,3";
            c.CreateMeal(input);
            var orderResult = c.DisplayMeal(); 

            Assert.IsTrue(orderResult == "eggs, toast, coffee(x3)");
        }

        [TestMethod]
        public void Order_OrderNight1234_ShowSteakPotatoWineCake()
        {
            var c = new Ordering();
            string input = "night,1,2,3,4";
            c.CreateMeal(input);
            var orderResult = c.DisplayMeal(); 

            Assert.IsTrue(orderResult == "steak, potato, wine, cake");
        }

        [TestMethod]
        public void Order_OrderNight1244_ShowMultipleSides()
        {
            var c = new Ordering();
            string input = "night,1,2,2,4";
            c.CreateMeal(input);
            var orderResult = c.DisplayMeal(); 

            Assert.IsTrue(orderResult == "steak, potato(x2), error");
        }

        [TestMethod]
        public void Order_NightUpperCase_ShowMultipleSides()
        {
            var c = new Ordering();
            string input = "NIGHT,1,2,2,4";
            c.CreateMeal(input);
            var orderResult = c.DisplayMeal();

            Assert.IsTrue(orderResult == "steak, potato(x2), error");
        }

        [TestMethod]
        public void Order_OrderNightInvalidDishRepetition_ShowMultipleErros()
        {
            var c = new Ordering();
            string input = "night,1,2,2,2,3,3,3,4";
            c.CreateMeal(input);
            var orderResult = c.DisplayMeal(); 

            Assert.IsTrue(orderResult == "steak, potato(x3), error");
        }

        [TestMethod]
        public void Order_InputInvalidMeal_ShowErrorWord()
        {
            var c = new Ordering();
            string input = "afternoon,1,2,2,2,3,3,3,4";
            c.CreateMeal(input);
            var orderResult = c.DisplayMeal(); 
            
            Assert.IsTrue(orderResult == "error");
        }
        #endregion
    }

}
