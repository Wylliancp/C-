using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using System;
using System.Linq;

namespace Infra.Repositories
{
    public class TasksRepository : BaseRepository<Tasks>, ITasksRepository
    {
        private readonly TasksContext _context;

        public TasksRepository(TasksContext context) : base(context)
        {
            _context = context;
        }

        public Tasks GetTasksPeriodAsync(DateTime dateInitial, DateTime DateEnd)
        {
            return _context.Tasks.Where(x => x.DateCreate == dateInitial && x.DateEnd == DateEnd).FirstOrDefault();
            
        }
    }
}