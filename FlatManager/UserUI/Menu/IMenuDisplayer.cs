using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatManager.UserUI.Menu
{
    public interface IMenuDisplayer
    {
        List<string> Items { get; }

        int Run();
    }
}
