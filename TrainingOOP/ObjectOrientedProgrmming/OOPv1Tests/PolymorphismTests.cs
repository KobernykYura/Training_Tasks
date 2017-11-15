using Microsoft.VisualStudio.TestTools.UnitTesting;
using IncorrectOOPv1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncorrectOOPv1.Tests
{
    [TestClass()]
    public class PolymorphismTests
    {
        Person person;

        [TestInitialize()]
        public void Initialisation()
        {
            person = new Person("Sam");
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void WorkHardTest()
        {
            for (int i = 0; i < 55; i++)
            {
                person.WorkHard();
            }
        }

        [TestMethod()]
        public void IsTiredTest()
        {
            for (int i = 0; i < 40; i++)
            {
                person.WorkHard();
            }
            Assert.IsTrue(person.IsTired());
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void RelaxWhileTest()
        {
            person.RelaxWhile(23);
        }
    }
}