using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagement
{
    public class TaxiManager
    {
        private SortedDictionary<int, Taxi> taxis = new SortedDictionary<int, Taxi>();

        public Taxi CreateTaxi(int taxiNum)
        {
            if (taxis.ContainsKey(taxiNum))
            {
                return taxis[taxiNum];
            }
            else
            {
                Taxi t = new Taxi(taxiNum);
                taxis.Add(taxiNum,t);
                return t;
            }
        }
        public Taxi FindTaxi(int taxiNum)
        {
            if (taxis.ContainsKey(taxiNum))
            {
                return taxis[taxiNum];
            }
            else
            {
                return null;
            }
        }
        public SortedDictionary<int, Taxi> GetAllTaxis()
        {
            return taxis;
        }
    }
}
