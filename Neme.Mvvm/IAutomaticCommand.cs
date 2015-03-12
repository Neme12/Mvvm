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
        void RaiseCanExecuteChanged();
    }

    public interface IAutomaticCommandBarCommand : ICommandBarCommand
    {
        void RaiseAvailabilityChanged();
    }
}
