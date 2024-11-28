using Internship_4_MarketplaceApp.Data.Entities;
using Internship_4_MarketplaceApp.Data.Entities.Models;
using Internship_4_MarketplaceApp.Domain.Repositorioes;
using Internship_4_MarketplaceApp.Presentation.Helpers;
using System;

namespace Internship_4_MarketplaceApp.Presentation.Actions.MainMenu.ShowMenu
{
    public class MenuBuyer
    {
        public static void BuyerOptions(Marketplace marketplace, Buyer buyer)
        {
            Console.Clear();
            var choice = -1;
            while (choice != 0) 
            { 
                Console.WriteLine("Odaberite:\n1 - Pregled svih artikala\n2 - Napravi kupnju \n3 - Povratak proizvoda \n4 - Dodaj u omiljene \n5 - Prikazi povijest \n6 - Prikazi favorite \n7 - izlaz");
                choice = Returners.CheckNumber(1, 7);
                switch (choice) { 
                    case 1:
                        {
                            Console.Clear();
                            MenuBuyerHelpers.ItemForSale(marketplace);
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            var itemToBuy = Returners.FindItemById(marketplace);
                            MenuBuyerHelpers.DoSale(itemToBuy, buyer, marketplace);
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            var itemToReturn = Returners.FindItemById(marketplace);
                            MenuBuyerHelpers.ReturnItem(itemToReturn, buyer, marketplace);
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            var itemToFavorites = Returners.FindItemById(marketplace);
                            MenuBuyerHelpers.AddToFavorites(itemToFavorites, buyer);
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            MenuBuyerHelpers.PrintHistoryOfShopping(buyer);
                            break;
                        }
                    case 6:
                        {
                            Console.Clear();
                            MenuBuyerHelpers.PrintFavorites(buyer);
                            break;
                        }
                    case 7:
                        return;
                }
            }
        }
    }
}
