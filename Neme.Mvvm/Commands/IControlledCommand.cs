using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Neme.Mvvm.Commands
{
    public interface IControlledCommand : ICommand
    {
        bool IsEnabled { get; set; }
    }

    public interface IControlledSmartCommand : ISmartCommand
    {
        new Availability Availability { get; set; }
    }
}
