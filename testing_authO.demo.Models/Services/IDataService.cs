using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace testing_authO.demo.Domain.Services
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByUsername();
        Task<T> Create(T entity);
    }
}
