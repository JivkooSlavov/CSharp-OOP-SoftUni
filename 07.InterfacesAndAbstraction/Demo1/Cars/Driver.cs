using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Cars
{
    public class Driver
    {
        private ICar car = new Tesla();
        public void DriveTo(string address)
        {
            car.Start();

            car.Acceleration(100);

            car.Stop();
        }

    }
}
