namespace Television.Tests
{
    using System;
    using System.Diagnostics;
    using System.Xml.Linq;
    using NUnit.Framework;
    public class Tests
    {
        TelevisionDevice tv;
        private const string Brand = "Samsung";
        private const double Price = 1000;
        private const int ScreenWidth = 50;
        private const int ScreenHeight = 50;
        [SetUp]
        public void Setup()
        {
            tv = new TelevisionDevice(Brand, Price, ScreenWidth, ScreenHeight);
        }

        [Test]
        public void Test1()
        {
            Assert.IsNotNull(tv);
            Assert.AreEqual(Brand, tv.Brand);
            Assert.AreEqual(Price, tv.Price);
            Assert.AreEqual(ScreenWidth, tv.ScreenHeigth);
            Assert.AreEqual(ScreenHeight, tv.ScreenWidth);
            Assert.AreEqual(0, tv.CurrentChannel);
            Assert.AreEqual(13, tv.Volume);
            Assert.AreEqual(false, tv.IsMuted);
        }

        [Test]
        public void Test_ToString()
        { 
            string expected = $"TV Device: {Brand}, Screen Resolution: {ScreenWidth}x{ScreenHeight}, Price {Price}$";
            string actual = tv.ToString();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test_SwitchOn()
        {
            string expected = $"Cahnnel 0 - Volume 13 - Sound On";
            string actual = tv.SwitchOn();
            Assert.AreEqual(expected, actual);  
        }
        [Test]
        public void ChangeChannel_SetTheRightChannel()
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => tv.ChangeChannel(-2));
            Assert.AreEqual("Invalid key!", ex.Message);
            tv.ChangeChannel(2);
            Assert.AreEqual(2, tv.CurrentChannel);
        }
        [Test]
        public void Change_Volume_Up()
        {
            string expected = "Volume: 100";
            string actual = tv.VolumeChange("UP", 101);
            Assert.AreEqual(expected, actual);
    
        }
        [Test]
        public void Change_Volume_Down()
        {
            string expected = "Volume: 0";
            string actual = tv.VolumeChange("DOWN", -15);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Test_TvIsMuted()
        {
            tv.MuteDevice();
            Assert.AreEqual(true, tv.IsMuted);
            tv.MuteDevice();
            Assert.AreEqual(false, tv.IsMuted);
        }
    }
}