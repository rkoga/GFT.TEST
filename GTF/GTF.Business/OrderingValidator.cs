using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Meal;
using Framework.Dish;

namespace GFT.Business
{
    public class OrderingValidator
    {
        #region Constructor
        private List<int> listDishes;

        public OrderingValidator()
        {
        }
        #endregion

        #region isInputValid
        public bool isInputValid(string input, out MealType meal)
        {
            bool isOK = false;
            meal = MealType.NOTAVAILABLE;

            try
            {
                if(!string.IsNullOrEmpty(input))
                {
                    string[] inputArray = input.Split(',').ToArray();
                    
                    //Step 1, first item should have at least 4 itens 
                    if (inputArray.Length >= 4)
                    {
                        //Step 2, firt item show be Morning or Night
                        meal = this.GetMealType(inputArray[0]);
                        if (meal != MealType.NOTAVAILABLE)
                        {
                            //Step 3, the next itens should be number to 1 to 4
                            try
                            {
                                listDishes = new List<int>();
                                for (int i = 1; i < inputArray.Length; i++)
                                {
                                    int dishNumber = 0;
                                    bool aux = int.TryParse(inputArray[i].ToString().Trim(), out dishNumber);
                                    if (aux)
                                        listDishes.Add(dishNumber);
                                    else
                                        listDishes.Add(0);
                                }

                                isOK = true;
                            }
                            catch (Exception e)
                            {
                                Framework.Log.Logger.Error(e);
                            }
                        }                       
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Framework.Log.Logger.Error(e);
            }

            return isOK;
        }
        #endregion

        #region GetListDishes
        public List<int> GetListDishes()
        {
            return this.listDishes;
        }
        #endregion

        #region GetToDishType
        public DishType? GetToDishType(int dishType)
        {
            if(dishType > 0 && dishType < 5)
                return (DishType)dishType;
            else
                return null;
        }
        #endregion

        #region GetMealType
        public MealType GetMealType(string input)
        {
            MealType mealtype = MealType.NOTAVAILABLE;
            try
            {
                mealtype = (MealType)Enum.Parse(typeof(MealType), input.ToUpper().Trim(), true);
                string x = "MealType Value: " + mealtype.ToString();

            }
            catch (Exception ex)
            {
                Framework.Log.Logger.Error("input: " + input + " " + ex.ToString());
            }

            return mealtype;
        } 
        #endregion
    }
}
