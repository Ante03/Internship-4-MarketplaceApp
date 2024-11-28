using Internship_4_MarketplaceApp.Data.Entities;
using Internship_4_MarketplaceApp.Data.Entities.Models;
using Internship_4_MarketplaceApp.Domain.Repositorioes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_MarketplaceApp.Presentation.Helpers
{
    public class MenuBuyerHelpers
    {
        public static void ItemForSale(Marketplace marketplace)
        {
            Console.WriteLine("ID   -   Ime     -   Cijena      -   Opis");
            foreach (var item in marketplace.Items)
            {
                if (item.Status == Data.Enums.ItemStatus.Onsell)
                {
                    Console.WriteLine($"{item.Id}   -   {item.Name}     -   {item.Price}    -   {item.Description}");
                }
            }
        }

        public static void DoSale(Item item, Buyer buyer, Marketplace marketplace)
        {
            if (Returners.CheckNullBuyer(buyer))
            {
                return;
            }
            if (Returners.CheckNullItem(item))
            {
                return;
            }
            if (item.Status == Data.Enums.ItemStatus.Onsell && buyer.StartingMoney > item.Price)
            {
                var applicableCoupon = marketplace.Coupons
                .FirstOrDefault(c => c.Category == item.Category);
                Console.WriteLine("Zelite li koristiti kupon: \n1 - Da \n2 - Ne");
                var choiceCoupon = Returners.CheckNumber(1, 2);
                if (applicableCoupon != null && choiceCoupon == 1)
                {
                    int counter = 0;
                    Console.WriteLine("Unesite cetveroznamenkasti kod sa kupona");
                    var CodeFromCoupon = Returners.CheckNumber(1000, 9999);
                    foreach (var coupon in marketplace.Coupons)
                    {
                        if (coupon.CouponCode == CodeFromCoupon)
                        {
                            MenuBuyerFunctions.MakeSale(item, buyer, marketplace, CodeFromCoupon);
                            Console.WriteLine($"Uspjesno obavljena kupnja proizvoda '{item.Name}'!");
                            counter++;
                            break;
                        }
                    }
                    if(counter == 0)
                    {
                        Console.WriteLine("Unijeli ste krivi kod!");
                    }
                }
                else
                {
                    MenuBuyerFunctions.MakeSale(item, buyer, marketplace);
                    Console.WriteLine($"Uspjesno obavljena kupnja proizvoda '{item.Name}'!");
                }  
            }
            else
            {
                if(item.Status != Data.Enums.ItemStatus.Onsell)
                    Console.WriteLine("Proizvod vise nije dostupan");
                else
                    Console.WriteLine("Neuspjesna kupnja, nedovoljan iznos!");
            }
        }

        public static void ReturnItem(Item item, Buyer buyer, Marketplace marketplace)
        {
            if (Returners.CheckNullBuyer(buyer))
                return;


            if (Returners.CheckNullItem(item))
                return;

            if (!buyer.History.Contains(item))
            {
                Console.WriteLine($"Kupac '{buyer.UserName}' ne posjeduje proizvod '{item.Name}'!");
                return;
            }
            var transactionToRemove = marketplace.Transactions
            .FirstOrDefault(t => t.Id_proizvoda == item.Id);
            if (transactionToRemove == null)
            {
                Console.WriteLine("Dogodila se greska neuspjesno briasnje!");
                return;
            }
            MenuBuyerFunctions.ReturnItem(item, buyer, marketplace, transactionToRemove);
            Console.WriteLine("Proizvod uspjesno vracen!");
        }

        public static void AddToFavorites(Item item, Buyer buyer)
        {
            if (Returners.CheckNullBuyer(buyer))
                return;

            if (Returners.CheckNullItem(item))
                return;

            if (buyer.Favorites.Contains(item))
            {
                Console.WriteLine($"'{item.Name}' je vec dodano u omiljene!");
                return;
            }
            buyer.Favorites.Add(item);
            Console.WriteLine($"uspjesno dodano u omiljene '{item.Name}'!");
        }

        public static void PrintHistoryOfShopping(Buyer buyer)
        {
            if (Returners.CheckNullBuyer(buyer))
                return;

            if (!buyer.History.Any())
            {
                Console.WriteLine("Povijest prazna!");
                return;
            }
            Console.WriteLine("Ime - Cijena");
            foreach (Item item in buyer.History)
            {
                Console.WriteLine($"{item.Name} - {item.Price}");
            }
        }

        public static void PrintFavorites(Buyer buyer)
        {
            if (Returners.CheckNullBuyer(buyer))
                return;
            if (!buyer.Favorites.Any())
            {
                Console.WriteLine("Omiljeni prazni!");
                return;
            }
            Console.WriteLine("Ime - Cijena");
            foreach (Item item in buyer.Favorites)
            {
                Console.WriteLine($"{item.Name} - {item.Price}");
            }
        }
    }
}
