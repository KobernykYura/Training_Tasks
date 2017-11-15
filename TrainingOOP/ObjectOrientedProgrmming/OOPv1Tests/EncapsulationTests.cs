using Microsoft.VisualStudio.TestTools.UnitTesting;
using IncorrectOOPv1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncorrectOOPv1;

namespace IncorrectOOPv1.Tests
{
    [TestClass()]
    public class EncapsulationTests
    {
        [TestMethod()]
        public void UserTest_UseConstrucorAndThanChangeFieldsByProperties()
        {
            string login = "user007";
            string password = "qwerty12";

            User user = new User(login, password); // user is created with constructor

            user.Login = "root008"; // we change important properties
            user.Password = "ytrewq21";

            Assert.AreNotEqual(login, user.Login); // properties are changed
            Assert.AreNotEqual(password, user.Password);
        }

    }
}