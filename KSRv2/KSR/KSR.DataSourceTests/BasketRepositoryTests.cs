using Microsoft.VisualStudio.TestTools.UnitTesting;
using KSR.DataSourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSR.Product;
using KSR.Interfaces;
using System.ComponentModel.DataAnnotations;
using KSR.Exceptions;

namespace KSR.DataSourse.Tests
{
    [TestClass()]
    public class BasketRepositoryTests
    {
        private IRepository<AbstractGood> _repository;
        private IRepository<AbstractGood> _emptyRepository;

        private List<AbstractGood> _list;

        [TestInitialize]
        public void Initialisation()
        {
            _repository = new ShopRepository();
            _emptyRepository = new ShopRepository();

            _list = new List<AbstractGood>
            {
                new MealProduct("Bread",1,100),
                new MealProduct("Milk",1,10),
                new Clothes("T-Shirt",2,200),
                new MealProduct("Apple",1,27),
                new MealProduct("Butter",3,100)
            };

            foreach (var item in _list)
            {
                _repository.Register(item);
            }
        }

        #region ---------------------------- GetProduct(id)-------------------------------
        [TestMethod()]
        public void GetProductTest_ByGoodId()
        {
            int id = int.MinValue + 2;
            var obj = _repository.GetProduct(id);
            Assert.IsNotNull(obj);
        }

        [TestMethod()]
        public void GetProductTest_ByGoodId2()
        {
            int id = int.MinValue + 3;
            var obj = _repository.GetProduct(id);
            Assert.IsNotNull(obj);
        }

        [TestMethod()]
        public void GetProductTest_ByBadId()
        {
            int id = int.MaxValue - 2;
            var obj = _repository.GetProduct(id);
            Assert.IsNull(obj);
        }

        [TestMethod()]
        public void GetProductTest_ByBadId2()
        {
            int id = 100;
            var obj = _repository.GetProduct(id);
            Assert.IsNull(obj);
        }
        #endregion

        #region ------------------------GetProduct(name)--------------------------------
        [TestMethod()]
        public void GetProductByNameTest_GoodName()
        {
            string name = "Milk";
            var obj = _repository.GetProductByName(name);
            Assert.IsNotNull(obj);
        }
        [TestMethod()]
        public void GetProductByNameTest_GoodName2()
        {
            string name = "Apple";
            var obj = _repository.GetProductByName(name);
            Assert.IsNotNull(obj);
        }
        [TestMethod()]
        public void GetProductByNameTest_BadName()
        {
            string name = "chjkl;";
            var obj = _repository.GetProductByName(name);
            Assert.IsNull(obj);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void GetProductByNameTest_BadNameCallArgumentException()
        {
            string name = " ";
            var obj = _repository.GetProductByName(name);
            Assert.IsNull(obj);
        }


        #endregion

        #region ----------------------GetShopList-----------------------------
        [TestMethod()]
        public void GetShopListTest_FullList()
        {
            var obj = _repository.GetShopList();
            Assert.IsNotNull(obj);
        }

        public void GetShopListTest_EmptyList()
        {
            var obj = _emptyRepository.GetShopList();
            Assert.IsNull(obj);
        }

        #endregion

        #region ---------------------Add()------------------------------
        [TestMethod()]
        public void AddTest_AddGoodProduct()
        {
            var name = new MealProduct("Pizza", 10, 20);

            _repository.Register(name);

            var result = _repository.GetProduct(int.MinValue + 5);

            Assert.IsNotNull(result);
            Assert.AreEqual(name, result);
            Assert.AreEqual(name.Name, result.Name);
        }

        [TestMethod()]
        public void AddTest_AddGoodProduct2()
        {
            var name1 = new MealProduct("Desk", 45, 200);
            var name2 = new MealProduct("Jogurt", 15, 150);

            _repository.Register(name1);
            _repository.Register(name2);

            var result = _repository.GetProduct(int.MinValue + 6);

            Assert.IsNotNull(result);
            Assert.AreEqual(name2, result);
            Assert.AreEqual(name2.Name, result.Name);
        }

        [TestMethod()]
        [ExpectedException(typeof(ValidationException))]
        public void AddTest_AddBadProduct()
        {
            var name1 = new MealProduct("Mask", 5, -1200);

            _repository.Register(name1);

        }
        [TestMethod()]
        [ExpectedException(typeof(ValidationException))]
        public void AddTest_AddBadProduct2()
        {
            var name1 = new MealProduct("Mask", 1, -56);

            _repository.Register(name1);

        }

        #endregion

        #region -----------------Remove()-----------------------
        [TestMethod()]
        public void RemoveTest_GoodID()
        {
            int id = int.MinValue + 2;

            var count1 = _repository.GetShopList().Count();

            _repository.Unregister(id);

            var count2 = _repository.GetShopList().Count();

            Assert.AreNotEqual(count1, count2);
        }

        [TestMethod()]
        public void RemoveTestGoodID2()
        {
            int id = int.MinValue + 1;
            var count1 = _repository.GetShopList().Count();

            _repository.Unregister(id);

            var count2 = _repository.GetShopList().Count();

            Assert.AreNotEqual(count1, count2);
        }

        [TestMethod()]
        public void RemoveTest_BadID()
        {
            int id = 40;
            var count1 = _repository.GetShopList().Count();

            _repository.Unregister(id);

            var count2 = _repository.GetShopList().Count();

            Assert.AreEqual(count1, count2);
        }

        [TestMethod()]
        public void RemoveTest_BadID2()
        {
            int id = -23;
            var count1 = _repository.GetShopList().Count();

            _repository.Unregister(id);

            var count2 = _repository.GetShopList().Count();

            Assert.AreEqual(count1, count2);
        }

        #endregion

        #region -----------MakePurchase(one product and many)----------------
        [TestMethod()]
        public void MakePurchaseTest_GoodBuyOneProduct()
        {
            var name1 = new MealProduct("Toast", 1, 1200);

            _repository.Register(name1);

            var cast = _repository.MakePurchase(name1);

            Assert.AreEqual(name1.Price, cast);
        }

        [TestMethod()]
        public void MakePurchaseTest_GoodBuyOneProduct2()
        {
            var name1 = new MealProduct("Oil", 1, 100);

            _repository.Register(name1);

            var cast = _repository.MakePurchase(name1);

            Assert.AreEqual(name1.Price, cast);
        }

        [TestMethod()]
        public void MakePurchaseTest_GoodBuyManyProducts()
        {
            var cast = _repository.MakePurchases(_list);
            decimal price = 0;

            foreach (var item in _list)
            {
                price += item.Price;
            }

            Assert.AreEqual(price, cast);
        }

        [TestMethod()]
        public void MakePurchaseTest_GoodBuyManyProducts2()
        {
            var prod1 = new MealProduct("Fish", 2, 34);
            var prod2 = new MealProduct("Toast", 3, 100);

            _repository.Register(prod1);
            _repository.Register(prod2);

            IEnumerable<AbstractGood> abstractProduct = new List<AbstractGood>
            {
                prod1,
                prod2,
            };

            var cast = _repository.MakePurchases(abstractProduct);

            Assert.AreEqual(134, cast);
        }

        [TestMethod()]
        [ExpectedException(typeof(IDException))]
        public void MakePurchaseTest_BadBuyOneProductCallIDException()
        {
            var name1 = new MealProduct("Butter", 1, 30);
            var prod2 = new Clothes("White jeans", 2, 150);

            _repository.Register(name1);

            var cast = _repository.MakePurchase(prod2);
        }

        [TestMethod()]
        [ExpectedException(typeof(IDException))]
        public void MakePurchaseTest_BadBuyOneProductCallIDException2()
        {
            var name1 = new MealProduct("Bread", 5, 90);
            var prod2 = new MealProduct("Cucumber", 1, 60);

            _repository.Register(name1);

            var cast = _repository.MakePurchase(prod2);
        }

        [TestMethod()]
        [ExpectedException(typeof(IDException))]
        public void MakePurchaseTest_BadBuyManyProducts()
        {
            var prod1 = new MealProduct("Fish", 2, 34);
            var prod3 = new MealProduct("Meat", 5, 210);
            var prod4 = new MealProduct("Toast", 3, 100);

            _repository.Register(prod1);

            IEnumerable<AbstractGood> abstractProduct = new List<AbstractGood>
            {
                prod4,
                prod3
            };

            var cast = _repository.MakePurchases(abstractProduct);

        }

        [TestMethod()]
        [ExpectedException(typeof(IDException))]
        public void MakePurchaseTest_BadBuyManyProducts2()
        {
            var prod1 = new MealProduct("Fish", 2, 34);
            var prod3 = new MealProduct("Meat", 5, 210);
            var prod4 = new MealProduct("Toast", 3, 100);

            _repository.Register(prod1);

            IEnumerable<AbstractGood> abstractProduct = new List<AbstractGood>
            {
                prod4,
                prod3
            };

            var cast = _repository.MakePurchases(abstractProduct);
        }


        #endregion

        [TestMethod()]
        public void UpdateTest_GoodUpdateReturnTrue()
        {
            var prod1 = new MealProduct("Fish", 2, 34);
            var prod3 = new MealProduct("Meat", 5, 210);

            _repository.Register(prod1);
            _repository.Register(prod3);

            var prod4 = new MealProduct("Toast", 3, 100);
            prod4.ID = prod3.ID;

            var b = _repository.Update(prod4);

            Assert.IsTrue(b);
        }

        [TestMethod()]
        public void UpdateTest_GoodUpdateReturnTrue2()
        {
            var prod1 = new MealProduct("Fish", 2, 34);
            var prod3 = new MealProduct("Toast", 3, 100);

            _repository.Register(prod1);
            _repository.Register(prod3);

            var prod4 = new MealProduct("Meat", 5, 210);
            prod4.ID = prod3.ID;

            var b = _repository.Update(prod4);

            Assert.IsTrue(b);
        }

        [TestMethod()]
        public void UpdateTest_BabUpdateReturnFalse()
        {
            var prod1 = new MealProduct("Fish", 2, 34);
            var prod3 = new MealProduct("Toast", 3, 100);

            _repository.Register(prod1);
            _repository.Register(prod3);

            var prod4 = new MealProduct("Meat", 5, 210);

            prod4.ID = 3423;

            var b = _repository.Update(prod4);

            Assert.IsFalse(b);
        }

        [TestMethod()]
        public void UpdateTest_BabUpdateReturnFalse2()
        {
            var prod1 = new MealProduct("Fish", 2, 34);
            var prod3 = new MealProduct("Toast", 3, 100);

            _repository.Register(prod1);
            _repository.Register(prod3);

            var prod4 = new MealProduct("Meat", 5, 210);

            prod4.ID = -458;

            var b = _repository.Update(prod4);

            Assert.IsFalse(b);
        }
    }
}