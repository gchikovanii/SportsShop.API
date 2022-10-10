using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SportsShop.Infrastructure.Repositories.Abstraction
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetCollectionAsync(Expression<Func<T, bool>> expression = null);
        IQueryable<T> GetQuery(Expression<Func<T, bool>> expression = null);
        Task CreateAsync(T input);
        void Update(T input);
        void Delete(T input);
        Task<bool> SaveChangesAsync();
    }
}
