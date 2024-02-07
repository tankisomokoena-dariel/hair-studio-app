using backend.Application.Common.Interfaces.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly HairStudioDbContext _dbContext;

        public GenericRepository(HairStudioDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(T item)
        {
            await _dbContext.AddAsync(item);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(T item)
        {
            _dbContext.Remove(item);
            await SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>?> GetAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(T item)
        {
            _dbContext.Update(item);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
