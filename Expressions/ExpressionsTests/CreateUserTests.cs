using Microsoft.VisualStudio.TestTools.UnitTesting;
using Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expressions.Tests
{
    [TestClass()]
    public class CreateUserTests
    {
        [TestMethod()]
        public void GetUserTest_FuncStringStringDateTimeUser_SamWhite2010Age7()
        {
            var user = CreateExpression.GetUser("Sam", "White", DateTime.UtcNow.AddYears(-7));

            Assert.AreEqual("Sam", user.FirstName);
            Assert.AreEqual("White", user.LastName);
            Assert.AreEqual(DateTime.UtcNow.AddYears(-7).Year, user.BirthDay.Year);
            Assert.AreEqual((uint)7, user.Age);
        }

        [TestMethod()]
        public void GetUserTest_FuncStringStringDateTimeUser_OttoBecker2001Age16()
        {
            var user = CreateExpression.GetUser("Otto", "Becker", DateTime.UtcNow.AddYears(-16));

            Assert.AreEqual("Otto", user.FirstName);
            Assert.AreEqual("Becker", user.LastName);
            Assert.AreEqual(DateTime.UtcNow.AddYears(-16).Year, user.BirthDay.Year);
            Assert.AreEqual((uint)16, user.Age);

        }

        [TestMethod()]
        public void GetUserTest_FuncStringStringUser_NikolaiKopernyk()
        {
            var user = CreateExpression.GetUser("Nikolai", "Kopernyk");

            Assert.AreEqual("Nikolai", user.FirstName);
            Assert.AreEqual("Kopernyk", user.LastName);
        }

        [TestMethod()]
        public void GetUserTest_FuncStringStringUser_YaroslavWecker()
        {
            var user = CreateExpression.GetUser("Yaroslav", "Wecker");

            Assert.AreEqual("Yaroslav", user.FirstName);
            Assert.AreEqual("Wecker", user.LastName);
        }
    }
}