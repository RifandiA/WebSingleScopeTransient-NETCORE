using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSingleScopeTransient.Interfaces;

namespace WebSingleScopeTransient.Services
{
    public class TaskService : ITransientServices, IScopeServices, ISingletonServices
    {
        Guid id;

        public TaskService()
        {
            id = Guid.NewGuid();
        }
        public Guid GetTaskID()
        {
            return id;
        }
    }
}
