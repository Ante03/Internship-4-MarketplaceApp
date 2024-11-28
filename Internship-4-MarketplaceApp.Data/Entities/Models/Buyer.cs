using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_MarketplaceApp.Data.Entities.Models
{
    public class Buyer : User
    {
        public double StartingMoney { get; set; }
        public List<Item> History { get; set; } = new List<Item>();
        public List<Item> Favorites { get; set; } = new List<Item>();
        public Buyer(string name, string mail, double money) : base(name, mail)
        {
            StartingMoney = money;
        }
    }
}
