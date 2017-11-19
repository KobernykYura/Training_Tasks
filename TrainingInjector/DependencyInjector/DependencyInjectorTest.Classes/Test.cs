using System;

namespace DependencyInjectorTest.Classes
{
    public class Test : ITest
    {
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field4 { get; set; }

        public Test()
        {
            Field1 = "We are ";
            Field2 = "not live ";
            Field3 = "heare.";
        }
        public Test(string field1) : this()
        {
            Field1 = field1;
        }
        public Test(string field1, string field2) : this(field1)
        {
            Field2 = field2;
        }
        public Test(string field1, string field2, string field3) : this(field1, field2)
        {
            Field3 = field3;
        }

        public string Print()
        {
            return (Field1 + Field2 + Field3);
        }
    }
    
}
