using Internship_4_MarketplaceApp.Data.Entities;
using Internship_4_MarketplaceApp.Data.Entities.Models;
using System;
using System.Linq;


namespace Internship_4_MarketplaceApp.Domain.Repositorioes
{
    public class MenuBuyerFunctions
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
            item.Owner.Earnings += 0.85 * item.Price;
            Transaction newTransaction = new Transaction(item.Id, buyer, item.Owner, true);
            marketplace.Transactions.Add(newTransaction);
            buyer.History.Add(item);
        }
        public static void ReturnItem(Item item, Buyer buyer, Marketplace marketplace, Transaction transaction)
        {
            if(transaction.IsCouponUsed == true)
            {
                buyer.History.Remove(item);
                item.Status = Data.Enums.ItemStatus.Onsell;
                buyer.StartingMoney += 0.8 * 0.9 * item.Price;
                item.Owner.Earnings -= 0.85 * item.Price;
                marketplace.Transactions.Remove(transaction);
            }
            else
            {
                buyer.History.Remove(item);
                item.Status = Data.Enums.ItemStatus.Onsell;
                buyer.StartingMoney += 0.8 * item.Price;
                item.Owner.Earnings -= 0.95 * item.Price;
                marketplace.Transactions.Remove(transaction);
            }

        }

    }
}
