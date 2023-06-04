using Aplication.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.interfaces
{
    public interface ITaskService
    {
        Task<TaskDto> GetByID(int id);
        Task<List<TaskDto>> GetAll();
        Task<AddTaskDto> Add(AddTaskDto taskDto);
        Task<TaskDto> Update(TaskDto taskDto);
        Task<TaskDto> Delete(int id);
        Task<TaskDto> CompleteTask(int id);
        Task<List<TaskDto>> GetToDayTasks();
    }
}
