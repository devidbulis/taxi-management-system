using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagement
{
    public class TransactionManager
    {
        private List<Transaction> transactions = new List<Transaction>();

        public List<Transaction> GetAllTransactions()
        {
            return transactions;
        }
        public void RecordDrop(int taxiNum, bool pricePaid)
        {
            DateTime now = DateTime.Now;
            DropTransaction dt = new DropTransaction(now, taxiNum, pricePaid);
            transactions.Add(dt);
        }
        public void RecordJoin(int taxiNum, int rankId)
        {
            DateTime now = DateTime.Now;
            JoinTransaction jt = new JoinTransaction(now, taxiNum, rankId);
            transactions.Add(jt);
        }
        public void RecordLeave(int rankId, Taxi t)
        {
            DateTime now = DateTime.Now;
            LeaveTransaction lt = new LeaveTransaction(now, rankId, t);
            transactions.Add(lt);
        }
    }
}
