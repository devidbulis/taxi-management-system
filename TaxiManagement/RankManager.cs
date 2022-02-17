using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagement
{
    public class RankManager
    {
        private Dictionary<int, Rank> ranks = new Dictionary<int, Rank>();

        public RankManager()
        {
            Rank r1 = new Rank(1, 5);
            ranks.Add(1, r1);
            Rank r2 = new Rank(2, 2);
            ranks.Add(2, r2);
            Rank r3 = new Rank(3, 4);
            ranks.Add(3, r3);
        }
        public bool AddTaxiToRank(Taxi t, int rankId)
        {
            if (t.Rank == null && ranks.ContainsKey(rankId) && t.Destination.Equals("") && ranks[rankId].AddTaxi(t))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Rank FindRank(int rankId)
        {
            if (ranks.ContainsKey(rankId))
            {
                return ranks[rankId];
            }
            else
            {
                return null;
            }
        }
        public Taxi FrontTaxiInRankTakesFare(int rankId, string destination, double agreedPrice)
        {
            if (!ranks.ContainsKey(rankId))
            {
                return null;
            }
            else
            {
                return ranks[rankId].FrontTaxiTakesFare(destination, agreedPrice);
                
            }
        }
    }
}
