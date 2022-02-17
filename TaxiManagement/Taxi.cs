using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagement
{
    public class Taxi
    {
        public static string IN_RANK = "in rank";
        public static string ON_ROAD = "on the road";
        public double CurrentFare { get; private set; }
        public string Destination { get; private set; } = "";
        public string Location { get; private set; } = ON_ROAD;
        public int Number { get; }
        public double TotalMoneyPaid { get; private set; } = 0;
        private Rank rank;
        public Rank Rank {

            get
            {
                return rank;
            }
            set
            {
                if (value == null)
                {
                    throw new Exception("Rank cannot be null");
                }
                else if (!Destination.Equals(""))
                {
                    throw new Exception("Cannot join rank if fare has not been dropped");
                }
                else if (Destination.Equals(""))
                {
                    this.rank = value;
                    this.Location = IN_RANK;
                }
            }
        }

        public Taxi(int taxiNum)
        {
            this.Number = taxiNum;
        }

        public void AddFare(string destination, double agreedPrice)
        {
            Destination = destination;
            CurrentFare = agreedPrice;
            rank = null;
            Location = ON_ROAD;
        }
        public void DropFare(bool priceWasPaid)
        {
            Destination = "";
            if (priceWasPaid == true)
            {
                TotalMoneyPaid += CurrentFare;
            }
            CurrentFare = 0;
            Location = ON_ROAD;
        }
    }
}
