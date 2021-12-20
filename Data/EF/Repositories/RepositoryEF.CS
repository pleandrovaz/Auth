using Domain.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF.Repositories
{
    public abstract class RepositoryEF<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DataContext _ctx;
        public readonly DbSet<TEntity> _db;

        public RepositoryEF(DataContext ctx)
        {
            _ctx = ctx;
            _db = ctx.Set<TEntity>();
        }
        public async Task<TEntity> Get(object id)
        {
            return await _db.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
           return await _db.ToListAsync();
        }
        public void Add(TEntity entity)
        {
            _db.Add(entity);
            _ctx.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _ctx.Update(entity);
            _ctx.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _db.Remove(entity);
            _ctx.SaveChanges();
        }
    }
}
