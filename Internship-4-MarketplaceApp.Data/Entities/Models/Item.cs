using System;

namespace Internship_4_MarketplaceApp.Data.Entities.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Enums.ItemStatus Status { get; set; }
        public Enums.ItemCategory Category { get; set; }
        public Seller Owner { get; set; }

        public Item(string name, string description, double price, Enums.ItemCategory category, Seller owner)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Price = price;
            Category = category;
            Status = Enums.ItemStatus.Onsell;
            Owner = owner;
        }
    }
}
