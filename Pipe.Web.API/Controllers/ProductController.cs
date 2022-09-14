using Microsoft.AspNetCore.Mvc;
using Pipe.Web.API.Dto;
using Pipe.Web.API.Services;

namespace Pipe.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService) => _productService = productService;

        [HttpGet]
        public async Task<IEnumerable<ProductDto>> Get(CancellationToken ct) => await _productService.GetAllAsync(ct);

        [HttpGet("{id:guid}")]
        public async Task<ProductDto> Get(Guid id, CancellationToken ct) => await _productService.GetByIdAsync(id, ct);

        [HttpPost]
        public async Task<ProductDto> Post([FromBody] ProductDto value, CancellationToken ct) => await _productService.UpsertAsync(value, ct);

        [HttpPut("{id:guid}")]
        public async Task<ProductDto> Put(Guid id, [FromBody] ProductDto value, CancellationToken ct)  => await _productService.UpsertAsync(value, ct);

        [HttpDelete("{id:guid}")]
        public async Task<bool> Delete(Guid id, CancellationToken ct) => await _productService.DeleteAsync(id, ct);
    }
}