using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Dtos.Basket
{
    public class UpdateBasketItem
    {
        public string BasketItemId { get; set; }

        public int Quantity { get; set; }
    }
}
