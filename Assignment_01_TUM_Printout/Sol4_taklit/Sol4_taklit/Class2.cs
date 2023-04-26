using System;
namespace Lecture4
{
    public interface IAddable<T> where T : INumber<T>
    {
        Vector<T> Add(Vector<T> otherVector);
    }
    public interface IMultipliable<T> where T : INumber<T>
    {
        Vector<T> Multiply(Vector<T> otherVector);
    }
    public interface IVector<T> : IAddable<T>, IMultipliable<T> where T : INumber<T> // note: constraints always come in end 
    {
        // interface methods
        bool IsEqual(Vector<T> otherVector);
        void Assign(Vector<T> otherVector);
        T CalculateDotProduct(Vector<T> otherVector);
        T GetNorm2(); // dot-product and norm^2 have same return type as the type of vector
        void Print();
        void PrintItem(int i);
    }
}// Lecture4