using kubetask_api.Data.Repositories;
using kubetask_api.DTO;
using kubetask_api.Models;
using kubetask_api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kubetask_api.Services
{
    public class TaskService: ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            this._taskRepository = taskRepository;
        }

        public async Task<KTask> GetTask(Guid id)
        {
            return await this._taskRepository.Get(id);
        }

        public async Task<IEnumerable<KTask>> ListTasks()
        {
            return await this._taskRepository.List();
        }

        public async Task AddTask(TaskData taskData)
        {
           await this._taskRepository.AddAsync(new KTask() { Name = taskData.Name, Description = taskData.Description });
        }

        public async Task DeleteTask(Guid id)
        {
            var task = await this._taskRepository.Get(id);
            await this._taskRepository.DeleteAsync(task);
        }

        public async Task Update(Guid taskID, TaskData taskData)
        {
            var task = await this._taskRepository.Get(taskID);
            task.Name = taskData.Name;
            task.Description = taskData.Description;

            await this._taskRepository.Update(task);
        }
    }
}
