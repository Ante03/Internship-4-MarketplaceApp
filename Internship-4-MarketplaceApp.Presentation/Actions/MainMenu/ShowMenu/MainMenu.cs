using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internship_4_MarketplaceApp.Presentation.Helpers;
using Internship_4_MarketplaceApp.Presentation.Actions.HomePage;
using Internship_4_MarketplaceApp.Data.Entities;

namespace Internship_4_MarketplaceApp.Presentation.Actions.MainMenu.ShowMenu
{
    public class MainMenu
    {
        public static void showMenu()
        {
            Console.WriteLine("Odaberite: \n1 - Registarcija \n2 - Prijava \n3 - izlaz");
            var smallestChoice = 1;
            var biggestChoice = 3;
            var choiceLoginOrRegistar = Returners.CheckNumber(smallestChoice, biggestChoice);
            if (choiceLoginOrRegistar == 3)
            {
                return;
            }
            if (choiceLoginOrRegistar == 2)
            {
                HomePage.Login.Login.LoginInApp();
            }
            else
            {

            }
        }
    }
}
