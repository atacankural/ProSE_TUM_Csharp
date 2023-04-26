using System;
using System.Numerics; // required for INumber

namespace Lecture4
{
    // generic class Vector inherits from generic interface IVector along with constraint that 'T' must be a numeric type from INumber<T> 
    public class Vector<T> : IVector<T> where T : INumber<T>
    {
        public int Size { get; set; } = 1;
        public List<T> entries { get; set; } // data structures can also be initialised using 'get' and 'set' in C#

        /*------------------------------- Constructors -------------------------------*/
        public Vector()
        {
            List<T> entryValue = new List<T>(1); // create a new list object with size 1
            entryValue.Add(default(T)); // add default value of INumber types (i.e. 0) to it
            /* Note: you can't assign '0' directly because C# can't implicitly convert values from one type to other
             * due to memory safety features
             * that's why default() function is used here */
            this.entries = entryValue; // store this list object in Vector.entries
        }
        public Vector(T initValue)
        {
            List<T> entryValue = new List<T>(1);
            entryValue.Add(initValue);
            this.entries = entryValue;
        }
        public Vector(T initValue, int vectorSize)
        {
            this.Size = vectorSize;
            List<T> entryValues = new List<T>(vectorSize);
            for (int i = 0; i < vectorSize; i++)
            {
                entryValues.Add(initValue); // same intial value being added to List again and again
            }
            this.entries = entryValues;
        }
        public Vector(T[] initArray)
        {
            this.Size = initArray.Length;
            List<T> entryValues = new List<T>(initArray.Length);
            foreach (var value in initArray)
            {
                entryValues.Add(value); // add values from initArray to List
            }
            this.entries = entryValues;
        }
        public Vector(List<T> values) // takes a List of values as input and initialises Vector.entries with it
        {
            this.Size = values.Count(); // Count() function gives number of elements in a List
            this.entries = values;
        }

        /*--------------------------------- Data Access ---------------------------------*/
        public T GetValue(int i)
        {
            return this.entries[i];
        }
        public bool Exists(T value)
        {
            return this.entries.Contains(value);
        }

        /*----------------------------- Container Modifiers -----------------------------*/
        public void PushBack(T value)
        {
            this.entries.Add(value);
            this.Size++; // don't forget to increment the size of Vector
        }
        public void Delete(int i)
        {
            this.entries.RemoveAt(i); // remove entry from index i
            this.Size--;
        }
        public void SetValue(int i, T value)
        {
            this.entries[i] = value;
        }
        /* Reset() methods use Assign() method defined later in code below
         * Also, notice how constructors are being called so that you don't have to write same code again */
        public void Reset()
        {
            this.Assign(new Vector<T>());
        }
        public void Reset(T initValue)
        {
            this.Assign(new Vector<T>(initValue));
        }
        public void Reset(T initValue, int vectorSize)
        {
            this.Assign(new Vector<T>(initValue, vectorSize));
        }
        public void Reset(T[] initArray)
        {
            this.Assign(new Vector<T>(initArray));
        }
        /*------------------------------ Interface Methods ------------------------------*/
        public bool IsEqual(Vector<T> secondVector)
        {
            if (this.Size != secondVector.Size) // if lengths are different then vectors aren't equal
            {
                return false;
            }
            for (int i = 0; i < secondVector.Size; i++)
            {
                if (!this.entries[i].Equals(secondVector.entries[i])) // if any element is different then vectors aren't equal, notice '!' (negation)
                {
                    return false;
                }
            }
            return true; // returned only if size and all elements are same
        }
        public void Assign(Vector<T> otherVector) // takes a Vector object as input and assigns it to 'this' object 
        {
            this.Size = otherVector.Size;
            this.entries = otherVector.entries;
        }
        public Vector<T> Add(Vector<T> secondVector) // adds two Vectors elementwise
        {
            if (this.Size != secondVector.Size) // first check for Vectors sizes
            {
                Console.WriteLine("Lengths of vectors are different. Can't Add.");
                return new Vector<T>();
            }
            List<T> valuesToAdd = new List<T>(secondVector.Size); // create a List object to store results
            for (int i = 0; i < secondVector.Size; i++)
            {
                valuesToAdd.Add(this.entries[i] + secondVector.entries[i]); // do elementwise addition
            }
            return new Vector<T>(valuesToAdd); // return a Vector object with above values
        }
        public Vector<T> Multiply(Vector<T> secondVector) // multiplies two Vectors elementwise, similar to Add()
        {
            if (this.Size != secondVector.Size)
            {
                Console.WriteLine("Lengths of vectors are different. Can't Multiply.");
                return new Vector<T>();
            }
            List<T> valuesToMultiply = new List<T>(secondVector.Size);
            for (int i = 0; i < secondVector.Size; i++)
            {
                valuesToMultiply.Add(this.entries[i] * secondVector.entries[i]);
            }
            return new Vector<T>(valuesToMultiply);
        }

        /*----------------------------- Operator Overloads -----------------------------*/
        public static Vector<T> operator +(Vector<T> firstVector, Vector<T> secondVector)
        {
            Vector<T> result = firstVector.Add(secondVector); // using Add() function defined above
            return result;
        }
        public static bool operator ==(Vector<T> firstVector, Vector<T> secondVector)
        {
            bool result = firstVector.IsEqual(secondVector); // using IsEqual() function defined above
            return result;
        }
        public static bool operator !=(Vector<T> firstVector, Vector<T> secondVector)
        {
            return !(firstVector == secondVector); // using overloaded '==' from above and just negating it
        }
        public static Vector<T> operator *(Vector<T> firstVector, Vector<T> secondVector)
        {
            Vector<T> result = firstVector.Multiply(secondVector); // using Multiply() function defined above
            return result;
        }
        public T this[int i] // implementation already shown/given in exercise pdf 
        {
            get
            {
                return GetValue(i);
            }
            set
            {
                SetValue(i, value);
            }
        }

        /*------------------------------- Miscellaneous -------------------------------*/
        public T CalculateDotProduct(Vector<T> otherVector)
        {
            // Bonus: try using Multiply() function to achieve similar result
            if (this.Size != otherVector.Size)
            {
                Console.WriteLine("Lengths of vectors are different. Dot-product can't be calculated.");
                return default(T);
            }
            T result = this.entries[0] * otherVector.entries[0];
            /* Important note: 
             * 'T' is still a generic type so you can't initialise a 'T' type variable as '0' and then add values to it
             * Hence, it needs to be defined like above */
            for (int i = 1; i < otherVector.Size; i++)
            {
                result += this.entries[i] * otherVector.entries[i];
            }
            return result;
        }
        public T GetNorm2() // Norm^2 since we can't apply math.sqrt to generic type 'T' 
        {
            // Bonus: you can also use CalculateDotProduct to compute Norm^2
            T result = this.entries[0] * this.entries[0];
            for (int i = 1; i < this.Size; i++)
            {
                result += this.entries[i] * this.entries[i];
            }
            return result;
        }
        public void PrintItem(int i)
        {
            Console.WriteLine("Vector[" + i + "] = " + this.entries[i]);
        }
        public void Print()
        {
            Console.Write("Vector: [");
            foreach (var value in this.entries)
            {
                Console.Write(value + ",");
            }
            Console.WriteLine("]");
        }
    } // Vector<T>
} // Lecture4