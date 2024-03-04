using _04.WildFarm.Entities.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Entities.Animals
{
    public class Cat : Feline
    {
        public const double Modifier = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }
        public override void Eat(IFood food)
        {
            if (food is Vegetable || food is Meat)
            {
                Weight += Modifier * food.Quantity;
                FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
        public override string ProduceSound()=> "Meow";
    }
}
