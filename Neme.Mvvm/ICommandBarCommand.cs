using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neme.Mvvm
{
    public interface ICommandBarCommand
    {
        event EventHandler AvailabilityChanged;

        Availability Availability { get; }

        void Execute();
    }
}
