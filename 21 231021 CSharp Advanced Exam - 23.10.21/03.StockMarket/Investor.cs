using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private HashSet<Stock> portfolio;
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            portfolio = new HashSet<Stock>();
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = Math.Abs(moneyToInvest);
            BrokerName = brokerName;
        }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public int Count { get {return portfolio.Count; } }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && stock.PricePerShare <= MoneyToInvest)
            {
                MoneyToInvest -= stock.PricePerShare;
                portfolio.Add(stock);
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            if (CompanyExist(companyName))
            {
                Stock currentStock = FindStock(companyName);
                if (sellPrice < currentStock.PricePerShare)
                {
                    return $"Cannot sell {companyName}.";
                }
                else
                {
                    portfolio.Remove(currentStock);
                    MoneyToInvest += sellPrice;
                    return $"{companyName} was sold.";
                }
            }
            else
            {
                return $"{companyName} does not exist.";
            }
        }
        public Stock FindStock(string companyName)
        {
            foreach (var stock in portfolio)
            {
                if (stock.CompanyName == companyName)
                {
                    return stock;
                }
            }
            return null;
        }
        public Stock FindBiggestCompany()
        {
            return portfolio.OrderByDescending(s => s.MarketCapitalization).FirstOrDefault();
        }

        public string InvestorInformation()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            foreach (var stock in portfolio)
            {
                sb.AppendLine(stock.ToString());
            }
            return sb.ToString().TrimEnd();
        }
        private bool CompanyExist(string companyName)
        {
            foreach (var stock in portfolio)
            {
                if (stock.CompanyName == companyName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}