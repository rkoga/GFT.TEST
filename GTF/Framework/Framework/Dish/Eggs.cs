using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Dish
{
    public class Eggs : Dish
    {
        public Eggs()
        {
            this._name = "Eggs";
            this._dishType = DishType.ENTREE;
        }

        public override void Add(Dish c)
        {
            Console.WriteLine("Cannot add to a leaf");
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
