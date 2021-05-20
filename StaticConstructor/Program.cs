using System;

namespace StaticConstructor
{
    class Program
    {



        public class Example
        {
            private static int Counter;
            private Example()
            {
                Counter = 10;
            }


            static Example()
            {
                Counter = 20;
            }

            public Example(int counter)
            {
                Counter = Counter + counter;
            }
            public static int getCounter()
            {

                return Counter;
            }
        }
        static void Main(string[] args)
        {

            Example ex = new Example(50);
            Console.WriteLine(Example.getCounter());
        }
    }
}
