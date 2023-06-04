using EmployeeManagement.Application.Interfaces.Services;
using EmployeeManagement.Application.Repositories.BaseRepository;
using EmployeeManagement.Domain.Entities.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Persistence.Services.Base
{
    public class BaseService<T> : IBaseService<T> where T : class, IBaseEntity
    {
        private readonly ICRUDRepository<T> _baseRepository;
        public BaseService(ICRUDRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<bool> AddRangeAsync(List<T> entity)
        {
            return await _baseRepository.AddRangeAsync(entity);
        }

        public async Task<bool> CreateAsync(T entity)
        {
            return await _baseRepository.CreateAsync(entity);
        }

        public bool Delete(T entity)
        {
            return _baseRepository.Delete(entity);
        }

        public async Task<bool> DeleteById(int id)
        {
            return await _baseRepository.DeleteById(id);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> filter)
        {
            return _baseRepository.Find(filter);
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await _baseRepository.FindByIdAsync(id);
        }

        public IQueryable<T> GetAll()
        {
            return _baseRepository.GetAll();
        }

        public bool RemoveRange(List<T> entities)
        {
            return _baseRepository.RemoveRange(entities);
        }

        public async Task<int> SaveAsync()
        {
            return await _baseRepository.SaveAsync();
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            return await _baseRepository.UpdateAsync(entity);
        }
    }
}
