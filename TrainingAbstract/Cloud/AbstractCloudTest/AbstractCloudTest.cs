using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudAbstractCloud;

namespace AbstractCloudTest
{
    [TestClass]
    public class AbstractCloudTest
    {
        /// <summary>
        /// Проверка метода предсказания координат
        /// </summary>
        [TestMethod]
        public void FutureCoordinateTest_InCoordinate304578_OutCoordinate284376()
        {
            Cloud cloud = new Cloud("Перьевое", 300000, 500000, "Вода", 300, -25, new Direction(-2, 1), new Coordinate(30, 45, 78));

            Coordinate res = cloud.FutureCoordinate();
            //----Проверка координат
            Assert.AreEqual(28, res.Gradus);
            Assert.AreEqual(43, res.Minuts);
            Assert.AreEqual(76, res.Seconds);
        }
        /// <summary>
        /// Проверка метода увеличения массы и объема облака. 
        /// </summary>
        [TestMethod]
        public void IncreaseMassTest_InVolume20Mass1000_OutVolume500020Mass301000()
        {
            Cloud cloud = new Cloud("Перьевое", 300000, 500000, "Вода", 300, -25, new Direction(-2, 1), new Coordinate(30, 45, 78));

            cloud.IncreaseMass(20, 1000);

            //----Проверка массы
            Assert.AreEqual((uint)301000, cloud.Mass);

            //----Проверка объема
            Assert.AreEqual((uint)500020, cloud.Volume);
        }
        /// <summary>
        /// Проверка методов моделирования дождя, снега, града. 
        /// </summary>
        [TestMethod]
        public void ItsRaining_InMinuts5Temperature10_OutVolumeSmaller()
        {
            Cloud cloud = new Cloud("Перьевое", 300, 5000, "Вода", 300, -9, new Direction(-2, 1), new Coordinate(30, 45, 78));

            cloud.ItsRaining(5);

            //----Проверка массы
            Assert.AreEqual((uint)250, cloud.Mass);

            //----Проверка объема
            Assert.AreEqual((uint)4500, cloud.Volume);
        }
        /// <summary>
        /// Проверка метода выпадения градовых осадков. 
        /// </summary>
        [TestMethod]
        public void ItsHailing_InMinuts10Temperature25_OutVolumeSmaller()
        {
            Cloud cloud = new Cloud("Перьевое", 300000, 500000, "Вода", 300, -25, new Direction(-2, 1), new Coordinate(30, 45, 78));

            cloud.ItsHailing(10);

            //----Проверка массы
            Assert.AreEqual((uint)299800, cloud.Mass);

            //----Проверка объема
            Assert.AreEqual((uint)498000, cloud.Volume);
        }
        /// <summary>
        /// Проверка метода выпадения снежных осадков. 
        /// </summary>
        [TestMethod]
        public void ItsSnowing_InMinuts15Temperature13_OutVolumeSmaller()
        {
            Cloud cloud = new Cloud("Перьевое", 300000, 500000, "Вода", 300, -13, new Direction(-2, 1), new Coordinate(30, 45, 78));

            cloud.ItsSnowing(15);

            //----Проверка массы
            Assert.AreEqual((uint)300000 - 5 * 15, cloud.Mass);

            //----Проверка объема
            Assert.AreEqual((uint)500000 - 50 * 15, cloud.Volume);
        }
        /// <summary>
        /// Проверка исключения неверной для метода температуры. 
        /// </summary>
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void ItsSnowing_InMinuts15Temperature10_OutTemperatureException()
        {
            Cloud cloud = new Cloud("Перьевое", 300000, 500000, "Вода", 300, 10, new Direction(-2, 1), new Coordinate(30, 45, 78));
            cloud.ItsSnowing(15);
        }
        /// <summary>
        /// Проверка исключения неверного для метода ввода температуры. 
        /// </summary>
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void ItsHailing_InMinuts10Temperature13_OutTemperatureException()
        {
            Cloud cloud = new Cloud("Перьевое", 300000, 500000, "Вода", 300, -13, new Direction(-2, 1), new Coordinate(30, 45, 78));
            cloud.ItsHailing(10);
        }
        /// <summary>
        /// Проверка исключения слишком долгого ввода времени выпадения осадков. 
        /// </summary>
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void ItsHailing_InMinuts10Temperature13_OutMassVolumeException()
        {
            Cloud cloud = new Cloud("Перьевое", 300, 5000, "Вода", 300, -23, new Direction(-2, 1), new Coordinate(30, 45, 78));
            cloud.ItsHailing(500);
        }
    }
}
