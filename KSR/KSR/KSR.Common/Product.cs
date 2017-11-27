using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR.Common
{
    public class Product :  IProduct
    {
        public string Name { get; set; }
        public uint Value { get; private set; }
        public int ID { get; private set; }
        public DateTime ReleaseDate { get; set; }

        public Product(string name, uint value, DateTime dateTime)
        {
            this.Name = name;
            this.Value = value;
            this.ReleaseDate = dateTime;
        }

        public Product(string name, uint value, int id, DateTime dateTime) : this(name, value, dateTime)
        {
            this.ID = id;
        }

    }
}
