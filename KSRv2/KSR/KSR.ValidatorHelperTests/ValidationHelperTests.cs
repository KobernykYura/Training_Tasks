using Microsoft.VisualStudio.TestTools.UnitTesting;
using KSR.ValidatorHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSR.Product;
using System.ComponentModel.DataAnnotations;

namespace KSR.ValidatorHelper.Tests
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
        public void ObjectNotTypeTest_BulkProductIsAbstractProduct()
        {
            var obj = new MealProduct();
            string message = "Problem";

            ValidationHelper.ObjectNotType<AbstractGood>(obj, message);
        }

        [TestMethod()]
        public void ObjectNotTypeTest_LiquidProductIsAbstractProduct()
        {
            var obj = new Clothes();
            string message = "Problem";

            ValidationHelper.ObjectNotType<AbstractGood>(obj, message);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidCastException))]
        public void ObjectNotTypeTest_StringBuilderCastToAbstractProductCallInvalidCastException()
        {
            var obj = new StringBuilder();
            string message = "Problem";

            ValidationHelper.ObjectNotType<AbstractGood>(obj, message);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidCastException))]
        public void ObjectNotTypeTest_MemberAccessExceptionCastToAbstractProductCallInvalidCastException()
        {
            var obj = new MemberAccessException();
            string message = "Problem";

            ValidationHelper.ObjectNotType<AbstractGood>(obj, message);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidCastException))]
        public void ObjectNotTypeTest_IgnoreAttributeCastToAbstractProductCallInvalidCastException()
        {
            var obj = new IgnoreAttribute();
            string message = "Problem";

            ValidationHelper.ObjectNotType<AbstractGood>(obj, message);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidCastException))]
        public void ObjectNotTypeTest__SerializableAttributeCastToAbstractProductCallInvalidCastException()
        {
            var obj = new SerializableAttribute();
            string message = "Problem";

            ValidationHelper.ObjectNotType<AbstractGood>(obj, message);
        }



        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullStringTest_StringIsEmptyCallArgumentNullException()
        {
            var obj = "";

            ValidationHelper.NullString(obj);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void NullStringTest_StringIsOnlyWhiteSpaceCallArgumentNullException()
        {
            var obj = "    ";

            ValidationHelper.NullString(obj);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullStringTest_StringIsNullCallArgumentNullException()
        {
            string obj = null;

            ValidationHelper.NullString(obj);
        }

        [TestMethod()]
        public void NullStringTest_StringIsNotNull()
        {
            var obj = "dfghjkl;";

            ValidationHelper.NullString(obj);
        }

        [TestMethod()]
        public void NullStringTest_StringIsNotEmpty()
        {
            var obj = "zxfgh nmop";

            ValidationHelper.NullString(obj);
        }




        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NotNullStringTest_StringIsNotWhiteSpaceCallArgumentNullException()
        {
            var obj = "zxfgh nmop";

            ValidationHelper.NotNullString(obj);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NotNullStringTest_StringIsNotNullCallArgumentNullException()
        {
            var obj = "dfghjkl;";

            ValidationHelper.NotNullString(obj);
        }

        [TestMethod()]
        public void NotNullStringTest_StringIsNotNull()
        {
            string obj = null;

            ValidationHelper.NotNullString(obj);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NotNullStringTest_StringIsWhiteSpace()
        {
            var obj = "    ";

            ValidationHelper.NotNullString(obj);
        }

        [TestMethod()]
        public void NotNullStringTest_StringIsEmpty()
        {
            var obj = "";

            ValidationHelper.NotNullString(obj);
        }

        [TestMethod()]
        public void ProductValidationTest_GoodBulkProduct()
        {
            var obj = new MealProduct("Chalk", 1, 1);

            ValidationHelper.ProductValidation(obj);

        }

        [TestMethod()]
        [ExpectedException(typeof(ValidationException))]
        public void ProductValidationTest_BadBulkProductCallValidationException()
        {
            var obj = new MealProduct("Chalk", 1, -891);

            ValidationHelper.ProductValidation(obj);

        }
    }
}