using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            Fuel= fuel;
            HorsePower = horsePower;
        }

        public const double DefaultFuelConsumption = 1.25;

        public virtual double FuelConsumpiton => DefaultFuelConsumption;
        public double Fuel { get; set; }
        public int HorsePower {  get; set; }

        public virtual void Drive (double kilometers)
        {
            if (this.Fuel-(kilometers*FuelConsumpiton) >=0)
            {
                this.Fuel -= kilometers * FuelConsumpiton;
            }

        }

    }
}
