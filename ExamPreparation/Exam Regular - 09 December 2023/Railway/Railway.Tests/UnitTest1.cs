namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using static System.Collections.Specialized.BitVector32;

    public class Tests
    {
        private RailwayStation station;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Constructor()
        {
            station = new RailwayStation("Stara Zagora");
            Assert.IsNotNull(station);
            Assert.AreEqual("Stara Zagora", station.Name);
            Assert.AreEqual(0, station.DepartureTrains.Count);
            Assert.AreEqual(0, station.ArrivalTrains.Count);

        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Test_Empty_ThrowEx(string name)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>  new RailwayStation(name));
            Assert.AreEqual("Name cannot be null or empty!", ex.Message);
        }

        [Test]
        public void Test_InfoTrain()
        {
            station = new RailwayStation("Stara Zagora");
            station.NewArrivalOnBoard("plovdiv-varna");
            Assert.AreEqual("plovdiv-varna", station.ArrivalTrains.Peek());
            Assert.AreEqual(1, station.ArrivalTrains.Count);

        }
        [Test]
        public void Test_TrainHasArrived()
        {
            station = new RailwayStation("Stara Zagora");
            station.NewArrivalOnBoard("plovdiv-varna");

            Assert.AreEqual("There are other trains to arrive before sofia-varna.", station.TrainHasArrived("sofia-varna"));


            Assert.AreEqual("plovdiv-varna is on the platform and will leave in 5 minutes.", station.TrainHasArrived("plovdiv-varna"));

            Assert.AreEqual(1, station.DepartureTrains.Count);
            Assert.AreEqual("plovdiv-varna", station.DepartureTrains.Dequeue());
            Assert.AreEqual(0, station.ArrivalTrains.Count);

        }
        [Test]
        public void Test_TrainHasLeft()
        {
            station = new RailwayStation("Stara Zagora");
            station.NewArrivalOnBoard("plovdiv-varna");
            station.TrainHasArrived("plovdiv-varna");

            Assert.AreEqual(false, station.TrainHasLeft("Non exist"));
            Assert.AreEqual(true, station.TrainHasLeft("plovdiv-varna"));
            Assert.AreEqual(0, station.DepartureTrains.Count);

        }
    }
}