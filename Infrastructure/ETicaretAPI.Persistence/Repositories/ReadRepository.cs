using ETicaretAPI.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class
    {
        private Context _context;

        public ReadRepository(Context context)
        {
            _context = context;
        }
    
        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _context.Set<T>().FindAsync(Guid.Parse(id));//SingleOrDefault da kullanılabilir.
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(filter);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Where(filter);
        }

    }
}
