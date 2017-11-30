using Microsoft.VisualStudio.TestTools.UnitTesting;
using KSR.DataSourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSR.Product;

namespace KSR.DataSourse.Tests
{
    [TestClass()]
    public class BasketRepositoryTests
    {
        private BasketRepository _repository;
        private BasketRepository _emptyRepository;

        private List<AbstractProduct> _list;

        [TestInitialize]
        public void Initialisation()
        {
            _repository = new BasketRepository();
            _emptyRepository = new BasketRepository();

            _list = new List<AbstractProduct>
            {
                new BulkProduct("Sofa",2.3,1,100),
                new BulkProduct("Milk",2,1,10),
                new BulkProduct("Stone",12.3,1,230),
                new BulkProduct("Apple",2.3,1,900),
                new BulkProduct("Book",2.3,1,1000)
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
        public void GetProductByNameTest_BadName2()
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
            var name = new BulkProduct("Pizza", 10, 20);

            _repository.Register(name);

            var result = _repository.GetProduct(int.MinValue + 6);

            Assert.IsNotNull(result);
            Assert.AreEqual(name, result);
            Assert.AreEqual(name.Name, result.Name);
        }

        [TestMethod()]
        public void AddTest_AddGoodProduct2()
        {
            var name1 = new BulkProduct("Desk", 45, 200);
            var name2 = new BulkProduct("Desk", 15, 150);

            _repository.Register(name1);
            _repository.Register(name2);

            var result = _repository.GetProduct(int.MinValue + 7);

            Assert.IsNotNull(result);
            Assert.AreEqual(name2, result);
            Assert.AreEqual(name2.Name, result.Name);
        }

        [TestMethod()]
        public void AddTest_AddBadProduct2()
        {
            var name1 = new BulkProduct("Mask", 47, 1200);

            _repository.Register(name1);

            var result = _repository.GetProduct(int.MinValue + 7);

            Assert.IsNotNull(result);
            Assert.AreEqual(name1, result);
            Assert.AreEqual(name1.Name, result.Name);
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

            Assert.AreNotEqual(count1,count2);
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


        [TestMethod()]
        public void GetPriceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetPriceTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetPriceTest2()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetPriceAllTest()
        {
            Assert.Fail();
        }
    }
}