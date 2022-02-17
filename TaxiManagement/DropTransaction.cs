using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagement
{
    public class DropTransaction : Transaction
    {
        private int taxiNum;
        private bool priceWasPaid;

        public DropTransaction(DateTime transactionDateTime, int taxiNum, bool priceWasPaid) : base(type:"Drop fare",dt:transactionDateTime)
        {
            this.taxiNum = taxiNum;
            this.priceWasPaid = priceWasPaid;
        }
        public override string ToString()
        {
            if (priceWasPaid)
            {
                return TransactionDatetime.ToString("dd/MM/yyyy HH:mm") + $" Drop fare - Taxi {taxiNum}, price was paid";
            }
            else
            {
                return TransactionDatetime.ToString("dd/MM/yyyy HH:mm") + $" Drop fare - Taxi {taxiNum}, price was not paid";
            }
        }
    }
}
