using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagement
{
    public class Rank
    {
        public int Id { get; private set; }
        private int numberOfTaxiSpaces;
        private List<Taxi> taxiSpace = new List<Taxi>();

        public Rank (int rankId, int numberOfTaxiSpaces)
        {
            this.Id = rankId;
            this.numberOfTaxiSpaces = numberOfTaxiSpaces;
        }
        public bool AddTaxi(Taxi t)
        {
            if (numberOfTaxiSpaces > taxiSpace.Count)
            {
                t.Rank = this;
                taxiSpace.Add(t);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Taxi FrontTaxiTakesFare(string destination, double agreedPrice)
        {
            if (taxiSpace.Count == 0)
            {
                return null;
            }
            else
            {
                Taxi t1 = taxiSpace[0];
                taxiSpace.RemoveAt(0);
                t1.AddFare(destination, agreedPrice);
                return t1;
            }
        }
    }
}
