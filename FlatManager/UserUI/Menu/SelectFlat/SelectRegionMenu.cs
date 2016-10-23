using System;
using System.Collections.Generic;

namespace FlatManager.UserUI.Menu.SelectFlat
{
    public class SelectRegionMenu : MenuDisplayer
    {
        public SelectRegionMenu(IEnumerable<string> regions) : base(regions, () => Console.WriteLine("Выберите область:"))
        {
        }
    }
}
