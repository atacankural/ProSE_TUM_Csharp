using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;


namespace Assignment06
{
    public static class ExtensionMethods
    {
        public static List<int> QuicksortInt(this List<int> list)
        {
            if (list.Count() <= 1)
                return list;

            var pivot = list.First();

            var less = (from item in list where item < pivot select item).ToList();
            var same = (from item in list where item == pivot select item).ToList();
            var greater = (from item in list where item > pivot select item).ToList();

            return (QuicksortInt(less).Concat(same.Concat(QuicksortInt(greater)))).ToList();
        }
        
        public static List<T> QuicksortGeneric<T>(this List<T> list, Comparison<T> comparisonDel)
        {
            if (list.Count() <= 1)
                return list;

            var pivot = list.First();

            var less = (from item in list where comparisonDel(item,pivot).Equals(-1) select item).ToList();
            var same = (from item in list where comparisonDel(item,pivot).Equals(0) select item).ToList();
            var greater = (from item in list where comparisonDel(item, pivot).Equals(1) select item).ToList();

            return (QuicksortGeneric(less, comparisonDel).Concat(same.Concat(QuicksortGeneric(greater, comparisonDel)))).ToList();

        }


        public static void Display<T>(this List<T> list)
        {
            
            foreach (var item in list)
            {
                if (item != null)
                    Console.Write(item +"  ");
                else
                    Console.Write("-null-");
            }
            Console.WriteLine("");

        }


    }

    class Program
    {        

        public static void Main(string[] args)
        {
            //Integer list sorting
            List<int> list = new List<int>() { 6,8,2,5,3,0,1,9,7,4 };
            List<int> sortedList = new List<int>(list.QuicksortInt());

            Console.WriteLine("The original list of int:");
            list.Display();
            Console.WriteLine("The sorted list of int:");
            sortedList.Display();

            

            //Double list sorting
            List<double> list2 = new List<double> { 1.2, 5.3, 7.8, 6.4, 0.8, 6.7 };
            List<double> sortedList2 = new List<double>(ExtensionMethods.QuicksortGeneric(list2, (a, b) => a.CompareTo(b)));
            Console.WriteLine("=========================================");
            Console.WriteLine("The original list of doubles:");
            list2.Display();
            Console.WriteLine("The sorted list of doubles:");
            sortedList2.Display();
        }
    }
}