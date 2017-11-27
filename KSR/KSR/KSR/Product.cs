using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR
{
    class Product
    {
        public string Name { get; private set; }
        public uint Value { get; private set; }

        public Product(string name, uint value)
        {
            this.Name = name;
            this.Value = value;
        }

    }
}
