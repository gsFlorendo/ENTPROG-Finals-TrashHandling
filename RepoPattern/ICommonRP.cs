using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrashHandling.RepoPattern
{
    public interface ICommonRP<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<List<T>> GetListAsync();
        Task<T> GetIdAsync(int id);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
