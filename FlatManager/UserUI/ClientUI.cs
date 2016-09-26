using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlatManager.Managers;

namespace FlatManager.UserUI
{
    public class ClientUI : UserUI
    {
        public ClientUI(BaseFlatManager flatManager) : base(flatManager) { }

        public override void Run()
        {
            var regions = flatManager.GetRegionList().ToList();
            ShowRegionList(regions);
            var regionIndex = EnterAnswer(1, regions.Count);

        }

        private void ShowRegionList(IEnumerable<string> regions)
        {
            Console.WriteLine("Выберите регион:");
            var i = 1;
            foreach (var region in regions)
            {
                Console.WriteLine("{0}. {1}", i++, region);
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
            } while (!numberParsed || result < lowerBound || result > upperBound );
            return result;
        }
    }
}
