using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Dish
{
    public class Coffee : Dish
    {
        public Coffee()
        {
            this._name = "Coffee";
            this._dishType = DishType.DRINK;
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
            string strDisplay = "";
            if (HasMultipleOrder() && this.Quantity > 1)
            {
                strDisplay = this.Name + "(x"+this.Quantity+")";
            }
            else
            {
                strDisplay = this.Name;
            }
            return strDisplay;
        }
    }
}
