using System;
using System.Collections.Generic;

namespace TaxiManagement
{
    public class Program
    {
        private static UserUI ui;
        static void Main(string[] args)
        {
            RankManager rm = new RankManager();
            TaxiManager txm = new TaxiManager();
            TransactionManager trm = new TransactionManager();
            ui = new UserUI(rm, txm, trm);

            DisplayMenu();
        }
        private static void DisplayMenu()
        {
            int menu = -1;
            while (menu != 0)
            {
                Console.WriteLine("\n" + "*** Taxi management system ***" + "\n");
                Console.WriteLine("Menu:" + "\n" +
                    "1| Taxi joins a rank" + "\n" +
                    "2| Taxi leaves a rank" + "\n" +
                    "3| Taxi drops a fare" + "\n" +
                    "4| Financial report" + "\n" +
                    "5| Display transaction log" + "\n" +
                    "6| Report taxi locations" + "\n" +
                    "0| Exit" + "\n");
                Console.Write("Menu option: > ");
                menu = ReadInteger(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        TaxiJoinsRank();
                        break;
                    case 2:
                        TaxiLeavesRank();
                        break;
                    case 3:
                        TaxiDropFare();
                        break;
                    case 4:
                        ViewFinancialReport();
                        break;
                    case 5:
                        ViewTransactionLog();
                        break;
                    case 6:
                        ViewTaxiLocations();
                        break;
                    case 0:
                        Console.WriteLine("Exit");
                        break;
                    default:
                        Console.WriteLine("Invalid value");
                        break;
                }
            }
        }
        private static void DisplayResults(List<string> results)
        {
            Console.WriteLine();
            foreach (string s in results)
            {
                Console.WriteLine(s);
            }
        }
        private static double ReadDouble(string prompt)
        {
            double doubleReturn = -1;
            while (doubleReturn == -1)
            {
                try
                {
                    doubleReturn = Convert.ToDouble(prompt);
                }
                catch (FormatException)
                {
                    Console.Write("Invalid value, try again: > ");
                    prompt = Console.ReadLine();
                }
            }
            doubleReturn = Math.Round(doubleReturn, 2);
            return doubleReturn;
        }
        private static int ReadInteger(string prompt)
        {
            int intReturn = -1;
            while (intReturn == -1)
            {
                try
                {
                    intReturn = Convert.ToInt32(prompt);
                }
                catch (FormatException)
                {
                    Console.Write("Invalid value, try again: > ");
                    prompt = Console.ReadLine();
                }
            }
            return intReturn;
        }
        private static string ReadString(string prompt)
        {
            string strReturn = prompt;
            return strReturn;
        }
        private static void TaxiDropFare()
        {
            Console.WriteLine("\n" + "Taxi drops a fare:" + "\n" + "******************");
            Console.Write("Enter a taxi number: > ");
            int taxiNum = ReadInteger(Console.ReadLine());
            while (true)
            {
                Console.Write("Is the price paid(Y/N): > ");
                string pricePaidBool = Console.ReadLine().ToLower();
                if (pricePaidBool.Equals("y"))
                {
                    try
                    {
                        DisplayResults(ui.TaxiDropsFare(taxiNum, true));
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("\n" + "UserUI is missing");
                    }
                    break;
                }
                else if (pricePaidBool.Equals("n"))
                {
                    try
                    {
                        DisplayResults(ui.TaxiDropsFare(taxiNum, false));
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("\n" + "UserUI is missing");
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid value");
                }
            }
        }
        private static void TaxiJoinsRank()
        {
            Console.WriteLine("\n" + "Taxi joins a rank:" + "\n" + "******************");
            Console.Write("Enter a taxi number: > ");
            int taxiNum = ReadInteger(Console.ReadLine());
            Console.Write("Enter a rank id: > ");
            int rankId = ReadInteger(Console.ReadLine());
            try
            {
                DisplayResults(ui.TaxiJoinsRank(taxiNum, rankId));
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("\n" + "UserUI is missing");
            }
            if (rankId > 3)
            {
                Console.WriteLine("There are only three taxi ranks.");
            }
        }
        private static void TaxiLeavesRank()
        {
            Console.WriteLine("\n" + "Taxi leaves a rank:" + "\n" + "*******************");
            Console.Write("Enter a rank id: > ");
            int rankId = ReadInteger(Console.ReadLine());
            Console.Write("Enter a fare destination: > ");
            string destination = ReadString(Console.ReadLine());
            Console.Write("Enter an agreed price: > ");
            double agreedPrice = ReadDouble(Console.ReadLine());
            try
            {
                DisplayResults(ui.TaxiLeavesRank(rankId, destination, agreedPrice));
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("\n" + "UserUI is missing");
            }
            if (rankId > 3)
            {
                Console.WriteLine("There are only three taxi ranks.");
            }
        }
        private static void ViewFinancialReport()
        {
            try
            {
                DisplayResults(ui.ViewFinancialReport());
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("\n" + "UserUI is missing");
            }
        }
        private static void ViewTaxiLocations()
        {
            try
            {
                DisplayResults(ui.ViewTaxiLocations());
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("\n" + "UserUI is missing");
            }
        }
        private static void ViewTransactionLog()
        {
            try
            {
                DisplayResults(ui.ViewTransactionLog());
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("\n" + "UserUI is missing");
            }
        }
    }
}
