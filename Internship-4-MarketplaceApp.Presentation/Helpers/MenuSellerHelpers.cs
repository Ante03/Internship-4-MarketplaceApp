using Internship_4_MarketplaceApp.Data.Entities;
using Internship_4_MarketplaceApp.Data.Entities.Models;
using Internship_4_MarketplaceApp.Data.Enums;
using Internship_4_MarketplaceApp.Domain.Repositorioes;
using System;

namespace Internship_4_MarketplaceApp.Presentation.Helpers
{
    public class MenuSellerHelpers
    {
        public static void AddNewItem(Seller seller, Marketplace marketplace)
        {
            Console.Clear();
            Console.Write("Unesite ime proizvoda: ");
            var nameOfItem = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(nameOfItem))
            {
                Console.Write("Unesite ime proizvoda: ");
                nameOfItem = Console.ReadLine();
            }

            Console.Write("Unesite opis proizvoda: ");
            var descriptionOfItem = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(descriptionOfItem) || int.TryParse(descriptionOfItem, out _))
            {
                Console.Write("Unesite opis proizvoda: ");
                descriptionOfItem = Console.ReadLine();
            }

            var min_price = 0.01;
            var max_price = 100000.00;
            Console.Write("Unesite cijenu proizvoda: ");
            double priceOfItem = Returners.CheckNumberDouble(min_price, max_price);

            ItemCategory categoryOfItem = ItemCategory.Books;
            Console.WriteLine("Odaberite kategoriju: \n1 - Elektronika \n2 - Odjeca \n3 - Knjige \n4 - Hrana \n5 - Pice");
            var choiceCategory = Returners.CheckNumber(1, 5);
            switch (choiceCategory) {
                case 1:
                    {
                        categoryOfItem = ItemCategory.Electronics;
                        break;
                    }
                case 2:
                    {
                        categoryOfItem = ItemCategory.Clothes;
                        break;
                    }
                case 3:
                    {
                        categoryOfItem = ItemCategory.Books;
                        break;
                    }
                case 4:
                    {
                        categoryOfItem = ItemCategory.Food;
                        break;
                    }
                case 5:
                    {
                        categoryOfItem = ItemCategory.Drinks;
                        break;
                    }
            }

            Console.WriteLine("Jeste sigurni da zelite dodati proizvod?");
            if (!Returners.CheckYesOrNo())
            {
                Console.WriteLine("Odustali od brisanja");
                return;
            }
            MenuSellerFunctions.MakeItem(nameOfItem, descriptionOfItem, priceOfItem, categoryOfItem, seller, marketplace);
            Console.WriteLine("Uspjesno dodan novi proizvod!");
        } 

        public static void PrintItems(Seller seller, Marketplace marketplace)
        {
            Console.Clear();
            Console.WriteLine("ID       -       Ime      -       Opis       -       Cijena       -       Status");
            foreach (Item item in marketplace.Items) 
            { 
                if(item.Owner == seller)
                {
                    Console.WriteLine($"{item.Id}      -       {item.Name}      -      {item.Description}       -       {item.Price}      -       {item.Status}");
                }
            }
        }

        public static void PrintSoldItemsByCategory(Seller seller, Marketplace marketplace)
        {
            Console.Clear();

            ItemCategory categoryOfItem = ItemCategory.Books;
            Console.WriteLine("Odaberite kategoriju: \n1 - Elektronika \n2 - Odjeca \n3 - Knjige \n4 - Hrana \n5 - Pice");
            var choiceCategory = Returners.CheckNumber(1, 5);
            switch (choiceCategory)
            {
                case 1:
                    {
                        categoryOfItem = ItemCategory.Electronics;
                        break;
                    }
                case 2:
                    {
                        categoryOfItem = ItemCategory.Clothes;
                        break;
                    }
                case 3:
                    {
                        categoryOfItem = ItemCategory.Books;
                        break;
                    }
                case 4:
                    {
                        categoryOfItem = ItemCategory.Food;
                        break;
                    }
                case 5:
                    {
                        categoryOfItem = ItemCategory.Drinks;
                        break;
                    }
            }
            Console.WriteLine("Proizvodi koji su prodani po kategoriji: ");
            var counter = 0;
            foreach (Item item in marketplace.Items)
            {
                if (item.Owner == seller && item.Status == ItemStatus.Sold && item.Category == categoryOfItem) 
                {
                    counter++;
                    Console.WriteLine($"{item.Name}      -      {item.Description}       -       {item.Price}      -       {item.Status}");
                }
            }
            if (counter == 0) {
                Console.WriteLine($"Trenutno nema prodanih proizvoda u kategoriji {categoryOfItem}");
            }
        }

        public static void PrintEariningsInTimePeriod(Seller seller, Marketplace marketplace)
        {
            Console.Clear();
            Console.Write("Unesite pocetni datum: ");
            DateTime startDate = Returners.NewDate();
            while (startDate > DateTime.Now) {
                Console.Write("Unesite ponovo pocetni datum: ");
                startDate = Returners.NewDate();
            }

            Console.Write("Unesite krajnji datum: ");
            DateTime endDate = Returners.NewDate();
            while (endDate > DateTime.Now || endDate < startDate)
            {
                Console.Write("Unesite ponovo pocetni datum: ");
                endDate = Returners.NewDate();
            }
            var earnings = MenuSellerFunctions.FindEarnings(startDate, endDate, seller, marketplace);
            Console.WriteLine($"Ukupna zarada izmedu {startDate.ToString("dd/MM/yyyy")} i {endDate.ToString("dd/MM/yyyy")} je {earnings}$");
        }

        public static void ChangePrice(Seller seller, Marketplace marketplace)
        {
            Console.Clear();
            PrintItems(seller, marketplace);
            Item itemToChangePrice = Returners.FindItemById(marketplace);
            if (itemToChangePrice == null) {
                Console.WriteLine("Proizvod s tim Id-om ne postoji!");
                return;
            }
            if(itemToChangePrice.Owner != seller)
            {
                Console.WriteLine("Vi niste vlasnik tog proizvoda!");
                return;
            }
            if (itemToChangePrice.Status != ItemStatus.Onsell)
            {
                Console.WriteLine("Proizvod je vec prodan!");
                return;
            }
            var min_price = 0.01;
            var max_price = 100000.00;
            Console.Write("Unesite cijenu proizvoda: ");
            double newPriceOfItem = Returners.CheckNumberDouble(min_price, max_price);
            itemToChangePrice.Price = newPriceOfItem;
            Console.WriteLine("Cijena uspjesno promijenjena!");
            return;
        }
    }
}
