using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Dish
{
    public class Cake : Dish
    {
        public Cake()
        {
            this._name = "Cake";
            this._dishType = DishType.DESERT;
        }

        public override void Add(Dish c)
        {
            Console.WriteLine("Cannot add to a Cake");
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
