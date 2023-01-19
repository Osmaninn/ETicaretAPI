using ETicaretAPI.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class WriteRepository<T>: IWriteRepository<T> where T : class
    {
        private Context _context;

        public WriteRepository(Context context)
        {
            _context = context;
        }
        public async Task<bool> AddAsync(T model)
        {
            EntityEntry Entry = await _context.AddAsync<T>(model);
            await _context.SaveChangesAsync();
            return Entry.State == EntityState.Added; 
        }

        public async Task<bool> RemoveAsync(string id)
        {
            T model = await _context.Set<T>().FindAsync(Guid.Parse(id));
            if(model is not null){
                _context.Remove(model);
                await _context.SaveChangesAsync();
                return true;

            }return false;

        }
        public bool Update(T model)
        {
            EntityEntry entry = _context.Update<T>(model);
            return entry.State == EntityState.Modified;

        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
