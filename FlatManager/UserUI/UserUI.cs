using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlatManager.Managers;

namespace FlatManager.UserUI
{
    public abstract class UserUI
    {
        protected BaseFlatManager flatManager;

        public UserUI(BaseFlatManager flatManager)
        {
            this.flatManager = flatManager;
        }

        public abstract void Run();
    }
}
