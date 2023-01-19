using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IReadRepository<T>: IRepository
    {
        public IQueryable<T> GetAll();

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> filter);

        public Task<T> GetSingleAsync(Expression<Func<T, bool>> filter);

        public Task<T> GetByIdAsync(string id);
    }

}
