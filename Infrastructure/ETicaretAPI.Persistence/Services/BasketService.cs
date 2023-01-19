using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.Dtos.Basket;
using ETicaretAPI.Application.Repositories.BasketItemRepository;
using ETicaretAPI.Application.Repositories.BasketRepository;
using ETicaretAPI.Application.Repositories.OrderRepository;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Identity;
using ETicaretAPI.Persistence.Repositories.BasketRepository;
using ETicaretAPI.Persistence.Repositories.OrderRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Services
{
    public class BasketService : IBasketService
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly UserManager<AppUser> _userManager;
        readonly IOrderReadRepository _orderReadRepository;
        readonly IBasketItemWriteRepository _basketItemWriteRepository;
        readonly IBasketItemReadRepository _basketItemReadRepository;
        readonly IBasketReadRepository _basketReadRepository;
        readonly IBasketWriteRepository _basketWriteRepository;

        public BasketService(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, 
            IOrderReadRepository orderReadRepository, IBasketItemWriteRepository basketItemWriteRepository,
            IBasketItemReadRepository basketItemReadRepository, IBasketReadRepository basketReadRepository,
            IBasketWriteRepository basketWriteRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _orderReadRepository = orderReadRepository;
            _basketItemWriteRepository = basketItemWriteRepository;
            _basketItemReadRepository = basketItemReadRepository;
            _basketReadRepository = basketReadRepository;
            _basketWriteRepository = basketWriteRepository;
        }

        private async Task<Basket?> ContextUser()
        {
            //var username = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;
            var username = _userManager.FindByIdAsync("b85e726d-1cc5-4fab-80dd-8659ecca294b").Result.UserName;

            if (!string.IsNullOrEmpty(username))
            {
                AppUser? user = await _userManager.Users
                    .Include(u => u.Baskets)
                    .FirstOrDefaultAsync(u => u.UserName == username);

                var _basket = from basket in user.Baskets
                join order in _orderReadRepository.GetAll()
                on basket.Id equals order.BasketId into orders
                from order in orders.DefaultIfEmpty()
                select new
                {
                    Basket = basket,
                    Order = order
                };

                Basket? targetBasket = null; 
                if(_basket.Any(b => b.Order is null))
                {
                    targetBasket = _basket.FirstOrDefault(b => b.Order is null)?.Basket;
                }
                else
                {
                    targetBasket = new();
                    user.Baskets.Add(targetBasket);
                }

                
                await _userManager.UpdateAsync(user);
                return targetBasket;
            }
            throw new Exception("Hata oluştu.");
        }

        public async Task AddItemAsync(CreateBasketItem item)
        {
            Basket? basket = await ContextUser();
            if(basket != null)
            {
                BasketItem basketItem = await _basketItemReadRepository.GetSingleAsync(i => i.BasketId == basket.Id && i.ProductId == Guid.Parse(item.ProductId));
                if(basketItem != null)
                {
                    basketItem.Quantity++;
                }
                else
                    await _basketItemWriteRepository.AddAsync(new()
                    {
                        BasketId = basket.Id,
                        ProductId = Guid.Parse(item.ProductId),
                        Quantity = item.Quantity
                    });
               await _basketItemWriteRepository.SaveChangesAsync();
            }

        }

        public async Task<List<BasketItem>> GetBasketItemsAsync()
        {
            Basket? basket = await ContextUser();
            
            Basket? result = await _basketReadRepository.GetAll().Include(b=> b.BasketItems)
                .ThenInclude(bi => bi.Product).FirstOrDefaultAsync(b=> b.Id == basket.Id);
            return result.BasketItems.ToList();
        }

        public async Task RemoveItemAsync(string itemId)
        {
            BasketItem? item = await _basketItemReadRepository.GetByIdAsync(itemId);
            if(item != null)
            {
                await _basketItemWriteRepository.RemoveAsync(itemId);
            }
            
        }

        public Task UpdateQuantityAsync(UpdateBasketItem item)
        {
            throw new NotImplementedException();
        }

        public Basket? GetBasketActiveUser
        {
            get
            {
                Basket? basket = ContextUser().Result;
                return basket;
            }
        }
    }
}
