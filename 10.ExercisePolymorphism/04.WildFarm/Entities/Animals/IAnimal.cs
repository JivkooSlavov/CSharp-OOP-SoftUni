using _04.WildFarm.Entities.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.WildFarm.Entities.Animals
{
    public interface IAnimal
    {
        public string Name { get; }
        public double Weight {  get; }
        public int FoodEaten {  get; }

        public string ProduceSound();

        public void Eat(IFood food);
    }
}
