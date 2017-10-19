using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1000;
            int[] array = new int[n];
            int[] result;        
            //----Инициализация
            for (int i = 1; i <= array.Length; i++)
            {
                array[i-1] = i;
            }
            //----Сортировка через for() loop
            result = SorterClass.SortAsFor(array);            
            //Вывод результата
            Out(ref result, "Сортировка через for()");

            //----Сортировка через GetEnumerator
            result = SorterClass.SortAsEnumerator(array);
            //Вывод результата
            Out(ref result, "Сортировка через Enumerator");

            //----Сортировка через GetEnumerator2
            result = SorterClass.SortAsEnumerator2(array);
            //Вывод результата
            Out(ref result, "Сортировка через Enumerator и рекурсию");

            //----Сортировка к нормальному виду
            result = SorterClass.SortAsEnumerator2(result);
            //Вывод результата
            Out(ref result, "Сортировка к нормальному виду через рекурсию");
        }
        static void Out(ref int[] list, string title)
        {
            //Вывод результата
            Console.WriteLine("\n----------{0}----------------", title);
            foreach (var item in list)
            {
                Console.Write("| {0} ", item);
            }
            Console.WriteLine("\n----------{0}----------------", title);
            Console.ReadLine();
        }
    }
}
