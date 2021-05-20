using System;

namespace Destructor
{





    class Example
    {
        public Example()
        {
            Console.WriteLine("Constructor called");
        }

        //destructor
        ~Example()
        {
            Console.WriteLine("destructor called to clean up memory");
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Example ex = new Example();
        }
    }
}
