using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Neme.Mvvm.Commands
{
    public class AutomaticCommand : AutomaticCommandShared
    {
        private readonly Action execute;

        public AutomaticCommand(Action execute, Func<bool> canExecute = null)
            : base(canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            this.execute = execute;
        }

        // ICommand

        public override void Execute(object parameter)
        {
            execute();
        }
    }
}
