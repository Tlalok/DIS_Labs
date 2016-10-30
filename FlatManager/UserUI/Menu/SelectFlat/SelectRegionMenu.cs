using System;
using System.Collections.Generic;

namespace FlatManager.UserUI.Menu.SelectFlat
{
    public class SelectRegionMenu : MenuDisplayer
    {
        public SelectRegionMenu(IEnumerable<string> regions) : base(regions, OnDisplayingMenu)
        {
        }

        private static Action OnDisplayingMenu
        {
            get
            {
                return () =>
                {
                    Console.WriteLine();
                    Console.WriteLine("Выберите область:");
                };
            }
        }
    }
}
