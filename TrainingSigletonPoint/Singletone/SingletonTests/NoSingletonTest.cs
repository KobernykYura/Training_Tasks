using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Singletone;

namespace SingletonTests
{
    /// <summary>
    /// Class for testing NoSingleton. 
    /// </summary>
    [TestClass]
    public class NoSingletonTest
    {
        /// <summary>
        /// Testing getter of singleton.
        /// </summary>
        [TestMethod]
        public void SingletonCreationTest()
        {
            NoSingletone noSingletone = NoSingletone.Instance; // creating singleton.

            Assert.IsNotNull(noSingletone); // if created.
            Assert.IsInstanceOfType(noSingletone, typeof(NoSingletone)); // equaliy of types.

            NoSingletone noSingletone2 = NoSingletone.Instance; // get created singleton.

            Assert.AreEqual(noSingletone, noSingletone2); // is we get the same singleton.
        }
        /// <summary>
        /// Testing propertys of singleton.
        /// </summary>
        [TestMethod]
        public void SingletonPropertyTest_IfReturnSameProperty()
        {
            NoSingletone noSingletone = NoSingletone.Instance; // creating singleton.

            NoSingletone noSingletone2 = NoSingletone.Instance; // get created singleton.

            Assert.AreEqual(noSingletone.AppDomainId, noSingletone2.AppDomainId); // is we get the same singleton.
            Assert.AreEqual(noSingletone.AppDomainFriendly, noSingletone2.AppDomainFriendly); // is we get the same singleton.
            Assert.AreEqual(noSingletone.AppDomainCurrent, noSingletone2.AppDomainCurrent); // is we get the same singleton.
        }
        /// <summary>
        /// Testing methods of Singleton.
        /// </summary>
        [TestMethod]
        public void SingletonMethodTest_IfMehodChangeSameValueInClass()
        {
            NoSingletone noSingletone = NoSingletone.Instance; // creating singleton.
            NoSingletone noSingletone2 = NoSingletone.Instance; // get created singleton.

            // First person change value inside of class
            byte r1 = noSingletone.ChangeField(6);

            // Nex person change value inside of class
            byte r2 = noSingletone.ChangeField(10);

            // Test of equality.
            Assert.AreEqual(16, r2);
            Assert.AreNotEqual(r1, r2);
            Assert.AreEqual(noSingletone.Result, noSingletone2.Result);

        }
    }
}
