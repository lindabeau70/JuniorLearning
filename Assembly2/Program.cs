using System;
using AccessModifier;






namespace Assembly2
{
  
    

    public class Assembly2DerivedClass : AssemblyBaseClass 
    {

        public void TestAccess3()
        {
            AssemblyBaseClass objAssOP = new AssemblyBaseClass();
            // Accessible
           // Console.WriteLine(objAssOP.privateVariable);
            //Console.WriteLine(objAssOP.protectedVariable);
           // Console.WriteLine(objAssOP.internalVariable);
           // Console.WriteLine(objAssOP.protectedInternalVariabe);

            // Only public members are available.
            Console.WriteLine(objAssOP.publicVariable);

        }

    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            Assembly2DerivedClass objOth = new Assembly2DerivedClass();

            objOth.TestAccess();


        }
    }
}
