using System.Net.Mime;

namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class DeviceTests

    {
        private Device device;
        private int memoryCapacity = 1000;
        private int memoryOfPhoto = 800;
        private string appName = "FishingApp";
        private int smallSizeOfApp = 100;
        private int bigSizeOfApp = 1001;
        [SetUp]
        public void Setup()
        {
            device = new Device(memoryCapacity);
        }

        [Test]
        public void Test_Constructor_Saves_Correctly()
        {
            Assert.AreEqual(memoryCapacity, device.MemoryCapacity);
            Assert.AreEqual(memoryCapacity, device.AvailableMemory);
            Assert.AreEqual(0, device.Photos);
            Assert.AreEqual(0, device.Applications.Count);
        }

        [Test]
        public void Test_TakePhoto_WorkCorrectly()
        {
            bool result = device.TakePhoto(memoryOfPhoto);
            Assert.AreEqual(memoryCapacity, device.MemoryCapacity);
            Assert.AreEqual(memoryCapacity - memoryOfPhoto, device.AvailableMemory);
            Assert.AreEqual(1, device.Photos);
            Assert.AreEqual(true, result);
        }
        [TestCase(1001)]
        public void Test_TakePhoto_FailurePatch(int memoryPhoto)
        {
            bool result = device.TakePhoto(memoryPhoto);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void Test_Positive_InstallApp()
        {
            string result = device.InstallApp(appName, smallSizeOfApp);

            Assert.AreEqual(memoryCapacity-smallSizeOfApp, device.AvailableMemory);
            Assert.AreEqual(1, device.Applications.Count);
            Assert.AreEqual($"{appName} is installed successfully. Run application?", result);
        }

        [Test]
        public void Test_Failure_InstallApp()
        {
            Assert.Throws<InvalidOperationException>(() => device.InstallApp(appName, bigSizeOfApp));
        }

        [Test]
        public void Test_Format_Device()
        {
            device.InstallApp(appName, smallSizeOfApp);
            device.TakePhoto(memoryOfPhoto);
            device.FormatDevice();
            Assert.AreEqual(memoryCapacity, device.MemoryCapacity);
            Assert.AreEqual(memoryCapacity, device.AvailableMemory);
            Assert.AreEqual(0, device.Applications.Count);
        }

        [Test]
        public void Test_GetDeviceStatus()
        {
            Device device = new Device(1000);
            device.InstallApp(appName, smallSizeOfApp);
            device.TakePhoto(memoryOfPhoto);
            string status = device.GetDeviceStatus();

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Memory Capacity: {memoryCapacity} MB, Available Memory: {memoryCapacity-memoryOfPhoto-smallSizeOfApp} MB");
            stringBuilder.AppendLine($"Photos Count: {1}");
            stringBuilder.AppendLine($"Applications Installed: FishingApp");


            string result = stringBuilder.ToString().TrimEnd();
          

            Assert.AreEqual(result, status);

        }

    }
}