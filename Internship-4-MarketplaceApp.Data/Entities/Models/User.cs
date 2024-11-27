using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_MarketplaceApp.Data.Entities.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserEmail { get; set; }

        public User(string name, string surname, string mail) 
        { 
            UserName = name;
            UserSurname = surname;
            UserEmail = mail;
            Id = Guid.NewGuid();
        }
    }
}
