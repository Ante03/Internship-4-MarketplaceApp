using System;


namespace Internship_4_MarketplaceApp.Data.Entities.Models
{
    public class Coupon
    {
        public Guid Id { get; set; }
        public int CouponCode { get; set; }
        public Enums.ItemCategory Category { get; set; }
        public DateTime EndDate { get; set; }
        public Buyer Buyer { get; set; }

        public Coupon(int code, Enums.ItemCategory category, DateTime endDate, Buyer buyer)
        {
            Id = Guid.NewGuid();
            CouponCode = code;
            Category = category;
            EndDate = endDate;
            Buyer = buyer;
        }
    }
}
