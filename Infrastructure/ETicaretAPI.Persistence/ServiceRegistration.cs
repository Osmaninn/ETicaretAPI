using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.Repositories.BasketItemRepository;
using ETicaretAPI.Application.Repositories.BasketRepository;
using ETicaretAPI.Application.Repositories.CustomerRepository;
using ETicaretAPI.Application.Repositories.OrderRepository;
using ETicaretAPI.Application.Repositories.ProductRepository;
using ETicaretAPI.Domain.Entities.Identity;
using ETicaretAPI.Persistence.Concretes;
using ETicaretAPI.Persistence.Repositories.BasketItemRepository;
using ETicaretAPI.Persistence.Repositories.BasketRepository;
using ETicaretAPI.Persistence.Repositories.CustomerRepository;
using ETicaretAPI.Persistence.Repositories.OrderRepository;
using ETicaretAPI.Persistence.Repositories.ProductRepository;
using ETicaretAPI.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            //services.AddDbContext<Context>(options => options.UseSqlServer());
            //services.AddDbContext<Context>(options => options.UseSqlServer(@"Server=(localdb)\MsSqlLocalDb;Database=ETicaretDb;Trusted_Connection=True;"));
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IBasketReadRepository, BasketReadRepository>();
            services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();
            services.AddScoped<IBasketItemReadRepository, BasketItemReadRepository>();
            services.AddScoped<IBasketItemWriteRepository, BasketItemWriteRepository>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
