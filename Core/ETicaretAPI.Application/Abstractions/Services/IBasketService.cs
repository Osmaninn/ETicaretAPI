using ETicaretAPI.Application.Dtos.Basket;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstractions.Services
{
    public interface IBasketService
    {
        public Task<List<BasketItem>> GetBasketItemsAsync();

        public Task AddItemAsync(CreateBasketItem item);

        public Task RemoveItemAsync(string itemId);

        public Task UpdateQuantityAsync(UpdateBasketItem item);

        public Basket? GetBasketActiveUser{ get; }
    }
}
