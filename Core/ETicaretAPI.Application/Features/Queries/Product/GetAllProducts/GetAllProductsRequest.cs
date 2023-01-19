using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Product.GetAllProducts
{
    public class GetAllProductsRequest : IRequest<GetAllProductsResponse>
    {
        //public int Page { get; set; } = 0;

        //public int Count { get; set; } = 5;
    }
}
