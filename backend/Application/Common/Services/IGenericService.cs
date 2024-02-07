using backend.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Services
{
    public interface IGenericService<TDto>
    {
        public Task<IEnumerable<TDto>?> GetAsync();
        public Task<TDto?> GetByIdAsync(Guid id);
        public Task<Result> AddAsync(TDto item);
        public Task<Result> UpdateAsync(TDto item);
        public Task<Result> DeleteAsync(Guid id);
    }
}
