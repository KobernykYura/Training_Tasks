using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventReflection;
using System;
using EventReflection.Products;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace EventReflection.Tests
{
    /// <summary>
    /// Testing bouth classes of reflection.
    /// </summary>
    [TestClass()]
    public class EventReflectorTests
    {
        private EventHandler<PriceChangedEventArgs> action;
        private EventHandler func;

        [TestInitialize()]
        public void Initialization()
        {

            action = Action1;       
            action += Action2;            

            func = Function1;        
            func += Function2;       

        }

        [TestMethod()]
        public void CreateInstTest_IgnoreAttribute()
        {
            CreateReflector reflector = new CreateReflector();

            var obj = reflector.Create<IgnoreAttribute>();

            Assert.IsNotNull(obj);
        }
        [TestMethod()]
        [ExpectedException(typeof(MissingMethodException))]
        public void CreateInstTes_ValueType()
        {
            CreateReflector reflector = new CreateReflector();

            var obj = reflector.Create<ValueType>();

            Assert.IsNotNull(obj);
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
        public void GetEventTest_BadPropertyNameBackNullEvent()
        {
            CreateReflector reflector = new CreateReflector();

            var obj = reflector.Create<Product>();
            var eve = obj.GetEvent<Product>("PrizeChanged");

            Assert.IsNull(eve);
        }

        [TestMethod()]
        public void GetEventTest_EmptyNameIsNullProperty()
        {
            CreateReflector reflector = new CreateReflector();

            string name = "";

            var obj = reflector.Create<Product>();
            var eve = obj.GetEvent<Product>(name);

            Assert.IsNull(eve);
        }

        [TestMethod()]
        public void GetPropertyTest_GoodName()
        {
            CreateReflector reflector = new CreateReflector();

            var obj = reflector.Create<Product>();
            var prop = obj.GetProperty<Product>("Price");

            Assert.IsNotNull(prop);
        }

        [TestMethod()]
        public void GetPropertyTest_EmptyNameGetNullPrpterty()
        {
            CreateReflector reflector = new CreateReflector();

            string name = "";

            var obj = reflector.Create<Product>();
            var prop = obj.GetProperty<Product>(name);

            Assert.IsNull(prop);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetPropertyTest_BadNameCallArgumentNullException()
        {
            CreateReflector reflector = new CreateReflector();

            string name = null;

            var obj = reflector.Create<Product>();
            var prop = obj.GetProperty<Product>(name);

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
        public void AddEventHandlerTest()
        {
            CreateReflector reflector = new CreateReflector();

            var obj = reflector.Create<Product>();
            
            obj.GetEvent<Product>("PriceChanged").AddEventHandler(obj, action);

            obj.Price = 10000;

        }

        [TestMethod()]
        public void SetNewValueTest_GoodDecimal()
        {
            CreateReflector reflector = new CreateReflector();

            var obj = reflector.Create<Product>();
            
            obj.GetEvent<Product>("PriceChanged").AddEventHandler(obj, action);
            obj.GetProperty<Product>("Price").SetNewValue(obj, 56);
        }

        [TestMethod()]
        [ExpectedException(typeof(System.Reflection.TargetException))]
        public void SetNewValueTest_BadTargetIsTargetException()
        {
            CreateReflector reflector = new CreateReflector();

            var obj = reflector.Create<Product>();

            obj.GetEvent<Product>("PriceChanged").AddEventHandler(obj, action);
            obj.GetProperty<Product>("Price").SetNewValue(this, 56);

        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException))]
        public void SetNewValueTest_NullPropertyCallNullReferenceException()
        {
            CreateReflector reflector = new CreateReflector();

            var obj = reflector.Create<Product>();

            obj.GetEvent<Product>("PriceChanged").AddEventHandler(obj, action);
            PropertyInfo prop = null; //obj.GetProperty<Product>("Price");
            prop.SetNewValue(obj, 56);

        }

        [TestMethod()]
        [ExpectedException(typeof(System.Reflection.TargetException))]
        public void SetNewValueTest_NullTargetCallTargetException()
        {
            CreateReflector reflector = new CreateReflector();

            var obj = reflector.Create<Product>();

            obj.GetEvent<Product>("PriceChanged").AddEventHandler(obj, action);
            PropertyInfo prop = obj.GetProperty<Product>("Price");
            prop.SetNewValue(null, 56);

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

