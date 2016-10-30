using System;
using System.Collections.Generic;

namespace FlatManager.UserUI.Menu.Client.SetFilter
{
    public class SetRangeFilterMenu : MenuDisplayer
    {
        public SetRangeFilterMenu() : base(Items, Console.WriteLine)
        {
            
        }
        private static IEnumerable<string> Items
        {
            get
            {
                var items = new List<string>
                {
                    "Ввести верхнюю границу.",
                    "Очистить верхнюю границу.",
                    "Ввесит нижнюю границу.",
                    "Очистить нижнюю границу."
                };
                return items;
            }
        }
    }
}
