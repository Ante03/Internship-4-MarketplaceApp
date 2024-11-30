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
            Console.Clear();
            var user = Returners.CheckMailInUsers(marketplace);
            if (user == null) { return; }
            var name = Returners.EnterName(marketplace);

            if (user is Buyer && name.ToLower() == user.UserName.ToLower())
            {
                MenuBuyer.BuyerOptions(marketplace, (Buyer)user);
            }
            else if (user is Seller && name.ToLower() == user.UserName.ToLower())
            {
                MenuSeller.SellerOptions(marketplace, (Seller)user);
            }
            else 
            {
                Console.WriteLine("Nismo vas uspjeli naci u sustavu");
            }
        }
    }
}
