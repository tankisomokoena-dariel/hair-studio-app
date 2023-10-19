using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Domain.Interfaces;
public interface IRepository<T>
{
    public Task<List<T>?> GetAllAsync();
    public Task<T?> GetByIdAsync(int id);
    public Task AddAsync(T item);
    public Task UpdateAsync(T item);
    public Task DeleteAsync(int id);
}
