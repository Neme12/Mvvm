using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Neme.Mvvm
{
    public interface IAutomaticCommand : ICommand
    {
        void RaiseCanExecuteChanged(object sender = null, EventArgs e = null);
    }

    public interface IAutomaticCommandBarCommand : ICommandBarCommand
    {
        void RaiseAvailabilityChanged(object sender = null, EventArgs e = null);
    }
}
