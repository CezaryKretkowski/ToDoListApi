using Aplication.Dtos;
using Aplication.interfaces;
using AutoMapper;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskEnities = Domain.Entites.Task;

namespace Aplication.Services
{
    public class TaskServivce : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
   

        public TaskServivce(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;

        }
        public async Task<AddTaskDto> Add(AddTaskDto taskDto)
        {
            TaskEnities task = taskDto.ToEntity();
            var addedTask = await _taskRepository.Add(task);

            if (addedTask != null)
                return AddTaskDto.ToDto(addedTask);
            else
                return null;
        }

        public async Task<TaskDto> CompleteTask(int id)
        {
            var task = await _taskRepository.GetTaskById(id);
            if (task != null)
            {
                bool isCompeted = !task.IsCompleted;
                task.IsCompleted = isCompeted;
                var retTask = await _taskRepository.Update(task);
                if (retTask != null)
                    return TaskDto.ToDto(task);
                else
                    return null;
            }
            else
                return null;

        }

        public async Task<TaskDto> Delete(int id)
        {
            var taskDeleted = await _taskRepository.Delete(id);
            if (taskDeleted != null)
                return TaskDto.ToDto(taskDeleted);
            else
                return null;
        }
        public async Task<List<TaskDto>> GetAll()
        {
            var tasks = await _taskRepository.GetAllTasks();
            
            return tasks.Select(e=>TaskDto.ToDto(e)).ToList();
        }

        public async Task<TaskDto> GetByID(int id)
        {
            var task = await _taskRepository.GetTaskById(id);

            if (task != null)
                return TaskDto.ToDto(task);
            else
                return null;
        }

        public async Task<List<TaskDto>> GetToDayTasks()
        {
            var tasks = await _taskRepository.GetAllTasks();

            tasks = tasks.Where(e=>e.DeadLine.Date==DateTime.Today);

            return tasks.Select(e => TaskDto.ToDto(e)).ToList();
        }

        public async Task<TaskDto> Update(TaskDto taskDto)
        {
            TaskEnities task = taskDto.ToEntity();
            var updateTask = await _taskRepository.Update(task);

            if (updateTask != null)
                return TaskDto.ToDto(updateTask);
            else
                return null;
        }
    }
}
