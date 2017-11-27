using KSR.Common;
using System;
using System.Collections.Generic;

namespace KSR.DataSource
{
    public class Repository : IRepository
    {
        // список покупок
        private readonly List<IProduct> list;

        public Repository()
        {
            this.list = new List<IProduct>();
        }

        // просмотр продукта по id
        public IProduct GetProduct(int id)
        {
            try
            {
                return list.Find(i => i.ID == id);
            }
            catch (ArgumentNullException)
            {

                throw;
            }
        }

        // просмотр продукта по имени
        public IProduct GetProductByName(string name)
        {
            try
            {
                return list.Find(i => i.Name == name);
            }
            catch (ArgumentNullException)
            {

                throw;
            }

        }

        // покупка
        public uint Buy() 
        {
            uint cast = 0;

            for (int i = 0; i < list.Count; i++)
            {
                cast += list[i].Value;
            }

            return cast;
        }

        // получить список купленного
        public IEnumerable<IProduct> GetList(IProduct product)
        {
            return list;
        }

        // добавить покупку
        public void Register(IProduct product)
        {
            list.Add(product);
        }

        //убрать покупку
        public void Unregister(int id)
        {
            try
            {
                list.Remove(GetProduct(id));
            }
            catch (ArgumentOutOfRangeException)
            {
                throw;
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }
    }
}
