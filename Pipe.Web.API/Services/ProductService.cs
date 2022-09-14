using Pipe.Web.API.Dto;
using Pipe.Web.API.Services.Base;

namespace Pipe.Web.API.Services;

public sealed class ProductService : ApiService<ProductDto>, IProductService
{
    private static readonly string BaseUrl = "/api/product";
    public ProductService(IHttpClientFactory httpClientFactory) : base(httpClientFactory, BaseUrl, SD.ProductApiClientName) { }
}