using Internship_4_MarketplaceApp.Data.Entities.Models;
using Internship_4_MarketplaceApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internship_4_MarketplaceApp.Data.Enums;
using System.Runtime.InteropServices.ComTypes;

namespace Internship_4_MarketplaceApp.Domain.Repositorioes
{
    public class MenuSellerFunctions
    {
        public static void MakeItem(string name, string description, double price, ItemCategory category, Seller seller, Marketplace marketplace)
        {
            Item newItem = new Item(name, description, price, category, seller);
            marketplace.Items.Add(newItem);
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
                        if(item.Id == transaction.Id_proizvoda && transaction.IsCouponUsed == true)
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
