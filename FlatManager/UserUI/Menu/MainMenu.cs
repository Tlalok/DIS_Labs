using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatManager.UserUI.Menu
{
    public class MainMenu : MenuDisplayer
    {
        public MainMenu() : base(Items, Console.WriteLine) { }

        private static IEnumerable<string> Items
        {
            get
            {
                var items = new List<string>
                {
                    "Редактирование квартир.",
                    "Поиск квартиры."
                };
                return items;
            }
        }
    }
}
