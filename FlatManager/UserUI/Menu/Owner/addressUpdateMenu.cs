using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlatManager.Models.FlatModels;

namespace FlatManager.UserUI.Menu.Owner
{
    public class AddressUpdateMenu : MenuDisplayer
    {
        public AddressUpdateMenu(Address address) : base(Items, OnDisplayingMenu(address)) { }

        private static IEnumerable<string> Items
        {
            get
            {
                var items = new List<string>
                {
                    "Установить область.",
                    "Установить город.",
                    "Установить улицу.",
                    "Установить дом.",
                    "Установить квартиру."
                };
                return items;
            }
        }

        private static Action OnDisplayingMenu(Address address)
        {
            return () =>
            {
                Console.WriteLine();
                Console.WriteLine("Область:  {0}", address.Region);
                Console.WriteLine("Город:    {0}", address.City);
                Console.WriteLine("Улица:    {0}", address.Street);
                Console.WriteLine("Дом:      {0}", address.HouseNumber == 0 ? "" : address.HouseNumber.ToString());
                Console.WriteLine("Квартира: {0}", address.FlatNumber == 0 ? "" : address.FlatNumber.ToString());
            };
        }
    }
}
