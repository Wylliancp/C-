using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
    {
        private readonly TasksContext _context;
        public BaseRepository(TasksContext context)
        {
            _context = context;
        }
         public BaseRepository()//necessario por causa da injecao de dependencia
         {
            
         }

        public bool Create(T item)
        {
            if (item == null)
                return false;

            _context.Add(item);//especificar o dbset
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> CreateAsync(T item)
        {
            if (item == null)
                return false;

            await _context.AddAsync(item);//especificar o dbset
            await _context.SaveChangesAsync();
            return true;
        }

        public bool Delete(int id)
        {
            if (id == 0 || id == default)
                return false;

            var item = _context.Tasks.Where(x => x.Id == id)
                                     .AsNoTracking()
                                     .FirstOrDefault();
            
            if (item == null)
                return false;

            _context.Remove(item);//especificar o dbset
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (id == 0 || id == default)
                return false;

            var item = await _context.Tasks.Where(x => x.Id == id)
                                     .AsNoTracking()
                                     .FirstOrDefaultAsync();

            if (item == null)
                return false;

            _context.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public IEnumerable<T> GetAll()
        {
            var result = _context.Tasks.AsEnumerable();
            return result as IEnumerable<T>;
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            var result = _context.Tasks.AsNoTracking();
            return result as Task<IEnumerable<T>>;
        }

        public T GetById(int id)
        {
            var result = _context.Tasks.Where(x => x.Id == id).FirstOrDefault();
            return result as T;
        }

        public Task<T> GetByIdAsync(int id)
        {
            var result = _context.Tasks.Where(x => x.Id == id).FirstOrDefaultAsync();
            return result as Task<T>;
        }

        public bool Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            return true;
        }

        public async Task<bool> UpdateAsync(T item)
        {
            _context.Tasks.Update(item as Tasks);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}