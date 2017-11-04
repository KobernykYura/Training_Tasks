using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PointClass;

namespace PointTest
{
    /// <summary>
    /// Class for testing operators for <see cref="Point"/>.
    /// </summary>
    [TestClass]
    public class PointOperatorsTest
    {
        /// <summary>
        /// Testing of increment and plus operators.
        /// </summary>
        [TestMethod]
        public void SumIncrementOperatorsTest_Summ_Increments()
        {
            double x = 100;
            double y = 50;

            Point point = new Point(x, y); // default Points.
            Point point2 = new Point(x + 10, y + 10);

            Point result = point + point2; // testing Add operator.

            Assert.AreEqual(210, result.X); // getting result of sum
            Assert.AreEqual(110, result.Y);

            result++; // postfix increment
            Assert.AreEqual(211, result.X);
            Assert.AreEqual(111, result.Y);

            ++result; // prefix increment
            Assert.AreEqual(212, result.X);
            Assert.AreEqual(112, result.Y);
        }
        /// <summary>
        /// Testing decrement and minus operator.
        /// </summary>
        [TestMethod]
        public void MinDecrementTest_Minus_Decrement()
        {
            double x = 100;
            double y = 50;

            Point point = new Point(x, y); // default Points.
            Point point2 = new Point(x + 10, y + 10);

            Point result = point2 - point; // testing minus operator.

            Assert.AreEqual(10, result.X); // getting result of minus
            Assert.AreEqual(10, result.Y);

            result--; // postfix decrement
            Assert.AreEqual(9, result.X);
            Assert.AreEqual(9, result.Y);

            --result; // prefix decrement
            Assert.AreEqual(8, result.X);
            Assert.AreEqual(8, result.Y);
        }
        /// <summary>
        /// Testing overrided true and false.
        /// </summary>
        [TestMethod]
        public void TrueFalseTest_InNull_OutFalse()
        {
            bool result = false;
            Point point = new Point(100, 50); // default Point
            Point point2 = null;

            if (point) // testing true
            {
                result = true;
            }

            Assert.IsTrue(result);

            if (point2) // testing false
            {
                result = true;
            }
            else result = false;

            Assert.IsFalse(result);

        }
        /// <summary>
        /// Testing of comparation operators.
        /// </summary>
        [TestMethod]
        public void ComparationTest()
        {
            double x = 100;
            double y = 50;

            Point point = new Point(x, y); // default Points.
            Point point2 = new Point(x, y);  
            Point point3 = new Point(x + 100, y + 50);
            Point pnull = null;

            Assert.IsTrue(point == point2); // testing comparation
            Assert.IsFalse(point == point3);
            Assert.IsFalse(pnull == point); // testing null

            Assert.IsTrue(point != point3);
            Assert.IsFalse(point != point2);
            Assert.IsTrue(pnull != point2); // testing null

            Assert.IsFalse(point2 >= point3);
            Assert.IsTrue(point3 >= point);
            Assert.IsFalse(pnull >= point3); // testing null

            Assert.IsFalse(point3 <= point2);
            Assert.IsTrue(point2 <= point3);
            Assert.IsFalse(pnull <= point); // testing null

            Assert.IsFalse(point3 < point2);
            Assert.IsTrue(point2 < point3);
            Assert.IsFalse(pnull < point2); // testing null

            Assert.IsTrue(point3 > point);
            Assert.IsFalse(point2 > point3);
            Assert.IsFalse(pnull > point3); // testing null

        }

        /// <summary>
        /// Testing overrided Equals().
        /// </summary>
        [TestMethod]
        public void EqualsTest_InNull_OutFalse()
        {
            bool result;
            Point point = new Point(100, 50); // default Point
            Point point2 = null;

            result = point.Equals(point2); // equal point with point2(null)

            Assert.IsFalse(result);

            result = point.Equals(point); // equal point with point 

            Assert.IsTrue(result);
        }
    }
}
