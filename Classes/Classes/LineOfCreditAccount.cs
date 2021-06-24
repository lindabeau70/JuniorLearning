using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class LineOfCreditAccount : BankAccount
    {
        public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit) { }

        public override void PerformMonthEndTransactions()
        {
            if (Balance < 0)
            {
                // Negate the balance to get a positive interest charge:
                var interest = -Balance * 0.07m;
                MakeWithdrawal(interest, DateTime.Now, "Charge monthly interest");
            }
        }

        /// <summary>
        /// Overrides the base method to allow a withdrawal transaction to overdraw account
        /// But charges a fee of $20 for each overdrawn transaction and creates the 
        /// corresponding transaction for the fee
        /// </summary>
        /// <param name="isOverdrawn">boolean indicator of if transaction takes the account below minimum balance</param>
        /// <returns>Transaction? - the ? indicates can be null - if not overdrawn the default return is null</returns>
        protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn) =>
            isOverdrawn ? new Transaction(-20, DateTime.Now, "Apply overdraft fee") : default;
        
    }
}
