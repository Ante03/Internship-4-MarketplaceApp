using Internship_4_MarketplaceApp.Presentation.Actions.MainMenu.ShowMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internship_4_MarketplaceApp.Data.Entities.Models;
using Internship_4_MarketplaceApp.Data.Entities;


namespace Internship_4_MarketplaceApp.Presentation
{
    public class Program
    {
        static void Main(string[] args)
        {
            DbContext context = new DbContext();

            MainMenu.showMenu();
        }
    }
}
