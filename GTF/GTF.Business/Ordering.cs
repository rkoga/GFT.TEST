using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Meal;
using Framework.Factory;
using Framework.Dish;
using Framework.Cache;
using Framework.Log;

namespace GFT.Business
{
    public class Ordering
    {
        #region Constructor
        private Meal _meal;
        private CacheManager _cache;

        public Ordering()
        {
            this._cache = CacheManagerFactory.GetCacheManager("Meal");
        }
        #endregion

        #region CreateMeal
        public void CreateMeal(string input)
        {
            Logger.Info("Input: " + input);
                
            this._meal = (Meal)this._cache.Get(input);

            if (this._meal == null)
            {
                #region Create Meal
                MealType meal = MealType.NOTAVAILABLE;
                var validator = new OrderingValidator();
                if (validator.isInputValid(input, out meal))
                {
                    if (meal != MealType.NOTAVAILABLE)
                    {
                        #region Create Meal
                        this._meal = MealFactory.CreateMeal(meal);

                        var listDishes = validator.GetListDishes().OrderBy(x => x).GroupBy(x => x);
                        bool hasError = false;

                        foreach (var item in listDishes)
                        {
                            DishType? currentDishType = validator.GetToDishType(item.Key);
                            int dishRepetition = item.Count();

                            if (currentDishType != null)
                            {
                                var dish = this._meal.Dishes.Where(x => x.DishType == currentDishType).FirstOrDefault();
                                if (dishRepetition > 1)
                                {
                                    if (dish.HasMultipleOrder())
                                    {
                                        dish.HasOrdered = true;
                                        dish.Order(dishRepetition);
                                    }
                                    else
                                        dish = new ErrorDish();
                                }
                                else
                                {
                                    if (dish != null)
                                    {
                                        dish.HasOrdered = true;
                                        dish.Order(1);
                                    }

                                    if (currentDishType == DishType.DESERT && meal == MealType.MORNING)
                                    {
                                        this._meal.Add(new ErrorDish());
                                    }
                                }
                            }
                            else
                            {
                                if (!hasError)
                                    this._meal.Add(new ErrorDish());
                            }
                        }

                        //Check if there is any previous dish that isn't ordered
                        ValidOrder();
                        #endregion

                        #region Adding Meal to Cache
                        this._cache.Set(input, this._meal);
                        #endregion
                    }
                    else
                    {
                        #region Meal Type Not Found
                        this._meal = new Meal("Error");
                        this._meal.Add(new ErrorDish());
                        #endregion
                    }
                }
                #endregion
            }
        }

        #region ValidOrder
        private void ValidOrder()
        {
            for (int i = 0; i < this._meal.Dishes.Count; i++)
            {
                if (!this._meal.Dishes[i].HasOrdered)
                {
                    this._meal.Dishes[i] = new ErrorDish();
                }
            }
        }
        #endregion

        #endregion

        #region DisplayMeal
        public string DisplayMeal()
        {
            string display = "";
            if (this._meal != null)
            {
                display = this._meal.Display(0).ToLower().Trim(); 
            }
            else
            {
                display = new ErrorDish().Display(0).ToLower().Trim(); 
            }

            Logger.Info("Display: " + display);

            return display;
        }
        #endregion
    }
}
