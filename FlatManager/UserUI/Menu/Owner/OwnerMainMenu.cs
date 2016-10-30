using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatManager.UserUI.Menu
{
    public class OwnerMainMenu : MenuDisplayer
    {
        public OwnerMainMenu() : base(Items, System.Console.WriteLine)
        {
        }

        private static IEnumerable<string> Items
        {
            get
            {
                var items = new List<string>
                {
                    "Вход.",
                    "Регистрация."
                };
                return items;
            }
        }
    }

}
