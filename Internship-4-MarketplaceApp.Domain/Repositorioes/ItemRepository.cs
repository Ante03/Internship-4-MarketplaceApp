using Internship_4_MarketplaceApp.Data.Entities.Models;
using Internship_4_MarketplaceApp.Data.Entities;
using Internship_4_MarketplaceApp.Data.Enums;

namespace Internship_4_MarketplaceApp.Domain.Repositorioes
{
    public class ItemRepository
    {
        public static void MakeItem(string name, string description, double price, ItemCategory category, Seller seller, Marketplace marketplace)
        {
            Item newItem = new Item(name, description, price, category, seller);
            marketplace.Items.Add(newItem);
        }
    }
}
