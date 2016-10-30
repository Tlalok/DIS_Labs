using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlatManager.Models;

namespace FlatManager.UserUI.Menu.SetFilter
{
    public class SelectFilterMenu : MenuDisplayer
    {
        public SelectFilterMenu(FlatFilterArgs filter) : base(Items, OnDisplayingMenu(filter))
        {
        }

        private static IEnumerable<string> Items
        {
            get
            {
                var items = new List<string>
                {
                    "Фильтр площади.",
                    "Фильтр кол-ва комнат.",
                    "Фильтр цены.",
                    "Фильтр города."
                };
                return items;
            }
        }

        private static Action OnDisplayingMenu(FlatFilterArgs filter)
        {
            return () =>
            {
                Console.WriteLine();
                Console.WriteLine("Площадь (S):        {0, 6} <= S  <= {1, 6}", filter.Square.Min, filter.Square.Max);
                Console.WriteLine("Кол-во комнат (RC): {0, 6} <= RC <= {1, 6}", filter.RoomCount.Min,
                    filter.RoomCount.Max);
                Console.WriteLine("Цена (C):           {0, 6} <= C  <= {1, 6}", filter.Cost.Min, filter.Cost.Max);
                Console.WriteLine("Город (T):          {0}", filter.City);
            };
        }
    }
}
