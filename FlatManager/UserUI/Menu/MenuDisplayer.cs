using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatManager.UserUI.Menu
{
    public class MenuDisplayer
    {
        private readonly List<string> items;
        private readonly Action onShowingMenu;
        private readonly string backMenuItemName = "Назад.";

        public List<string> Items
        {
            get { return items; }
        }

        public MenuDisplayer(IEnumerable<string> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            this.items = items.Concat(new [] { backMenuItemName }).ToList();
            onShowingMenu = () => { };
        }

        public MenuDisplayer(IEnumerable<string> items, Action onShowingMenu) : this(items)
        {
            if (onShowingMenu == null) throw new ArgumentNullException(nameof(onShowingMenu));

            this.onShowingMenu = onShowingMenu;
        }

        public int Run()
        {
            int pickedItem;
            do
            {
                onShowingMenu();
                ShowMenu();
                pickedItem = EnterAnswer(1, items.Count);
            } while (pickedItem < 1 || pickedItem > items.Count);
            return pickedItem;
        }

        private void ShowMenu()
        {
            foreach (var i in Enumerable.Range(1, items.Count))
            {
                Console.WriteLine("{0}. {1}", i, items[i - 1]);
            }
        }

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
