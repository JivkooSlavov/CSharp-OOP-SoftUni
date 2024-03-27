using _06.FoodShortage.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FoodShortage.Models
{
    public class Robot : INameable, IIdentifiable
    {
        public Robot(string name, string id)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; private set; }

        public string Id { get; private set; }
    }
}
