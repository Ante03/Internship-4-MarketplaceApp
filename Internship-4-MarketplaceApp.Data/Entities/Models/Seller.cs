
namespace Internship_4_MarketplaceApp.Data.Entities.Models
{
    public class Seller : User
    {
        public double Earnings { get; set; }
        public Seller(string name, string mail) : base(name, mail)
        {
            Earnings = 0.00;
        }
    }
}
