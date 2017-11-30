using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventReflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventReflection.Products;

namespace EventReflection.Tests
{
    [TestClass()]
    public class CreateReflectorTests
    {
        [TestMethod()]
        [ExpectedException(typeof(MissingMethodException))]
        public void CreateTest_StringCallMissingMethodException()
        {
            CreateReflector reflector = new CreateReflector();

            var obj = reflector.Create<string>();

            Assert.IsNotNull(obj);
        }

        [TestMethod()]
        [ExpectedException(typeof(MissingMethodException))]
        public void CreateTest_MulticastDelegateCallNotSupportedException()
        {
            CreateReflector reflector = new CreateReflector();

            var obj = reflector.Create<MulticastDelegate>();

            Assert.IsNotNull(obj);
        }

        [TestMethod()]
        public void CreateTest_Product()
        {
            CreateReflector reflector = new CreateReflector();

            var obj = reflector.Create<Product>();

            Assert.IsNotNull(obj);
        }

        [TestMethod()]
        public void CreateTest_Object()
        {
            CreateReflector reflector = new CreateReflector();

            var obj = reflector.Create<Object>();

            Assert.IsNotNull(obj);
        }

        [TestMethod()]
        public void CreateTest_Random()
        {
            CreateReflector reflector = new CreateReflector();

            var obj = reflector.Create<Random>();

            Assert.IsNotNull(obj);
        }

    }
}