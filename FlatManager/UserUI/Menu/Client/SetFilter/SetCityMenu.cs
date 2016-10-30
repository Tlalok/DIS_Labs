using System;
using System.Collections.Generic;

namespace FlatManager.UserUI.Menu.Client.SetFilter
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
