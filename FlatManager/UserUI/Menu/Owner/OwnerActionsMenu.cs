using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FlatManager.Models.FlatModels;

namespace FlatManager.UserUI.Menu.Owner
{
    public class OwnerActionsMenu : MenuDisplayer
    {
        public OwnerActionsMenu() : base(Items, Console.WriteLine) { }

        private static IEnumerable<string> Items
        {
            get
            {
                var items = new List<string>
                {
                    "Добавить квартиру.",
                    "Редактировать существующие.",
                };
                return items;
            }
        }
    }
}
