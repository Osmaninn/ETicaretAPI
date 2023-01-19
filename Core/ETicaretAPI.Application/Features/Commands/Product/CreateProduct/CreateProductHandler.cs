using ETicaretAPI.Application.Repositories.ProductRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
    {
        private readonly IProductWriteRepository _productWriteRepository;
        public CreateProductHandler(IProductWriteRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }
        public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product product = new()
            {
                Name = request.ProductName,
                Stock= request.Stock,
                Price= request.Price,

            };
            await _productWriteRepository.AddAsync(product);

            return new(); 

        }
    }
}
