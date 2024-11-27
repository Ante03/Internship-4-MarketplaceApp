using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_4_MarketplaceApp.Presentation.Helpers
{
    public class Returners
    {
        public static int CheckNumber(int smallestNumber, int biggestNumber)
        {
            var EnteredNumber = -1;
            do
            {
                int.TryParse(Console.ReadLine(), out EnteredNumber);
            } while (EnteredNumber > biggestNumber || EnteredNumber < smallestNumber);

            return EnteredNumber;
        }
    }
}
