using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neme.Mvvm.Commands
{
    public class AutomaticSmartCommand : SmartCommandNotifier, IAutomaticSmartCommand
    {
        private readonly Action execute;
        private readonly Func<Availability> availability;

        public AutomaticSmartCommand()
        {
            throw new NotSupportedException();
        }

        public AutomaticSmartCommand(Action execute, Func<Availability> availability = null)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            this.execute = execute;
            this.availability = availability;
        }

        public AutomaticSmartCommand(Action execute, Func<bool> isVisible, Func<bool> isEnabled)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            this.execute = execute;
            this.availability = () => GetAvailability(isVisible, isEnabled);
        }

        private Availability GetAvailability(Func<bool> isVisible, Func<bool> isEnabled)
        {
            if (isVisible == null || isVisible())
                return isEnabled == null || isEnabled() ? Availability.Available : Availability.Disabled;
            else
                return Availability.Hidden;
        }

        // IAutomaticSmartCommand

        public void RaiseAvailabilityChanged()
        {
            AvailabilityChanged?.Invoke(this, EventArgs.Empty);
        }

        public void RaiseAvailabilityChanged(object sender, EventArgs e)
        {
            RaiseAvailabilityChanged();
        }

        // ISmartCommand

        public new Availability Availability => availability == null ? Availability.Available : availability();

        public override void Execute()
        {
            execute();
        }

        public override event EventHandler AvailabilityChanged;
    }
}
