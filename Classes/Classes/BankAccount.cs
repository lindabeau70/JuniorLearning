using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class BankAccount
    {
        private static int accountNumberSeed = 1234567890;
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance {
            get
            {
                decimal balance = 0;
                foreach(var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            } 
        }

        /// <summary>
        /// Apparently the people writing this tutorial think that the credit limit for an account would never change from 
        /// when the account is opened....  Cannot say that I would make this readonly.
        /// </summary>
        private readonly decimal minimumBalance;

        /// <summary>
        /// Constructor when minimum Balance is not specified.
        /// i.e. Minimum Balance is zero - i.e. not a credit account
        /// Calls the three parameter constructor with minimumBalance set to zero
        /// </summary>
        /// <param name="name">Name of the account</param>
        /// <param name="initialBalance">Opening balance for the account</param>
        public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) { }

        /// <summary>
        /// Constructor when minimum balance is specified
        /// </summary>
        /// <param name="name">Account name</param>
        /// <param name="initialBalance">Opening balance for the account</param>
        /// <param name="minimumBalance">Minimum allowed balance for the account.  
        /// Zero for normal accounts.  Equals credit limit (as negative number) for credit accounts</param>
        public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
        {
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            this.Owner = name;
            this.minimumBalance = minimumBalance;
            if (initialBalance > 0)
            {
                MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
            }
        }

        private List<Transaction> allTransactions = new List<Transaction>();

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note) { 
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            var overdraftTransaction = CheckWithdrawalLimit(Balance - amount < minimumBalance);
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
            if (overdraftTransaction != null)
            {
                allTransactions.Add(overdraftTransaction);
            }
           
        }
        /// <summary>
        /// Checking if transaction falls within the withdrawal limit - throws error if not
        /// Virtual so can be overridden if overdrawn transaction allowed by derived class
        /// </summary>
        /// <param name="isOverdrawn">boolean measure of whether transaction takes balance below minimum balance allowed</param>
        /// <returns>Transaction? - ? indicates may return a null</returns>
        protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
        {
            if (isOverdrawn)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            else
            {
                return default;     // default Transaction would be a null
            }
        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");  // title line
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }

        public virtual void PerformMonthEndTransactions() { }
    }
}
