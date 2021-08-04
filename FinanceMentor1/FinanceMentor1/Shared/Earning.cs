using System;


namespace FinanceMentor1.Shared
{
    public class Earning
    {
        public Earning()
        {
            ID = Guid.NewGuid();
        }

        public Guid ID { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public EarningCategory Category { get; set; }
        public decimal Amount { get; set; }
    }
}
