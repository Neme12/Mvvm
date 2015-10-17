using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neme.Mvvm.Commands
{
    public abstract class SmartCommandNotifier : ISmartCommand, INotifyPropertyChanged
    {
        private readonly PropertyChangedEventArgs AvailabilityChangedEventArgs =
            new PropertyChangedEventArgs(nameof(Availability));

        public SmartCommandNotifier()
        {
            AvailabilityChanged += (sender, e) => PropertyChanged?.Invoke(sender, AvailabilityChangedEventArgs);
        }

        // ISmartCommand

        public Availability Availability
        {
            get { throw new NotImplementedException(); }
        }

        public abstract void Execute();

        public abstract event EventHandler AvailabilityChanged;

        // INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
