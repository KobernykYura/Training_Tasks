using System;
using MyCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests
{
    /// <summary>
    /// Class for testing validation methods.
    /// </summary>
    [TestClass]
    public class ValidationTest
    {
        Validation validat = new Validation();
        /// <summary>
        /// Attempting to convert "90" string type to double type.
        /// </summary>
        [TestMethod]
        public void TryDouble_InStringAsDouble_OutTrue()
        {
            var str = "90";
            double res;

            var tr = validat.TryDouble(str, out res);
            Assert.IsTrue(tr);
            Assert.AreNotEqual(res, 0);
        }
        /// <summary>
        /// Attempting to convert "teststring" string type to double type.
        /// </summary>
        [TestMethod]
        public void TryDouble_InStringAsString_OutFalse()
        {
            var str = "teststring";
            double res;

            var tr = validat.TryDouble(str, out res);
            Assert.IsFalse(tr);
            Assert.AreEqual(res, 0);
        }
        /// <summary>
        /// Attempting to convert "1.7976931348623157E+309" string type to double type.
        /// </summary>
        [TestMethod]
        public void TryDouble_InPositiveInfinity_OutFalse()
        {
            var str = "1.7976931348623157E+309";
            double res;

            var tr = validat.TryDouble(str, out res);
            Assert.IsFalse(tr);
            Assert.AreEqual(res, 0);
        }
        /// <summary>
        /// Attempting to convert "-1.7976931348623157E+309" string type to double type.
        /// </summary>
        [TestMethod]
        public void TryDouble_InNegativeInfinity_OutFalse()
        {
            var str = "-1.7976931348623157E+309";
            double res;

            var tr = validat.TryDouble(str, out res);
            Assert.IsFalse(tr);
            Assert.AreEqual(res, 0);
        }
        /// <summary>
        /// Checking value double type out of range.
        /// </summary>
        [TestMethod]
        public void IsBordered_InNoInfinity_OutFalse()
        {
            var value = 9;

            var tr = validat.IsBordered(value);
            Assert.IsFalse(tr);
        }
        /// <summary>
        /// Checking value double type out of range.
        /// </summary>
        [TestMethod]
        public void IsBordered_InDoubleTypeBorder_OutFalse()
        {
            var value1 = 1.7976931348623157E+308;
            var value2 = -1.7976931348623157E+308;

            var tr1 = validat.IsBordered(value1);
            var tr2 = validat.IsBordered(value2);
            Assert.IsFalse(tr1);
            Assert.IsFalse(tr2);
        }
    }
}
