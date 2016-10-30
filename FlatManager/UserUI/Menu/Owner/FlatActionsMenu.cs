using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlatManager.Models.FlatModels;

namespace FlatManager.UserUI.Menu.Owner
{
    public class FlatActionsMenu : MenuDisplayer
    {
        public FlatActionsMenu(Flat flat) : base(Items, OnDisplayingMenu(flat)) { }

        private static IEnumerable<string> Items
        {
            get
            {
                var items = new List<string>
                {
                    "Добавить квартиру.",
                    "Обновить квартиру.",
                    "Удалить квартиру."
                };
                return items;
            }
        }

        private static Action OnDisplayingMenu(Flat flat)
        {
            return () =>
            {
                Console.WriteLine();
                Console.WriteLine("Владелец:");
                Console.WriteLine("Имя:     {0}", flat.Owner.Name);
                Console.WriteLine("Телефон: {0}", flat.Owner.PhoneNumber);
                Console.WriteLine("================================");
                Console.WriteLine("ID:                {0}", flat.Id);
                Console.WriteLine("Цена за месяц:     {0}", flat.RentCostPerMonth);
                Console.WriteLine("Кол-во комнат:     {0}", flat.RoomCount);
                Console.WriteLine("Площадь:           {0}", flat.Square);
                Console.WriteLine("Адрес:             {0}", flat.Address);
                Console.WriteLine("Кол-во просмотров: {0}", flat.Views);
            };
        }
    }
}
