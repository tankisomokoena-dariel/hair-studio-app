using backend.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Services
{
    public interface IService<T>
    {
        public Task<IEnumerable<T>?> GetAsync();
        public Task<T?> GetByIdAsync(Guid id);
        public Task<Result> AddAsync(T item);
        public Task<Result> UpdateAsync(T item);
        public Task<Result> DeleteAsync(Guid id);
    }
}
