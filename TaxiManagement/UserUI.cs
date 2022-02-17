using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagement
{
    public class UserUI
    {
        private RankManager rankMgr;
        private TaxiManager taxiMgr;
        private TransactionManager transactionMgr;

        public UserUI(RankManager rkMgr, TaxiManager txMgr, TransactionManager trMgr)
        {
            rankMgr = rkMgr;
            taxiMgr = txMgr;
            transactionMgr = trMgr;
        }
        public List<string> TaxiDropsFare(int taxiNum, bool pricePaid)
        {
            List<string> msg = new List<string>();
            if (taxiMgr.FindTaxi(taxiNum).Destination.Equals(""))
            {
                msg.Add($"Taxi {taxiNum} has not dropped its fare.");
            }
            else
            {
                taxiMgr.FindTaxi(taxiNum).DropFare(pricePaid);
                if (pricePaid == true)
                {
                    msg.Add($"Taxi {taxiNum} has dropped its fare and the price was paid.");
                }
                else
                {
                    msg.Add($"Taxi {taxiNum} has dropped its fare and the price was not paid.");
                }
                transactionMgr.RecordDrop(taxiNum,pricePaid);
            }
            return msg;
        }
        public List<string> TaxiJoinsRank(int taxiNum, int rankId)
        {
            List<string> msg = new List<string>();
            if (rankMgr.FindRank(rankId) != null)
            {
                if (taxiMgr.FindTaxi(taxiNum) == null)
                {
                    taxiMgr.CreateTaxi(taxiNum);
                }
                if (rankMgr.AddTaxiToRank(taxiMgr.FindTaxi(taxiNum), rankId) == true)
                {
                    msg.Add($"Taxi {taxiNum} has joined rank {rankId}.");
                    transactionMgr.RecordJoin(taxiNum,rankId);
                }
                else
                {
                    msg.Add($"Taxi {taxiNum} has not joined rank {rankId}.");
                }
            }
            return msg;
        }
        public List<string> TaxiLeavesRank(int rankId, string destination, double agreedPrice)
        {
            Taxi t = rankMgr.FrontTaxiInRankTakesFare(rankId, destination, agreedPrice);
            List<string> msg = new List<string>();
            if (t == null)
            {
                msg.Add($"Taxi has not left rank {rankId}.");
            }
            else
            {
                transactionMgr.RecordLeave(rankId, t);
                msg.Add($"Taxi {t.Number} has left rank {rankId} to take a fare to {destination} for £{agreedPrice:N2}.");
            }
            return msg;
        }
        public List<string> ViewFinancialReport()
        {
            List<string> msg = new List<string>();
            double total = 0.00;
            msg.Add("Financial report");
            msg.Add("================");
            if (taxiMgr.GetAllTaxis().Count == 0)
            {
                msg.Add("No taxis, so no money taken");
            }
            else
            {
                foreach (int i in taxiMgr.GetAllTaxis().Keys)
                {
                    Taxi t1 = taxiMgr.GetAllTaxis()[i];
                    if (t1.TotalMoneyPaid == 0)
                    {
                        msg.Add($"Taxi {t1.Number}      0.00");
                    }
                    else if (t1.TotalMoneyPaid > 0)
                    {
                        msg.Add($"Taxi {t1.Number}      {t1.TotalMoneyPaid:N2}");
                        total += t1.TotalMoneyPaid;
                    }
                }
                msg.Add("           ======");
                msg.Add($"Total:       {total:N2}");
                msg.Add("           ======");
            }
            return msg;
        }
        public List<string> ViewTaxiLocations()
        {
            List<string> msg = new List<string>();
            msg.Add("Taxi locations");
            msg.Add("==============");
            if (taxiMgr.GetAllTaxis().Count == 0)
            {
                msg.Add("No taxis");
            }
            else
            {
                foreach (int i in taxiMgr.GetAllTaxis().Keys)
                {
                    Taxi t1 = taxiMgr.GetAllTaxis()[i];
                    if (t1.Location == Taxi.IN_RANK)
                    {
                        msg.Add($"Taxi {t1.Number} is in rank {t1.Rank.Id}");
                    }
                    else if (t1.Location == Taxi.ON_ROAD)
                    {
                        if (t1.Destination.Equals(""))
                        {
                            msg.Add($"Taxi {t1.Number} is on the road");
                        }
                        else
                        {
                            msg.Add($"Taxi {t1.Number} is on the road to {t1.Destination}");
                        }
                    }
                }
            }
            return msg;
        }
        public List<string> ViewTransactionLog()
        {
            List<string> msg = new List<string>();
            msg.Add("Transaction report");
            msg.Add("==================");
            if (transactionMgr.GetAllTransactions().Count == 0)
            {
                msg.Add("No transactions");
            }
            else
            {
                foreach (Transaction t in transactionMgr.GetAllTransactions())
                {
                    msg.Add(t.ToString());
                }
            }
            return msg;
        }
    }
}
