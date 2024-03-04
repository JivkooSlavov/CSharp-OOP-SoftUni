using _04.WildFarm.Entities.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Entities.Animals
{
    public class Hen : Bird
    {
        private const double Modifier = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood food)
        {
            Weight += Modifier * food.Quantity;
            FoodEaten += food.Quantity;
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
