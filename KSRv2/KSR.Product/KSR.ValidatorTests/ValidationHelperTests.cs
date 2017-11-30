using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validator.Tests
{
    [TestClass()]
    public class ValidationHelperTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullObjectTest_NullObjectThrowArgumentNullException()
        {
            object obj = null;
            string message = "Problem";

            ValidationHelper.NullObject(obj, message);
        }

        [TestMethod()]
        public void NullObjectTest_NotNullObjectDontThrowArgumentNullException()
        {
            object obj = new object();
            string message = "Problem";

            ValidationHelper.NullObject(obj, message);
        }

        [TestMethod()]
        public void NullObjectTest_NotNullRandomObjectDontThrowArgumentNullException()
        {
            var obj = new Random();
            string message = "Problem";

            ValidationHelper.NullObject(obj, message);
        }

        [TestMethod()]
        public void NotNullObjectTest_NullObjectDontThrowArgumentNullException()
        {
            object obj = null;
            string message = "Problem";

            ValidationHelper.NotNullObject(obj, message);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NotNullObjectTest_NotNullObjectThrowArgumentNullException()
        {
            object obj = new object();
            string message = "Problem";

            ValidationHelper.NotNullObject(obj, message);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NotNullObjectTest_NotNullStackObjectThrowArgumentNullException()
        {
            var obj = new Stack<string>();
            string message = "Problem";

            ValidationHelper.NotNullObject(obj, message);
        }

        [TestMethod()]
        public void ObjectNotTypeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ObjectIsTypeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void NullStringTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void NotNullStringTest()
        {
            Assert.Fail();
        }
    }
}