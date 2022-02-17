using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagement
{
    public class LeaveTransaction : Transaction
    {
        private int taxiNum;
        private int rankId;
        private string destination;
        private double agreedPrice;

        public LeaveTransaction(DateTime transactionDateTime, int rankId, Taxi t) : base(type:"Leave",dt:transactionDateTime)
        {
            this.rankId = rankId;
            taxiNum = t.Number;
            destination = t.Destination;
            agreedPrice = t.CurrentFare;
        }
        public override string ToString()
        {
            return TransactionDatetime.ToString("dd/MM/yyyy HH:mm") + $" Leave     - Taxi {taxiNum} from rank {rankId} to {destination} for £{agreedPrice}";
        }
    }
}
