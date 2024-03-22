using System;
using System.Diagnostics;

namespace CarManager.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private const string Make = "Ford";
        private const string Model = "Mustang";
        private const double FuelConsumption = 7;
        private const double FuelCapacity = 50;

        [Test]
        public void Ctor_CorrectParameters_CreatesNewInstance()
        {
            Car newFord = new Car(Make, Model, FuelConsumption, FuelCapacity);
            Assert.IsNotNull(newFord);
            Assert.AreEqual(Make, newFord.Make);
            Assert.AreEqual(Model, newFord.Model);
            Assert.AreEqual(FuelConsumption, newFord.FuelConsumption);
            Assert.AreEqual(FuelCapacity, newFord.FuelCapacity);
            Assert.AreEqual(0, newFord.FuelAmount);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Make_NullOrWhiteSpace_ThrowsException(string make)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(()
                => new Car(make, Model, FuelConsumption, FuelCapacity));
            Assert.AreEqual("Make cannot be null or empty!", ex.Message);
        }

        [TestCase(null)]
        [TestCase("")]
        public void Model_NullOrWhiteSpace_ThrowsException(string model)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(()
                => new Car(Make, model, FuelConsumption, FuelCapacity));
            Assert.AreEqual("Model cannot be null or empty!", ex.Message);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void FuelConsumptionCantBeZeroOrNegative_ThrowsException(double fuelConsuption)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(()
                => new Car(Make, Model, fuelConsuption, FuelCapacity));
            Assert.AreEqual("Fuel consumption cannot be zero or negative!", ex.Message);
        }
        [TestCase(-1)]
        public void FuelCapacityCantBeNegative_ThrowsException(double fuelCapacity)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(()
                => new Car(Make, Model, FuelConsumption, fuelCapacity));
            Assert.AreEqual("Fuel capacity cannot be zero or negative!", ex.Message);

        }

        [TestCase(0)]
        [TestCase(-1)]
        public void CantRefuelWithNegativeOrZero_ThrowsException(double refuel)
        {
            Car ford = new Car(Make, Model, FuelConsumption, FuelCapacity);
          
            ArgumentException ex = Assert.Throws<ArgumentException>(()
                => ford.Refuel(refuel));
            Assert.AreEqual("Fuel amount cannot be zero or negative!", ex.Message);
        }
        [TestCase(10)]
        public void RefuelWithHappyPatchCorrectly(double refuel)
        {
            Car ford = new Car(Make, Model, FuelConsumption, FuelCapacity);

            ford.Refuel(refuel);
            Assert.AreEqual(10, ford.FuelAmount);
        }
        [TestCase(60)]
        public void RefuelCantFuelAmountBeMoreThanCapacity(double refuel)
        {
            Car ford = new Car(Make, Model, FuelConsumption, FuelCapacity);

            ford.Refuel(refuel);
            Assert.AreEqual(50, ford.FuelAmount);
        }
        [TestCase(100)]
        public void DontHaveEnoghtFuelForThisDistance_ThrowsException(double distance)
        {
            Car ford = new Car(Make, Model, FuelConsumption, FuelCapacity);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()
                => ford.Drive(distance));
            Assert.AreEqual("You don't have enough fuel to drive!", ex.Message);
        }
        [Test]
        public void HappyPatchEnoghtFuelForThisDistance()
        {
            Car ford = new Car(Make, Model, FuelConsumption, FuelCapacity);
            ford.Refuel(10);
            ford.Drive(100);
            Assert.AreEqual(3, ford.FuelAmount);
        }
    }

}