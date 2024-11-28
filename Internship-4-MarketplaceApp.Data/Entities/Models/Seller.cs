using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_MarketplaceApp.Data.Entities.Models
{
    public class Seller : User
    {
        public double Earnings { get; set; }
        public Seller(string name, string mail) : base(name, mail)
        {

        }
    }
}
