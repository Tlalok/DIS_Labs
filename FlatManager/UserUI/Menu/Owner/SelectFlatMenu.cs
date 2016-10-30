using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatManager.UserUI.Menu.Owner
{
    public class SelectFlatMenu : MenuDisplayer
    {
        public SelectFlatMenu(Func<IEnumerable<string>> flatSelector) : base(flatSelector, OnDisplayingMenu)
        {

        }

        private static Action OnDisplayingMenu
        {
            get
            {
                return () =>
                {
                    Console.WriteLine();
                    Console.WriteLine("Выберите квартиру:");
                };
            }
        }
    }
}
