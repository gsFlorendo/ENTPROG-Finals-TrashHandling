using Microsoft.EntityFrameworkCore;
using TrashHandling.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrashHandling.RepoPattern
{
    public class CommonRP<T> : ICommonRP<T> where T : class
    {
        private readonly PatientConsultAuthDBContext dbContext;

        public CommonRP(PatientConsultAuthDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await dbContext.Set<T>().FindAsync(id);
            dbContext.Set<T>().Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            T entity = await dbContext.Set<T>().FindAsync(id);

            var x = entity == null ? false : true;
            return x;
        }

        public async Task<T> GetIdAsync(int id)
        {
            T entity = await dbContext.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task<List<T>> GetListAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            dbContext.Set<T>().Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
