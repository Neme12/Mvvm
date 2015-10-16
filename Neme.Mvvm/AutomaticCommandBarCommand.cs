using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neme.Mvvm
{
    public class AutomaticCommandBarCommand : IAutomaticCommandBarCommand
    {
        private readonly Action execute;
        private readonly Func<Availability> availability;

        public AutomaticCommandBarCommand()
        {
            throw new NotSupportedException();
        }

        public AutomaticCommandBarCommand(Action execute, Func<Availability> availability = null)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            this.execute = execute;
            this.availability = availability;
        }

        public AutomaticCommandBarCommand(Action execute, Func<bool> isVisible, Func<bool> isEnabled)
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

        // IAutomaticCommandBarCommand

        public void RaiseAvailabilityChanged()
        {
            AvailabilityChanged?.Invoke(this, EventArgs.Empty);
        }

        public void RaiseAvailabilityChanged(object sender, EventArgs e)
        {
            RaiseAvailabilityChanged();
        }

        // ICommandBarCommand

        public Availability Availability => availability == null ? Availability.Available : availability();

        public void Execute()
        {
            execute();
        }

        public event EventHandler AvailabilityChanged;
    }
}
