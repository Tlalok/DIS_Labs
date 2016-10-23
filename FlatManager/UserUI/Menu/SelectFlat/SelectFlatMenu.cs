using System;
using System.Collections.Generic;

namespace FlatManager.UserUI.Menu.SelectFlat
{
    public class SelectFlatMenu : MenuDisplayer
    {
        public SelectFlatMenu(IEnumerable<string> flats) : base(flats, () => Console.WriteLine("Выберите квартиру:"))
        {
            
        }
    }
}
