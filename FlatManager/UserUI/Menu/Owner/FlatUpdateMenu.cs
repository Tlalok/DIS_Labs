using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlatManager.Models;
using FlatManager.Models.FlatModels;

namespace FlatManager.UserUI.Menu.Owner
{
    public class FlatUpdateMenu : MenuDisplayer
    {
        public FlatUpdateMenu(Flat flat) : base(Items, OnDisplayingMenu(flat))
        {
        }

        private static IEnumerable<string> Items
        {
            get
            {
                var items = new List<string>
                {
                    "Установить цену за месяц.",
                    "Установить кол-во комнат.",
                    "Установить площадь.",
                    "Установить адрес.",
                    "Сохранить."
                };
                return items;
            }
        }

        private static Action OnDisplayingMenu(Flat flat)
        {
            return () =>
            {
                Console.WriteLine();
                Console.WriteLine("Цена за месяц:     {0}", flat.RentCostPerMonth == 0 ? "" : flat.RentCostPerMonth.ToString());
                Console.WriteLine("Кол-во комнат:     {0}", flat.RoomCount == 0 ? "" : flat.RoomCount.ToString());
                Console.WriteLine("Площадь:           {0}", flat.Square == 0 ? "" : flat.Square.ToString());
                Console.WriteLine("Адрес:             {0}", flat.Address);
            };
        }
    }
}
