using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internship_4_MarketplaceApp.Presentation.Helpers;
using Internship_4_MarketplaceApp.Presentation.Actions.HomePage;
using Internship_4_MarketplaceApp.Data.Entities;
using Internship_4_MarketplaceApp.Presentation.Actions.HomePage.Registar;
using Internship_4_MarketplaceApp.Presentation.Actions.HomePage.Login;

namespace Internship_4_MarketplaceApp.Presentation.Actions.MainMenu.ShowMenu
{
    public class MainMenu
    {
        public static void showMenu(Marketplace marketplace)
        {
            var choiceLoginOrRegistar = 0;
            while (choiceLoginOrRegistar != 3)
            {
                Console.WriteLine("Odaberite: \n1 - Registarcija \n2 - Prijava \n3 - izlaz");
                var smallestChoice = 1;
                var biggestChoice = 3;
                choiceLoginOrRegistar = Returners.CheckNumber(smallestChoice, biggestChoice);
                if (choiceLoginOrRegistar == 3)
                {
                    return;
                }
                if (choiceLoginOrRegistar == 2)
                {
                    Login.LoginInApp(marketplace);
                }
                else
                {
                    Registar.AddNewUser(marketplace);
                }
            }
            
        }
    }
}
