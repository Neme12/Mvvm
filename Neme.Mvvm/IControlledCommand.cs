using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Neme.Mvvm
{
    public interface IControlledCommand : ICommand
    {
        bool IsEnabled { get; set; }
    }

    public interface IControlledCommandBarCommand : ICommandBarCommand
    {
        new Availability Availability { get; set; }
    }
}
