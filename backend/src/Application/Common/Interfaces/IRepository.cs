using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend.Domain.Interfaces;
public interface IRepository<T>
{
    public Task<List<T>?> GetAll();
    public Task<T?> GetById(int id);
    public Task Add(T item);
    public Task Update(T item);
    public Task Delete(int id);
}
