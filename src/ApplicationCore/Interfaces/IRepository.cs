using ParkingRegistry.ApplicationCore.BaseEntities.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingRegistry.ApplicationCore.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        IQueryable<T> GetQuery();
    }
}
