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
    public class CreateExpressionTests
    {
        [TestMethod()]
        public void TaskForAllExpressionTest_4sub2div2Is1()
        {
            var func = CreateExpression.TaskForAllExpression();

            var res = func(4, 2);

            Assert.AreEqual((double)1, res);
        }

        [TestMethod()]
        public void TaskForAllExpressionTest_3sub8div2Isminus2andHalf()
        {
            var func = CreateExpression.TaskForAllExpression();

            var res = func(3, 8);

            Assert.AreEqual(-2.5, res);
        }

        [TestMethod()]
        public void TaskForAllExpressionTest_2sub7div2Isminus2andHalf()
        {
            var func = CreateExpression.TaskForAllExpression();

            var res = func(2, 7);

            Assert.AreEqual(-2.5, res);
        }
    }
}