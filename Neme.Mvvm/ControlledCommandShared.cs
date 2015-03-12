using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neme.Mvvm
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
            var handler = CanExecuteChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        // IControlledCommand

        public bool IsEnabled
        {
            get { return isEnabled; }
            set { isEnabled = value; RaiseCanExecuteChanged(); }
        }

        // ICommand

        public bool CanExecute(object parameter)
        {
            return isEnabled;
        }

        public abstract void Execute(object parameter);

        public event EventHandler CanExecuteChanged;
    }
}
