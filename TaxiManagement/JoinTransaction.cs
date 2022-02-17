using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagement
{
    public class JoinTransaction : Transaction
    {
        private int taxiNum;
        private int rankId;

        public JoinTransaction(DateTime transactionDateTime, int taxiNum, int rankId) : base(type:"Join", dt:transactionDateTime)
        {
            this.taxiNum = taxiNum;
            this.rankId = rankId;
        }
        public override string ToString()
        {
            return TransactionDatetime.ToString("dd/MM/yyyy HH:mm") + $" Join      - Taxi {taxiNum} in rank {rankId}";
        }
    }
}
