using System;
using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Queries
{
    public static class TaskQueries
    {
        
        public static Expression<Func<Tasks,bool>> GetById(int id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<Tasks,bool>> GetAllDone()
        {
            return x => x.Finished == true;
        }

        public static Expression<Func<Tasks,bool>> GetAllUnDone()
        {
            return x => x.Finished == false;
        }

        public static Expression<Func<Tasks,bool>> GetByPeriod(bool done, DateTime date)
        {
            return x => x.Finished == done && x.DateCreate.Date == date;
        }

    }
}