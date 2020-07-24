using auth_test.demo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace auth_test.demo.Domain.Services
{
    public interface IDataService<T> where T:DomainObject
    {
        IEnumerable<T> GetAll();
        T Insert(T entity);
        T Update(int id, T entity);
        bool Delete(int id);
        T GetById(int id);
    }
}
