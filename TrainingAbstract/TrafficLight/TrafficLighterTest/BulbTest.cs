using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrafficLight;

namespace TrafficLighterTest
{
    [TestClass]
    public class BulbTest
    {
        Bulb bulb = new Bulb();

        [TestMethod]
        public void OnOffBulb_()
        {
            bulb.CurrentDuration = 1000000;
            bulb.ChangeBulb("Sony", 200, 5000, "E75");
            Assert.AreEqual(false, bulb.IsBroken());
        }
    }
}
