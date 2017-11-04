using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EncriptionCode;

namespace StaticClassTests
{
    [TestClass]
    public class EncryptionTest
    {
        /// <summary>
        /// Testing the method Encode() with numbers only.
        /// </summary>
        [TestMethod]
        public void EncodeTest_In12345_Out01234()
        {
            string enter = "12345";
            var result = Encryption.Encode(enter); // Encoding

            string expected = "01234";

            Assert.AreEqual(expected, result);
        }
        /// <summary>
        /// Testing the method Encode() with numbers and letters.
        /// </summary>
        [TestMethod]
        public void EncodeTest_In12d345_Out01e234()
        {
            string enter = "12d345";
            var result = Encryption.Encode(enter);

            string expected = "01c234";

            Assert.AreEqual(expected, result);
        }
        /// <summary>
        /// Testing the method Encode() with numbers and letters.
        /// </summary>
        [TestMethod]
        public void EncodeTest_Inpsv34_Outoru23()
        {
            string enter = "psv34";
            var result = Encryption.Encode(enter);

            string expected = "oru23";

            Assert.AreEqual(expected, result);
        }
        /// <summary>
        /// Testing the method Decode() with numbers only.
        /// </summary>
        [TestMethod]
        public void EncodeTest_In1234_Out2345()
        {
            string enter = "1234";
            var result = Encryption.Decode(enter);

            string expected = "2345";

            Assert.AreEqual(expected, result);
        }
        /// <summary>
        /// Testing the method Decode() with numbers and letters.
        /// </summary>
        [TestMethod]
        public void EncodeTest_Inoru23_Outpsv34()
        {
            string enter = "oru23";
            var result = Encryption.Decode(enter);

            string expected = "psv34";

            Assert.AreEqual(expected, result);
        }
        /// <summary>
        /// Testing bouth methods Encode() and Decode() with letters and numbers.
        /// </summary>
        [TestMethod]
        public void EncodeAndDecodeTest_InABCD98_OutABCD98()
        {
            string enter = "AB0CD989";
            var result = Encryption.Encode(enter);
            result = Encryption.Decode(result);

            Assert.AreEqual(enter, result);
        }
    }
}
