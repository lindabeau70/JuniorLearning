using System;

namespace ComplelyNewProject
{

    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }


        //methods 
        public void ShowDetails()
        {
            Console.WriteLine("Show Student details: ");
            Console.WriteLine("StudentId : {0}, Name:{1}, Address:{2}", StudentId, Name, Address);


        }

    }



    class Program
    {
        static void Main(string[] args)
        {
            Student st = new Student();
            st.StudentId = 1;
            st.Name = "Evan";
            st.Address = "Sydney";
            

            //calling method
            st.ShowDetails();    
            //stop console from auto shut
            Console.ReadKey();   
        }
    }
}
