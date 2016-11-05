using System;
using System.Collections.Generic;
using System.Linq;
using FlatManager.Managers;
using FlatManager.Models.FlatModels;
using FlatManager.UserUI.Menu;
using FlatManager.UserUI.Menu.Owner;

namespace FlatManager.UserUI
{
    public class OwnerUI : UserUI
    {
        private Owner owner;
        public OwnerUI(BaseFlatManager flatManager) : base(flatManager) { }

        public override void Run()
        {
            var menu = new MenuWrapper(
                new OwnerMainMenu(),
                new List<Action>
                { 
                    Login,
                    Registration
                });
            menu.Run();
        }

        private void Login()
        {
            flatManager.ReadFlats();
            var loginMenu = new LoginMenu(flatManager.Owners);
            var ownerId = loginMenu.Run();
            owner = flatManager.Owners.Single(ow => ow.Id == ownerId);
            OwnerActions();
            flatManager.WriteFlats();
        }

        private void Registration()
        {
            flatManager.ReadFlats();
            var newOwner = new Owner();
            var menu = new MenuWrapper(
                   new CreateOwnerMenu(newOwner), 
                   new List<Action>
                   {
                       () => newOwner.Name = EnterStringValue(1, 30),
                       () => newOwner.Secondname = EnterStringValue(1, 30),
                       () => newOwner.PhoneNumber = EnterStringValue(1, 12),
                       () =>
                       {
                           if (ValidateOwner(newOwner))
                           {
                               flatManager.CreateOwner(newOwner);
                               Console.WriteLine("Аккаунт был создан.");
                           }
                       }
                   });
            menu.Run();
            flatManager.WriteFlats();
        }

        private void OwnerActions()
        {
            var menu = new MenuWrapper(
                   new OwnerActionsMenu(), 
                   new List<Action>
                   {
                       CreateFlat,
                       SelectFlat,
                   });
            menu.Run();
        }

        private void SelectFlat()
        {
            var flats = flatManager.GetFlatList(owner.Id)
                                   .ToList();
            Func<IEnumerable<string>> flatSelector = () => flatManager.GetFlatList(owner.Id).Select(f => f.Value);
            var menu = new MenuWrapper(
                   new SelectFlatMenu(flatSelector),
                   pickedFlat => ShowFlatMenu(flats[pickedFlat].Key)
                   );
            menu.Run();
        }

        private void ShowFlatMenu(int flatId)
        {
            var flat = flatManager.GetFlat(flatId, false);
            var menu = new MenuWrapper(
                   new FlatActionsMenu(flat), 
                   new List<Action>
                   {
                       CreateFlat,
                       () => UpdateFlat(flatId),
                       () => DeleteFlat(flatId)
                   },
                   new List<int> { 2 });
            menu.Run();
        }

        private void CreateFlat()
        {
            var newFlat = new Flat();
            newFlat.Owner = owner;
            var menu = new MenuWrapper(
                   new FlatUpdateMenu(newFlat), 
                   new List<Action>
                   {
                       () => newFlat.RentCostPerMonth = EnterIntegerValue(1),
                       () => newFlat.RoomCount = EnterIntegerValue(1, 5),
                       () => newFlat.Square = EnterIntegerValue(1),
                       () => UpadeAddress(newFlat.Address),
                       () =>
                       {
                           if (ValidateFlat(newFlat))
                           {
                               flatManager.CreateFlat(newFlat);
                               Console.WriteLine("Квартира была создана");
                           }
                       }
                   });
            menu.Run();
        }

        private bool ValidateFlat(Flat flat)
        {
            var valid = flat.RentCostPerMonth != 0
                   && flat.RoomCount != 0
                   && flat.Square != 0
                   && !string.IsNullOrEmpty(flat.Address.City)
                   && !string.IsNullOrEmpty(flat.Address.Street)
                   && flat.Address.HouseNumber != 0
                   && flat.Address.FlatNumber != 0;
            if (!valid)
            {
                Console.WriteLine("Вы не заполнили все поля.");
            }
            return valid;
        }

        private bool ValidateOwner(Owner owner)
        {
            var valid = !string.IsNullOrEmpty(owner.Name)
                        && !string.IsNullOrEmpty(owner.Secondname)
                        && !string.IsNullOrEmpty(owner.PhoneNumber);
            if (!valid)
            {
                Console.WriteLine("Вы не заполнили все поля.");
            }
            if (!flatManager.IsUniqueOwner(owner))
            {
                Console.WriteLine("Пользователь с таким телефон уже зарегистрирован.");
                return false;
            }
            return valid;
        }

        private void UpdateFlat(int flatId)
        {
            var flat = (Flat)flatManager.GetFlat(flatId, false).Clone();
            var menu = new MenuWrapper(
                   new FlatUpdateMenu(flat),
                   new List<Action>
                   {
                       () => flat.RentCostPerMonth = EnterIntegerValue(1),
                       () => flat.RoomCount = EnterIntegerValue(1, 5),
                       () => flat.Square = EnterIntegerValue(1),
                       () => UpadeAddress(flat.Address),
                       () =>
                       {
                            flatManager.UpdateFlat(flat);
                            Console.WriteLine("Квартира была обновлена");
                       }
                   });
            menu.Run();
        }

        private void DeleteFlat(int flatId)
        {
            flatManager.DeleteFlat(flatId);
        }

        private void UpadeAddress(Address address)
        {
            var menu = new MenuWrapper(
                   new AddressUpdateMenu(address), 
                   new List<Action>
                   {
                       () => address.Region = EnterStringValue(),
                       () => address.City = EnterStringValue(1),
                       () => address.Street = EnterStringValue(1),
                       () => address.HouseNumber = EnterIntegerValue(1),
                       () => address.FlatNumber = EnterIntegerValue(1)
                   });
            menu.Run();
        }

        private int EnterIntegerValue(int lowerBound, int upperBound = int.MaxValue)
        {
            bool numberParsed;
            int result;
            do
            {
                Console.Write("Введите значение: ");
                var answer = Console.ReadLine();
                numberParsed = int.TryParse(answer, out result);
            } while (!numberParsed || result < lowerBound || result > upperBound);
            return result;
        }

        private string EnterStringValue(int minLength = 0, int maxLength = int.MaxValue)
        {
            string result;
            do
            {
                Console.Write("Введите значение: ");
                result = Console.ReadLine().Trim();
            } while (result.Length < minLength || result.Length > maxLength);
            return result;
        }
    }
}
