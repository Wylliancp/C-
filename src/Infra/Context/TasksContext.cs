using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class TasksContext : DbContext
    {
        public TasksContext(DbContextOptions<TasksContext> options) : base(options)
        {

        }

        public DbSet<Tasks> Tasks { get; set; }
    }
}
