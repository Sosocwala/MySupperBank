﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySupperBank
{
    public class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance { 
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            } 
        }

        private static int accountNumberSeed = 1234567890;

        private List<Transaction> allTransactions = new List<Transaction>();

        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;

            MakeDiposit(initialBalance, DateTime.Now, "Initial Balance");
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }

        public void MakeDiposit(decimal amount, DateTime date, string note)
        {
            if (amount <=0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "The amount of deposite must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <=0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount),"The amount of withdrawal must be positive");
            }
            if (Balance < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }


    }
}
