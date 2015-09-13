using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Dish
{
    public class Wine : Dish
    {
        public Wine()
        {
            this._name = "Wine";
            this._dishType = DishType.DRINK;
        }

        public override void Add(Dish c)
        {
            Console.WriteLine("Cannot add to a " + this.Name);
        }

        public override void Remove(Dish c)
        {
            Console.WriteLine("Cannot add to a " + this.Name);
        }

        public override string Display(int depth)
        {
            return this.Name;
        }
    }
}
