﻿using System.Collections.Generic;

namespace FlatManager.UserUI.Menu
{
    public class ClientMainMenu : MenuDisplayer
    {
        public ClientMainMenu() : base(Items)
        {
        }

        private static IEnumerable<string> Items
        {
            get
            {
                var items = new List<string>
                {
                    "Поиск квартиры.",
                    "Установка фильтра."
                };
                return items;
            }
        }
    }
}
