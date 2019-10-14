using kubetask_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kubetask_api.Data.Repositories
{
    public interface ITaskRepository: IRepository<KTask>
    {
    }
}
