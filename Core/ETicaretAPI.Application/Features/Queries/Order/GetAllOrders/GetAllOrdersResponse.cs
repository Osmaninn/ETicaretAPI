using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Order.GetAllOrders
{
    public class GetAllOrdersResponse
    {
        public string OrderCode{ get; set; }

        public string Username{ get; set; }

        public float TotalPrice{ get; set; }

        public DateTime CreatedDate{ get; set; }
    }
}
