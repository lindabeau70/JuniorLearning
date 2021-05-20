using System;

namespace MethodOverLoadingAndOverriding
{

    class Calulator
    {

        public int Add(int num1, int num2)
        {
            return num1 + num2;
        }


        //method overloading
        public decimal Add(decimal num1, int num2)
        {
            return num1 + num2;
        }

        //method overloading 
        public decimal Add(decimal num1, int num2, int num3)
        {
            return num1 + num2 + num3;
        }




        class Employee
        {
            public decimal Salary;
            public virtual decimal CalculateSalary()
            {
                return Salary;
            }
        
        
            //method overriding
       class SalesEmployee : Employee
        {
            public decimal SalesBonus;
            public override decimal CalculateSalary()
                {
                    return Salary + SalesBonus;
                }
                

                }
            
            }





    }
    class Program
    {
        static void Main(string[] args)
        {
            Calulator cal = new Calulator();
            decimal result = cal.Add(1, 4, 7);


        }
    }
}
