using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Concretes
{
    public class ProductService : IProductService
    {

        private Context _context;

        public ProductService(Context context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
            => new()
            {
                new(){Id=Guid.NewGuid(), Name="Product1", Price=111, Stock=11},
                new(){Id=Guid.NewGuid(), Name="Product2", Price=222, Stock=22},
                new(){Id=Guid.NewGuid(), Name="Product3", Price=333, Stock=33},
                new(){Id=Guid.NewGuid(), Name="Product4", Price=444, Stock=44}

            };

        public IQueryable<Product> GetProductsDb()
        {
            return _context.Set<Product>();

        }

    }
}
