using Neme.Mvvm.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Neme.Mvvm.Converters
{
    public class SmartCommandConverter : OneWayConverter<ISmartCommand, ICommand>
    {
        public override ICommand Convert(ISmartCommand value) => new SmartCommandHolder(value);

        class SmartCommandHolder : ICommand
        {
            private readonly ISmartCommand command;

            public SmartCommandHolder(ISmartCommand command)
            {
                this.command = command;
                command.AvailabilityChanged += (sender, e) => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }

            public void Execute(object parameter)
            {
                command.Execute();
            }

            public bool CanExecute(object parameter) => command.Availability == Availability.Available;

            public event EventHandler CanExecuteChanged;
        }
    }
}
