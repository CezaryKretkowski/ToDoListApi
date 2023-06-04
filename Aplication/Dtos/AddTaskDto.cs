using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskEntity = Domain.Entites.Task;
namespace Aplication.Dtos
{
    public class AddTaskDto
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }

        public DateTime DeadLine { get; set; }

        public TaskEntity ToEntity()
        {
            return new TaskEntity
            {
                Name = Name,
                Description = Description,
                IsCompleted = IsCompleted,
                DeadLine = DeadLine
            };
        }
        public static AddTaskDto ToDto(TaskEntity t)
        {
            return new AddTaskDto
            {
                Name = t.Name,
                Description = t.Description,
                IsCompleted = t.IsCompleted,
                DeadLine = t.DeadLine

            };
        }
    }
}
