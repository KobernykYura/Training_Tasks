﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using DependencyInjector;
using Injector.Common;
using System.Collections;
using System;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjectorTest.Classes;

namespace DependencyInjector.Tests
{
    [TestClass()]
    public class InjectorContainerTests
    {
        private InjectorContainer _kernel;

        [TestInitialize()]
        public void InjectorContainerTest()
        {
            _kernel = new InjectorContainer();
        }

        #region -------------------BindingHimself Tests------------------------

        [TestMethod()]
        public void BindHimselfTest_CorrectTypeClass()
        {
            _kernel.Bind<Match>();
        }

        [TestMethod()]
        [ExpectedException(typeof(NotSupportedException))]
        public void BindHimselfTest_TypeAlreadyBinded()
        {
            _kernel.Bind<Match>();
            _kernel.Bind<Match>();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void BindHimselfTest_IncorrectTypeITest()
        {
            _kernel.Bind<ITest>();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void BindHimselfTest_IncorrectTypeIFormattable()
        {
            _kernel.Bind<IFormattable>();
        }

        #endregion


        #region -------------------BindingKey Tests------------------------

        [TestMethod()]
        public void BindingKeyTest_GoodKeyAndType()
        {
            _kernel.Bind<ITest, Test>("asdfgh");
        }

        [TestMethod()]
        public void BindingKeyTest_TypeAlreadyBinded()
        {
            string key1 = "asdfgh";
            string key2 = "iuytre";

            _kernel.Bind<ITest, Test>(key1);
            _kernel.Bind<ITest, Test>(key2);
        }

        [TestMethod()]
        [ExpectedException(typeof(NotSupportedException))]
        public void BindingKeyTest_KeyAlreadyBinded()
        {
            _kernel.Bind<ITest, Test>("asdfgh");
            _kernel.Bind<ICollection, SortedList>("asdfgh");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void BindingKeyTest_BadKey()
        {
            _kernel.Bind<IList, Array>("");
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void BindingKeyTest_BadType()
        {
            _kernel.Bind<IConvertible, Activator>("asdfgh");
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void BindingKeyTest_BadInterface()
        {
            _kernel.Bind<IComparable, Hashtable>("asdfgh");
        }

        #endregion



        #region -------------------Bind interface to type Tests------------------------


        [TestMethod()]
        public void BindInterfaceToTypeTest_CorrectInterface()
        {
            _kernel.Bind<ITest, Test>();
        }

        [TestMethod()]
        public void BindInterfaceToTypeTest_ManyBindings()
        {
            _kernel.Bind<ITest, Test>("get");
            _kernel.Bind<ITest, TestA>("load");
            _kernel.Bind<ITest, TestB>("yesno");
        }

        [TestMethod()]
        [ExpectedException(typeof(NotSupportedException))]
        public void BindInterfaceToTypeTest_AlreadyBinded()
        {
            _kernel.Bind<ITest, Test>();
            _kernel.Bind<ITest, Test>();
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void BindInterfaceToTypeTest_IncorrectInterface()
        {
            _kernel.Bind<ICloneable, Test>();
        }

        [TestMethod()]
        public void BindInterfaceToTypeTest_CorrectSignatureIterfaceClass()
        {
            _kernel.Bind<IComparable, String>();
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void BindInterfaceToTypeTest_NoImplementationIterfaceClass()
        {
            _kernel.Bind<IAsyncResult, String>();
        }

        [TestMethod()]
        [ExpectedException(typeof(NotImplementedException))]
        public void BindInterfaceToTypeTest_IncorrectSignatureIterfaceClass()
        {
            _kernel.Bind<ITest, String>();
        }
        
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void BindInterfaceToTypeTest_IncorrectSignatureInterfaceInterface()
        {
            _kernel.Bind<IConvertible, IComparable>();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void BindInterfaceToTypeTest_IncorrectSignatureClassClass()
        {
            _kernel.Bind<Type, Random>();
        }

        #endregion



        #region -------------------Get method Tests------------------------


        [TestMethod()]
        public void GetTest()
        {
            _kernel.Bind<ITest, Test>();
            var obj = _kernel.Get<ITest>();

            Assert.IsNotNull(obj);
        }

        [TestMethod()]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void GetTest_InCorrectInterface()
        {
            _kernel.Bind<ITest, Test>();
            var obj = _kernel.Get<Test>();
        }

        [TestMethod()]
        [ExpectedException(typeof(TypeInitializationException))]
        public void GetTest_MoreThanTwoSimilarConstructors()
        {
            _kernel.Bind<ITest, TestA>();
            var obj = _kernel.Get<ITest>();

            Assert.IsNotNull(obj);
        }


        #endregion



        #region -------------------Get by key method Tests------------------------


        [TestMethod()]
        public void GetByKeyTest()
        {
            string key = "xcvbn";
            string key2 = "zxcvb";
            _kernel.Bind<ITest, Test>(key);
            _kernel.Bind<ITest, TestA>(key2);

            var obj = _kernel.GetByKey<ITest>(key);

            Assert.IsNotNull(obj);
        }

        [TestMethod()]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void GetByKeytTest_InCorrectInterfaceToGet()
        {
            string key = "xcvbn";
            _kernel.Bind<ITest, Test>(key);
            var obj = _kernel.GetByKey<Test>(key);
        }

        [TestMethod()]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void GetByKeytTest_InCorrectKey()
        {
            string key = "xcvbn";
            _kernel.Bind<ITest, Test>(key);
            var obj = _kernel.GetByKey<Test>("oiuytre");
        }

        [TestMethod()]
        [ExpectedException(typeof(TypeInitializationException))]
        public void GetByKeyTest_MoreThanTwoSimilarConstructors()
        {
            var key = "keykey";
            _kernel.Bind<ITest, TestA>(key);
            var obj = _kernel.GetByKey<ITest>(key);

            Assert.IsNotNull(obj);
        }
        
        #endregion

    }
}