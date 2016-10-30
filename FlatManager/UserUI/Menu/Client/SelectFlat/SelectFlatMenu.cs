using System;
using System.Collections.Generic;

namespace FlatManager.UserUI.Menu.Client.SelectFlat
{
    public class SelectFlatMenu : MenuDisplayer
    {
        public SelectFlatMenu(IEnumerable<string> flats) : base(flats, OnDisplayingMenu)
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
