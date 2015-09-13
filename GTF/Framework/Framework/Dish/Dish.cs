using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Dish
{
    public abstract class Dish
    {
        public Dish() { }
        public Dish(string name)
        {
            this._name = name;
            this._hasOrdered = false;
            this._multipleOrder = false;
            this._quantity = 0;
        }

        protected string _name;
        public string Name
        {
            get { return _name; }
        }
        protected DishType _dishType;
        public DishType DishType
        {
            get { return _dishType; }
        }

        protected bool _multipleOrder;
        public bool MultipleOrder
        {
            set { this._multipleOrder = value; }
            get { return _multipleOrder; }
        }

        protected bool _hasOrdered;
        public bool HasOrdered
        {
            set { this._hasOrdered = value; }
            get { return _hasOrdered; }
        }

        protected int _quantity;
        protected int Quantity
        {
            get { return _quantity; }
        }


        public void EnableMultipleOrder()
        {
            this._multipleOrder = true;
        }

        public bool HasMultipleOrder()
        {
            return this._multipleOrder;
        }

        public void Order(int quantity)
        {
            this._quantity = quantity;
        }

        public abstract void Add(Dish c);
        public abstract void Remove(Dish c);
        public abstract string Display(int depth);


    }
}
