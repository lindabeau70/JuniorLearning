using System;
using System.Reflection;

namespace Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            TypeInfo typeInfo = typeof(MyClass).GetTypeInfo();
            Console.WriteLine($"The assembly qualified name of MyClass is {typeInfo.AssemblyQualifiedName}");

            var attrs = typeInfo.GetCustomAttributes();
            foreach(var attr in attrs)
            {
                Console.WriteLine("Attribute on MyClass: " + attr.GetType().Name);
            }
        }
    }

    /// <summary>
    /// Yep - example of Obsolete attribute on class
    /// </summary>
    [Obsolete("Example of making a clase obsolete.  Would give details of class that supersedes etc here...")]
    public class MyClass
    {

    }

    /// <summary>
    /// Example of creating own custom attribute
    /// </summary>
    public class MySpecialAttribute : Attribute
    {
        public MySpecialAttribute(string comment)
        {
            // do something
        }
    }

    /// <summary>
    /// Example of custom attribute applied to class
    /// </summary>
    [MySpecial("Here we apply the attribute created to another class")]
    public class SomeOtherClass
    {

    }
}
