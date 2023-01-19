using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Application.Repositories.ProductRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Product.GetAllProducts
{
    public class GetAllProductsHandle : IRequestHandler<GetAllProductsRequest, GetAllProductsResponse>
    {
        private IProductReadRepository _productReadRepository;

        public GetAllProductsHandle(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }
        public async Task<GetAllProductsResponse> Handle(GetAllProductsRequest? request, CancellationToken cancellationToken)
        {
            var products =  _productReadRepository.GetAll();
            return new()
            {
                products = products
            };
        }
    }
}
