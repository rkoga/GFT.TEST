using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Meal
{
    public class Meal : Dish.Dish
    {
        private List<Dish.Dish> _children = new List<Dish.Dish>();

        public Meal(string name)
            : base(name)
        {
        }

        public List<Dish.Dish> Dishes
        {
            get { return this._children; }
        }

        public override void Add(Dish.Dish component)
        {
            _children.Add(component);
        }

        public override void Remove(Dish.Dish component)
        {
            _children.Remove(component);
        }


        public override string Display(int depth)
        {
            StringBuilder sb = new StringBuilder();
            
            List<Dish.Dish> SortedList = this._children.OrderBy(o => o.DishType).ToList();

            // Recursively display child nodes
            foreach (Dish.Dish component in _children)
            {
                sb.Append(" " + component.Display(1) + ",");
                if (component.DishType == Dish.DishType.ERROR)
                {
                    break;
                }
            }
            sb.Remove(sb.Length - 1, 1);//remove last coma

            return sb.ToString();
            
        }
    }
}
