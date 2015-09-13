using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Meal;
using Framework.Dish;

namespace Framework.Factory
{
    internal class NightFactory
    {

        public static Night Create()
        {
            Night instance = new Night();
            instance.Add(new Steak());
            Potato obj = new Potato();
            obj.EnableMultipleOrder();
            instance.Add(obj);
            instance.Add(new Wine());

            instance.Add(new Cake());

            return instance;
        }
    }
}
