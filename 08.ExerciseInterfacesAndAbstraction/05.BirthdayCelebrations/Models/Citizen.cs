using _05.BirthdayCelebrations.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BirthdayCelebrations.Models
{
    public class Citizen : INameable, IIdentifiable, IBirthable
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Id = id;
            Birthdate = birthdate;
            Age = age;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }

        public string Birthdate { get; private set; }

    }
}
