using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Internship_4_MarketplaceApp.Presentation.Helpers
{
    public class CheckEmail
    {
        public static void CheckMail()
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Console.WriteLine("Unesite e-mail: ");
            var EnternedMail = Console.ReadLine();
            while (!Regex.IsMatch(EnternedMail, emailPattern))
            {
                Console.WriteLine("Unijeli ste krivi mail, pokusajte ponovo: ");
                EnternedMail = Console.ReadLine();
            }
        }
        public static void CheckMailInUsers()
        {
            
        }
    }
}
