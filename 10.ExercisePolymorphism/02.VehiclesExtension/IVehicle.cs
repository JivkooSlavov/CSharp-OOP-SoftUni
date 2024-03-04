namespace _02.VehiclesExtension
{
    public interface IVehicle
    {
        public double FuelQuantity {  get;}
        public double FuelConsumptionPerKm {  get; }

        public double TankCapacity { get;}
        public bool CanDrive(double km);

        public void Drive (double km);

        public bool IsEmpty { get; set; }
        public void Refuel(double amount);

        public bool CanRefuel(double amount);

    }
}
