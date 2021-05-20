using System;

namespace AccessModifier
{



    public class AssemblyBaseClass
    {

        private string privateVariable = "private";
        protected string protectedVariable = "protected";
        internal string internalVariable = "internal";
        protected internal string protectedInternalVariabe = "protected internal";
        public string publicVariable = "public variable";


        public void TestAccess()
        {

            // Accessible
            Console.WriteLine(privateVariable);
            Console.WriteLine(protectedVariable);
            Console.WriteLine(internalVariable);
            Console.WriteLine(protectedInternalVariabe);
            Console.WriteLine(publicVariable);

        }
          
    }




    public class AssemblyDerivedClass : AssemblyBaseClass
    {
        // Accessible
        public void TestAccess1()
        {

            // Not Accessible
           // Console.WriteLine(privateVariable);

            //Accessible
            Console.WriteLine(protectedVariable);
            Console.WriteLine(internalVariable);
            Console.WriteLine(protectedInternalVariabe);
            Console.WriteLine(publicVariable);

        }
    }





    public class AssemblyOtherClass
    {
        public void TestAccess()
        {
            AssemblyBaseClass objAss = new AssemblyBaseClass();
            
          //  Private & Protected variables are not accessible by any other class
          //  Console.WriteLine(objAss.privateVariable);
          //  Console.WriteLine(objAss.protectedVariable);


            Console.WriteLine(objAss.internalVariable);
            Console.WriteLine(objAss.protectedInternalVariabe);
            Console.WriteLine(objAss.publicVariable);

      
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            //base class accessibility
            AssemblyBaseClass obj = new AssemblyBaseClass();
            obj.TestAccess();


            Console.WriteLine();

            //derived class accessibility
            AssemblyDerivedClass ObjDerived = new AssemblyDerivedClass();
            ObjDerived.TestAccess1();

            Console.WriteLine();

            //derived class can access to base class private property
            ObjDerived.TestAccess();



            Console.ReadKey();


        }
    }
}