using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagement
{
    public abstract class Transaction
    {
        public DateTime TransactionDatetime { get; } = new DateTime();
        public string TransactionType { get; }

        public Transaction(string type, DateTime dt)
        {
            this.TransactionType = type;
            this.TransactionDatetime = dt;
        }
        public override abstract string ToString();
    }
}
