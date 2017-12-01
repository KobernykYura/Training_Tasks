using Microsoft.VisualStudio.TestTools.UnitTesting;
using KSR.Service;
using KSR.Product;
using KSR.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using KSR.Exceptions;

namespace KSR.Service.Tests
{
    [TestClass()]
    public class ServiceTests
    {
        private decimal _bigPrice;
        private AbstractGood _good;
        private IEnumerable<AbstractGood> _goodsList;
        private Mock<IRepository<AbstractGood>> _repositoryMoq;

        [TestInitialize]
        public void Initialize() //---- moq initializer.
        {
            _good = new MealProduct("Milk", 2, 100);

            _goodsList = new List<AbstractGood>
            {
                new Clothes("C1",2,23),
                new MealProduct("C2",1,1123),
                new Clothes("C3",7,213)
            };

            _bigPrice = 0;
            _goodsList.ToList<AbstractGood>().ForEach(i => _bigPrice += i.Price);

            _repositoryMoq = new Mock<IRepository<AbstractGood>>();

            //---- setup result of register product _repositoryMoq.Register() in repository.
            _repositoryMoq.Setup(r => r.Register(It.IsAny<AbstractGood>()))
                .Callback<AbstractGood>(u => u.ID = int.MinValue);

            //---- setup result of unregister product _repositoryMoq.Register() in repository.
            _repositoryMoq.Setup(r => r.Unregister(It.IsAny<int>()))
                .Callback(() => _good = null);

            //---- setup result of update product _repositoryMoq.Update() in repository.
            _repositoryMoq.Setup(r => r.Update(It.IsAny<AbstractGood>()))
                .Callback(() => _good = new MealProduct("Cheese", 5, 100) { ID = _good.ID });

            //---- setup result of _repositoryMoq.GetProduct(int id) call.
            _repositoryMoq.Setup(r => r.GetProduct(It.IsAny<int>()))
                .Returns(_good);

            //---- setup result of _repositoryMoq.GetProductByName(string name) call.
            _repositoryMoq.Setup(r => r.GetProductByName(It.IsAny<string>()))
                .Returns(_good);

            //---- setup result of _repositoryMoq.GetShopList(string name) call.
            _repositoryMoq.Setup(r => r.GetShopList())
                .Returns(_goodsList);

            //---- setup result of _repositoryMoq.GetShopList(string name) call.
            _repositoryMoq.Setup(r => r.MakePurchase(It.IsAny<AbstractGood>()))
                .Returns(_good.Price);

            //---- setup changing user as null in _repositoryMoq.Delete() method.
            _repositoryMoq.Setup(r => r.MakePurchases(It.IsAny<IEnumerable<AbstractGood>>()))
                .Callback(() => _goodsList = null)
                .Returns(_bigPrice);
        }

        //---------------------Register tests()

        [TestMethod()]
        public void RegisterTest_WithCorrectInput()
        {
            var service = new Service(_repositoryMoq.Object);
            service.Register(_good);

            int idExp = int.MinValue;
            int idAct = _good.ID;


            Assert.AreEqual(idExp, idExp); //---- as Stub test

            _repositoryMoq
                .Verify(r => r.Register(It.IsAny<AbstractGood>()), () => Times.AtLeastOnce()); //---- as Moq test
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RegisterTest_NullObjectCallArgumentNullException()
        {
            var service = new Service(_repositoryMoq.Object);
            service.Register(null);

        }

        [TestMethod()]
        [ExpectedException(typeof(ValidationException))]
        public void RegisterTest_BadObjectCallValidationException()
        {
            var service = new Service(_repositoryMoq.Object);
            service.Register(new Clothes("T-Shirt", 2, -100));

        }


        //----------------------GetProductTests()

        [TestMethod()]
        public void GetProductTest_GoodId()
        {
            var service = new Service(_repositoryMoq.Object);
            var result = service.GetProduct(_good.ID);

            Assert.IsNotNull(result); //---- as Stub test
            _repositoryMoq
                .Verify(r => r.GetProduct(It.IsAny<int>()), () => Times.Once());  //---- as Moq test
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetProductTest_BadIdCallArgumentNullException()
        {
            //---- setup null back from repository.
            _repositoryMoq.Setup(r => r.GetProduct(It.IsAny<int>()))
                .Returns((AbstractGood)null);

            var service = new Service(_repositoryMoq.Object);
            var result = service.GetProduct(_good.ID);

        }

        [TestMethod()]
        [ExpectedException(typeof(ConnectionException))]
        public void GetProductTest_ConnectionFailCallConnectionException()
        {
            //---- setup exception call from repository.
            _repositoryMoq.Setup(r => r.GetProduct(It.IsAny<int>()))
                .Throws<ConnectionException>();

            var service = new Service(_repositoryMoq.Object);
            var result = service.GetProduct(_good.ID);

        }


        // ------------------GetProductByNameTest()

        [TestMethod()]
        public void GetProductByNameTest_GoodName()
        {
            var service = new Service(_repositoryMoq.Object);
            var result = service.GetProductByName(_good.Name);

            Assert.AreEqual(_good, result);

            _repositoryMoq
                .Verify(r => r.GetProductByName(It.IsAny<string>()), () => Times.AtLeastOnce()); //---- as Moq test
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetProductByNameTest_NullNameCallArgumentNullException()
        {
            var service = new Service(_repositoryMoq.Object);
            var result = service.GetProductByName(null);

            Assert.AreEqual(_good, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(ConnectionException))]
        public void GetProductByNameTest_ConnectionFailCallConnectionException()
        {
            //---- setup exception call from repository.
            _repositoryMoq.Setup(r => r.GetProductByName(It.IsAny<string>()))
                .Throws<ConnectionException>();

            var service = new Service(_repositoryMoq.Object);
            var result = service.GetProductByName(_good.Name);
        }


        // -------------------UnregisterTest()

        [TestMethod()]
        public void UnregisterTest_GoodID()
        {
            var service = new Service(_repositoryMoq.Object);
            service.Unregister(_good.ID);

            Assert.IsNull(_good);

            _repositoryMoq
                .Verify(r => r.Unregister(It.IsAny<int>()), () => Times.AtLeastOnce()); //---- as Moq test
        }

        [TestMethod()]
        [ExpectedException(typeof(IDException))]
        public void UnregisterTest_BadId()
        {
            //---- setup exception call from repository.
            _repositoryMoq.Setup(r => r.GetProduct(It.IsAny<int>()))
                .Returns((AbstractGood)null);

            var service = new Service(_repositoryMoq.Object);
            service.Unregister(_good.ID);
        }

        [TestMethod()]
        [ExpectedException(typeof(ConnectionException))]
        public void UnregisterTest_ConnectionFailCallConnectionException()
        {
            //---- setup exception call from repository.
            _repositoryMoq.Setup(r => r.GetProduct(It.IsAny<int>()))
                .Throws<ConnectionException>();

            var service = new Service(_repositoryMoq.Object);
            service.Unregister(_good.ID);
        }


        // -------------------BuyTest(product)

        [TestMethod()]
        public void MakePurchaseTest_GoodObjectBackSumm()
        {
            var service = new Service(_repositoryMoq.Object);
            var res = service.Purchase(_good);

            Assert.AreEqual(_good.Price, res);

            _repositoryMoq
                .Verify(r => r.MakePurchase(It.IsAny<AbstractGood>()), () => Times.AtLeastOnce()); //---- as Moq test
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidationException))]
        public void MakePurchaseTest_BadObjectThrowValidationException()
        {
            var service = new Service(_repositoryMoq.Object);
            var res = service.Purchase(new Clothes("Jeanse", 3, -700));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MakePurchaseTest_BadObjectThrowArgumentNullException()
        {
            var service = new Service(_repositoryMoq.Object);
            var res = service.Purchase((AbstractGood)null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ConnectionException))]
        public void MakePurchaseTest_BadObjectThrowConnectionException()
        {
            //---- setup exception call from repository.
            _repositoryMoq.Setup(r => r.MakePurchase(It.IsAny<AbstractGood>()))
                .Throws<ConnectionException>();

            var service = new Service(_repositoryMoq.Object);
            var res = service.Purchase(_good);
        }


        // -------------------BuyTest(IEnumerable)

        [TestMethod()]
        public void MakePurchaseTest_EnumerableProductsSumm()
        {
            var service = new Service(_repositoryMoq.Object);
            var res = service.Purchase(_goodsList);

            Assert.AreEqual(_bigPrice, res);

            _repositoryMoq
                .Verify(r => r.MakePurchases(It.IsAny<IEnumerable<AbstractGood>>()), () => Times.AtLeastOnce()); //---- as Moq test
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidationException))]
        public void MakePurchaseTest_BadEmptyListThrowValidationException()
        {
            var list = new List<AbstractGood>
            {
                new Clothes("T-Shirt", 2, -100),
                new Clothes("Shoes", 6, 60),
                new Clothes("Shirt", 2, -1)
            };

            var service = new Service(_repositoryMoq.Object);
            var res = service.Purchase(list);

        }

        [TestMethod()]
        [ExpectedException(typeof(ConnectionException))]
        public void MakePurchaseTest_BadEmptyListThrowConnectionException()
        {
            //---- setup exception call from repository.
            _repositoryMoq.Setup(r => r.MakePurchases(It.IsAny<IEnumerable<AbstractGood>>()))
                .Throws<ConnectionException>();

            var list = new List<AbstractGood>
            {
                new Clothes("T-Shirt", 2, 100),
                new Clothes("Shoes", 6, 60),
                new Clothes("Shirt", 2, 1)
            };

            var service = new Service(_repositoryMoq.Object);
            var res = service.Purchase(list);

        }


        // -------------------GetListTest()

        [TestMethod()]
        public void GetListTest_GiveGoodList()
        {
            var service = new Service(_repositoryMoq.Object);
            var res = service.GetList();

            Assert.AreEqual(_goodsList, res);

            _repositoryMoq
                .Verify(r => r.GetShopList(), () => Times.AtLeastOnce()); //---- as Moq test
        }

        [TestMethod()]
        [ExpectedException(typeof(ConnectionException))]
        public void GetListTest_ThrowConnectionException()
        {
            //---- setup exception call from repository.
            _repositoryMoq.Setup(r => r.GetShopList())
                .Throws<ConnectionException>();

            var service = new Service(_repositoryMoq.Object);
            var res = service.GetList();
        }


        // -------------------UpdateTest()

        [TestMethod()]
        public void UpdateTest_GoodUpdateCloth()
        {

            var obj = new Clothes(_good.Name, _good.Amount, _good.Price) { ID = _good.ID };

            var service = new Service(_repositoryMoq.Object);
            service.Update(_good);

            Assert.AreNotEqual(_good.Name, obj.Name);

            _repositoryMoq
                .Verify(r => r.Update(It.IsAny<AbstractGood>()), () => Times.AtLeastOnce()); //---- as Moq test
        }

        [TestMethod()]
        public void UpdateTest_GoodUpdateMealProduct()
        {

            var obj = new MealProduct(_good.Name, _good.Amount, _good.Price) { ID = _good.ID };

            var service = new Service(_repositoryMoq.Object);
            service.Update(_good);

            Assert.AreNotEqual(_good.Name, obj.Name);

            _repositoryMoq
                .Verify(r => r.Update(It.IsAny<AbstractGood>()), () => Times.AtLeastOnce()); //---- as Moq test
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateTest_NullObjectThrowArgumentNullException()
        {
            var service = new Service(_repositoryMoq.Object);
            service.Update(null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidationException))]
        public void UpdateTest_BadObjectThrowValidationException()
        {
            var service = new Service(_repositoryMoq.Object);
            service.Update(new MealProduct("", 45, -4));
        }

        [TestMethod()]
        [ExpectedException(typeof(ConnectionException))]
        public void UpdateTest_ThrowConnectionException()
        {
            //---- setup exception call from repository.
            _repositoryMoq.Setup(r => r.Update(It.IsAny<AbstractGood>()))
                    .Throws<ConnectionException>();

            var service = new Service(_repositoryMoq.Object);
            service.Update(_good);
        }



    }
}
