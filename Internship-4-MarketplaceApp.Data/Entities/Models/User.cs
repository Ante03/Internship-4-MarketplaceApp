using System;

namespace Internship_4_MarketplaceApp.Data.Entities.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }

        public User(string name, string mail) 
        { 
            UserName = name;
            UserEmail = mail;
            Id = Guid.NewGuid();
        }
    }
}
