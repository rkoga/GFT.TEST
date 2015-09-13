using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Meal;
using Framework.Dish;

namespace Framework.Factory
{
    internal class MorningFactory
    {

        public static Morning Create()
        {
            Morning instance = new Morning();

            instance.Add(new Eggs());
            instance.Add(new Toast());

            Coffee obj = new Coffee();
            obj.EnableMultipleOrder();
            obj.Order(3);
            instance.Add(obj);

            return instance;
        }
    }
}

