using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventReflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventReflection.Products;
using System.Reflection;

namespace EventReflection.Tests
{
    [TestClass()]
    public class StaticReflectorTests
    {
        private EventHandler<PriceChangedEventArgs> action;
        private EventHandler func;

        [TestInitialize()]
        public void Initialization()
        {
            
            action = Action1;       //() => { System.Diagnostics.Debug.WriteLine(helloOutPut); };
            action += Action2;              //() => { System.Diagnostics.Debug.WriteLine(helloOut); };

            func = Function1;        //(decimal i) => { System.Diagnostics.Debug.WriteLine(helloOutPut); };
            func += Function2;        //(decimal i) => { System.Diagnostics.Debug.WriteLine(helloOut); };

        }

        [TestMethod()]
        public void GetEventTest_GoodPropertyName()
        {
            CreateReflector reflector = new CreateReflector();

            var obj = reflector.Create<Product>();
            var eve = obj.GetEvent<Product>("PriceChanged");

            Assert.IsNotNull(eve);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetEventTest_NullObjectNullReferenceException()
        {
            CreateReflector reflector = new CreateReflector();

            object obj = null;
            var eve = obj.GetEvent<Product>("Event");

        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetEventTest_NullNameArgumentNullException()
        {
            CreateReflector reflector = new CreateReflector();

            string name = null;

            var obj = reflector.Create<Product>();
            var eve = obj.GetEvent<Product>(name);

        }

        [TestMethod()]
        public void GetPropertyTest_GoodNameBackProperty()
        {
            CreateReflector reflector = new CreateReflector();

            var prop = reflector.Create<Product>().GetProperty<Product>("Price");

            Assert.IsNotNull(prop);
        }

        [TestMethod()]
        public void GetPropertyTest_BadNameBackNullProperty()
        {
            CreateReflector reflector = new CreateReflector();

            var prop = reflector.Create<Product>().GetProperty<Product>("Priice");

            Assert.IsNull(prop);
        }

        [TestMethod()]
        public void GetPropertyTest_EmptyNameGetNullPrpterty()
        {
            CreateReflector reflector = new CreateReflector();

            string name = "";

            var prop = reflector.Create<Product>().GetProperty<Product>(name);

            Assert.IsNull(prop);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetPropertyTest_BadNameCallArgumentNullException()
        {
            CreateReflector reflector = new CreateReflector();

            string name = null;

            var prop = reflector.Create<Product>().GetProperty<Product>(name);

            Assert.IsNotNull(prop);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetPropertyTest_NullObjectCallNullReferenceException()
        {
            CreateReflector reflector = new CreateReflector();

            object obj = null;
            var prop = obj.GetProperty<Product>("Price");

            Assert.IsNotNull(prop);
        }

        [TestMethod()]
        public void AddEventHandlerTest_AddGoodDelegate()
        {
            CreateReflector reflector = new CreateReflector();

            var obj = reflector.Create<Product>();

            obj.GetEvent<Product>("PriceChanged").AddToEventHandler(obj, action);

            obj.Price = 10000;
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void AddEventHandlerTest_NullObjectNullReferenceException()
        {
            CreateReflector reflector = new CreateReflector();

            object obj = null;

            obj.GetEvent<Product>("PriceChanged").AddToEventHandler(obj, action);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void AddEventHandlerTest_BadEventCallNullReferenceException()
        {
            CreateReflector reflector = new CreateReflector();

            var obj = reflector.Create<Product>();

            obj.GetEvent<Product>("PriceChhanged").AddToEventHandler(obj, action);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void AddEventHandlerTest_FunctionCallArgumentException()
        {
            CreateReflector reflector = new CreateReflector();

            var obj = reflector.Create<Product>();

            obj.GetEvent<Product>("PriceChanged").AddToEventHandler(obj, func);
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void SetNewValueTest_NullPropertyCallNullReferenceException()
        {
            CreateReflector reflector = new CreateReflector();

            var obj = reflector.Create<Product>();

            obj.GetEvent<Product>("PriceChanged").AddToEventHandler(obj, action);
            PropertyInfo prop = null; //obj.GetProperty<Product>("Price");
            prop.SetNewValue(obj, 56);

        }

        [TestMethod()]
        [ExpectedException(typeof(System.Reflection.TargetException))]
        public void SetNewValueTest_BadObjectTargetCallTargetException()
        {
            CreateReflector reflector = new CreateReflector();

            var obj = reflector.Create<Product>();

            var eve = obj.GetEvent<Product>("PriceChanged");
                eve.AddToEventHandler(obj, action);
            PropertyInfo prop = obj.GetProperty<Product>("Price");
            prop.SetNewValue(new object(), 56);

        }

        public void Action1(object obj, PriceChangedEventArgs write)
        {
            Product prodt = obj as Product;
            System.Diagnostics.Debug.WriteLine($"Name: {prodt.Name} Price: {write.LastPrice}");
        }

        public void Action2(object obj, PriceChangedEventArgs write)
        {
            Product prodt = obj as Product;
            System.Diagnostics.Debug.WriteLine($"Name: {prodt.Name} Price: {write.LastPrice}");
        }

        public void Function1(object obj, EventArgs write)
        {
            Product prodt = obj as Product;
            System.Diagnostics.Debug.WriteLine($"Name: {prodt.Name}");
        }

        public void Function2(object obj, EventArgs write)
        {
            Product prodt = obj as Product;
            System.Diagnostics.Debug.WriteLine($"Name: {prodt.Name}");
        }

    }
}