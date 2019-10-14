using kubetask_api.DTO;
using kubetask_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kubetask_api.Services.Interfaces
{
    public interface ITaskService
    {
        Task<KTask> GetTask(Guid id);
        Task<IEnumerable<KTask>> ListTasks();
        Task AddTask(TaskData taskData);
        Task DeleteTask(Guid id);
        Task Update(Guid taskID, TaskData taskData);
    }
}
