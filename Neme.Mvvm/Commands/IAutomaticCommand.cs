using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Neme.Mvvm.Commands
{
    public interface IAutomaticCommand : ICommand
    {
        void RaiseCanExecuteChanged(object sender = null, EventArgs e = null);
    }

    public interface IAutomaticSmartCommand : ISmartCommand
    {
        void RaiseAvailabilityChanged(object sender = null, EventArgs e = null);
    }
}
