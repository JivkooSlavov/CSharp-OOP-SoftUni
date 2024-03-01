using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Animals
{
    public class Animal
    {
        public string name;
        public string favouriteFood;

        public Animal(string name, string favouriteFood)
        {
            Name = name;
            FavouriteFood = favouriteFood;
        }

        public string Name { get; set; }
        public string FavouriteFood {  get; set; }  

        public virtual string ExplainSelf()
        {
            return $"I am {name} and my fovourite food is {favouriteFood}";
        }
    }
}
