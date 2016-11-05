using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlatManager.Models.FlatModels;

namespace FlatManager.UserUI.Menu.Owner
{
    public class CreateOwnerMenu : MenuDisplayer
    {
        public CreateOwnerMenu(Models.FlatModels.Owner owner) : base(Items, OnDisplayingMenu(owner))
        {
        }

        private static IEnumerable<string> Items
        {
            get
            {
                var items = new List<string>
                {
                    "Установить имя.",
                    "Установить фамилию.",
                    "Установить телефон.",
                    "Сохранить."
                };
                return items;
            }
        }

        private static Action OnDisplayingMenu(Models.FlatModels.Owner owner)
        {
            return () =>
            {
                Console.WriteLine();
                Console.WriteLine("Имя:     {0}", owner.Name);
                Console.WriteLine("Фамилия: {0}", owner.Secondname);
                Console.WriteLine("Телефон: {0}", owner.PhoneNumber);
            };
        }
    }
}
