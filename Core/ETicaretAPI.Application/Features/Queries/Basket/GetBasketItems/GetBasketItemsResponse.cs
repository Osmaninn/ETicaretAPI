using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Basket.GetBasketItems
{
    public class GetBasketItemsResponse
    {
        public string BasketItemId{ get; set; }
        public string ProductName{ get; set; }

        public float Price{ get; set; }

        public int Quantity{ get; set; }
    }
}
