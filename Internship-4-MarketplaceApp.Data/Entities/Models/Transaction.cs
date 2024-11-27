using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_MarketplaceApp.Data.Entities.Models
{
    public class Transaction
    {
        public int Id_proizvoda { get; set; }
        public Buyer Buyer { get; set; }
        public Seller Seller { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
