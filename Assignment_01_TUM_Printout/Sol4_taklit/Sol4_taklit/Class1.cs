using System;
using System.Collections.Generic; // required for generic data structures, List in our case

namespace Lecture4
{
    class Program
    {
        public static void Main(string[] args)
        {
            /* Note: You can write all these tests as NUnit tests as well */
            // basic constructor tests
            Vector<int> v1 = new Vector<int>(5, 4);
            Vector<int> v2 = new Vector<int>(2, 4);
            Vector<double> v3 = new Vector<double>();

            // miscellaneous function tests
            v1.Print();
            v1.PrintItem(2);
            Console.WriteLine("Dot-Product: " + v2.CalculateDotProduct(v1));
            Console.WriteLine("Norm^2: " + v1.GetNorm2());
            v3.PrintItem(0);

            // container modifier tests
            double[] testArray = { 1.0, 2.3, 3.4, 4.1, 5.0 };
            Vector<double> v4 = new Vector<double>(testArray);
            v4.PushBack(6.7);
            v4.Delete(1);
            v4.Print();
            Console.WriteLine(v4.Exists(2.3));

            // operator overload tests
            Vector<int> v5 = new Vector<int>(5, 4);
            int[] array = { 5, 1, 2, 3 };
            Vector<int> v6 = new Vector<int>(array);
            v6.Print();
            Console.WriteLine("Equality: " + (v5 != v6));

            Vector<int> v7 = v1 * v2;
            Console.Write("Multiply: ");
            v7.Print();
            Vector<int> v8 = v1 + v2;
            Console.Write("Addition: ");
            v8.Print();

            Console.WriteLine("Vector[3] = " + v6[3]);
            v6[3] = 4;
            Console.WriteLine("Vector[3] = " + v6[3]);

            // Assign and Reset tests
            v6.Assign(v8);
            Console.Write("Assign: ");
            v6.Print();
            v6.Reset();
            Console.Write("Resetted: ");
            v6.Print();
        }
    } // Program
} // Lecture4