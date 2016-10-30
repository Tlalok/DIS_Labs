using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatManager.UserUI.Menu.Owner
{
    public class LoginMenu : IMenuDisplayer
    {
        private List<Models.FlatModels.Owner> owners;

        public LoginMenu(List<Models.FlatModels.Owner> owners)
        {
            if (owners == null) throw new ArgumentNullException(nameof(owners));
            this.owners = owners;
        }

        public List<string> Items { get; }

        public int Run()
        {
            string enteredPhone;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Введите ваш номер телефона:");
                enteredPhone = Console.ReadLine();
                if (string.Equals(enteredPhone, "exit", StringComparison.InvariantCultureIgnoreCase))
                {
                    return -1;
                }
            } while (!owners.Any(ow => string.Equals(ow.PhoneNumber, enteredPhone, StringComparison.InvariantCultureIgnoreCase)));
            return owners.First(ow => string.Equals(ow.PhoneNumber, enteredPhone, StringComparison.InvariantCultureIgnoreCase)).Id;
        }
    }
}
