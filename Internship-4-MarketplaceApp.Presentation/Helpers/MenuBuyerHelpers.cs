using Internship_4_MarketplaceApp.Data.Entities;
using Internship_4_MarketplaceApp.Data.Entities.Models;
using Internship_4_MarketplaceApp.Domain.Repositorioes;
using System;
using System.Linq;

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
                        if (coupon.CouponCode == CodeFromCoupon && applicableCoupon.EndDate > DateTime.Now)
                        {
                            Console.WriteLine("Jeste sigurni da zelite obaviti kupnju: ");
                            if (Returners.CheckYesOrNo())
                            {
                                MenuBuyerFunctions.MakeSale(item, buyer, marketplace, CodeFromCoupon);
                                Console.WriteLine($"Uspjesno obavljena kupnja proizvoda '{item.Name}'!");
                                counter++;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Odustali od kupnje");
                            }
                            counter++;
                        }
                    }
                    if(counter == 0)
                    {
                        Console.WriteLine("Unijeli ste nevazeci kupon!");
                    }
                }
                else
                {
                    Console.WriteLine("Jeste sigurni da zelite obaviti kupnju: ");
                    if (Returners.CheckYesOrNo())
                    {
                        MenuBuyerFunctions.MakeSale(item, buyer, marketplace);
                        Console.WriteLine($"Uspjesno obavljena kupnja proizvoda '{item.Name}'!");
                    }
                    else
                    {
                        Console.WriteLine("Odustali od kupnje");
                    }
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
            Console.WriteLine("Jeste sigurni da zelite vratite proizvod: ");
            if (Returners.CheckYesOrNo())
            {
                MenuBuyerFunctions.ReturnItem(item, buyer, marketplace, transactionToRemove);
                Console.WriteLine("Proizvod uspjesno vracen!");
            }
            else
            {
                Console.WriteLine($"Odustali od vracanja {item.Name}");
            }
            
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
            Console.WriteLine($"Jeste sigurni da zelite dodati {item.Name} u omiljene!");
            if (Returners.CheckYesOrNo())
            {
                buyer.Favorites.Add(item);
                Console.WriteLine($"uspjesno dodano u omiljene '{item.Name}'!");
            }
            else
            {
                Console.WriteLine($"Odustali od dodavanja {item.Name} u omiljene");
            }
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
