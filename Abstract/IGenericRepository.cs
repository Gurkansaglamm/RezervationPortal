using System.Collections.Generic;
using System.Threading.Tasks;

namespace RezervationPortal.Abstract
{
    // Generic repository arayüzü, T sadece referans tipi (class) olmalıdır.
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
