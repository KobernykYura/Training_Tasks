using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectorTest.Classes
{
    public class TestA : ITest
    {
        public Test ObjTest { get; set; }
        public TestB ObjTestB { get; set; }

        public TestA(Test t)
        {
            ObjTest = t;
        }

        public TestA(TestB t)
        {
            ObjTestB = t;
        }

        public string Print()
        {
            throw new NotImplementedException();
        }
    }
}
