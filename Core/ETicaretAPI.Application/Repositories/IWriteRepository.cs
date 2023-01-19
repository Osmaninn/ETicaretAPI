using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IWriteRepository<T>: IRepository
    {
        public Task<bool> AddAsync(T model);

        public Task<bool> RemoveAsync(string id);

        public bool Update(T model);

        public Task<int> SaveChangesAsync();
    }
}
