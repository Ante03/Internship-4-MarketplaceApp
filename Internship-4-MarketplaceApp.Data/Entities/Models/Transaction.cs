using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_MarketplaceApp.Data.Entities.Models
{
    public class Transaction
    {
        public Guid Id_proizvoda { get; set; }
        public Buyer Buyer { get; set; }
        public Seller Seller { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool IsCouponUsed {  get; set; }
        public Transaction(Guid id, Buyer buyer, Seller seller, bool isCouponUsed)
        {
            Id_proizvoda = id;
            Buyer = buyer;
            Seller = seller;
            TransactionDate = DateTime.Now;
            IsCouponUsed = isCouponUsed;
        }
    }
}
