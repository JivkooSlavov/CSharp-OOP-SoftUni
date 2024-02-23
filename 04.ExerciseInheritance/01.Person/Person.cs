using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Person
{
    public class Person
    {
		private int age;

		private string name;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public virtual int Age
		{
			get { return age; }
			set
			{
				if (age<0)
				{
					throw new Exception();
				} 
				age = value; 
			}
		}

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(String.Format("Name: {0}, Age: {1}",this.Name,this.Age));

            return stringBuilder.ToString();
        }

    }
}
