using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neme.Mvvm.Commands
{
    public class ControlledSmartCommand : SmartCommandNotifier, IControlledSmartCommand
    {
        private readonly Action execute;
        private Availability availibility;

        public ControlledSmartCommand(Action execute, Availability availibility)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            this.execute = execute;
            this.availibility = availibility;
        }

        private void RaiseAvailabilityChanged()
        {
            AvailabilityChanged?.Invoke(this, EventArgs.Empty);
        }

        // IControlledSmartCommand

        public new Availability Availability
        {
            get { return availibility; }
            set { availibility = value; RaiseAvailabilityChanged(); }
        }

        // ISmartCommand

        public override void Execute()
        {
            execute();
        }

        public override event EventHandler AvailabilityChanged;
    }
}
