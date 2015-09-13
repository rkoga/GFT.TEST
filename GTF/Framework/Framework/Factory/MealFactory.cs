using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Meal;

namespace Framework.Factory
{
    public class MealFactory
    {
        public static Meal.Meal CreateMeal(MealType type)
        {
            Meal.Meal meal = null;
            switch (type)
            {
                case MealType.MORNING:
                    meal = MorningFactory.Create();
                    break;
                case MealType.NIGHT:
                    meal = NightFactory.Create();
                    break;
            }
            return meal;
        }
    }
}
