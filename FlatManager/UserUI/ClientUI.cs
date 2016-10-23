using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlatManager.Managers;
using FlatManager.Models.FlatModels;
using static FlatManager.Managers.BaseFlatManager;
using FlatManager.Models;

namespace FlatManager.UserUI
{
    public class ClientUI : UserUI
    {
        public ClientUI(BaseFlatManager flatManager) : base(flatManager) { }
        private FlatFilterArgs filter;

        public override void Run()
        {
            do
            {
                ShowMenu();
                var pickedItem = EnterAnswer(1, 3);
                if (pickedItem == 1)
                {
                    SelectRegion();
                }
                else if (pickedItem == 2)
                {
                    SetFilter();
                }
                else
                {
                    break;
                }
            } while (true);
        }

        private void ShowMenu()
        {
            Console.WriteLine("1. Поиск квартиры.");
            Console.WriteLine("2. Установка фильтра.");
            Console.WriteLine("2. Назад.");
        }

        #region Flat search
        private void SelectRegion()
        {
            flatManager.ReadFlats();
            var regions = flatManager.GetRegionList().ToList();
            int pickedRegion = -1;
            do
            {
                ShowRegionList(regions);
                pickedRegion = EnterAnswer(1, regions.Count + 1) - 1;
                if (pickedRegion != regions.Count)
                {
                    SelectFlat(regions[pickedRegion]);
                }
                else
                {
                    break;
                }
            } while (true);
            flatManager.WriteFlats();
        }

        private void SelectFlat(string region)
        {
            int pickedFlat = -1;
            var flats = flatManager.GetFlatList(f => string.Equals(f.Address.Region, region, StringComparison.InvariantCultureIgnoreCase) && filter(f))
                                   .ToList();
            do
            {
                ShowFlatList(flats.Select(f => f.Value));
                pickedFlat = EnterAnswer(1, flats.Count + 1) - 1;
                if (pickedFlat != flats.Count)
                {
                    ShowFlat(flats[pickedFlat].Key);
                }
                else
                {
                    break;
                }
            } while (true);
        }

        private void ShowRegionList(IEnumerable<string> regions)
        {
            Console.WriteLine("Выберите область:");
            var i = 1;
            regions = regions.Select(f => string.IsNullOrEmpty(f) ? "Минск" : f);
            foreach (var region in regions)
            {
                Console.WriteLine("{0}. {1}", i++,  region);
            }
            Console.WriteLine("{0}. Назад", i);
        }

        private void ShowFlatList(IEnumerable<string> flats)
        {
            Console.WriteLine("Выберите квартиру:");
            var i = 1;
            foreach (var flat in flats)
            {
                Console.WriteLine("{0}. {1}", i++, flat);
            }
            Console.WriteLine("{0}. Назад", i);
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
        private void ShowCurrentFilter()
        {
            Console.WriteLine("Площадь (S):        {0, 6} <= S  <= {1, 6}", filter.Square.Min, filter.Square.Max);
            Console.WriteLine("Кол-во комнат (RC): {0, 6} <= RC <= {1, 6}", filter.RoomCount.Min, filter.RoomCount.Max);
            Console.WriteLine("Цена (C):           {0, 6} <= C  <= {1, 6}", filter.Cost.Min, filter.Cost.Max);
            Console.WriteLine("Город (T):          {0}", filter.City);
        }

        private void ShowFilterMenu()
        {
            Console.WriteLine("1. Фильтр площади.");
            Console.WriteLine("2. Фильтр кол-ва комнат.");
            Console.WriteLine("3. Фильтр цены.");
            Console.WriteLine("4. Фильтр города.");
            Console.WriteLine("5. Назад.");
        }

        private void SetFilter()
        {

        }
        #endregion

        private int EnterAnswer(int lowerBound, int upperBound)
        {
            bool numberParsed;
            int result;
            do
            {
                Console.Write("Введите ответ: ");
                var answer = Console.ReadLine();
                numberParsed = int.TryParse(answer, out result);
            } while (!numberParsed || result < lowerBound || result > upperBound);
            return result;
        }
    }
}
