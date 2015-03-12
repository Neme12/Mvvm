using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Neme.Mvvm
{
    public class AutomaticCommand<TParameter> : AutomaticCommandShared
    {
        private readonly Action<TParameter> execute;

        public AutomaticCommand(Action<TParameter> execute, Func<bool> canExecute = null)
            : base(canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            this.execute = execute;
        }

        // ICommand

        public override void Execute(object parameter)
        {
            execute((TParameter)parameter);
        }
    }
}
