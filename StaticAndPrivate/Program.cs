using System;

namespace StaticAndPrivate
{
   
    

    public class Example
    {
        private static int Counter;
        private Example()
       {
         Counter = 10;   
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

 


    class Program
    {
        static void Main(string[] args)
        {
            Example ex = new Example(10);
            Console.WriteLine(Example.getCounter());
        }
    }
}
