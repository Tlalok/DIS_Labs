using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatManager.UserUI.Menu.SetFilter
{
    public class SetRangeFilterMenu : MenuDisplayer
    {
        public SetRangeFilterMenu() : base(Items)
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
