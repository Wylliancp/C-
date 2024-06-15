using System;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface ITasksRepository : IBaseRepository<Tasks>
    {
        public Tasks GetTasksPeriodAsync(DateTime dateInitial, DateTime DateEnd); 
    }
}   