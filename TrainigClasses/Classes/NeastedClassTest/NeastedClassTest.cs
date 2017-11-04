using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NestedClass;

namespace NeastedClassTest
{
    [TestClass]
    public class NeastedClassTest
    {
        /// <summary>
        /// Testing method of adding element to linked list. 
        /// </summary>
        [TestMethod]
        public void AddTest()
        {
            NodeList<int> list = new NodeList<int>();

            int[] numbers = new int[3] { 34, 14, 54 };

            // Adding elements to nodelist
            int i;
            for (i = 0; i < numbers.Length; i++)
            {
                list.Add(numbers[i]);
            }

            Assert.IsNotNull(list);

            // Check if elements are similar
            i = 0;
            foreach (var item in list)
            {
                Assert.AreEqual(numbers[i++], item);
            }

        }/// <summary>
        /// Testing method of adding element to linked list. 
        /// </summary>
        [TestMethod]
        public void RemoveTest()
        {
            NodeList<int> list = new NodeList<int>();

            int[] numbers = new int[3] { 34, 14, 54 };

            // Adding elements to nodelist
            for (int i = 0; i < numbers.Length; i++)
            {
                list.Add(numbers[i]);
            }

            // Check if list is not null
            Assert.IsNotNull(list);

            // Removeing data from list
            for (int i = 0; i < numbers.Length; i++)
            {
                list.Remove(numbers[i]);
            }
            // Check if list is null
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
        }
    }
}
