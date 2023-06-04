using Domain.Interfaces;
using Infrastructure.Persistance.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TaskEntites = Domain.Entites.Task;

namespace Infrastructure.Persistance.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApiDBContext _dbContext;

        public TaskRepository(ApiDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TaskEntites> Add(TaskEntites task)
        {
            try
            {

                var entities = await _dbContext.Tasks.AddAsync(task);
                await _dbContext.SaveChangesAsync();

                return entities.Entity;

            }
            catch (DbUpdateException ex)
            {
                
                if (ex.InnerException != null)
                {
                    throw new Exception("Error while adding entities: " + ex.InnerException.Message);
                }
                else
                {
                    throw new Exception("Error while adding entities: " + ex.Message);
                }
            }
        }

        public async Task<TaskEntites> Delete(int id)
        {
            try
            {
                var t = await _dbContext.Tasks.FindAsync(id);

                if (t != null)
                {
                    _dbContext.Tasks.Remove(t);
                    await _dbContext.SaveChangesAsync();
                    return t;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while delete Entities" + ex.Message);
            }

        }

        public async Task<IEnumerable<TaskEntites>> GetAllTasks()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<TaskEntites> GetTaskById(int id)
        {
            try
            {
                return await _dbContext.Tasks.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while finding record" + ex.Message);
            }
        }

        public async Task<TaskEntites> Update(TaskEntites task)
        {
            try
            {
                var t = _dbContext.Tasks.Update(task);
                await _dbContext.SaveChangesAsync();

                return t.Entity;

            }
            catch (Exception ex)
            {
                throw new Exception("Error while delete Entities" + ex.Message);
            }
        }
    }
}
