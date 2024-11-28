using Internship_4_MarketplaceApp.Data.Entities;
using Internship_4_MarketplaceApp.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Internship_4_MarketplaceApp.Presentation.Helpers
{
    public class Returners
    {
        public static int CheckNumber(int smallestNumber, int biggestNumber)
        {
            var EnteredNumber = -1;
            do
            {
                int.TryParse(Console.ReadLine(), out EnteredNumber);
            } while (EnteredNumber > biggestNumber || EnteredNumber < smallestNumber);
            return EnteredNumber;
        }
        public static int CheckBuyerOrSeller()
        {
            Console.WriteLine("Zelite li se prijaviti kao kupac ili kao prodavac: \n1 - Kupac \n2 - Prodavac");
            var smallestChoice = 1;
            var biggestChoice = 2;
            var choice = CheckNumber(smallestChoice, biggestChoice);
            if (choice == 1) 
            {
                Console.WriteLine("Unesite svoje pocetno stanje na racunu (10$ - 1000$): ");
                smallestChoice = 10;
                biggestChoice = 1000;
                var moneyOnAccount = CheckNumber(smallestChoice, biggestChoice);
                return moneyOnAccount;
            }
            else
            {
                return 0;
            }
        }
        public static Item FindItemById(Marketplace marketplace)
        {
            Console.Write("Unesite id proizvoda: ");
            var id_item = Console.ReadLine();
            Item userToReturn = null;
            foreach (var item in marketplace.Items)
            {
                if (id_item == item.Id.ToString())
                {
                    userToReturn = item;
                    break;
                }      
            }
            return userToReturn;
        }
        public static bool CheckNullBuyer(Buyer buyer)
        {
            if(buyer == null)
            {
                Console.WriteLine("Korisnik je neispravan!");
                return true;
            }
            return false;
        }
        public static bool CheckNullItem(Item item)
        {
            if (item == null)
            {
                Console.WriteLine("Proizvod je neispravan!");
                return true;
            }
            return false;
        }
        public static bool CheckEmailIsFree(string email, Marketplace marketplace)
        {
            foreach (var buyer in marketplace.Buyers)
            {
                if (email == buyer.UserEmail)
                {
                    return true;
                }
            }
            foreach (var seller in marketplace.Sellers)
            {
                if (email == seller.UserEmail)
                {
                    return true;
                }
            }
            return false;
        }
        public static string EnterName(Marketplace marketplace)
        {
            Console.Write("Unesite ime: ");
            var enteredName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(enteredName))
            {
                Console.Write("Neispravno ime, unesite novo ime: ");
                enteredName = Console.ReadLine();
            }
            return enteredName;
        }
        public static User CheckMailInUsers(Marketplace marketplace)
        {
            Console.WriteLine("Unesite e-mail: ");
            var enternedMail = Console.ReadLine();
            foreach (var buyer in marketplace.Buyers)
            {
                if (enternedMail == buyer.UserEmail)
                {
                    return buyer;
                }
            }
            foreach (var seller in marketplace.Sellers)
            {
                if (enternedMail == seller.UserEmail)
                {
                    return seller;
                }
            }
            Console.WriteLine("Korinsik s tim imenom i mail-om ne postoji!");
            return null;
        }
        public static string CheckMail(Marketplace marketplace)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Console.Write("Unesite e-mail: ");
            var EnternedMail = Console.ReadLine();
            while (!Regex.IsMatch(EnternedMail, emailPattern) || Returners.CheckEmailIsFree(EnternedMail, marketplace))
            {
                Console.WriteLine("Unijeli ste krivo mail ili je mail zauzet vec, pokusajte ponovo (nesto@nesto.nesto): ");
                EnternedMail = Console.ReadLine();
            }
            return EnternedMail;
        }
    }
}
