using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSingleScopeTransient.Interfaces
{
    public interface ITransientServices
    {
        Guid GetTaskID();
    }
}
