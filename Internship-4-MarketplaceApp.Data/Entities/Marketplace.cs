using Internship_4_MarketplaceApp.Data.Entities.Models;
using Internship_4_MarketplaceApp.Data.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_MarketplaceApp.Data.Entities
{
    public class Marketplace
    {
        public List<Buyer> Buyers { get; set; } = DatabaseSeeder.Buyers;
        public List<Seller> Sellers { get; set; } = DatabaseSeeder.Sellers;
        public List<Item> Items { get; set; } = DatabaseSeeder.Items;
        public List<Transaction> Transactions { get; set; } = DatabaseSeeder.Transactions;
        public List<Coupon> Coupons { get; set; } = DatabaseSeeder.Coupons;

    }
}
