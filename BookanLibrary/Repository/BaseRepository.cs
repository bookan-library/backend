using BookanLibrary.Core.Model;
using BookanLibrary.Helpers;
using BookanLibrary.Repository.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;

        public DataContext DbContext
        {
            get { return _context as DataContext; }
        }

        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        public async virtual Task<TEntity> Get(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public async virtual Task<IEnumerable<TEntity>> GetAll(int pageNumber)
        {
            return _context.Set<TEntity>().Where(x => !(x as Entity).Deleted).ToList();
        }

        public async virtual Task Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public async virtual Task Update(TEntity entity)
        {
            _context.Entry(entity).State = (entity as Entity).Id == 0 ? EntityState.Added : EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
