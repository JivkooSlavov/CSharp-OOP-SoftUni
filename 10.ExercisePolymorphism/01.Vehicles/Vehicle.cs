 namespace _01.Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumptionPerKm)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
        }

        public double FuelQuantity {  get; set; }

        public virtual double FuelConsumptionPerKm { get; set;}

        public bool CanDrive(double km) => this.FuelQuantity - (km * this.FuelConsumptionPerKm) >= 0;

        public void Drive (double km)
        {
            if (CanDrive(km))
            {
                this.FuelQuantity -= km * this.FuelConsumptionPerKm;
            }
        }
        public virtual void Refuel(double amount)
        {
            this.FuelQuantity += amount;
        }
    }
}
