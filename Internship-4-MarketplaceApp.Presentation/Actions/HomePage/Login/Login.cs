using System;
using Internship_4_MarketplaceApp.Presentation.Helpers;
using Internship_4_MarketplaceApp.Data.Entities;
using Internship_4_MarketplaceApp.Data.Entities.Models;
using Internship_4_MarketplaceApp.Presentation.Actions.MainMenu.ShowMenu;

namespace Internship_4_MarketplaceApp.Presentation.Actions.HomePage.Login
{
    public class Login
    {
        public static void LoginInApp(Marketplace marketplace)
        {
            var user = Returners.CheckMailInUsers(marketplace);
            if (user == null) {  return; }

            if(user is Buyer)
            {
                MenuBuyer.BuyerOptions(marketplace, (Buyer)user);
            }
            else if(user is Seller)
            {
                Console.WriteLine("Seellll");
            }
        }
    }
}
