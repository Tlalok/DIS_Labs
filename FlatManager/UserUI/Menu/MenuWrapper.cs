using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatManager.UserUI.Menu
{
    public class MenuWrapper
    {
        private readonly List<Action> actions;
        private readonly IMenuDisplayer menuDisplayer;
        private readonly Action<int> action;
        private readonly List<int> exitOnAction;
        public MenuWrapper(IMenuDisplayer menuDisplayer, List<Action> actions, List<int> exitOnAction = null)
        {
            this.exitOnAction = exitOnAction ?? new List<int>();
            if (menuDisplayer == null) throw new ArgumentNullException(nameof(menuDisplayer));
            if (actions == null) throw new ArgumentNullException(nameof(actions));
            if ((menuDisplayer.Items.Count - 1) != actions.Count)
                throw new ArgumentException();

            this.menuDisplayer = menuDisplayer;
            this.actions = actions;
        }

        public MenuWrapper(IMenuDisplayer menuDisplayer, Action<int> action)
        {

            if (menuDisplayer == null) throw new ArgumentNullException(nameof(menuDisplayer));
            if (action == null) throw new ArgumentNullException(nameof(action));

            this.menuDisplayer = menuDisplayer;
            this.action = action;
        }

        public void Run()
        {
            if (action == null)
                RunActionSelector();
            else
                RunActionIndexSelector();
        }

        private void RunActionSelector()
        {
            do
            {
                var actionIndex = menuDisplayer.Run() - 1;
                if (actionIndex == actions.Count)
                {
                    break;
                }
                actions[actionIndex]();
                if (exitOnAction.Contains(actionIndex))
                {
                    break;
                }
            } while (true);
        }

        private void RunActionIndexSelector()
        {
            do
            {
                var actionIndex = menuDisplayer.Run() - 1;
                if (actionIndex == (menuDisplayer.Items.Count - 1))
                {
                    break;
                }
                action(actionIndex);
            } while (true);
        }
    }
}
