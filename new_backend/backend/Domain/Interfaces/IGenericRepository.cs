using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Application.Common.Interfaces.Repositories;
public interface IGenericRepository<T>
{
    public Task<IReadOnlyList<T>?> GetAllAsync();
    public Task<T?> GetByIdAsync(Guid id);
    public Task AddAsync(T item);
    public Task UpdateAsync(T item);
    public Task DeleteAsync(T item);
}
