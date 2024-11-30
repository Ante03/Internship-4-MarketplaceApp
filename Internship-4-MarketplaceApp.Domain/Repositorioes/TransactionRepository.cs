using Internship_4_MarketplaceApp.Data.Entities.Models;
using Internship_4_MarketplaceApp.Data.Entities;
using System;

namespace Internship_4_MarketplaceApp.Domain.Repositorioes
{
    public class TransactionRepository
    {
        public static void MakeSale(Item item, Buyer buyer, Marketplace marketplace)
        {
            item.Status = Data.Enums.ItemStatus.Sold;
            buyer.StartingMoney = buyer.StartingMoney - item.Price;
            item.Owner.Earnings += 0.95 * item.Price;
            Transaction newTransaction = new Transaction(item.Id, buyer, item.Owner, false);
            marketplace.Transactions.Add(newTransaction);
            buyer.History.Add(item);
        }

        public static void MakeSale(Item item, Buyer buyer, Marketplace marketplace, int codeCoupon)
        {
            item.Status = Data.Enums.ItemStatus.Sold;
            buyer.StartingMoney = buyer.StartingMoney - item.Price * 0.9;
            item.Owner.Earnings += 0.95 * 0.9 * item.Price;
            Transaction newTransaction = new Transaction(item.Id, buyer, item.Owner, true);
            marketplace.Transactions.Add(newTransaction);
            buyer.History.Add(item);
        }

        public static void ReturnItem(Item item, Buyer buyer, Marketplace marketplace, Transaction transaction)
        {
            if (transaction.IsCouponUsed == true)
            {
                buyer.History.Remove(item);
                item.Status = Data.Enums.ItemStatus.Onsell;
                buyer.StartingMoney += 0.8 * 0.9 * item.Price;
                item.Owner.Earnings -= 0.8 * 0.9 * item.Price;
                marketplace.Transactions.Remove(transaction);
            }
            else
            {
                buyer.History.Remove(item);
                item.Status = Data.Enums.ItemStatus.Onsell;
                buyer.StartingMoney += 0.8 * item.Price;
                item.Owner.Earnings -= 0.8 * item.Price;
                marketplace.Transactions.Remove(transaction);
            }

        }

        public static double FindEarnings(DateTime start, DateTime end, Seller seller, Marketplace marketplace)
        {
            var earnings = 0.00;
            foreach (Transaction transaction in marketplace.Transactions)
            {
                if (transaction.TransactionDate > start && transaction.TransactionDate < end && transaction.Seller == seller)
                {
                    foreach (Item item in marketplace.Items)
                    {
                        if (item.Id == transaction.Id_proizvoda && transaction.IsCouponUsed == true)
                        {
                            earnings += item.Price * 0.85;
                        }
                        if (item.Id == transaction.Id_proizvoda && transaction.IsCouponUsed == false)
                        {
                            earnings += item.Price * 0.95;
                        }
                    }
                }
            }
            return earnings;
        }
    }
}
