using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using DependencyInjectorTest.Classes;
using System.Collections;

namespace DependencyInjectorTests
{
    [TestClass]
    public class NinjectTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            string str1 = "I'm ";
            string str2 = "live ";
            string str3 = "there.";

            //IParameter par1 = (IParameter)"I'm ";
            object[] par2 = new string[] { str1, str2 };
            string[] par3 = new string[] { str1, str2, str3 };


            IKernel kernel = new StandardKernel();
            kernel.Bind<ITest>().To<Test>();
            //kernel.Bind<ICollection>().To<Stack>();

            var costructor1 = kernel.Get<ITest>();
           // var costructor2 = kernel.Get<ICollection>();
            //var costructor3 = kernel.Get(typeof(Test), str3);

            costructor1.Print();
            //costructor2.GetType();

        }
    }
}
