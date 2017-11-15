using Microsoft.VisualStudio.TestTools.UnitTesting;
using IncorrectOOPv2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncorrectOOPv2.Tests
{
    [TestClass()]
    public class PolymorphismTests
    {
        [TestMethod]
        public void BitAlgoritmTest_GoodInputLeftAndRightBorder()
        {
            int first = 10;
            int secound = 4;

            Assert.AreEqual(12, first.BitInsertAlgoritm(secound, 0, 2));

            int first1 = -14;
            int secound1 = 9;

            Assert.AreEqual(-24, first1.BitInsertAlgoritm(secound1, 1, 4));

            int first2 = 20;
            int secound2 = -8;

            Assert.AreEqual(56, first2.BitInsertAlgoritm(secound2, 1, 5));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void BitAlgoritmTest_BadInputLeftBorder()
        {
            int first1 = -14;
            int secound1 = 9;

            Assert.AreEqual(-24, first1.BitInsertAlgoritm(secound1, -45, 3));

        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void BitAlgoritmTest_BadInputRightBorder()
        {
            int first2 = 20;
            int secound2 = -8;

            Assert.AreEqual(56, first2.BitInsertAlgoritm(secound2, 1, 35));
        }

        [TestMethod()]
        public void SetBitTest()
        {
            int i = 1;

            Encapsulation.SetBit(ref i, 2, true);

            Assert.AreEqual(5, i);
        }

        [TestMethod()]
        public void GetBitTest()
        {
            int first2 = 20;
            int secound2 = -8;

            bool resF = first2.GetBit(1);
            bool resS = secound2.GetBit(5);

            Assert.IsFalse(resF);
            Assert.IsTrue(resS);
        }
    }
}