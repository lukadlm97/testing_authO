using auth_test.demo.Domain.Models;
using auth_test.demo.Entityframework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auth_test.demo.Services.Common
{
    public class NonQueryDataService<T> where T:DomainObject
    {
        private readonly AuthContext _context;

        public NonQueryDataService(AuthContext context)
        {
            _context = context;
        }
        public async Task<T> Create(T entity)
        {
            try
            {
                EntityEntry<T> createdEntity = await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();

                return createdEntity.Entity;
            }catch(Exception e)
            {
                return null;
            }
        }
        public async Task<T> Update(int id,T entity)
        {
            try
            {
                entity.Id = id;
                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception e)
            {

                return null;
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var entity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
                if (entity == null)
                    return false;
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
    }
}
