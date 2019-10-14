using kubetask_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace kubetask_api.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly KubeTaskContext _kubeTaskContext;

        public TaskRepository(KubeTaskContext kubeTaskContext)
        {
            this._kubeTaskContext = kubeTaskContext;
        }

        public async Task AddAsync(KTask entity)
        {
            this._kubeTaskContext.Add(entity);
            await this._kubeTaskContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(KTask entity)
        {
            this._kubeTaskContext.Remove(entity);
            await this._kubeTaskContext.SaveChangesAsync();
        }

        public async Task<KTask> Get(Guid id)
        {
           return await this._kubeTaskContext.Tasks.FindAsync(id);
        }

        public async Task<IEnumerable<KTask>> List()
        {
            return await this._kubeTaskContext.Tasks.ToListAsync();
        }

        public async Task Update(KTask entity)
        {
            this._kubeTaskContext.Update(entity);
            await this._kubeTaskContext.SaveChangesAsync();
        }
    }
}
