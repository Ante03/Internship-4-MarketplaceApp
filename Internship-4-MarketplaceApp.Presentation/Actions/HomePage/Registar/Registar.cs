using Internship_4_MarketplaceApp.Data.Entities;
using Internship_4_MarketplaceApp.Data.Entities.Models;
using Internship_4_MarketplaceApp.Presentation.Helpers;
using System;


namespace Internship_4_MarketplaceApp.Presentation.Actions.HomePage.Registar
{
    public class Registar
    {
        public static void AddNewUser(Marketplace marketplace)
        {
            Console.Clear();
            Console.Clear();
            var name = Returners.EnterName(marketplace);
            var mail = Returners.CheckMail(marketplace);
            var moneyOnAccount = Returners.CheckBuyerOrSeller();
            if(moneyOnAccount == 0)
            {
                Seller newSeller = new Seller(name, mail);
                marketplace.Sellers.Add(newSeller);
                Console.WriteLine("Uspjesno registrirani u sustav kao prodavac! \nPrijavite se i koristite nasu aplikaciju :)");
                return;
            }
            Buyer newBuyer = new Buyer(name, mail, moneyOnAccount);
            marketplace.Buyers.Add(newBuyer);
            Console.WriteLine("Uspjesno registrirani u sustav kao kupac! \nPrijavite se i koristite nasu aplikaciju :)");
        }
    }
}
