using System.Collections.Generic;
using System.Threading.Tasks;

namespace AysmmTest.WebAPI.Services
{
    public interface ICustomService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetAsync(int id);

        Task<TEntity> InsertAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(int id);
    }
}
