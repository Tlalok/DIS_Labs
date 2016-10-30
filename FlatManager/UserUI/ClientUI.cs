using System;
using System.Collections.Generic;
using System.Linq;
using FlatManager.Managers;
using FlatManager.Models;
using FlatManager.UserUI.Menu;
using FlatManager.UserUI.Menu.Client;
using FlatManager.UserUI.Menu.Client.SelectFlat;
using FlatManager.UserUI.Menu.Client.SetFilter;

namespace FlatManager.UserUI
{
    public class ClientUI : UserUI
    {
        public ClientUI(BaseFlatManager flatManager) : base(flatManager) { }
        private FlatFilterArgs filter = new FlatFilterArgs();

        public override void Run()
        {
            var menu = new MenuWrapper(
                new ClientMainMenu(),
                new List<Action>
                {
                    SelectRegion,
                    SetFilter,
                });
            menu.Run();
        }

        #region Flat search
        private void SelectRegion()
        {
            flatManager.ReadFlats();
            var regions = flatManager.GetRegionList()
                                     .Select(f => string.IsNullOrEmpty(f) ? "Минск" : f)
                                     .ToList();
            var menu = new MenuWrapper(
                new SelectRegionMenu(regions),
                (pickedRegion) => SelectFlat(regions[pickedRegion])
                );
            menu.Run();
            flatManager.WriteFlats();
        }

        private void SelectFlat(string region)
        {
            var flats = flatManager.GetFlatList(region, f => filter.Predicate(f))
                                   .ToList();
            var menu = new MenuWrapper(
                new SelectFlatMenu(flats.Select(f => f.Value)),
                (pickedFlat) => ShowFlat(flats[pickedFlat].Key));
            menu.Run();
        }

        private void ShowFlat(int flatId)
        {
            var flat = flatManager.GetFlat(flatId);
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
            Console.WriteLine();
            Console.WriteLine("Нажмите любой кнопку, чтобы перейти назад.");
            Console.ReadKey();
        }
        #endregion

        #region Set filter
        private void SetFilter()
        {
            var menu = new MenuWrapper(
                new SelectFilterMenu(filter), 
                new List<Action>
                {
                    () => SetRangeFilter(filter.Square),
                    () => SetRangeFilter(filter.RoomCount),
                    () => SetRangeFilter(filter.Cost),
                    () => SetCity(filter)
                });
            menu.Run();
        }

        private void SetRangeFilter(Range range)
        {
            var menu = new MenuWrapper(
                new SetRangeFilterMenu(),
                new List<Action>
                {
                    () => range.Max = EnterIntegerValue(0, int.MaxValue),
                    () => range.Max = null,
                    () => range.Min = EnterIntegerValue(0, int.MaxValue),
                    () => range.Min = null
                } 
            );
            menu.Run();
        }

        private void SetCity(FlatFilterArgs filter)
        {
            var menu = new MenuWrapper(
                new SetCityMenu(),
                new List<Action>
                {
                    () =>
                    {
                        Console.Write("Введите город: ");
                        filter.City = Console.ReadLine();
                    },
                    () => filter.City = null
                }
            );
            menu.Run();
        }

        private int EnterIntegerValue(int lowerBound, int upperBound)
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
        #endregion
    }
}
