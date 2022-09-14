using Microsoft.AspNetCore.Mvc;
using Products.Dto;
using Products.Repository;

namespace Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository) => _repository = repository;

        [HttpGet]
        public async Task<IEnumerable<ProductDto>> Get(CancellationToken ct) => await _repository.GetAllAsync(ct);

        [HttpGet("{id:guid}")]
        public async Task<ProductDto> Get(Guid id, CancellationToken ct) => await _repository.GetByIdAsync(id, ct);

        [HttpPost]
        public async Task<ProductDto> Post([FromBody] ProductDto value, CancellationToken ct) => await _repository.UpsertAsync(value, ct);

        [HttpPut("{id:guid}")]
        public async Task<ProductDto> Put(Guid id, [FromBody] ProductDto value, CancellationToken ct)  => await _repository.UpsertAsync(value, ct);

        [HttpDelete("{id:guid}")]
        public async Task<bool> Delete(Guid id, CancellationToken ct) => await _repository.DeleteAsync(id, ct);
    }
}