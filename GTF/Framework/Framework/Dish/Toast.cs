using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Dish
{
    public class Toast : Dish
    {
        public Toast()
        {
            this._name = "Toast";
            this._dishType = DishType.SIDE;
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
