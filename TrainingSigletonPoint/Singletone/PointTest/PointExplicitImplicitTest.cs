using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PointClass;

namespace PointTest
{
    /// <summary>
    /// Class of testing of implicit and explicit convertion <see cref="Point"/> to <see cref="Type"/>.
    /// </summary>
    [TestClass]
    public class PointExplicitImplicitTest
    {
        /// <summary>
        /// Testing implicit convertion <see cref="Point"/> to <see cref="int"/>.
        /// </summary>
        [TestMethod]
        public void ImplicitTest_int()
        {
            double X = 0.200;
            double Y = 300;
            Point point = new Point(X, Y);

            Assert.IsInstanceOfType((int)point, typeof(int)); // equality of int types
            Assert.AreEqual((int)point, (int)point.X + (int)point.Y); // equality of ins
        }
        /// <summary>
        /// TEsting implicit convertion <see cref="Point"/> to <see cref="double"/>.
        /// </summary>
        [TestMethod]
        public void ImplicitTest_double()
        {
            double X = 200;
            double Y = 300;
            Point point = new Point(X, Y);

            Assert.IsInstanceOfType((double)point, typeof(double)); // equality of types
            Assert.AreEqual((double)point, point.X + point.Y); // equality of strngs
        }
        /// <summary>
        /// Testing implicit convertion <see cref="Point"/> to <see cref="string"/>.
        /// </summary>
        [TestMethod]
        public void ExplicitTest_string()
        {
            double X = 200;
            double Y = 300;
            Point point = new Point(X, Y);

            Assert.IsInstanceOfType((string)point, typeof(string)); // equality of string types
            Assert.AreEqual((string)point, $"{point.X} {point.Y}"); // equality of strings
        }
        /// <summary>
        /// Testing implicit convertion <see cref="int"/> to <see cref="Point"/>.
        /// </summary>
        [TestMethod]
        public void ExplicitTest_int()
        {
            int X = 200;

            Assert.IsInstanceOfType((Point)X, typeof(Point)); // equality of Point types
            Assert.AreEqual((Point)X, new Point(X, X)); // equality of Point
        }
        /// <summary>
        /// Testing implicit convertion <see cref="Point"/> to <see cref="string"/>.
        /// </summary>
        [TestMethod]
        public void ExplicitTest_double()
        { 
            double X = 200;

            Assert.IsInstanceOfType((Point)X, typeof(Point)); // equality of string types
            Assert.AreEqual((Point)X, new Point(X, X)); // equality of strings
        }

    }
}
