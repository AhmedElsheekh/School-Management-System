using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using School_Management_System.Domain.Abstractions;
using School_Management_System.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_System.Infrastructure.Bases
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity
        : BaseEntity<TKey> where TKey : struct
    {
        private readonly ApplicationDBContext _dBContext;
        private readonly DbSet<TEntity> _dBSet;

        public GenericRepository(ApplicationDBContext dBContext)
        {
            _dBContext = dBContext;
            _dBSet = _dBContext.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dBSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(ICollection<TEntity> entities)
        {
            await _dBSet.AddRangeAsync(entities);
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _dBContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _dBContext.Database.CommitTransaction();
        }

        public Task<int> SaveChangesAsync()
        {
            return _dBContext.SaveChangesAsync();
        }

        public void Delete(TEntity entity)
        {
            _dBContext.Remove(entity);
        }

        public void DeleteRange(ICollection<TEntity> entities)
        {
            _dBContext.RemoveRange(entities);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dBSet.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(TKey id)
        {
            return await _dBSet.FindAsync(id);
        }

        public IQueryable<TEntity> GetNoTracking()
        {
            return _dBSet.AsNoTracking().AsQueryable();
        }

        public IQueryable<TEntity> GetWithTracking()
        {
            return _dBSet.AsQueryable();
        }

        public void RollBack()
        {
            _dBContext.Database.RollbackTransaction();
        }

        public void Update(TEntity entity)
        {
            _dBSet.Update(entity);
        }

        public void UpdateRange(ICollection<TEntity> entities)
        {
            _dBSet.UpdateRange(entities);
        }
    }
}
