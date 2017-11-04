using System;
using PointClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PointTest
{
    /// <summary>
    /// Class for testing extention methods for <see cref="Point"/> class.
    /// </summary>
    [TestClass]
    public class PointExtentionsTest
    {
        /// <summary>
        /// Method for testing <see cref="Point"/>.MoveTo(<see cref="Point"/>) extention method to positive point.
        /// </summary>
        [TestMethod]
        public void MoveToTest_In500100_OutTheSame()
        {
            double X = 100;
            double Y = 50;
            Point point = new Point(X, Y); // defaul point.

            double Xn = 500;
            double Yn = 100;
            point.MoveTo(new Point(Xn, Yn)); // move point to new position.

            Assert.AreEqual(500, point.X); // Point moved to new position. 
            Assert.AreEqual(100, point.Y);

        }
        /// <summary>
        /// Method for testing <see cref="Point"/>.MoveTo(<see cref="Point"/>) method with negative point parameters.
        /// </summary>
        [TestMethod]
        private void MoveToTest_Inmin400min120_OutTheSame()
        {
            double X = 100;
            double Y = 50;
            Point point = new Point(X, Y); // defaul point

            double Xnn = -400;
            double Ynn = -120;
            point.MoveTo(new Point(Xnn, Ynn)); // new point

            Assert.AreEqual(-400, point.X); // Point should change position to new
            Assert.AreEqual(-120, point.Y);
        }
        /// <summary>
        /// Method for testing <see cref="Point"/>.MoveX(<see cref="double"/>).MoveY(<see cref="double"/>) methods call.
        /// </summary>
        [TestMethod]
        public void SumTest_MoveXMoveY()
        {
            double X = 100;
            double Y = 50;
            Point point = new Point(X, Y); // defaul point.

            point.MoveX(10); // separated moving point on coordinates .
            point.MoveY(20);

            Assert.AreEqual(point.X, 110); // compare result.
            Assert.AreEqual(point.Y, 70);

            point.MoveX(30).MoveY(20); // combine call of methods.
            point.MoveY(20);

            Assert.AreEqual(point.X, 140); // compare result.
            Assert.AreEqual(point.Y, 110);
        }
        /// <summary>
        /// Method for testing methods MoveTo() to an empty object.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SumsTest_null()
        {
            Point point = null;
            point.MoveX(10); // expect exception.
            point.MoveY(20);

        }
        
    }
}
