using System;


namespace FinanceMentor1.Shared
{
    public class Expense
    {
        public Expense()
        {
            ID = Guid.NewGuid();
        }

        public Guid ID { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public ExpenseCategory Category { get; set; }
        public decimal Amount { get; set; }
    }
}
