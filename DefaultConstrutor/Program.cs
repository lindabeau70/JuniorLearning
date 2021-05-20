using System;

namespace DefaultConstrutor
{



    class Student
    {
       public int studentID { get; set; }
       public string name { get; set; }
       public string college { get; set; }
       public int phoneNumber { get; set; }

        public Student(int studentID, string name, string college, int phoneNumber)
        {
            this.studentID = studentID;
            this.name = name;
            this.college = college;
            this.phoneNumber = phoneNumber;

        }
    }





  class Program
    {
       
        static void Main(string[] args)
        {

            Student st = new Student(1, "Evan", "IIBIT", 0426747001);
            Console.WriteLine("student Id : {0}, Name : {1}", st.studentID, st.name);
        }
    }




}