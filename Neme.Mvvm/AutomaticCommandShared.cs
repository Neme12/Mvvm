using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Neme.Mvvm
{
    public abstract class AutomaticCommandShared : IAutomaticCommand
    {
        private readonly Func<bool> canExecute;

        public AutomaticCommandShared(Func<bool> canExecute)
        {
            this.canExecute = canExecute;
        }

        // IAutomaticCommand

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            RaiseCanExecuteChanged();
        }

        // ICommand

        public bool CanExecute(object parameter) => canExecute == null ? true : canExecute();

        public abstract void Execute(object parameter);

        public event EventHandler CanExecuteChanged;
    }
}
