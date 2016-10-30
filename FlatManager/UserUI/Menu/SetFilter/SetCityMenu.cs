using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatManager.UserUI.Menu.SetFilter
{
    public class SetCityMenu : MenuDisplayer
    {
        public SetCityMenu() : base(Items, Console.WriteLine)
        {
            
        }
        private static IEnumerable<string> Items
        {
            get
            {
                var items = new List<string>
                {
                    "Установить город",
                    "Очистить город"
                };
                return items;
            }
        }
    }
}
