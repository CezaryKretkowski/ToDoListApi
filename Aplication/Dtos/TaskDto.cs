using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskEntity = Domain.Entites.Task;

namespace Aplication.Dtos
{
    public class TaskDto {
        public int Id { get; set; }
  
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }

        public DateTime DeadLine { get; set; }

        public TaskEntity ToEntity()
        {
            return new TaskEntity { Id = Id, 
                Name = Name, 
                Description = Description ,   
                IsCompleted= IsCompleted,
                DeadLine=DeadLine 
            };
        }
        public static TaskDto ToDto(TaskEntity t) {
            return new TaskDto
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                IsCompleted = t.IsCompleted,
                DeadLine = t.DeadLine

            };
        }

    }
}
