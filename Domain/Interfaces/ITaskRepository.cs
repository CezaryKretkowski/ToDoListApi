using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskEnitites = Domain.Entites.Task;


namespace Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskEnitites>> GetAllTasks();
        Task<TaskEnitites> GetTaskById(int id);
        Task<TaskEnitites> Add(TaskEnitites task);
        Task<TaskEnitites> Update(TaskEnitites task);
        Task<TaskEnitites> Delete(int id);

    }
}
