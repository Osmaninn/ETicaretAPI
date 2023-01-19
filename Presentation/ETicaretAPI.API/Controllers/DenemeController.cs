using ETicaretAPI.Application.Repositories.ProductRepository;
using ETicaretAPI.Application.ViewModels.Product;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DenemeController : ControllerBase
    {
        private IProductReadRepository _productReadRepository;
        private IProductWriteRepository _productWriteRepository;

        public DenemeController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                await _productWriteRepository.AddAsync(new Product
                {
                    Name = product.ProductName,
                    Price = product.Price,
                    Stock = product.Stock
                });
                return StatusCode((int)HttpStatusCode.Created);
            }
            return BadRequest();
            
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductViewModel model)
        {
            var product = await _productReadRepository.GetByIdAsync(model.Id);
            if (product is not null)
            {
                product.Stock = model.Stock;
                product.Price = model.Price;
                product.Name = model.Name;

                return StatusCode((int)HttpStatusCode.OK);
            }
            return StatusCode((int)HttpStatusCode.NotModified); 
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var result = await _productWriteRepository.RemoveAsync(id);
            if (result is true)
                return Ok();
            else
                return BadRequest();            
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productReadRepository.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            //var product = await _productReadRepository.GetByIdAsync(id);
            var product = await _productReadRepository.GetSingleAsync(p => p.Id == Guid.Parse(id));
            return Ok(product);
        }

        
    }
    //public class CreateProductViewModel
    //{
    //    public string ProductName { get; set; }

    //    public int Stock { get; set; }

    //    public float Price{ get; set; }
    //}
    public class UpdateProductViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Stock{ get; set; }

        public float Price{ get; set; }
    }
}
