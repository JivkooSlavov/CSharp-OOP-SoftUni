using NUnit.Framework;
using System.Diagnostics;
using System.Reflection;

namespace RobotFactory.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Ctor_Suplements()
        {
            Supplement sup = new Supplement("arm", 55);
            Assert.IsNotNull(sup);
            Assert.AreEqual("arm", sup.Name);
            Assert.AreEqual(55, sup.InterfaceStandard);
        }
        [Test]
        public void Test_ToString_Suplements()
        {
            Supplement sup = new Supplement("arm", 55);
            string expected = $"Supplement: arm IS: 55";
            Assert.AreEqual(expected, sup.ToString());
        }
        [Test]
        public void Test_Ctor_Robot()
        {
            Robot robo = new Robot("zhivko", 50, 55);
            Assert.IsNotNull(robo);
            Assert.AreEqual("zhivko", robo.Model);
            Assert.AreEqual(50, robo.Price);
            Assert.AreEqual(55, robo.InterfaceStandard);
            Assert.AreEqual(0, robo.Supplements.Count);
        }
        [Test]
        public void Test_ToString_Robot()
        {
            Robot robo = new Robot("zhivko", 50, 55);
            string expected = "Robot model: zhivko IS: 55, Price: 50.00";
            Assert.AreEqual(expected, robo.ToString());
        }
        [Test]
        public void Test_Ctor_Factory()
        {
            Factory factory = new Factory("Zara", 3);
            Assert.IsNotNull(factory);
            Assert.AreEqual("Zara", factory.Name);
            Assert.AreEqual(3, factory.Capacity);
            Assert.AreEqual(0, factory.Supplements.Count);
            Assert.AreEqual(0, factory.Robots.Count);
        }
        [Test]
        public void Test_Factory_ProduceRobot_HappyPatch()
        {
            Factory factory = new Factory("Zara", 2);
            string result = factory.ProduceRobot("jaba", 5, 40);
            Assert.AreEqual(1, factory.Robots.Count);
            string expected = "Produced --> Robot model: jaba IS: 40, Price: 5.00";
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Test_Factory_ProduceRobot_FailPatch()
        {
            Factory factory = new Factory("Zara", 2);
            factory.ProduceRobot("jaba", 5, 40);
            factory.ProduceRobot("muha", 5, 40);
            string result = factory.ProduceRobot("riba", 2, 22);
            Assert.AreEqual(2, factory.Robots.Count);
            string expected = "The factory is unable to produce more robots for this production day!";
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Test_Factory_ProduceSuplements()
        {
            Factory factory = new Factory("Zara", 2);
            string result = factory.ProduceSupplement("leg", 2);
            Assert.AreEqual(1, factory.Supplements.Count);
            string expected = $"Supplement: leg IS: 2";
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void Test_FactoryUpgradeRobotFalse()
        {
            Factory factory = new Factory("Zara", 2);
            Robot robo = new Robot("zhivko", 50, 5);
            Supplement sup = new Supplement("arm", 4);
            bool result = factory.UpgradeRobot(robo, sup);
            Assert.AreEqual(false, result);
        }
        [Test]
        public void Test_FactoryUpgradeRobotTrue()
        {
            Factory factory = new Factory("Zara", 2);
            Robot robo = new Robot("zhivko", 50, 5);
            Supplement sup = new Supplement("arm", 5);
            bool result = factory.UpgradeRobot(robo, sup);
            Assert.AreEqual(true, result);
            Assert.AreEqual(1, robo.Supplements.Count);
        }
        [Test]
        public void Test_Factory_SellRobot()
        {
            Factory factory = new Factory("Zara", 2);
            factory.ProduceRobot("some", 222, 2020);
            factory.ProduceRobot("same", 60, 2222);
            Robot robot = new Robot("same", 60, 2222);
            Assert.AreEqual(robot.Model, factory.SellRobot(60).Model);
        }
    }
}