using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algoritms;
using System.Collections;
using System.Linq;

namespace AlgoritmsTests
{
    [TestClass]
    public class AlgoritmTests
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

        [TestMethod]
        public void RecursiveAlgoritmTest()
        {
            int[] array = new int[] { 12, 23, 12, 11, 2, 6, 5, 45, 7, 8, 4, 34, 90 };
            int biggest = Algoritms.Algoritms.RecursiveAlgoritm(array);
            Assert.AreEqual(array.Max(), biggest);

            int[] array2 = new int[] { -12, -23, -12, -50, -11, -2, -6, -5, -77, -45, -7, -8, -4, -34, -90 };
            int biggest2 = Algoritms.Algoritms.RecursiveAlgoritm(array2);
            Assert.AreEqual(array2.Max(), biggest2);

            int[] array3 = new int[] { 125, -423, 10002, 11, 2, -546, 5, 45, 57, 8, 9, -384, 60 };
            int biggest3 = Algoritms.Algoritms.RecursiveAlgoritm(array3);
            Assert.AreEqual(array3.Max(), biggest3);
        }
        
        [TestMethod]
        public void PairSumAlgoritmTest_DifferentArrays()
        {
            int[] array = new int[] { 1, 2, 3, 2, 1 };
            var res = Algoritms.Algoritms.EqualSumAlgoritm(array);

            Assert.AreEqual(2, res);

            int[] array2 = new int[] { 41, 3, 2, 15 };
            var res2 = Algoritms.Algoritms.EqualSumAlgoritm(array2);

            Assert.AreEqual(-1, res2);

            int[] array3 = new int[] { 6, 1, 34, 2, 5 };
            var res3 = Algoritms.Algoritms.EqualSumAlgoritm(array3);

            Assert.AreEqual(2, res3);

            int[] array4 = new int[] { 1, 0, 0, 2, 1 };
            var res4 = Algoritms.Algoritms.EqualSumAlgoritm(array4);

            Assert.AreEqual(3, res4);
        }

        [TestMethod]
        public void TwoStringsTest_GoodInputString()
        {
            string str1 = "abcdefg";
            string str2 = "defghklmnop";

            var res = Algoritms.Algoritms.TwoStrings(str1, str2);

            Assert.AreEqual("abcdefghklmnop", res);

            var res2 = Algoritms.Algoritms.TwoStrings("sdfgdgbvcn", "plmnbvghjkdfdf");

            Assert.AreEqual("bcdfghjklmnpsv", res2);


            var res3 = Algoritms.Algoritms.TwoStrings("dsfsgsfgfgggg", "uytredfghjhgf");

            Assert.AreEqual("defghjrstuy", res3);

            var res4 = Algoritms.Algoritms.TwoStrings("asddfdfs", "ghkl");

            Assert.AreEqual("adfghkls", res4);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TwoStringsTest_BadInputStringFormatExceptionNumbers()
        {
            string str1 = "abcd5efg";
            string str2 = "de3fgh9klmn3op";

            var res = Algoritms.Algoritms.TwoStrings(str1, str2);

            Assert.AreEqual("abcdefghklmnop", res);

        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TwoStringsTest_BadInputStringFormatExceptionSyblols()
        {
            string str1 = "ab]cde,fg";
            string str2 = "def.ghklmnop";

            var res = Algoritms.Algoritms.TwoStrings(str1, str2);

            Assert.AreEqual("abcdefghklmnop", res);

        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TwoStringsTest_BadInputStringNullReferenceException()
        {
            string str1 = null;
            string str2 = "def.ghklmnop";

            var res = Algoritms.Algoritms.TwoStrings(str1, str2);

            Assert.AreEqual("abcdefghklmnop", res);

        }

        [TestMethod]
        public void FilterLuckyTest_PositiveNumbers()
        {
            int[] input = new int[] { 2, 4, 6, 7, 3, 45, 17, 45456779, 67, 66 };
            int[] res = Algoritms.Algoritms.FilterLucky(input);
            int[] expected = new int[] { 7, 17, 45456779, 67 };

            for (int i = 0; i < res.Length; i++)
            {
                Assert.AreEqual(expected[i], res[i]);
            }

            int[] input2 = new int[] { 11, 33, 54, 7, 88, 343, 90, 345677, 478 };
            int[] res2 = Algoritms.Algoritms.FilterLucky(input2);
            int[] expected2 = new int[] { 7, 345677, 478 };

            for (int i = 0; i < res2.Length; i++)
            {
                Assert.AreEqual(expected2[i], res2[i]);
            }
        }

        [TestMethod]
        public void FilterLuckyTest_NegativeNumbers()
        {
            int[] input = new int[] { -34, 427, -87, 23, 354 };
            int[] res = Algoritms.Algoritms.FilterLucky(input);
            int[] expected = new int[] { 427, -87 };

            for (int i = 0; i < res.Length; i++)
            {
                Assert.AreEqual(expected[i], res[i]);
            }
        }
    }
}
