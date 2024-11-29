using Internship_4_MarketplaceApp.Data.Entities.Models;
using Internship_4_MarketplaceApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internship_4_MarketplaceApp.Presentation.Helpers;

namespace Internship_4_MarketplaceApp.Presentation.Actions.MainMenu.ShowMenu
{
    public class MenuSeller
    {
        public static void SellerOptions(Marketplace marketplace, Seller seller)
        {
            Console.Clear();
            var choice = -1;
            while (choice != 0)
            {
                Console.WriteLine("Odaberite: \n1 - Dodaj proizvod \n2 - Pregledaj proizvode \n3 - Zarada \n4 - Prodani po kategoriji\n5 - Zarada u vremenskom periodu \n6 - Promijeni cijenu \n7 - izlaz");
                choice = Returners.CheckNumber(1, 7);
                switch (choice) { 
                    case 1:
                        {
                            MenuSellerHelpers.AddNewItem(seller, marketplace);
                            break;
                        }
                    case 2:
                        {
                            MenuSellerHelpers.PrintItems(seller, marketplace);
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine($"Ukupno ste zaradili {seller.Earnings}$!");
                            break;
                        }
                    case 4:
                        {
                            MenuSellerHelpers.PrintSoldItemsByCategory(seller, marketplace);
                            break;
                        }
                    case 5:
                        {
                            MenuSellerHelpers.PrintEariningsInTimePeriod(seller, marketplace);
                            break;
                        }
                    case 6:
                        {
                            MenuSellerHelpers.ChangePrice(seller, marketplace);
                            break;
                        }
                    case 7:
                        {
                            return;
                        }
                }
            }
        }
    }
}
