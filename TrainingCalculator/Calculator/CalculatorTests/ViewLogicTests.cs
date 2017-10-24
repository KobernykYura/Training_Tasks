using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalculator.Tests
{
    [TestClass()]
    public class ViewLogicTests
    {
        /// <summary>
        /// Test takes x= double.MaxValue ,y= double.MaxValue, arg="+" parameters.
        /// Main condition is that we can't do this action because of out of double type value range.
        /// </summary>
        [TestMethod()]
        public void SwitchCaseTest_InPlus_XMaxValue_YMaxValue_OutFalse()
        {
            string arg = "+";
            double x = double.MaxValue;
            double y = double.MaxValue;
            double mean;

            Assert.IsFalse(ViewLogic.SwitchCase(arg, x, y, out mean));
        }
        /// <summary>
        /// Test takes x= double.MinValue ,y= double.MinValue, arg="+" parameters.
        /// Main condition is that we can't do this action because of out of double type value range.
        /// </summary>
        [TestMethod()]
        public void SwitchCaseTest_InPlus_XMinValue_YMinValue_OutFalse()
        {
            string arg = "+";
            double x = double.MinValue;
            double y = double.MinValue;
            double mean;

            Assert.IsFalse(ViewLogic.SwitchCase(arg, x, y, out mean));
        }
        /// <summary>
        /// Test takes x= double.MinValue ,y= double.MinValue, arg="-" parameters and should back mean= 0.
        /// Main condition is that we can't do this action because of out of double type value range.
        /// </summary>
        [TestMethod()]
        public void SwitchCaseTest_InPlus_XMinValu_YMinValu_OutMean0()
        {
            string arg = "+";
            double x = double.MinValue;
            double y = double.MinValue;
            double mean;

            Assert.IsFalse(ViewLogic.SwitchCase(arg, x, y, out mean));
        }
        /// <summary>
        /// Test takes x= -343 ,y= 0, arg="*" parameters and should back mean= 0.
        /// Main condition is that we can do this action even with negative double value.
        /// </summary>
        [TestMethod()]
        public void SwitchCaseTest_InMulti_X343_Y0_OutMean0()
        {
            string arg = "*";
            double x = -343;
            double y = 0;
            double mean;

            Assert.IsTrue(ViewLogic.SwitchCase(arg, x, y, out mean));
            Assert.AreEqual(0, mean);
        }
        /// <summary>
        /// Test takes x= -343 ,y= -30, arg="*" parameters and should back mean= "result".
        /// Main condition is that we can do this action even with negative double value.
        /// </summary>
        [TestMethod()]
        public void SwitchCaseTest_InMulti_X343_Y30_OutMeanResul()
        {
            string arg = "*";
            double x = -343;
            double y = -30;
            double mean;

            Assert.IsTrue(ViewLogic.SwitchCase(arg, x, y, out mean));
            Assert.AreNotEqual(0, mean);
        }
        /// <summary>
        /// Test takes x= 45 ,y= 0, arg="/" parameters.
        /// Main condition is that we can't do this action because of DivideByZeroException. 
        /// </summary>
        [TestMethod()]
        public void SwitchCaseTest_InDiv_X45_Y0_OutMean0()
        {
            string arg = "/";
            double x = 45;
            double y = 0;
            double mean;

            Assert.IsFalse(ViewLogic.SwitchCase(arg, x, y, out mean));
        }
        /// <summary>
        /// Test takes x= 0 ,y= 56, arg="/" parameters and should back mean= 0.
        /// Main condition is that we can do this action because this is not DivideByZeroException. 
        /// </summary>
        [TestMethod()]
        public void SwitchCaseTest_InDiv_X0_Y56_OutMean0()
        {
            string arg = "/";
            double x = 0;
            double y = 56;
            double mean;

            Assert.IsTrue(ViewLogic.SwitchCase(arg, x, y, out mean));
            Assert.AreEqual(0, mean);
        }
    }
}