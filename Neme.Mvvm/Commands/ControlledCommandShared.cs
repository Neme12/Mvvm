using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neme.Mvvm.Commands
{
    public abstract class ControlledCommandShared : IControlledCommand
    {
        private bool isEnabled;

        public ControlledCommandShared(bool isEnabled)
        {
            this.isEnabled = isEnabled;
        }

        protected void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        // IControlledCommand

        public bool IsEnabled
        {
            get { return isEnabled; }
            set { isEnabled = value; RaiseCanExecuteChanged(); }
        }

        // ICommand

        public bool CanExecute(object parameter) => isEnabled;

        public abstract void Execute(object parameter);

        public event EventHandler CanExecuteChanged;
    }
}
