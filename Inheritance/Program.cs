using System;

namespace Inheritance
{
    //base class
    class Vehicle
    {
        string number;
        string owner;
    } 

    //derived class + single level inheritance 
    class Fourwheeler : Vehicle
    {
        string type;

    }
      

    //Multi-level inheritance
    class Car : Fourwheeler
    {
        string colour;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Car c = new Car();
            Console.WriteLine(c);
        }
    }
}
