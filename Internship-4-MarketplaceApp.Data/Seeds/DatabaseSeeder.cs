using Internship_4_MarketplaceApp.Data.Entities.Models;
using Internship_4_MarketplaceApp.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_MarketplaceApp.Data.Seeds
{
    public class DatabaseSeeder
    {
        public static readonly List<Buyer> Buyers = new List<Buyer>
            {
                new Buyer("Ante", "Spajić", "ante@gmail.com", 100),
                new Buyer("Toni", "Tonic", "toni@gmail.com", 50),
                new Buyer("Marko", "Markic", "marko@fesb.hr", 300)
        };

        public static readonly List<Seller> Sellers = new List<Seller>
            {
                new Seller("Mirko", "Mirkic", "mirko@gmail.com"),
                new Seller("Marta", "Martic", "marta@mail.hr"),
                new Seller("Marija", "Maric", "mara@mail.hr")
        };

        public static readonly List<Item> Items = new List<Item>
            {
                new Item("Mobitel", "Samsung Galaxy S24", 700, ItemCategory.Electronics, Sellers[0]),
                new Item("Zimska jakna", "Zimska jakna s kapom i vunom", 120, ItemCategory.Clothes, Sellers[0]),
                new Item("Hamlet", "Stara knjiga", 50, ItemCategory.Books, Sellers[1]),
                new Item("Pizza", "Mijesana pizza", 10, ItemCategory.Food, Sellers[2]),
                new Item("Coca-cola", "Sok", 50, ItemCategory.Drinks, Sellers[1])
        };
    }
}


