using Microsoft.EntityFrameworkCore.Storage;
using School_Management_System.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_System.Infrastructure.Bases
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey> where TKey : struct
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(TKey id);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        Task AddRangeAsync(ICollection<TEntity> entities);
        void UpdateRange(ICollection<TEntity> entities);
        void DeleteRange(ICollection<TEntity> entities);
        IQueryable<TEntity> GetNoTracking();
        IQueryable<TEntity> GetWithTracking();
        IDbContextTransaction BeginTransaction();
        void Commit();
        void RollBack();
        Task<int> SaveChangesAsync();

    }
}
