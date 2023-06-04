using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Domain.Entites;
using Task = Domain.Entites.Task;

namespace Infrastructure.Persistance.Data
{
    public class ApiDBContext:DbContext
    {
        public virtual DbSet<Task> Tasks { get; set; }

        public virtual DbSet<Note> Notes { get; set; }
        public ApiDBContext(DbContextOptions<ApiDBContext> options) : base(options) {
            Database.EnsureCreated();
        }
        
    }
}
