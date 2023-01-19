using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Product.GetProductById
{
    public class GetProductByIdRequest : IRequest<GetProductByIdResponse>
    {
        public string Id{ get; set; }
    }
}
