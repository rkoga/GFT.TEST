using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GFT.Business;
using Framework.Meal;

namespace GFT
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
            
            string input = "";

            Console.WriteLine("To quit, press q.");

            while (true)
            {
                Console.Write("Please, input your order: ");
                input = Console.ReadLine();

                if (input.ToLower() == "q")
                {
                    break;
                }

                Ordering ordering = new Ordering();
                ordering.CreateMeal(input);
                Console.WriteLine(ordering.DisplayMeal());
            }

        }
    }
}
